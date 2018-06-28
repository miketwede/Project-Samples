using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;
using System.IO;
using Sqo.Documents;

namespace Siaqodb_Document_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Sqo.SiaqodbConfigurator.SetLicense(@"your license key");
            SiaqodbConfigurator.SetDocumentSerializer(new MyJsonSerializer());
            string siaoqodbPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + @"siaqodb";
            if (!Directory.Exists(siaoqodbPath))
            {
                Directory.CreateDirectory(siaoqodbPath);
            }
           
            using (Siaqodb siaqodb = new Siaqodb(siaoqodbPath))
            {
                CRUD_Document(siaqodb);
                Console.WriteLine("CRUD with Documents operations executed.");

                CRUD_POCO(siaqodb);
                Console.WriteLine("CRUD with POCO operations executed.");

                SimpleQuery(siaqodb);
                Console.WriteLine("SimpleQuery executed.");

                ComplexQuery(siaqodb);
                Console.WriteLine("ComplexQuery executed.");

            }
            Console.ReadLine();
            
        }
        private static void CRUD_Document(Siaqodb siaqodb)
        {
            IBucket bucket = siaqodb.Documents["invoices"];

            Invoice invoice = BuildInvoice();
            //insert
            Document doc = new Document();
            doc.Key = invoice.Id;
            doc.SetContent<Invoice>(invoice);

            bucket.Store(doc);

            Document documentLoaded = bucket.Load(invoice.Id);
            Invoice invoiceLoaded = documentLoaded.GetContent<Invoice>();
            invoiceLoaded.InvoiceDate = invoiceLoaded.InvoiceDate.AddDays(-1);
            documentLoaded.SetContent<Invoice>(invoiceLoaded);
            //update
            bucket.Store(documentLoaded);
            //delete
            bucket.Delete(documentLoaded);
        }
        private static void CRUD_POCO(Siaqodb siaqodb)
        {
            //register key convention, so we can work directly with POCO
            SiaqodbConfigurator.RegisterKeyConvention<Invoice>(a => a.Id);

            IBucket bucket = siaqodb.Documents["invoices"];

            Invoice invoice = BuildInvoice();
            //insert
            bucket.Store(invoice);

            Invoice invoiceLoaded = bucket.Load<Invoice>(invoice.Id);
            invoiceLoaded.InvoiceDate = invoiceLoaded.InvoiceDate.AddDays(-1);
            //update
            bucket.Store(invoiceLoaded);
            //delete
            bucket.Delete(invoiceLoaded.Id);
        }
        private static void SimpleQuery(Siaqodb siaqodb)
        {
            IBucket bucket = siaqodb.Documents["invoices"];

            Invoice invoice = BuildInvoice();
            //insert
            Document doc = new Document();
            doc.Key = invoice.Id;
            doc.SetContent<Invoice>(invoice);
            doc.SetTag<int>("year", invoice.InvoiceDate.Year);//this tag will be automatically indexed

            bucket.Store(doc);

            Query query = new Query();
            query.WhereEqual("year", invoice.InvoiceDate.Year);

            //execute query
            var docs = bucket.Find(query);
            foreach (Document d in docs)
            {
                Invoice inv = d.GetContent<Invoice>();
                Console.WriteLine("Invoice with Id:" +d.Key+" loaded by query");
            }

            //run same query using LINQ:
            var docsLINQ = from Document d in bucket
                           where d.GetTag<int>("year") == invoice.InvoiceDate.Year
                           select d;
            foreach (Document d in docsLINQ)
            {
                Invoice inv = d.GetContent<Invoice>();
                Console.WriteLine("Invoice with Id:" + d.Key + " loaded by LINQ query");
            }

        }
        private static void ComplexQuery(Siaqodb siaqodb)
        {
            IBucket bucket = siaqodb.Documents["invoices"];

            Invoice invoice = BuildInvoice();
            //insert invoice with tags with Document way
            Document doc = new Document();
            doc.Key = invoice.Id;
            doc.SetContent<Invoice>(invoice);
            doc.SetTag<int>("year", invoice.InvoiceDate.Year);//this tag will be automatically indexed
            doc.SetTag<string>("customer", invoice.CustomerCode);//this tag will be automatically indexed

            bucket.Store(doc);

            //register key convention, so we can work directly with POCO
            SiaqodbConfigurator.RegisterKeyConvention<Invoice>(a => a.Id);

            Invoice invoice2 = BuildInvoice();

            //insert invoice with tags in POCO way - invoice is tagged with 2 tags: year and customer
            bucket.Store(invoice2, new {year=invoice2.InvoiceDate.Year, customer=invoice2.CustomerCode });

            //query with Fluent API
            Query query = new Query();
            query.WhereGreaterThanOrEqual("year", invoice.InvoiceDate.Year).WhereEqual("customer", invoice.CustomerCode);
            //execute query
            var docs = bucket.Find(query);
            foreach (Document d in docs)
            {
                Invoice inv = d.GetContent<Invoice>();
                Console.WriteLine("Invoice with Id:" + d.Key + " loaded by complex query.");
            }

            //run same query using LINQ:
            var docsLINQ = from Document d in bucket
                           where d.GetTag<int>("year") >=invoice.InvoiceDate.Year && d.GetTag<string>("customer")==invoice.CustomerCode
                           select d;
            foreach (Document d in docsLINQ)
            {
                Invoice inv = d.GetContent<Invoice>();
                Console.WriteLine("Invoice with Id:" + d.Key + " loaded by LINQ complex query");
            }

        }
        private static Invoice BuildInvoice()
        {
            Random rnd = new Random();
            Invoice invoice = new Invoice();
            invoice.Id = rnd.Next().ToString();
            invoice.InvoiceDate = DateTime.Now;
            invoice.InvoiceNumber = 1;
            invoice.Lines = new List<InvoiceLine>();
            invoice.CustomerCode = "alfa";
            for (int i = 0; i < 3; i++)
            {
                InvoiceLine line = new InvoiceLine();
                line.NrCrt = i + 1;
                line.TheProduct = new Product() { ProductName = "Prod" + i.ToString() };
                line.Price = (i + 1) * 10;
                line.Quantity = 1;
                line.LineTotal = line.Price * line.Quantity;

                invoice.Lines.Add(line);
                invoice.InvoiceTotal += line.LineTotal;
            }
            return invoice;
        } 
    }
}
