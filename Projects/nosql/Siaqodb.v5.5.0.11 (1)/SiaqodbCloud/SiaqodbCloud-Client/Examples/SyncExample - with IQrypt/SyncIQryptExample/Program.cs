using IQryptSiaqodb;
using Newtonsoft.Json;
using SiaqodbCloud;
using Sqo;
using Sqo.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SyncExample
{
    internal class MyJsonSerializer : IDocumentSerializer
    {

        public object Deserialize(Type type, byte[] objectBytes)
        {
            string jsonStr = Encoding.UTF8.GetString(objectBytes);
            return JsonConvert.DeserializeObject(jsonStr.TrimEnd('\0'), type);
        }
        public byte[] Serialize(object obj)
        {
            string jsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented);
            return Encoding.UTF8.GetBytes(jsonStr);
        }

    }
    public class Invoice
    {
        public string CustomerName { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Sqo.SiaqodbConfigurator.SetLicense(@"your license");

            SiaqodbConfigurator.SetDocumentSerializer(new MyJsonSerializer());
            SiaqodbConfigurator.SetSyncableBucket("invoices_encrypted", true);
         
            //IQrypt settings
            IQryptSiaqodbConfigurator.SetEncryptionChiper(IQrypt.Cipher.AES256, "myencryption_key");
            IQryptSiaqodbConfigurator.EncryptDocumentContent("invoices_encrypted");
            IQryptSiaqodbConfigurator.EncryptTag("customer_code", IQrypt.EncryptionType.DET, typeof(string));

            try
            {
                using (Siaqodb siaqodb = new Siaqodb(@"c:\DATA\"))
                {
                    IBucket bucket = siaqodb.Documents["invoices_encrypted"];

                    Invoice inv = new Invoice { CustomerName = "My Company", InvoiceDate = DateTime.Now, Total = 2390 };

                    IQryptDocument document = new IQryptDocument();
                    document.Key = "InVoice-" + rnd.Next();
                    document.SetContent<Invoice>(inv);
                    string tagVal = "CU2323" + rnd.Next();
                    document.SetTag("customer_code", tagVal);

                    bucket.Store(document);
                    // let's run a query
                    Query query = new Query();
                    query.IQryptWhereEqual("customer_code", tagVal);

                    var q = bucket.Find(query);
                    foreach (Document o in q)
                    {
                        if (o.GetTag<string>("customer_code") == tagVal)
                        {
                            Console.WriteLine("Query over encrypted data run!");
                        }
                    }

                    using (SiaqodbSync syncContext = new SiaqodbSync("http://localhost:11735/v0/",
                                                         "97c7835153fd66617fad7b43f4000647",
                                                          "4362kljh63k4599hhgm"))


                    {
                        
                        //pull(which will trigger also push) will upload and than download changes to/from cloud/server
                        PullResult syncResult = syncContext.Pull(bucket);
                        if (syncResult.Error != null)
                            Console.WriteLine("Error downloading changes:" + syncResult.Error.Message);
                        else
                        {
                            Console.WriteLine("Sync finished!");
                            Console.WriteLine("Uploaded:" + syncResult.PushResult.SyncStatistics.TotalUploads + " documents!");
                            Console.WriteLine("Downloaded:" + syncResult.SyncStatistics.TotalDownloads + " documents!");
                        }
                    }


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();

        }
    }
}
