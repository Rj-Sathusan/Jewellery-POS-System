using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.PURCHASE
{
    public partial class PURCHASE : Form
    {
        BUS.customer customer = new BUS.customer();
        BUS.purchase purchase;
        DAT.function_ fun = new DAT.function_();
        public static PURCHASE instance;

        private int f_purchase_id;
        private string f_customer_id;
        private string f_customer_name;
        private string f_item_code;
        private string f_item_name;
        private int f_purchase_carat;
        private decimal f_purchase_weight;
        private double f_purchase_quantity;
        private decimal f_purchase_total_weight;
        private double f_purchase_unit_price;
        private double f_purchase_total_price;
        private double f_purchase_discount;
        private double f_purchase_net_total_price;
        private decimal f_purchase_making;
        private decimal f_purchase_wasting;
        private DateTime f_purchase_date;
       

        public bool Validation()
        {
            if (string.IsNullOrEmpty(this.txt_customer_id.Text.Trim()))
            { fun.validationMessge("Please Enter customer_id"); this.txt_customer_id.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_customer_name.Text.Trim()))
            { fun.validationMessge("Please Enter customer_name"); this.txt_customer_name.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_item_name.Text.Trim()))
            { fun.validationMessge("Please Enter item_name"); this.txt_item_name.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_carat.Text.Trim()))
            { fun.validationMessge("Please Enter carrot"); this.txt_carat.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_weight.Text.Trim()))
            { fun.validationMessge("Please Enter weight"); this.txt_weight.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_quantity.Text.Trim()))
            { fun.validationMessge("Please Enter quantity"); this.txt_quantity.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_total_weight.Text.Trim()))
            { fun.validationMessge("Please Enter Total Weight !"); this.txt_total_weight.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_unit_price.Text.Trim()))
            { fun.validationMessge("Please Enter unit_price"); this.txt_unit_price.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_total_price.Text.Trim()))
            { fun.validationMessge("Please Enter Total Weight !"); this.txt_total_price.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_discount.Text.Trim()))
            { fun.validationMessge("Please Enter discount"); this.txt_discount.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_net_total.Text.Trim()))
            { fun.validationMessge("Please Enter Net Total !"); this.txt_net_total.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_making.Text.Trim()))
            { fun.validationMessge("Please Enter Making"); this.txt_making.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_wasting.Text.Trim()))
            { fun.validationMessge("Please Enter Wasting"); this.txt_wasting.Focus(); return false; }

            return true;
        }

        public void Clear_Box()
        {
            try
            {
                txt_customer_id.Text = "";
                txt_customer_name.Text = "";
                txt_item_name.Text = "";
                txt_carat.Text = "";
                txt_weight.Text = "";
                txt_quantity.Text = "";
                txt_total_weight.Text = "";
                txt_unit_price.Text = "";
                txt_total_price.Text = "";
                txt_discount.Text = "";
                txt_net_total.Text = "";
                txt_making.Text = "";
                txt_wasting.Text = "";
                txt_customer_name.Focus();
            }
            catch { }
        }
        public PURCHASE()
        {
            InitializeComponent();
            instance = this;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PURCHASE_KeyDown);
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform=new Menu.Menu();
            menuform.Show();

        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                try
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = txt_customer_id.Text;
                    newRow.Cells[1].Value = txt_customer_name.Text;
                    newRow.Cells[2].Value = txt_itemid.Text;
                    newRow.Cells[3].Value = txt_item_name.Text;
                    newRow.Cells[4].Value = txt_carat.Text;
                    newRow.Cells[5].Value = txt_weight.Text;
                    newRow.Cells[6].Value = txt_quantity.Text;
                    newRow.Cells[7].Value = txt_total_weight.Text;
                    newRow.Cells[8].Value = txt_unit_price.Text;
                    newRow.Cells[9].Value = txt_total_price.Text;
                    newRow.Cells[10].Value = txt_discount.Text;
                    newRow.Cells[11].Value = txt_net_total.Text;
                    newRow.Cells[12].Value = txt_making.Text;
                    newRow.Cells[13].Value = f_purchase_wasting;
                    dataGridView1.Rows.Add(newRow);
                    Clear_Box();

                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (fun.ShowMessage("Are You Sure You Want To Save ?", "Confirm"))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    f_customer_id = Convert.ToString(dataGridView1.Rows[i].Cells[0].Value);
                    f_customer_name = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    f_item_code = Convert.ToString(dataGridView1.Rows[i].Cells[2].Value);
                    f_item_name = Convert.ToString(dataGridView1.Rows[i].Cells[3].Value);
                    f_purchase_carat = Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value);
                    f_purchase_weight = Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                    f_purchase_quantity = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    f_purchase_total_weight = Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                    f_purchase_unit_price = Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                    f_purchase_total_price = Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value);
                    f_purchase_discount = Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value);
                    f_purchase_net_total_price = Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value);
                    f_purchase_making = Convert.ToDecimal(dataGridView1.Rows[i].Cells[12].Value);
                    f_purchase_date = Convert.ToDateTime(DateTime.Now.ToString());
                    f_purchase_wasting = Convert.ToDecimal(dataGridView1.Rows[i].Cells[13].Value);
                    f_purchase_id = 0;

                    try
                    {
                        //this.purchase = new BUS.purchase(f_purchase_id, f_item_code, f_customer_id, f_customer_name, f_item_name, f_purchase_carat, f_purchase_weight, f_purchase_quantity, f_purchase_total_weight, f_purchase_unit_price, f_purchase_total_price, f_purchase_discount, f_purchase_net_total_price, f_purchase_making, f_purchase_wasting, f_purchase_date);
                        //purchase.Savepurchase();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }
                MessageBox.Show("Data Saved Successfully", "Warning");
                dataGridView1.Rows.Clear();
            }
        }
             

        private void btn_delete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(dataGridView1.RowCount));

        
        }

        private void PURCHASE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled)
            {
                if (e.KeyCode == Keys.F5)
                { Clear_Box(); }

                if (e.KeyCode == Keys.Delete)
                { btn_delete.PerformClick(); }

                if (e.KeyCode == Keys.Enter)
                { SendKeys.Send("{tab}"); e.Handled = e.SuppressKeyPress = true; }

                if (e.KeyCode == Keys.Escape)
                { this.Close(); }
            }
            e.Handled = true;

        }

        private void PURCHASE_Load(object sender, EventArgs e)
        {

        }

        
        private void btn_search_Click(object sender, EventArgs e)
        {
            PRE.CUSTOMER.CUSTOMER customerselect = new PRE.CUSTOMER.CUSTOMER(1);
            btn_search2.Focus();
            customerselect.Show();
           // PRE.CUSTOMER.CUSTOMER.instance.Status = "CONNECTED";
            
            
        }

        private void btn_search_Click2(object sender, EventArgs e)
        {
            //PRE.ITEMFORM.ITEMFORM Itemselect = new PRE.ITEMFORM.ITEMFORM();
            //txt_quantity.Focus();
            //Itemselect.Show();
            //PRE.ITEMFORM.ITEMFORM.instance.Status = "CONNECTED";
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_weight.Text = Convert.ToString(Convert.ToDecimal(txt_weight.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_weight.Text = ""; }

            try
            {
                txt_total_price.Text = Convert.ToString(Convert.ToDecimal(txt_unit_price.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_price.Text = ""; }        
        }

        private void txt_unit_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_price.Text = Convert.ToString(Convert.ToDecimal(txt_unit_price.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_price.Text = ""; }
        }

        private void txt_weight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_weight.Text = Convert.ToString(Convert.ToDecimal(txt_weight.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_weight.Text = ""; }
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_net_total.Text = Convert.ToString(Convert.ToDecimal(txt_total_price.Text) - Convert.ToDecimal(txt_discount.Text));
            }
            catch { txt_net_total.Text = ""; }

        }

        private void txt_total_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_net_total.Text = Convert.ToString(Convert.ToDecimal(txt_total_price.Text) - Convert.ToDecimal(txt_discount.Text));
            }
            catch { txt_net_total.Text = ""; }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void itemid_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    int rowIndex = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(rowIndex);
                }
            }
            catch { }
        }

        private void txt_wasting_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton4.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text); }
            }
            catch { }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton4.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text); }
            }
            catch { }
        }

        private void txt_total_weight_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_making_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
