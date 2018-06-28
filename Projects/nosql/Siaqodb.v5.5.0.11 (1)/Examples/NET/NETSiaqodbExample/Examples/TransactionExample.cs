using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;
using Sqo.Transactions;

namespace Example
{
    class TransactionExample : BaseExample, IExample
    {
        

        public void Run()
        {
             Siaqodb siaqodb=SiaqodbFactoryExample.GetInstance();
             ITransaction transaction = siaqodb.BeginTransaction();
             Log("Start transactional operation");
             try
             {

                 Invoice inv = new Invoice { Number = 1, CustomerId = 10, ID = Guid.NewGuid() };
                 siaqodb.StoreObject(inv, transaction);
                 for (int i = 1; i < 10; i++)
                 {
                     InvoiceDetail detail = new InvoiceDetail { InvoiceID = inv.ID, UnitPrice = i, Quantity = i % 3 };
                     siaqodb.StoreObject(detail, transaction);
                 }

                 transaction.Commit();
                 Log("Transaction Commit() successfully!");
             }
             catch (Exception ex)
             {
                 Log("There was a problem during transaction, Rollback all changes...");
                 transaction.Rollback();
             }
            

        }

        
    }
    public class Invoice
    {
        public int Number { get; set; }
        public int CustomerId { get; set; }
        public Guid ID { get; set; }
        public int OID { get; set; }
    }
    public class InvoiceDetail
    {
        public Guid InvoiceID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int OID { get; set; }
    }
}
