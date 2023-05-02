using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Jewellery_System.PRE.ITEMFORM
{
    public partial class frmSeachItems : Form
    {
        private int form_item_code;
        private string form_item_name;
        private int form_category_id;
        private string form_categories;
        private double form_amount;
        private DateTime form_item_date;
        private decimal form_item_weight;
        private int form_item_carat;
        private long shift_id;
        public string Status;
        private double qty;
      //  public static ITEMFORM instance;

        BUS.itemform itemform;
        DAT.function_ fun = new DAT.function_();

        public frmSeachItems(long _shiftid)
        {
            InitializeComponent();
            txt_shift_id.Text = _shiftid.ToString();
            //instance = this;
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ITEMFORM_KeyDown);
        }
        public frmSeachItems()
        {
            InitializeComponent();
         
            //instance = this;
            //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ITEMFORM_KeyDown);
        }
        public void Clear_Box()
        {
            try
            {
                txt_item_code.Text = "";
                txt_item_name.Text = "";
                txt_category_id.Text = "";
                txt_categories.Text = "";
                txt_item_amount.Text = "";
                txt_item_carat.Text = "";
                txt_item_weight.Text = "";
                txtqty.Text = "";
                btn_save.Text = "Save";
               btn_delete.Text = "Delete";

               txt_item_name.Focus();
            }
            catch { }
        }

        public bool Validation()
        {

            if(this.txt_categories.Text.Trim().Equals("Gold"))
            {}
            else if (this.txt_categories.Text.Trim().Equals("Silver"))
            { }
            else { fun.validationMessge("Please Select Category !"); txt_categories.Focus(); txt_categories.DroppedDown = true; return false; }
            if (btn_save.Text == "Save")
            {

            }
            else 
            {
                if (string.IsNullOrEmpty(this.txt_item_code.Text.Trim()))
                { fun.validationMessge("Please Enter Id Code !"); this.txt_item_code.Focus(); return false; }//1 Itemid
            }
            if (string.IsNullOrEmpty(this.txt_item_name.Text.Trim()))
            { fun.validationMessge("Please Enter ItemName !"); this.txt_item_name.Focus(); return false; }//2 Itemname
            if (string.IsNullOrEmpty(this.txt_category_id.Text.Trim()))
            { fun.validationMessge("Please Enter Category ID !"); this.txt_category_id.Focus(); return false; }// 3  Cat ID         
            if (string.IsNullOrEmpty(this.txt_categories.Text.Trim()))
            { fun.validationMessge("Please Enter Categories !"); this.txt_categories.Focus(); return false; } //4    Catog       
            if (string.IsNullOrEmpty(this.txt_item_amount.Text.Trim()))
            { fun.validationMessge("Please Enter Amount !"); this.txt_item_amount.Focus(); return false; }//5 Amount
            if (string.IsNullOrEmpty(this.txt_item_weight.Text.Trim()))
            { fun.validationMessge("Please Enter Weight !"); this.txt_item_weight.Focus(); return false; }//7 Weight
            if (string.IsNullOrEmpty(this.txt_item_carat.Text.Trim()))
            { fun.validationMessge("Please Enter Carat !"); this.txt_item_carat.Focus(); return false; }//8 Carat
            if (string.IsNullOrEmpty(this.txtqty.Text.Trim()))
            { fun.validationMessge("Please Enter Carat !"); this.txtqty.Focus(); return false; }//8 Carat
          
            else
            {
                if (string.IsNullOrEmpty(txt_item_code.Text.Trim())) { this.form_item_code = 0; }
                else { this.form_item_code = Convert.ToInt32(txt_item_code.Text); }

                this.form_item_name = this.txt_item_name.Text.Trim();
                this.form_category_id = Convert.ToInt32(this.txt_category_id.SelectedValue.ToString());
                this.form_categories = this.txt_categories.Text.Trim();
                this.form_amount = Convert.ToDouble(this.txt_item_amount.Text.Trim());
                this.form_item_date = Convert.ToDateTime(DateTime.Now.ToString());
                this.form_item_weight = Convert.ToDecimal(this.txt_item_weight.Text.Trim());
                this.form_item_carat = Convert.ToInt32(this.txt_item_carat.Text.Trim());
                this.shift_id = Convert.ToInt32(txt_shift_id.Text);
                this.qty = Convert.ToDouble(this.txtqty.Text);
            }

            return true;
        }
        public void BindCategory()
        {
            try
            {
                BUS.catogery1 cat = new BUS.catogery1();
                this.txt_category_id.DataSource = cat.Getcat1();
                this.txt_category_id.ValueMember = "id";
                this.txt_category_id.DisplayMember = "discription";
                cat = null;
            }
            catch 
            { 
            }
            
        
        }

        private void ITEMFORM_Load(object sender, EventArgs e)
        {
            try
            {
                itemform = new BUS.itemform();
                itemform.BindItemDetaislFull(dataGridView1);
                BindCategory();
            }
            catch
            {
 
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validation())
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.itemform = new BUS.itemform(this.form_item_code, this.form_item_name, this.form_category_id, this.form_categories, this.form_amount, this.form_item_date, this.form_item_weight, this.form_item_carat, this.shift_id, this.qty);


                        if (btn_save.Text == "Save")
                        {

                            if (this.itemform.saveItem(dataGridView1))
                            {
                                Clear_Box();

                            }
                            else
                            {}
                        }

                        else if (btn_save.Text == "Edit")
                        {
                            this.itemform.editItem(dataGridView1);
                            Clear_Box();
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
                            int rowindex = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Index);
                            this.form_item_code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                            this.itemform = new BUS.itemform(form_item_code);
                            if (this.itemform.deleteItem())
                            {
                                Clear_Box();

                                dataGridView1.Rows.RemoveAt(rowindex);

                                if (dataGridView1.SelectedRows.Count >= 1)
                                {
                                    dataGridView1.SelectedRows[0].Selected = false;
                                }
                            }
                            else
                            {
                                fun.validationMessge("Something Wrong!");
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
               
                try
                {

                    laselect.Text = "1";
                    this.Close();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void txt_category_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                form_category_id = Convert.ToInt32(txt_category_id.SelectedValue.ToString());
                ///  form_category_id = txt_category_id.SelectedValue;
                //MessageBox.Show(txt_category_id.SelectedValue.ToString());
            }
            catch
            { }
            
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            itemform = new BUS.itemform(this.txt_search.Text.Trim());
            itemform.BindItemyDetaisSearch(dataGridView1);
           // if (txt_search.Text == "") { itemform.BindItemDetaislFull(dataGridView1); }
        }

        private void ITEMFORM_KeyDown(object sender, KeyEventArgs e)
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

        private void ITEMFORM_Shown(object sender, EventArgs e)
        {
            txt_search.Focus();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {

                if (msg.WParam.ToInt32() == (int)Keys.Enter)
                {
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {



                         laselect.Text = "1";
                         this.Close();
                            return true;
                        }
                    
                }
                else if (msg.WParam.ToInt32() == (int)Keys.Down)
                {//da      tagridview select


                    //try
                    //{
                    //    if (txt_category_id.Focus() == true)
                    //    {  }
                    //    else if (txt_category_id.DroppedDown == true)
                    //    { }

                    //    else if (txt_categories.Focus() == true)
                    //    { }
                    //    else
                    //    {
                    //        if (dataGridView1.SelectedRows.Count >= 1)
                    //        { }
                    //        else
                    //        {
                    //            dataGridView1.Rows[0].Selected = true;
                    //            dataGridView1.Focus();

                    //        }
                    //    }

                    //}
                    //catch { }




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

        private void txt_item_carat_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_item_carat);
        }

        private void txt_item_weight_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_item_weight);
        }

        private void txtqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txtqty);
        }

        private void txt_item_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_item_amount);
        }

        private void txt_item_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_category_id.Focus();
                txt_category_id.DroppedDown = true;
            
            }
        }

        private void txt_category_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_categories.Focus();
                txt_categories.DroppedDown = true;

            }
        }

        private void txt_categories_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_item_carat.Focus();

            }
        }

        private void txt_item_carat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_item_weight.Focus();

            }
        }

        private void txt_item_weight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtqty.Focus();
            }
        }

        private void txtqty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_item_amount.Focus();

            }
        }

        private void txt_item_amount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();

            }
        }


    }
}
