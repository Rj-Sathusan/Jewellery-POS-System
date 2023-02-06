using System;
using System.Data;
using System.Windows.Forms;

namespace Jewellery_System.PRE.PRICE
{
    public partial class Price : Form
    {
        private long priceid;
        private double priceamount;
        private DateTime pricedate;
        private double difamont;
        private long shiftid;
       
        BUS.price price;
        DataTable dt;
        DAT.function_ fun = new DAT.function_();

        public Price(long sid)
        {
            InitializeComponent();
            shiftid = sid;
           // this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Price_KeyDown);
        }

        public void Progress_And_Clear()
        {
            try
            {
                pb_loading.Value = 0; pb_loading.Value = 100;
                priceididlbl.Text = "";
                amounttxt.Text = ""; txtlastprice.Text = ""; dtp.ResetText();
                btn_save.Text = "Save";
                price.BindPriceDetails(dataGridView1);
            }
            catch { }
        }



        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                {

                    if (Validation())
                    {
                        this.price = new BUS.price(priceid, pricedate, priceamount, difamont, shiftid);

                        if (btn_save.Text == "Save")
                        {

                            if (this.price.Saveprice())
                            {
                                Progress_And_Clear();
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
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation())
                    {
                        this.priceid = Convert.ToInt64(priceididlbl.Text);
                        this.price = new Jewellery_System.BUS.price(priceid);
                        if (this.price.Deleteprice())
                        {
                            Progress_And_Clear();
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


        /*-----------------------------------------Validation Process------------------------------------*/
        public bool Validation()
        {
            if (btn_save.Text == "Save")
            { }
            else
            {
                if (string.IsNullOrEmpty(this.priceididlbl.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.priceididlbl.Focus(); return false; }
            }

            if (string.IsNullOrEmpty(this.amounttxt.Text.Trim()))
            { fun.validationMessge("Please Enter Amount !"); this.amounttxt.Focus(); return false; }

           else if (string.IsNullOrEmpty(this.txtlastprice.Text.Trim()))
            { fun.validationMessge("Please Enter Last Amount !"); this.amounttxt.Focus(); return false; }

            else
            {

                if (string.IsNullOrEmpty(priceididlbl.Text.Trim())) { this.priceid = 0; /*this.priceididlbl = 0;*/ }
                else { this.priceid = Convert.ToInt64(priceididlbl.Text); }

                this.priceamount = Convert.ToDouble(amounttxt.Text);
                this.pricedate = Convert.ToDateTime(dtp.Text);
                if (dataGridView1.Rows.Count >= 1)
                {
                    this.difamont = Convert.ToDouble(amounttxt.Text) - Convert.ToDouble(txtlastprice.Text);
                }
                else
                {
                    this.difamont = 0;
                }
 
            }
            return true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.priceididlbl.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.amounttxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.dtp.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btn_save.Text = "Edit"; amounttxt.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Price_Load(object sender, EventArgs e)
        {
            try
            {
                price = new BUS.price();
                price.BindPriceDetails(dataGridView1);

                if (dataGridView1.Rows.Count >= 1)
                {

                    txtlastprice.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                }
                else
                {

                    txtlastprice.Text = "0";
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text == "") { price.BindPriceDetails(dataGridView1); }
            else
            {
                price = new BUS.price(Convert.ToInt64(txt_search.Text));
                price.BindPricebyID(dataGridView1);
            }
        }

        private void Price_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Handled)
            //{
            //    if (e.KeyCode == Keys.F5)
            //    { Progress_And_Clear(); }

            //    if (e.KeyCode == Keys.Delete)
            //    { btn_delete.PerformClick(); }

            //    if (e.KeyCode == Keys.Enter)
            //    { SendKeys.Send("{tab}"); e.Handled = e.SuppressKeyPress = true; }

            //    if (e.KeyCode == Keys.Escape)
            //    { this.Close(); }
            //}
            //e.Handled = true;
        }

        private void Price_Shown(object sender, EventArgs e)
        {
            dtp.Focus();
        }

        private void dtp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                amounttxt.Focus();
            }
        }

        private void amounttxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }
    }
}
