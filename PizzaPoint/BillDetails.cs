using System;

namespace PizzaPoint
{
    public class BillDetails
    {
        public int Billid { get; set; }
        public int OrderID { get; set; }
        public string CustID { get; set; }
        public string CustName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public TimeSpan Ordertime { get; set; }
        public DateTime OrderDate { get; set; }
        public string Totalqty { get; set; }
        public string TotalAmount { get; set; }
       
    }
}
