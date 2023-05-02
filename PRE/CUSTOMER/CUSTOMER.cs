using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.CUSTOMER
{
    public partial class CUSTOMER : Form
    {
        private string form_customer_id;
        private string form_customer_name;
        private string form_customer_address;
        private string form_customer_phoneno;
        private string form_customer_nicno;
        private string form_customer_type;
        public string Status;

        private long _shiftid;
      //  public static CUSTOMER instance;

        BUS.customer customer;
        DAT.function_ fun = new DAT.function_();
        
        public CUSTOMER(long shiftid)
        {
            InitializeComponent();
            _shiftid = shiftid;
            //instance = this;
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CUSTOMER_KeyDown);
        }
        public CUSTOMER()
        {
            InitializeComponent();

        }
        public void Clear_Box()
        {
            try
            {
               // txt_customer_id.Visible = false;
                txt_customer_id.Text = "";
                txt_customer_name.Text = "";
                txt_customer_address.Text = "";
                txt_customer_phoneno.Text = "";
                txt_customer_nicno.Text = "";
                txt_customer_type.Text = "";
                btn_save.Text = "Save"; btn_delete.Text = "Delete";
                txt_customer_name.Focus();
               // customer.BindCustomerDetails(dataGridView1);
              
            }
            catch { }
        }

        public bool Validation()
        {




            if(txt_customer_type.Text.Trim().Equals("Customer"))
            {
            
            }
            else if(txt_customer_type.Text.Trim().Equals("Supplier"))
            {}
             else if(txt_customer_type.Text.Trim().Equals("Bass"))
            {}
            else if (txt_customer_type.Text.Trim().Equals("Others"))
            { }
            else { fun.validationMessge("Please Select Type Of Person !!"); txt_customer_type.Focus(); txt_customer_type.DroppedDown = true; return false; }
            if (btn_save.Text == "Save")
            { }
            else
            {
                if (string.IsNullOrEmpty(this.txt_customer_id.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.txt_customer_id.Focus(); return false; }
            }

            if (string.IsNullOrEmpty(this.txt_customer_name.Text.Trim()))
            { fun.validationMessge("Please Enter Name !"); this.txt_customer_name.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_customer_type.Text.Trim()))
            { fun.validationMessge("Please Select Type !"); this.txt_customer_type.Focus(); return false; }

            else
            {
                if (string.IsNullOrEmpty(txt_customer_id.Text.Trim())) { this.form_customer_id = null; }
                else { this.form_customer_id = this.txt_customer_id.Text.Trim(); }
                this.form_customer_name = this.txt_customer_name.Text.Trim();
                this.form_customer_address = this.txt_customer_address.Text.Trim();
                this.form_customer_phoneno = this.txt_customer_phoneno.Text.Trim();
                this.form_customer_nicno = this.txt_customer_nicno.Text.Trim();
                this.form_customer_type = this.txt_customer_type.Text.Trim();
            }
            return true;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validation())
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.customer = new BUS.customer(form_customer_id, form_customer_name, form_customer_address, form_customer_phoneno, form_customer_nicno, form_customer_type,_shiftid);


                        if (btn_save.Text == "Save")
                        {

                            if (this.customer.Savecustomer(dataGridView1))
                            {
                               
                                Clear_Box();
                            }
                            else{}
                        }

                        else if (btn_save.Text == "Edit")
                        {
                            if (this.customer.Editcustomer(dataGridView1))
                            {

                                Clear_Box();
                            }
                        }
                        else { fun.validationMessge("Something Wrong!"); }


                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_delete.Text == "Cancel")
                {
                    Clear_Box();
                }
                else
                {
                    if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                    {
                        if (dataGridView1.SelectedRows.Count >= 1)
                        {
                            int rowindex = Convert.ToInt32(dataGridView1.SelectedRows[0].Index);

                            this.form_customer_id = (dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            this.customer = new BUS.customer(this.form_customer_id);
                            if (this.customer.Deletecustomer())
                            {

                                Clear_Box();
                                dataGridView1.Rows.RemoveAt(rowindex);
                            }
                            else
                            {
                                fun.validationMessge("Something Wrong!");
                            }
                        }
                        else
                        {
                            fun.validationMessge("Please Select Delete Data !!!");
                        }

                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
                try
                {
                   
                    this.txt_customer_id.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.txt_customer_name.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.txt_customer_address.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.txt_customer_phoneno.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    this.txt_customer_nicno.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    this.txt_customer_type.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();


                    btn_save.Text = "Edit"; btn_delete.Text = "Cancel";
                    txt_customer_name.Focus();
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        dataGridView1.SelectedRows[0].Selected = false;
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            
           
        }

        private void CUSTOMER_Load(object sender, EventArgs e)
        {
            try
            {
                customer = new BUS.customer();
                customer.BindCustomerDetails(dataGridView1);
            }
            catch { }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            //if (str txt_search.Text == "") { customer.BindCustomerDetails(dataGridView1); }
            //else
            //{
            try
            {
               // customer.tagsearch(txt_search.Text);
                customer.BindCustomeryDetaisSearch(dataGridView1, txt_search.Text);
            }
            catch { }
            //}
                
        }

        private void CUSTOMER_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.Handled)
            //{
            //    if (e.KeyCode == Keys.F5)
            //    { Clear_Box(); }

            //    if (e.KeyCode == Keys.Delete)
            //    { btn_delete.PerformClick(); }

            //    if (e.KeyCode == Keys.Enter)
            //    { SendKeys.Send("{tab}"); e.Handled = e.SuppressKeyPress = true; }

            //    if (e.KeyCode == Keys.Escape)
            //    { this.Close(); }
            //}
            //e.Handled = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {

                if (msg.WParam.ToInt32() == (int)Keys.Enter)
                {
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        DialogResult result = MessageBox.Show("Are You Sure You Want To Modify ?\n\nPerson Id : " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "\n\nPerson Name : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "", BUS1.Config.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.txt_customer_id.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            this.txt_customer_name.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            this.txt_customer_address.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                            this.txt_customer_phoneno.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                            this.txt_customer_nicno.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                            this.txt_customer_type.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();


                            btn_save.Text = "Edit"; btn_delete.Text = "Cancel";

                            if (dataGridView1.SelectedRows.Count >= 1)
                            {
                                dataGridView1.SelectedRows[0].Selected = false;
                            }


                            txt_customer_name.Focus();
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
        
    }
}
