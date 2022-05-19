using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }
        // Samuel Kiarie - 05/19/2022
        // TODO: declare class variables for array and list here
        List<decimal> invoiceTotalsList = new List<decimal>();
        

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSubtotal.Text == "")
                {
                    MessageBox.Show(
                        "Subtotal is a required field.", "Entry Error");
                }
                else
                {
                    decimal subtotal = Decimal.Parse(txtSubtotal.Text);
                    if (subtotal > 0 && subtotal < 10000)
                    {
                        decimal discountPercent = 0m;
                        if (subtotal >= 500)
                            discountPercent = .2m;
                        else if (subtotal >= 250 & subtotal < 500)
                            discountPercent = .15m;
                        else if (subtotal >= 100 & subtotal < 250)
                            discountPercent = .1m;
                        decimal discountAmount = subtotal * discountPercent;
                        decimal invoiceTotal = subtotal - discountAmount;

                        discountAmount = Math.Round(discountAmount, 2);
                        invoiceTotal = Math.Round(invoiceTotal, 2);


                        invoiceTotalsList.Add(invoiceTotal);

                        txtDiscountPercent.Text = discountPercent.ToString("p1");
                        txtDiscountAmount.Text = discountAmount.ToString();
                        txtTotal.Text = invoiceTotal.ToString();

                    }
                    else
                    {
                        MessageBox.Show(
                            "Subtotal must be greater than 0 and less than 10,000.",
                            "Entry Error");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter a valid number for the Subtotal field.",
                    "Entry Error");
            }
            catch (IndexOutOfRangeException)
            {
               // MessageBox.Show("Can only input 5 elements", "Array Issue");
            }
            
              txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {    // Samuel Kiarie
            // TODO: add code that displays dialog boxes here
            string msg = " ";
            invoiceTotalsList.Sort();   // sorting the list

            foreach (decimal total in invoiceTotalsList) // display all the invoice totals in the  in a msg box
            {

                if (total != 0) // totals that are not equal to zero
                {
                    msg += total.ToString("c") + "\n"; 
                }
            }
           // MessageBox.Show(msg, "Order Totals - Array");
            MessageBox.Show(msg, "Order Totals - List");

            this.Close();
        }

    }
}
