using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.Boxes
{
    public partial class Box : Form
    {
        private int Boxid;
        private decimal Boxweight;
        private long _shiftid;
        BUS.box box;
        DataTable dt;
        DAT.function_ fun = new DAT.function_();
        public Box(long sid)
        {
            InitializeComponent();
            _shiftid = sid;
           // this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Box_KeyDown);
        }
        public Box()
        {
            InitializeComponent();
           
        }
        public void Progress_And_Clear()
        {
            try
            {
                pb_loading.Value = 0; pb_loading.Value = 100;
                boxidlbl.Text = "";
                weighttxt.Text = "";
                btn_save.Text = "Save";
                box.BindBoxDetails(dataGridView1);
            }
            catch { }
        }

        public void GetMaxId()
        {
            box = new BUS.box();
            box.GetMaxBoxId(textBox1);
        }

        /*-----------------------------------------Get full chart------------------------------------*/
        private void Box_Load(object sender, EventArgs e)
        {
            try
            {
                box = new BUS.box();
                box.GetMaxBoxId(textBox1);
                if (Convert.ToInt32(textBox1.Text) > 1)
                {
                    box.BindBoxDetails(dataGridView1);
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        dataGridView1.SelectedRows[0].Selected = false;
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        public void Cle()
        {
            textBox1.ReadOnly = false;
            weighttxt.Text = "";
            btn_exit.Text = "Exit"; btn_save.Text = "Save";
            box = new BUS.box();
            box.GetMaxBoxId(textBox1);
            weighttxt.Focus();
        
        }
        /*-----------------------------------------SAVE-AND-EDIT-Process------------------------------------*/
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                {

                    if (Validation())
                    {
                        this.box = new BUS.box(Boxid, Boxweight,_shiftid);

                        if (btn_save.Text == "Save")
                        { this.box.SaveBox(dataGridView1);


                        Cle();
                        }

                        else if (btn_save.Text == "Edit")
                        {
                            if (this.box.EditBox(dataGridView1))
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

        /*-----------------------------------------Delete Process------------------------------------*/
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                {
                    if (Validation())
                    {
                        this.Boxid =Convert.ToInt32( this.boxidlbl.Text.Trim());
                        this.box = new Jewellery_System.BUS.box(Boxid);
                        if (this.box.DeleteBox())
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
                if (string.IsNullOrEmpty(this.textBox1.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.textBox1.Focus(); return false; }
            }

            if (string.IsNullOrEmpty(this.weighttxt.Text.Trim()))
            { fun.validationMessge("Please Enter Description !"); this.weighttxt.Focus(); return false; }

            else
            {
                if (string.IsNullOrEmpty(textBox1.Text.Trim())) { this.Boxid = 0; }
                else { this.Boxid =Convert.ToInt32( this.textBox1.Text.Trim()); }

                this.Boxweight = Convert.ToDecimal(weighttxt.Text);
            }
            return true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (btn_exit.Text.Trim() == "Cancel")
            { 
            
            }
            else
            {
                this.Close();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {

                if (msg.WParam.ToInt32() == (int)Keys.Enter)
                {
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        DialogResult result = MessageBox.Show("Are You Sure You Want To Modify ?\n\nBox Id : " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "\n\nWeight : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "", BUS1.Config.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            this.textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            this.weighttxt.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            btn_save.Text = "Edit";
                            btn_exit.Text = "Cancel";
                            textBox1.ReadOnly = true;
                            weighttxt.Focus();

                            if (dataGridView1.SelectedRows.Count >= 1)
                            { dataGridView1.SelectedRows[0].Selected = false; }
                           
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

        /*-----------------------------------------Grid double click------------------------------------*/
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.weighttxt.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                btn_save.Text = "Edit";
                btn_exit .Text = "Cancel";
                textBox1.ReadOnly = true;
                weighttxt.Focus();

                if (dataGridView1.SelectedRows.Count >= 1)
                {
                    dataGridView1.SelectedRows[0].Selected = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            //box = new BUS.box(this.txt_search.Text.Trim());
            //box.BindItemyDetaisSearch(dataGridView1);
            //if (txt_search.Text==""){ box.BindBoxDetails(dataGridView1); }
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu.Menu menuform = new Menu.Menu();
            menuform.Show();
        }

        private void Box_KeyDown(object sender, KeyEventArgs e)
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

        private void Box_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.InputNumberOnley( textBox1,e);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                weighttxt.Focus();
            }
        }

        private void weighttxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_save.Focus();
            }
        }

        private void weighttxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            fun.checkString(e, weighttxt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                box = new BUS.box();
               
                    box.BindBoxDetails(dataGridView1);
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        dataGridView1.SelectedRows[0].Selected = false;
                    }
                

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
