using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestMakingAPIJuly2018.Models;

namespace TestMakingAPIJuly2018.Controllers
{
    public class NorthwindController : ApiController
    {
        //action to get info about all customers
        //no params needed because you're getting ALL info
        public List<Customer> GetAllCustomers()
        {
            //create ORM
            northwindEntities ORM = new northwindEntities();//create obj
            //get all customers from the ORM
            List<Customer> customerList = ORM.Customers.ToList();
            //return the list of customers
            return customerList;
        }
    
        //action to get customers from specific city; filter cust by using the city
        [HttpGet] //bc it is dependant on input
        public List<Customer> GetCustomersByCity(string city) //need city input
        {
            //URL .... provide input by adding a query
            //http://localhost:portnum/api/Northwind/GetCustomersByCity?city=Detroit
            //create ORM
            northwindEntities ORM = new northwindEntities();
            //search cust based on city
            return ORM.Customers.Where(x => x.City.ToLower()==city.ToLower()).ToList();

            //return filtered cust list... included above
        }

        //action to get all cities where customers come from
        public List<string> GetAllCities()
        {
            //URL
            //....api/Northwind/GetAllCities
            //create ORM
            northwindEntities ORM = new northwindEntities();
            //return ORM.Customers.Select(x => x.City).Distinct().ToList();
            //return customers where city not null, filter through and only get that column
                //remove duplicates and return to list
            //LINQ statement WHERE&&SELECT taking lambdas //ORM.Customers ----list of cust
            return ORM.Customers.Where(x => x.City !=null)
                .Select(x => x.City).Distinct().ToList();

        }

        //action to get orders for a specific customer
        [HttpGet]
        public List<Order> GetCustomerOrders(string customerID) //takes in str customerID (PK)
        {   
            //URL... api/Northwind/GetCustomerOrders?customerID  can have customerID=ALFKI
            //ORM
            northwindEntities ORM = new northwindEntities();

            //Find cust, then get orders for that cust
            Customer c = ORM.Customers.Find(customerID); //Find then..save cust as var c
            if (c!=null) //if that cust c is not null
            {
                return c.Orders.ToList(); //will return orders made by that cust c
            }
            return null;

            //return list of orders for that cust/custID
            //Customer c = ORM.Cusotmers.Find()
            //foreach()
        }

        //action to get list of all orders sort by order date
        //URL.../api/Northwind/GetOrdersByDate

        [HttpGet]
        public List<Order> GetOrdersByDate(string orderID)
        {   
            //ORM
            northwindEntities ORM = new northwindEntities();
            //find all orders and make a new list OrderList by date
            List<Order> OrderList = ORM.Orders.ToList();
            var OrderedOrderList = OrderList.OrderByDescending(o => o.OrderDate).ToList();

            return OrderList;

        }

       //get list of* cust from spec country
       //URL.../api/Northwind/GetCustomersByCountry?country
       [HttpGet]
        public List<Customer> GetCustomersByCountry(string country)
        {
            //ORM
            northwindEntities ORM = new northwindEntities();
            //retrun via cust country
            return ORM.Customers.Where(x => x.Country.ToLower() == country.ToLower()).ToList();

        }

        //get last order made by spec cust
        //URL.../api/Northwind/
        [HttpGet]
        public List<Order> GetLastOrderByCustomer(string customerID)
        {
            //ORM
            northwindEntities ORM = new northwindEntities();
            //create a list of orders
            List<Order> CustomersOrderList = ORM.Orders.ToList();
            //list cust orders by descending(gives you last one first)...and select where order ==0
            var OrdereredList = CustomersOrderList.OrderByDescending(o => o.OrderDate).ToList();
            return CustomersOrderList;
        }

    }
}