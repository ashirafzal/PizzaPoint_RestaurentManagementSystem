using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaPoint
{
    public partial class BillPrint : Form
    {
        List<BillDetails> _bill;
        OrdersDetails _orders;

        public BillPrint(OrdersDetails orders, List<BillDetails> bill)
        {
            InitializeComponent();
            _orders = orders;
            _bill = bill;
        }

        private void BillPrint_Load(object sender, EventArgs e)
        {
            report();
        }

        public void report()
        {

            List<string> list = new List<string>();
            rptOrders1.SetDataSource(_bill);
            //rptOrders1.SetParameterValue("pBillid", _orders.Billid);
            rptOrders1.SetParameterValue("pOrderID", _orders.OrderID);
            rptOrders1.SetParameterValue("pCustID", _orders.CustID);
            rptOrders1.SetParameterValue("pCustName", _orders.CustName);
            rptOrders1.SetParameterValue("pTime", _orders.Ordertime.ToString());
            rptOrders1.SetParameterValue("pDate", _orders.OrderDate.ToString());
            rptOrders1.SetParameterValue("ProductName", _orders.ProductName);
            rptOrders1.SetParameterValue("Qty", _orders.ProductQuantity);
            rptOrders1.SetParameterValue("Price", _orders.ProductPrice);
            rptOrders1.SetParameterValue("pTotalQty", Convert.ToString(_orders.Totalqty));
            rptOrders1.SetParameterValue("pTotalAmount", Convert.ToString(_orders.TotalAmount));
            crystalReportViewer.ReportSource = rptOrders1;
            crystalReportViewer.Refresh();
        }
    }
}
