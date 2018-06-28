using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siaqodb_Document_Example
{
    [ProtoBuf.ProtoContract(ImplicitFields = ProtoBuf.ImplicitFields.AllPublic)]
    public class Invoice
    {

        public string Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal InvoiceTotal { get; set; }
        public List<InvoiceLine> Lines { get; set; }
        public string CustomerCode { get; set; }
    }
    [ProtoBuf.ProtoContract(ImplicitFields = ProtoBuf.ImplicitFields.AllPublic)]
    public class InvoiceLine
    {
        public int NrCrt { get; set; }
        public int Quantity { get; set; }
        public Product TheProduct { get; set; }
        public decimal Price { get; set; }
        public decimal LineTotal { get; set; }

    }
    [ProtoBuf.ProtoContract(ImplicitFields = ProtoBuf.ImplicitFields.AllPublic)]
    public class Product
    {
        public string ProductName { get; set; }
        public decimal DefaultPrice { get; set; }
    }
}
