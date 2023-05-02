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
    public partial class List : Form
    {
        BUS.purchase customer = new BUS.purchase();
        BUS.purchase purchase;
        DAT.function_ fun = new DAT.function_();


        private int primarykey;
        private long Billno;
        private string f_customer_id;
        private string f_customer_name;
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
        private string f_item_code;
        private DateTime f_purchase_date;
        private string makingtext;
        private string wastringtext;
        private int itemQupdate;
        private double wasteinggold;
        private double wasteingPuregold;
        private double all_nettotal;
        private double total_making_expenses;
        private double bill_net_totel;
        private double bill_discount;
        private string purchase_type;
        private int cuid;
        private string sunono;
        private string putype;
        private long _shiftid;

        public List()
        {
            InitializeComponent();
        }
        public List(long sid)
        {
            InitializeComponent();
            _shiftid = sid;
           
        }

                public bool Validation()
        {
            if (string.IsNullOrEmpty(this.txt_customer_id.Text.Trim()))
            { fun.validationMessge("Please Enter customer_id"); btn_search.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txtbillno.Text.Trim()))

            { fun.validationMessge("Please Enter Bill No"); bt_bill_no.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_item_name.Text.Trim()))

            { fun.validationMessge("Please Enter item_name"); btn_search2.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_carat.Text.Trim()))

            { fun.validationMessge("Please Enter carrot"); btn_search2.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_weight.Text.Trim()))
            { fun.validationMessge("Please Enter weight"); btn_search2.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_quantity.Text.Trim()))
            { fun.validationMessge("Please Enter quantity"); this.txt_quantity.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_total_weight.Text.Trim()))
            { fun.validationMessge("Please Enter Total Weight !");  return false; }
            if (string.IsNullOrEmpty(this.txt_unit_price.Text.Trim()))
            { fun.validationMessge("Please Enter unit_price"); this.txt_unit_price.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_total_price.Text.Trim()))
            { fun.validationMessge("Please Enter Total Weight !");  return false; }
            if (string.IsNullOrEmpty(this.txt_discount.Text.Trim()))
            { fun.validationMessge("Please Enter discount"); this.txt_discount.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_net_total.Text.Trim()))
            { fun.validationMessge("Please Enter Net Total !"); this.txt_net_total.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_making.Text.Trim()))
            { fun.validationMessge("Please Enter Making"); this.txt_making.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txt_wasting.Text.Trim()))
            { fun.validationMessge("Please Enter Wasting"); this.txt_wasting.Focus(); return false; }
            if (string.IsNullOrEmpty(this.bill_dicount_txt.Text.Trim()))
            { fun.validationMessge("Please Enter bill dicount"); this.txt_wasting.Focus(); return false; }
               

            else
            {

                if (lacategory.Text.Trim() == "Gold")
                {

                    if (ramaperitem.Checked == false && ramatotal.Checked == false) { fun.validationMessge("Please Select Making Option"); ramaperitem.Focus(); return false; }


                    if (rawaperitem.Checked == false && rawatotal.Checked == false) { fun.validationMessge("Please Select Wasting Option"); rawaperitem.Focus(); return false; }
                    GetTotalWastageGold();
                }
                else
                {
                    wasteinggold = 0;

                    wasteingPuregold = 0;

                }
                //

                if (ramaperitem.Checked == true)
                {
                    makingtext = ramaperitem.Text.Trim();

                }
                else
                {
                    makingtext =ramatotal.Text.Trim();
                }

                if (rawaperitem.Checked == true)
                {
                    wastringtext = rawaperitem.Text.Trim();


                 
                }
                else
                {
                    wastringtext =rawatotal.Text.Trim();
                }


                GetMakingExpensess();
                this.primarykey = Convert.ToInt32(this.txt_primary_key.Text);
                this.Billno = Convert.ToInt64(this.txtbillno.Text);
                this.f_customer_id = this.txt_customer_id.Text.Trim();
                this.f_customer_name = this.txt_customer_name.Text.Trim();
                this.f_item_name = this.txt_item_name.Text.Trim();
                this.f_purchase_carat = Convert.ToInt32(this.txt_carat.Text);
                this.f_purchase_weight = Convert.ToDecimal(txt_weight.Text);
                this.f_purchase_quantity = Convert.ToDouble(txt_quantity.Text);
                this.f_purchase_total_weight = Convert.ToDecimal(txt_total_weight.Text);
                this.f_purchase_unit_price = Convert.ToDouble(txt_unit_price.Text);
                this.f_purchase_total_price = Convert.ToDouble(txt_total_price.Text);
                this.f_purchase_discount = Convert.ToDouble(txt_discount.Text);
                this.f_purchase_net_total_price = Convert.ToDouble(txt_net_total.Text);
                this.f_purchase_making = Convert.ToDecimal(txt_making.Text);
                this.f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text);
                this.f_purchase_date = Convert.ToDateTime(DateTime.Now.ToString());
                this.f_item_code = txt_itmcode.Text.Trim();
                this.all_nettotal = Convert.ToDouble(txt_all_linetotal.Text);
                this.bill_discount = Convert.ToDouble(bill_dicount_txt.Text);
                this.bill_net_totel = Convert.ToDouble(bill_net_txt.Text);
                this.purchase_type = this.cmbpurchasetype.Text.Trim();
            }
            return true;
        }

        public void Clear_Box()
        {
            try
            {
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
                purchase.BindpurcaseDetails(dataGridView1);
            }
            catch { }
        }
      

     
        private void btn_save_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (Validation())
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.purchase = new BUS.purchase(primarykey,Billno, f_item_code, f_customer_id, f_customer_name, f_item_name, f_purchase_carat, f_purchase_weight, f_purchase_quantity, f_purchase_total_weight, f_purchase_unit_price, f_purchase_total_price, f_purchase_discount, f_purchase_net_total_price, f_purchase_making, f_purchase_wasting, f_purchase_date, wasteinggold, wasteingPuregold, wastringtext, makingtext, all_nettotal, total_making_expenses, bill_net_totel, bill_discount, purchase_type);


                        if (btn_save.Text == "ADD")
                        {

                            if (this.purchase.Savepurchase())
                            {

                                try
                                {
                                    Bill_totel.Text = Convert.ToString(Convert.ToDecimal(Bill_totel.Text) + Convert.ToDecimal(txt_net_total.Text));
                                }
                                catch { Bill_totel.Text = Bill_totel.Text; }
                           
                                Clear_Box();

                            }
                            else
                            {

                            }
                        }

                        else if (btn_save.Text == "Edit")
                        {
                            this.purchase.Editpurchase();                        
                            Clear_Box();
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void List_Load(object sender, EventArgs e)
        {
            try
            {
                purchase = new BUS.purchase();
                purchase.BindpurcaseDetails(dataGridView1);
            }
            catch
            {

            }
        }

        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (true)
                    {
                        this.Billno = Convert.ToInt64(this.txtbillno.Text);
                        this.purchase = new BUS.purchase(Billno);
                        if (this.purchase.Deletepurchase())
                        {
                            Clear_Box();
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

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_menu_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try {

                PRE.CUSTOMER.frmSearchCustomer frm = new PRE.CUSTOMER.frmSearchCustomer();
                frm.ShowDialog();

                if (frm.laselect.Text == "1")
                {
                 txt_customer_id.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                 txt_customer_name.Text= frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();


                 txtsuinno.Focus();
                }
                frm = null;
            
            }
            catch { }
            
        }

        private void btn_search2_Click(object sender, EventArgs e)
        {
            try
            {

                PRE.ITEMFORM.frmSeachItems frm = new PRE.ITEMFORM.frmSeachItems();
                frm.ShowDialog();

                if (frm.laselect.Text == "1")
                {
                 txt_itmcode .Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                  txt_item_name.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();

                   txt_carat .Text = frm.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                  txt_weight.Text = frm.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                  lacategory.Text = frm.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                  itemQupdate = Convert.ToInt32(frm.dataGridView1.CurrentRow.Cells[6].Value);
                  txt_quantity.Focus();

                }
                frm = null;

            }
            catch { }
        }

        private void txt_weight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_weight.Text = Convert.ToString(Convert.ToDecimal(txt_weight.Text) * Convert.ToDecimal(txt_quantity.Text));
            }
            catch { txt_total_weight.Text = ""; }
        }

        public void GetTotalWeight()
        {

            try {
                double qty = 0, weight = 0;

                if (string.IsNullOrEmpty(txt_quantity.Text.Trim())) { qty = 0; } else { qty = Convert.ToDouble(txt_quantity.Text); }
                if (string.IsNullOrEmpty(txt_weight.Text.Trim())) { weight = 0; } else { weight = Convert.ToDouble(txt_weight.Text); }
                txt_total_weight.Text = (qty * weight).ToString();

            }
            catch { }
        }

        public void GetRateAmunt()
        {

            try
            {
                double qty = 0, unitprice = 0;

                if (string.IsNullOrEmpty(txt_quantity.Text.Trim())) { qty = 0; } else { qty = Convert.ToDouble(txt_quantity.Text); }
                if (string.IsNullOrEmpty(txt_unit_price.Text.Trim())) { unitprice = 0; } else { unitprice = Convert.ToDouble(txt_unit_price.Text); }
                txt_total_price .Text = (qty * unitprice).ToString();

            }
            catch { }
        }

        private void txt_quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GetTotalWeight();
            }
            catch { }
        }

        private void txt_unit_price_TextChanged(object sender, EventArgs e)
        {
            try { GetRateAmunt(); }
            catch { }
        }

        private void txt_total_price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_net_total.Text = Convert.ToString(Convert.ToDecimal(txt_total_price.Text) - Convert.ToDecimal(txt_discount.Text));
            }
            catch { txt_net_total.Text = ""; }
        }

        public void GetFinalNettotal()
        {

            try
            {
                double nettotal = 0, discount = 0;

                if (string.IsNullOrEmpty(txt_net_total.Text.Trim())) { nettotal = 0; } else { nettotal = Convert.ToDouble(txt_net_total.Text); }
                if (string.IsNullOrEmpty(txt_discount.Text.Trim())) { discount = 0; } else { discount = Convert.ToDouble(txt_discount.Text); }
                txt_all_linetotal.Text = (nettotal - discount).ToString();

            }
            catch { }
        }
        private void txt_discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_net_total.Text = Convert.ToString(Convert.ToDecimal(txt_all_linetotal.Text) - Convert.ToDecimal(txt_discount.Text));
            }
            catch { txt_net_total.Text = ""; }

        }

        

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.txt_primary_key.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txtbillno.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txt_customer_id.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txt_customer_name.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txt_itmcode.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txt_item_name.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.txt_carat.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                this.txt_weight.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                this.txt_quantity.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                this.txt_total_weight.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                this.txt_unit_price.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                this.txt_total_price.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                this.txt_discount.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                this.txt_net_total.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                this.txt_making.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                this.txt_wasting.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();
                
                btn_save.Text = "Edit";

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            purchase = new BUS.purchase(this.txt_search.Text.Trim());
            purchase.BindPurchaseDetailsName(dataGridView1);
            if (txt_search.Text == "") { purchase.BindpurcaseDetails(dataGridView1); }
        }

        private void List_KeyDown(object sender, KeyEventArgs e)
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

        private void txt_wasting_TextChanged(object sender, EventArgs e)
        {
              try
            {
                if (rawaperitem.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text);}

                totel_wasting_txt.Text = Convert.ToString(f_purchase_wasting * Convert.ToDecimal(txt_quantity.Text));
            }
              catch {}
        }

        private void radioButton4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rawaperitem.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text); }
            }
            catch { }
        }

        public bool ValidationByBillNo()
        {
           

            if (string.IsNullOrEmpty(txt_customer_id.Text.Trim()))
            {
                fun.validationMessge("Please Select Supplier"); btn_search.Focus(); return false;
            }
         
            if (cmbpurchasetype.Text.Trim().Equals("Gold Purchas"))
            {
              
            }
            else if (cmbpurchasetype.Text.Trim().Equals("Cash Or Credit Purchase"))
            {

            }
            else
            {
                fun.validationMessge("Please Select Purchase Type"); cmbpurchasetype.Focus(); return false;
       
            }

            this.cuid = Convert.ToInt32(txt_customer_id.Text);
            this.putype = this.cmbpurchasetype.Text.Trim();
            this.sunono = this.txtsuinno.Text.Trim();
            return true;
        }

        private void bt_bill_no_Click(object sender, EventArgs e)
        {
            try {

                if (ValidationByBillNo())
                {
                    this.purchase = new BUS.purchase(this.putype,this.cuid,this.sunono,this._shiftid);

                    if (this.purchase.GetpurchaseNo(txtbillno))
                    {
                        cmbpurchasetype.Enabled = false;
                        btn_search.Enabled = false;
                        bt_bill_no.Enabled = false;
                    }

                }

            
            }
            catch { }
        }

        private void List_Shown(object sender, EventArgs e)
        {
            cmbpurchasetype.Focus();
            cmbpurchasetype.DroppedDown = true;
        }

        private void cmbpurchasetype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_search.Focus();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void txtsuinno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bt_bill_no.Focus();
            }
        }

        private void txt_quantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_unit_price.Focus();
            }
        }

        private void txt_unit_price_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_making.Focus();
            }
        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }

        private void txt_making_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_wasting.Focus();
            }
        }

        private void txt_wasting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_discount.Focus();
            }
        }

        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString( e,txt_quantity);
        }

        private void txt_unit_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_unit_price);
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_discount);
        }

        private void txt_making_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_making);
        }

        private void txt_wasting_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, txt_wasting);
        }

        public void GetMakingExpensess()
        {
            try
            {
                double totalerate = 0, makingamount = 0, qty = 0; total_making_expenses = 0;
                if (string.IsNullOrEmpty(txt_quantity.Text.Trim())) { qty = 0; } else { qty = Convert.ToDouble(txt_quantity.Text); }
                if (string.IsNullOrEmpty(txt_total_price.Text.Trim())) { totalerate = 0; } else { totalerate = Convert.ToDouble(txt_total_price.Text); }
                if (string.IsNullOrEmpty(txt_making.Text.Trim())) { makingamount = 0; } else { makingamount = Convert.ToDouble(txt_making.Text); }

                if (ramaperitem.Checked == true)
                {

                     total_making_expenses = (makingamount * qty);
                }
                else
                {

                     total_making_expenses = makingamount;
                }

                //    total_making_expenses = Convert.ToDouble(txt_net_total.Text);
            }
            catch { }
        }

        public void GetMakingAmount()
        {
            try
            {
                double totalerate = 0, makingamount = 0, qty = 0; total_making_expenses = 0;
                if (string.IsNullOrEmpty(txt_quantity.Text.Trim())) { qty = 0; } else { qty = Convert.ToDouble(txt_quantity.Text); }
                if (string.IsNullOrEmpty(txt_total_price.Text.Trim())) { totalerate = 0; } else { totalerate = Convert.ToDouble(txt_total_price.Text); }
                 if (string.IsNullOrEmpty(txt_making.Text.Trim())) { makingamount = 0; } else { makingamount = Convert.ToDouble(txt_making.Text); }

                 if (ramaperitem.Checked == true)
                 {

                     txt_all_linetotal.Text = ((makingamount * qty)+totalerate).ToString();
                     total_making_expenses = (makingamount * qty);
                 }
                 else
                 {

                     txt_all_linetotal.Text = (makingamount + totalerate).ToString();
                     total_making_expenses = makingamount ;
                 }

             //    total_making_expenses = Convert.ToDouble(txt_net_total.Text);
            }
            catch { }
        }

        public void GetTotalWastageGold()
        {

            try
            {
                double totalgold = 0,  qty = 0, westage = 0,totalwestage=0; int karat = 0;

                wasteinggold = 0;
                wasteingPuregold = 0;
       
                karat = Convert.ToInt32(txt_carat.Text);
                qty = Convert.ToDouble(txt_quantity.Text);
                totalgold = Convert.ToDouble(txt_total_weight.Text);
                westage = Convert.ToDouble(txt_wasting.Text);
                if (rawaperitem.Checked == true)
                {
                    wasteinggold = (totalgold / 8) * westage;

                    wasteingPuregold = ((1000 / 24) * karat) * totalwestage;

                }
                else
                {
                    wasteinggold = westage;

                    wasteingPuregold = ((1000 / 24) * karat) * totalwestage;
                }
               

            }
            catch { }
        }
        private void txt_making_TextChanged(object sender, EventArgs e)
        {
            try {

               // Convert.ToDouble(txt);
                GetMakingAmount();
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To save final summery ?", "Confirm"))
                {
                    if (true)
                    {
                        this.Billno = Convert.ToInt64(this.txtbillno.Text);
                        this.bill_discount = Convert.ToDouble(this.bill_dicount_txt.Text);
                        this.bill_net_totel = Convert.ToDouble(this.bill_net_txt.Text);
                        this.purchase = new BUS.purchase(Billno, bill_net_totel,bill_discount);
                        if (this.purchase.summerysave())
                        {
                            Clear_Box();
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

        private void ramaperitem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double totalerate = 0, makingamount = 0, qty = 0; total_making_expenses = 0;
                if (string.IsNullOrEmpty(txt_quantity.Text.Trim())) { qty = 0; } else { qty = Convert.ToDouble(txt_quantity.Text); }
                if (string.IsNullOrEmpty(txt_total_price.Text.Trim())) { totalerate = 0; } else { totalerate = Convert.ToDouble(txt_total_price.Text); }
                if (string.IsNullOrEmpty(txt_making.Text.Trim())) { makingamount = 0; } else { makingamount = Convert.ToDouble(txt_making.Text); }

                if (ramaperitem.Checked == true)
                {

                    txt_all_linetotal.Text = ((makingamount * qty) + totalerate).ToString();
                    total_making_expenses = (makingamount * qty);
                }
                else
                {

                    txt_all_linetotal.Text = (makingamount + totalerate).ToString();
                    total_making_expenses = makingamount;
                }

                //    total_making_expenses = Convert.ToDouble(txt_net_total.Text);
            }
            catch { }
        }

        private void ramatotal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                double totalerate = 0, makingamount = 0, qty = 0; total_making_expenses = 0;
                if (string.IsNullOrEmpty(txt_quantity.Text.Trim())) { qty = 0; } else { qty = Convert.ToDouble(txt_quantity.Text); }
                if (string.IsNullOrEmpty(txt_total_price.Text.Trim())) { totalerate = 0; } else { totalerate = Convert.ToDouble(txt_total_price.Text); }
                if (string.IsNullOrEmpty(txt_making.Text.Trim())) { makingamount = 0; } else { makingamount = Convert.ToDouble(txt_making.Text); }

                if (ramaperitem.Checked == true)
                {

                    txt_all_linetotal.Text = ((makingamount * qty) + totalerate).ToString();
                    total_making_expenses = (makingamount * qty);
                }
                else
                {

                    txt_all_linetotal.Text = (makingamount + totalerate).ToString();
                    total_making_expenses = makingamount;
                }

                //    total_making_expenses = Convert.ToDouble(txt_net_total.Text);
            }
            catch { }
        }

        private void rawaperitem_CheckedChanged(object sender, EventArgs e)
        {
               try
            {
                if (rawaperitem.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text);}

                totel_wasting_txt.Text = Convert.ToString(f_purchase_wasting * Convert.ToDecimal(txt_quantity.Text));
            }
              catch  { }
        
        }

        private void totel_waste_txt(object sender, EventArgs e)
        {

        }

        private void txt_net_total_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_all_linetotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rawatotal_CheckedChanged(object sender, EventArgs e)
        {
               try
            {
                if (rawaperitem.Checked)
                {
                    f_purchase_wasting = Convert.ToDecimal((Convert.ToDecimal(txt_weight.Text) / 8) * Convert.ToDecimal(txt_wasting.Text));
                }
                else { f_purchase_wasting = Convert.ToDecimal(txt_wasting.Text);}

                totel_wasting_txt.Text = Convert.ToString(f_purchase_wasting * Convert.ToDecimal(txt_quantity.Text));
            }
              catch {}

        }

        private void bill_dicount_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bill_net_txt.Text = Convert.ToString(Convert.ToDecimal(Bill_totel.Text) - Convert.ToDecimal(bill_dicount_txt.Text));
            }
            catch { bill_net_txt.Text = "0"; }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void bill_net_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
