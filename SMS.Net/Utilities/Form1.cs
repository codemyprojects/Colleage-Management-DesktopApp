using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMS.Net.Utilities
{
    public partial class Form1 : Form
    {
       private int cf=0;
       private int FeeId=7;
       private string FeeDate="2071-2-30";
       private int StudentId=2;
       private int PaidAmount;
       private int DueAmount;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
           // reportViewer1.BackColor = System.Drawing.Color.Bisque;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
                if (textBox1.Text != string.Empty)
                {
                    try{
                    dataGridView1.ColumnCount = 6;
                    dataGridView1.Columns[0].Name = "Fee Id";
                    dataGridView1.Columns[1].Name = "Student Id";
                    dataGridView1.Columns[2].Name = "Fee Date";
                    dataGridView1.Columns[3].Name = "Paid Amount";
                    dataGridView1.Columns[4].Name = "Total Amount";
                    dataGridView1.Columns[5].Name = "Due Amount";
                    // dataGridView1.Columns[2].Name = "Product Price";
                    cf = int.Parse(textBox1.Text.Trim()) + cf;
                    string[] row = new string[] {FeeId.ToString(),StudentId.ToString(),FeeDate, textBox1.Text,cf.ToString(), textBox2.Text.Trim() };
                    SqlParameter[] param=new SqlParameter[]
                    {
                        new SqlParameter("@FeeId",FeeId),
                        new SqlParameter("@StudentId",StudentId),
                        new SqlParameter("@FeeDate",FeeDate),
                        new SqlParameter("@PaidAmount",textBox1.Text.Trim()),
                        new SqlParameter("@DueAmount",textBox2.Text.Trim())
                    };
                    DataBaseLayer.DbOperations.ExecProc("[student].[spAddPayment]", param, true);
                    dataGridView1.Rows.Add(row);
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Amount Can't be string");
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please do not leave TextBox Empty");
                }
          
          
       
            
            //row = new string[] { "2", "Product 2", "2000" };
            //dataGridView1.Rows.Add(row);
            //row = new string[] { "3", "Product 3", "3000" };
            //dataGridView1.Rows.Add(row);
            //row = new string[] { "4", "Product 4", "4000" };
            //dataGridView1.Rows.Add(row);

            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //dataGridView1.Columns.Add(btn);
            //btn.HeaderText = "Click Data";
            //btn.Text = "Click Here";
            //btn.Name = "btn";
            //btn.UseColumnTextForButtonValue = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 3)
            //{
            //    MessageBox.Show((e.RowIndex + 1) + "  Row  " + (e.ColumnIndex + 1) + "  Column button clicked ");
            //}
        }
    }
}
