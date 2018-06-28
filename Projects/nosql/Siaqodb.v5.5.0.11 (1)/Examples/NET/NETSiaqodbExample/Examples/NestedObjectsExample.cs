using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sqo;

namespace Example
{
    class NestedObjectsExample : BaseExample, IExample
    {
        Random random = new Random();
        public void Run()
        {
           
            GenerateOrders();
            LoadAllOrders();
            LoadOrdersWithonlySomeRelatedObjects();
        }

      
        
        public void GenerateOrders()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            List<Customer> customersAdded = new List<Customer>();
            for (int i = 0; i < 5; i++)
            {
                Customer cust = new Customer() { Name = "Customer" + i.ToString() };
                cust.Address = new Address() { City = "Berlin" };
                siaqodb.StoreObject(cust);
                customersAdded.Add(cust);
            }
            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                Product prod = new Product() { Name = "Product" + i.ToString() };
                siaqodb.StoreObject(prod);
                products.Add(prod);
            }
            for (int i = 0; i < 10; i++)
            {
                Order order = new Order();
                order.OrderDate = DateTime.Now;
                order.OrderNumber = i;
                order.OrderCustomer = customersAdded[random.Next(0,4)];
                order.Details = new List<OrderDetail>();
                
                for (int j = 0; j < 5; j++)
                {
                    OrderDetail detail = new OrderDetail();
                    detail.Price = random.Next(10, 100);
                    detail.Quantity = random.Next(1, 10);
                    detail.DetailProduct = products[random.Next(0, 4)];

                    order.Details.Add(detail);
                }
                siaqodb.StoreObject(order);//order and all detail objects are saved
            }
            siaqodb.Flush();
        }
        public void LoadAllOrders()
        { 
             Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();

             IList<Order> orders = siaqodb.LoadAll<Order>();

             foreach (Order order in orders)
             { 
                Log("Order with nr:"+order.OrderNumber+" is of Customer:"+order.OrderCustomer.Name+
                    @" and it has:"+order.Details.Count+" details as:");
                foreach (OrderDetail det in order.Details)
                {
                    Log("Product:" + det.DetailProduct.Name + ", Price:" + det.Price + ", Quantity:" + det.Quantity);
                }
             }
            Customer customer = new Customer() { Name = "CustomerX", Address = new Address() { City = "Berlin" } };

            var q = from Order o in siaqodb
                    where o.OrderCustomer == customer
                    select o;
             foreach (var city in q)
             { 
                
             }
        }
        public  void LoadOrdersWithonlySomeRelatedObjects()
        {
            Siaqodb siaqodb = SiaqodbFactoryExample.GetInstance();
            SiaqodbConfigurator.LoadRelatedObjects<Order>(false);
            SiaqodbConfigurator.LoadRelatedObjects<Customer>(false);

            IList<Order> orders = siaqodb.LoadAll<Order>();
            Log("All orders loaded has complex properties(Customer,OrderDetails)= null, means was not loaded from DB");

            var query1 = siaqodb.Query<Order>().Where(o => o.OrderNumber > 2).Include("OrderCustomer");

            Log("All orders will have property OrderCustomer loaded(since Customer has LoadRelatedObjects=false, Address will not be loaded)");
            foreach (Order order in query1)
            {
                Log("Order with nr:" + order.OrderNumber + " is of Customer:" + order.OrderCustomer.Name );
            }
           
            var query2 = siaqodb.Query<Order>().Where(o => o.OrderNumber > 2).Include("OrderCustomer")
                                                                             .Include("OrderCustomer.Address");

            
            Log("All orders will have property OrderCustomer and also property OrderCustomer.Address loaded");
            foreach (Order order in query2)
            {
                Log("Order with nr:" + order.OrderNumber + " is of Customer:" + order.OrderCustomer.Name +
                                    " from City:" + order.OrderCustomer.Address.City);
            }
            var query3 = (from Order o in siaqodb
                         where o.OrderNumber > 2
                          select o).Include("OrderCustomer").Include("OrderCustomer.Address");

            foreach (Order order in query3)
            {
                Log("Order with nr:" + order.OrderNumber + " is of Customer:" + order.OrderCustomer.Name +
                                    " from City:" + order.OrderCustomer.Address.City);
            }
        }
    }
    public class Order
    {
       
        public Customer OrderCustomer { get; set; }
        public List<OrderDetail> Details{get;set;}
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
    }
    public class OrderDetail
    {
        
        public Product DetailProduct { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
    public class Product
    {
        //values for this property are managed automatically by Siaqodb(it is autoincremented)
        //see more about OID:http://siaqodb.com/?page_id=582
        public int OID { get; set; }


        public string Name { get; set; }
    }
    public class Customer
    {
       
        public string Name { get; set; }
        public Address Address { get; set; }
       
    }
    public class Address
    {
        
        public string Street { get; set; }
        public string City { get; set; }
    }
}
