using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.CATEGORY2
{
    public partial class frmCategoryByDays : Form
    {
        private int form_id;
        private string form_description;
        private int form_days;
        private double form_amount;

        BUS.category2 category2;
        DAT.function_ fun = new DAT.function_();

        public frmCategoryByDays()
        {
            InitializeComponent();
           
        }
      
        //public frmAddCatergory()
        //{
        //    InitializeComponent();
        //}
           
        private void fill_grid()
        {
     

        }
        public void getcatid()
        {
         
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {

                if (msg.WParam.ToInt32() == (int)Keys.Enter)
                {
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        DialogResult result = MessageBox.Show("Are You Sure You Want To Modify ?\n\nCategory Id : " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "\n\nCategory : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "", BUS1.Config.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                           txtcatergory_id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            txtdiscription.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        txt_days .Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                     txt_amount.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                       
                            
                            btn_save.Text = "Edit"; button5.Text = "Cancel";

                            if (dataGridView1.SelectedRows.Count >= 1)
                            { dataGridView1.SelectedRows[0].Selected = false; }
                            txtdiscription.Focus();
                            return true;
                        }
                    }
                }
                else if (msg.WParam.ToInt32() == (int)Keys.Down)
                {//da      tagridview select


                    try
                    {
                        if (dataGridView1.SelectedRows.Count >= 1)
                        { }
                        else
                        {
                            dataGridView1.Rows[0].Selected = true;
                            dataGridView1.Focus();
                        
                        }
                       
                    }
                    catch { }




                }

                else if (msg.WParam.ToInt32() == (int)Keys.Delete)
                {//da      tagridview select


                    return true;

                }
                else if (msg.WParam.ToInt32() == (int)Keys.F11)
                {//datagridview unselect

                    try
                    {


                      //  dataGridView1.SelectedRows[0].Selected = false;


                    }
                    catch { }



                }
                else if (msg.WParam.ToInt32() == (int)Keys.Escape)
                {//datagridview unselect

                    try
                    {

                        DialogResult result = MessageBox.Show("Are You Sure You Want To Exit  ?", "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                        }

                    }
                    catch { }



                }
            }
            catch { }
            return base.ProcessCmdKey(ref msg, keyData);
            return true;
        }
        private void frmAddCatergory_Load(object sender, EventArgs e)
        {
          


                try
                {


                    category2 = new BUS.category2();
                    category2.BindCategoryDetaisl(dataGridView1);

                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        dataGridView1.SelectedRows[0].Selected = false;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
             
           
        }


        private bool Validation()
        {

           

          
            if (btn_save.Text == "Save")
            { }
            else
            {
                if (string.IsNullOrEmpty(this.txtcatergory_id.Text.Trim()))
                { fun.validationMessge("Please Select Edit Data !"); dataGridView1.Focus(); return false; }

            }


            if (string.IsNullOrEmpty(this.txtdiscription.Text.Trim()))
            { fun.validationMessge("Please Enter Description !"); this.txtdiscription.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_days.Text.Trim()))
            { fun.validationMessge("Please Enter Days !"); this.txt_days.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_amount.Text.Trim()))
            { fun.validationMessge("Please Enter Amount !"); this.txt_amount.Focus(); return false; }

            else
            {
                if (string.IsNullOrEmpty(txtcatergory_id.Text.Trim())) { this.form_id = 0; }
                else { this.form_id = Convert.ToInt32(txtcatergory_id.Text); }
                this.form_description = this.txtdiscription.Text.Trim();
                this.form_days = Convert.ToInt32(this.txt_days.Text.Trim());
                this.form_amount = Convert.ToDouble(this.txt_amount.Text.Trim());

            }
            return true;
         
        }
        public void Cle()
        {
            txtdiscription.Text = ""; txtcatergory_id.Text = "";
            txt_days.Text = ""; txt_amount.Text = "";
            btn_save.Text = "Save"; button5.Text = "Delete";
            txtdiscription.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validation())
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.category2 = new BUS.category2(form_id, form_description, form_days, form_amount);


                        if (btn_save.Text == "Save")
                        {

                            if (this.category2.Saveshop(dataGridView1))
                            {

                              

                            }
                           


                        }

                        else if (btn_save.Text == "Edit")
                        {
                            if (this.category2.Editshop(dataGridView1))
                            {
                                Cle();
                            }
                        }
                        else { fun.validationMessge("Something Wrong!"); }


                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{

            //    if (Validation())
            //    {
            //        if (fun.ShowMessage("Do You Want To Save ?\n\nCategory : " + txtdiscription.Text.Trim() + "", "Confirm"))
            //        {
            //            cat._CategoryName = this.txtdiscription.Text.Trim();
            //            cat.EditCategory();

            //            button3.Visible = false;
            //            button1.Visible = true;
                     
            //            cat.BindDatagridview(dataGridView1);
            //            TextBox[] txt = { txtdiscription };
            //            fun.TextClear(txt); button5.Text = "Delete";
            //            if (dataGridView1.SelectedRows.Count >= 1)
            //            { dataGridView1.SelectedRows[0].Selected = false; }
            //            txtdiscription.Focus();
            //        }
            //    }
               


                   
            //}
            //catch 
            //{
                
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
             try
            {
                if (button5.Text == "Cancel")
                {
                    TextBox[] txt = { txtdiscription };
                    fun.TextClear(txt); button5.Text = "Delete";btn_save.Text="Save";
                    txtdiscription.Focus();
                }
                else
                {
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        fun.validationMessge("Please Select Catergory From Table !!!");
                    }
                    else
                    {
                        if (fun.ShowMessage("Are You Sure You Want To Delete ?\n\nCharges Id : " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "\n\nCharges: " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "", "Confirm"))
                        {
                           
                            int rowindex=Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Index);
                        this.form_id= Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        this.category2 = new Jewellery_System.BUS.category2(this.form_id);
                        if (this.category2.Deleteshop())
                        {
                          //  Progress_And_Clear();
                            dataGridView1.Rows.RemoveAt(rowindex);
                        }
                        else
                        {
                            fun.validationMessge("Something Wrong!");
                        }
                            if (dataGridView1.SelectedRows.Count >= 1)
                            { dataGridView1.SelectedRows[0].Selected = false; }
                            txtdiscription.Focus();

                        }


                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }

           
            //try
            //{
            //    if (button5.Text == "Cancel")
            //    {
            //        TextBox[] txt = { txtdiscription };
            //        fun.TextClear(txt); button5.Text = "Delete"; button3.Visible = false; button1.Visible = true ; 
            //        txtdiscription.Focus();
            //    }
            //    else
            //    {
            //        if (dataGridView1.SelectedRows.Count == 0)
            //        {
            //            fun.validationMessge("Please Select Catergory From Table !!!");
            //        }
            //        else
            //        {
            //            if (fun.ShowMessage("Are You Sure You Want To Delete ?\n\nCategory Id : " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "\n\nCategory : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "", "Confirm"))
            //            {
            //                cat._Categoryid = Convert.ToInt64(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //                cat.DeleteCategory();
                          
            //                cat.BindDatagridview(dataGridView1);
            //                if (dataGridView1.SelectedRows.Count >= 1)
            //                { dataGridView1.SelectedRows[0].Selected = false; }
            //                txtdiscription.Focus();

            //            }


                       
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
              
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Exit  ?", "Confirm Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (result == DialogResult.Yes)
             {
                 this.Close();
             }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                category2 = new BUS.category2(this.textBox1.Text.Trim());
                category2.GetCat2byDescription(dataGridView1);
                // if (txt_search.Text == "") { catogery1.BindCategory2Details(dataGridView1); };

                if (dataGridView1.SelectedRows.Count >= 1)
                { dataGridView1.SelectedRows[0].Selected = false; }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are You Sure You Want To Modify ?\n\nCategory Id : " + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString() + "\n\nCategory : " + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + "", BUS1.Config.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.txtcatergory_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.txtdiscription.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.txt_days.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.txt_amount.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                  
                    btn_save.Text = "Edit"; button5.Text = "Cancel";txtdiscription.Focus();
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {

                        dataGridView1.SelectedRows[0].Selected = false;
                    }
                }
              
            }
            catch
            {
                // MessageBox.Show(ex.Message);
               
            }
        }

        private void frmAddCatergory_Shown(object sender, EventArgs e)
        {
            txtdiscription.Focus();
        }

        private void txtdiscription_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {


                   
                       // fun.FistLeterCapita(txtdiscription);
                        txt_days.Focus();
                   
                }
            }
            catch { }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
            //    if (e.KeyData == Keys.Enter)
            //    {
            //        int col = dataGridView1.CurrentCell.ColumnIndex;
            //        int row = dataGridView1.CurrentCell.RowIndex;

            //        if (col < dataGridView1.ColumnCount - 1)
            //        {
            //            col++;
            //        }
            //        else
            //        {
            //            col = 0;
            //            row++;
            //        }

            //        if (row == dataGridView1.RowCount)
            //            dataGridView1.Rows.Add();

            //        dataGridView1.CurrentCell = dataGridView1[col, row];
            //        e.Handled = true;
            //    }
                // txtcatergory_id.ReadOnly = true;
            }
            catch
            {
                // MessageBox.Show(ex.Message);

            }
        }

        private void txtdiscription_TextChanged(object sender, EventArgs e)
        {

        }

        private void lasave_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Enter(object sender, EventArgs e)
        {
            fun.godFocusOnButton(btn_save);
        }

        private void button1_Leave(object sender, EventArgs e)
        {
          fun.lostFocusOnButton(btn_save);
        }

        private void button3_Enter(object sender, EventArgs e)
        {
          //  fun.godFocusOnButton(button3);
        }

        private void button3_Leave(object sender, EventArgs e)
        {
           // fun.lostFocusOnButton(button3);
        }

        private void button5_Enter(object sender, EventArgs e)
        {
            fun.godFocusOnButton(button5);
        }

        private void button5_Leave(object sender, EventArgs e)
        {
            fun.lostFocusOnButton(button5);
        }

        private void button4_Enter(object sender, EventArgs e)
        {
            fun.godFocusOnButton(button4);
        }

        private void button4_Leave(object sender, EventArgs e)
        {
            fun.lostFocusOnButton(button4);
        }

        public int da { get; set; }

        private void txt_days_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_days);
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_amount);
        }

        private void txt_days_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_amount.Focus();
            }
        }

        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {



                btn_save.Focus();

            }
        }
    }
}
