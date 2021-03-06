using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

/* ******************************************************
* CIS 123: Introduction to Object-Oriented Programming  *
* Murach C# 7th Edition                                 *
* Chapter 8: How to use arrays and collection           *
* Exercise 8-1 Use an array and a list                  *
*       Base code and form design provided by Murach    *
*       Exercise Instructions: pg. 267                  *
* Dominique Tepper, 25MAY2022                           *
* ******************************************************/

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }
/* ******************************************************************
*   2. Declare 2 class variables
*       A. An array that hold up tp 5 invoice totals
*       B. An index that can be used to work with the array
* ********************************************************* Tepper */
        
        decimal[] totalsArray = new decimal[5];       // 2A
        int totalsIndex = 0;                          // 2B


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

/* ******************************************************************
*   3. Add code that adds the invoice total to the next element in
*     the array each time the user clicks the Calculate button
* ********************************************************* Tepper */

                        totalsArray[totalsIndex] = invoiceTotal;
                        totalsIndex++;

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
            txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // TODO: add code that displays dialog boxes here

            this.Close();
        }

    }
}
