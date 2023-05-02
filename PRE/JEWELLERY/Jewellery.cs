using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.JEWELLERY
{
    public partial class Jewellery : Form
    {
        private int jewelleryid;
        private int jewellerytagno;
        private double jewelleryweight;

        BUS.jewellery jewellery;
        DataTable dt;
        DAT.function_ fun = new DAT.function_();
   

        public Jewellery()
        {
            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Jewellery_KeyDown);
        }
   
        /*-----------------------------------------Clear and progress bar------------------------------------*/
        public void Progress_And_Clear()
        {
            try
            {
                pb_loading.Value = 0; pb_loading.Value = 100;
                tagnotxt.Text = "";
                jewelleryididlbl.Text = "";
                weighttxt.Text = "";
                btn_save.Text = "Save";
                jewellery.BindCategory2Details(dataGridView1);
            }
            catch { }
        }


        /*-----------------------------------------SAVE-AND-EDIT-Process------------------------------------*/
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                {

                    if (Validation())
                    {
                        this.jewellery = new Jewellery_System.BUS.jewellery(jewelleryid, jewellerytagno, jewelleryweight);

                        if (btn_save.Text == "Save")
                        { this.jewellery.Savejewellery();}

                        else if (btn_save.Text == "Edit")
                        {
                            this.jewellery.Editjewellery();
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                        Progress_And_Clear(); 
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        /*-----------------------------------------Delete Process------------------------------------*/
        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation())
                    {
                        this.jewelleryid = Convert.ToInt32(this.jewelleryididlbl.Text);
                        this.jewellery = new Jewellery_System.BUS.jewellery(jewelleryid);
                        if (this.jewellery.Deletejewellery())
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
                if (string.IsNullOrEmpty(this.jewelleryididlbl.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.jewelleryididlbl.Focus(); return false; }
            }

            if (string.IsNullOrEmpty(this.tagnotxt.Text.Trim()))
            { fun.validationMessge("Please Enter TagNo"); this.tagnotxt.Focus(); return false; }
            if (string.IsNullOrEmpty(this.weighttxt.Text.Trim()))
            { fun.validationMessge("Please Enter Weight"); this.weighttxt.Focus(); return false; }
            else
            {
                if (string.IsNullOrEmpty(jewelleryididlbl.Text.Trim())) { this.jewelleryid = 0; }
                else { this.jewelleryid = Convert.ToInt32(jewelleryididlbl.Text); }
                this.jewellerytagno = Convert.ToInt32(this.tagnotxt.Text);
                this.jewelleryweight = Convert.ToDouble(this.weighttxt.Text);
            }
            return true;
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jewelleryididlbl_Click(object sender, EventArgs e)
        {

        }

        private void Jewellery_Load(object sender, EventArgs e)
        {
            try
            {
                jewellery = new BUS.jewellery();
                jewellery.BindCategory2Details(dataGridView1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.jewelleryididlbl.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.tagnotxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.weighttxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2 ].Value.ToString();
                btn_save.Text = "Edit"; tagnotxt.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void tagnotxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text == "") { jewellery.BindCategory2Details(dataGridView1); }
            else
            {
                jewellery.tagsearch(Convert.ToInt32(this.txt_search.Text));
                jewellery.BindJewelDetaisSearch(dataGridView1);
            }
        }

        private void Jewellery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Handled)
            {
                if (e.KeyCode == Keys.F5)
                { Progress_And_Clear(); }

                if (e.KeyCode == Keys.Delete)
                { btn_delete.PerformClick(); }

                if (e.KeyCode == Keys.Enter)
                { SendKeys.Send("{tab}"); e.Handled = e.SuppressKeyPress = true; }

                if (e.KeyCode == Keys.Escape)
                { this.Close(); }
            }
            e.Handled = true;
        }


 


        
    }
}

