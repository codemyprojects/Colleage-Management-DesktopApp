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

namespace SMS.Net.FeeStructure
{
    public partial class ViewFeeStructure : Form
    {
        public ViewFeeStructure()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
           
        }

        private void ViewFeeStructure_Load(object sender, EventArgs e)
        {
            BindClassComboBox();
            GridViewRowCellStyle();
            SaveButton.Enabled = false;
        }
        private void BindClassComboBox()
        {
            DataTable dt = DataBaseLayer.DbOperations.GetDataTable("[student].[spClassInfo]", null, true);
            ClassComboBox.ValueMember = "ClassId";
            ClassComboBox.DisplayMember = "Class";
            ClassComboBox.DataSource = dt;
        }

        private void ClassComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
           
        }
       

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.RowCount > 0)
            {

                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string a = Convert.ToString(selectedRow.Cells["FeeId"].Value);
                Common.FeeStructure.Fee f = new Common.FeeStructure.Fee();
                f.FeeId = int.Parse(a);
                SqlDataReader sdr = BusinessLayer.FeeStructure.AddFee.DisplyFeeByFeeId(f);
                FeeCodeComboBox.Text = sdr["FeeCode"].ToString();
                FeeNameTextBox.Text = sdr["FeeName"].ToString();
                FeeAmountTextBox.Text = sdr["FeeAmount"].ToString();
                FeeDescriptionRichTextBox.Text = sdr["FeeDescription"].ToString();

            }
      }

        private void EditButton_Click(object sender, EventArgs e)
        {
            SaveButton.Enabled = true;
            EditButton.Enabled = false;
        }

     

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Common.Class.Class c = new Common.Class.Class();
            c.ClassId = Convert.ToInt32(ClassComboBox.SelectedValue.ToString());
            if (ClassComboBox.SelectedIndex < 0)
            {

            }
            else
            {
                if (ClassComboBox != null)
                {
                    SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@ClassId",c.ClassId)
            };
                    DataTable dt = DataBaseLayer.DbOperations.GetDataTable("student.[spFeeStructureDisplay]", param, true);
                    if (dt.Rows.Count > 0)
                    {

                        // c.ClassId = Convert.ToInt32(ClassComboBox.SelectedValue.ToString());
                        //SqlDataReader sdr = BusinessLayer.FeeStructure.AddFee.ViewFee(c);
                        //FeeNameTextBox.Text = sdr["FeeName"].ToString();
                        //FeeAmountTextBox.Text = sdr["FeeAmount"].ToString();
                        //FeeDescriptionRichTextBox.Text = sdr["FeeDescription"].ToString();

                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("No Records Please!!");
                    }
                }



            }
        }

        private void GridViewRowCellStyle()
        {
            this.dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.Bisque;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige;
        }

        }
    }

