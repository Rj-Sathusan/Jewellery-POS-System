using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.BOXITEMS
{
    public partial class BoxItems : Form
    {
        private int Primarykey;
        private int BoxItemsboxid;
        private int BoxItemsitem;
        private long _shiftid;
        DataTable dt;
        BUS.boxitems boxitems;
        DAT.function_ fun = new DAT.function_();

        public BoxItems(long sid)
        {
            InitializeComponent();
            _shiftid = sid;
        }
        public BoxItems()
        {
            InitializeComponent();
        }
    /*-----------------------------------------Clear and progress bar------------------------------------*/
        public void Progress_And_Clear()
        {
            try
            {
                pb_loading.Value = 0; pb_loading.Value = 100;
                itemtxt.Text = "";
                btn_save.Text = "Save";
                boxitems.BindBoxDetails(dataGridView1);
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Convert.ToString(boxidtxt.SelectedValue.ToString());
                //this.boxitems = new BUS.boxitems(BoxItemsboxid);
                //fun.BindGrid(dataGridView1, dt);

                //boxitems = new BUS.boxitems(this.boxidtxt.Text.Trim());
                //boxitems.BindCategoryDetaislFull(dataGridView1);
                /////  form_category_id = txt_category_id.SelectedValue;
                //MessageBox.Show(boxidtxt.SelectedValue.ToString());

            }
            catch
            { }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {


                if (Validation())
                {
                    if (fun.ShowMessage("Are You Sure You Want To " + btn_save.Text + "  ?", "Confirm"))
                    {

                        this.boxitems = new BUS.boxitems(Primarykey, BoxItemsboxid, BoxItemsitem,_shiftid);

                        if (btn_save.Text == "Save")
                        {

                            if (this.boxitems.SaveBoxItems(dataGridView1))
                            {
                               // Progress_And_Clear();
                                txtitemname.Text = "";
                                laitemcode.Text = "0";
                                button2.Focus();
                            }
                            else
                            {

                            }


                        }

                        else if (btn_save.Text == "Edit")
                        {
                            if (this.boxitems.EditBoxItems(dataGridView1))
                            {
                                txtitemname.Text = "";
                                laitemcode.Text = "0";
                                button2.Focus();
                            
                            }
                            
                        }
                        else { fun.validationMessge("Something Wrong!"); }
                        Progress_And_Clear();

                    }

                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                int roinde = Convert.ToInt32(dataGridView1.SelectedRows[0].Index);
                int prid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                if (btn_delete.Text == "Cancel")
                {
                    TextBox[] txt = { txt_boxid, txtitemname }; laitemcode.Text = "0";
                    fun.TextClear(txt); btn_delete.Text = "Delete"; btn_save.Text = "Save";
                    button1.Focus();
                }
                else
                {
                    if (fun.ShowMessage("Are You Sure You Want To Delete ?", "Confirm"))
                    {

                        this.boxitems = new BUS.boxitems(prid);
                        if (this.boxitems.DeleteBoxItems())
                        {
                           // Progress_And_Clear();
                            dataGridView1.Rows.RemoveAt(roinde);
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
            this.Close();
        }

        /*-----------------------------------------Validation Process------------------------------------*/
        public bool Validation()
        {
            if (btn_save.Text == "Save")
            { }
            else
            {
                if (string.IsNullOrEmpty(this.primarykeytxt.Text.Trim()))
                { fun.validationMessge("Please Enter Id !"); this.primarykeytxt.Focus(); return false; }
            }

            if (string.IsNullOrEmpty(this.txt_boxid.Text.Trim()))
            { fun.validationMessge("Please Select Box id"); button1.Focus(); return false; }
            if (string.IsNullOrEmpty(this.txtitemname.Text.Trim()))
            { fun.validationMessge("Please Enter Item name"); this.button2.Focus(); return false; }

            else
            {
                if (string.IsNullOrEmpty(primarykeytxt.Text.Trim())) { this.Primarykey = 0; }
                else { this.Primarykey = Convert.ToInt32(primarykeytxt.Text); }

                BoxItemsboxid = Convert.ToInt32(txt_boxid.Text);
                BoxItemsitem = Convert.ToInt32(laitemcode.Text);
                
            }
            return true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {

                if (msg.WParam.ToInt32() == (int)Keys.Enter)
                {
                    if (dataGridView1.SelectedRows.Count >= 1)
                    {
                        DialogResult result = MessageBox.Show("Are You Sure You Want To Modify ?\n\nBox Id : " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "\n\nItem Name : " + dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + "", BUS1.Config.ApplicationName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {

                            this.laitemcode.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                            this.primarykeytxt.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                            this.txt_boxid.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                            this.txtitemname.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                            btn_save.Text = "Edit"; btn_delete.Text = "Cancel";
                           

                            if (dataGridView1.SelectedRows.Count >= 1)
                            { dataGridView1.SelectedRows[0].Selected = false; }
                            button1.Focus();
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
        private void BoxItems_Load(object sender, EventArgs e)
        {
            try
            {
                boxitems = new BUS.boxitems();
                boxitems.BindBoxDetails(dataGridView1);
               // BindItemandBox();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.laitemcode.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.primarykeytxt.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.txt_boxid.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txtitemname.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                btn_save.Text = "Edit"; btn_delete.Text = "Cancel";
                button1.Focus();
                if (dataGridView1.SelectedRows.Count >= 1)
                {
                    dataGridView1.SelectedRows[0].Selected = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        public void BindItemandBox()
        {
            try
            {
                BUS.itemform item = new BUS.itemform();
                BUS.box box = new BUS.box();
                this.itemtxt.DataSource = item.GetItem();
                this.itemtxt.ValueMember = "item_code";
                this.itemtxt.DisplayMember = "item_name";

                this.boxidtxt.DataSource = box.Getbox();
                this.boxidtxt.ValueMember = "id";
                this.boxidtxt.DisplayMember = "id";
                box = null;
                item = null;
            }
            catch
            {}
        }



        private void itemtxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            //    BoxItemsitem = Convert.ToInt32(boxidtxt.SelectedValue.ToString());
            //    boxitems = new BUS.boxitems(this.boxidtxt.Text.Trim());
            //    boxitems.BindCategoryDetaislFull(dataGridView1);
                ///  form_category_id = txt_category_id.SelectedValue;
                MessageBox.Show(boxidtxt.SelectedValue.ToString());
            }
            catch
            { }
            
        }

        private void BoxItems_KeyDown(object sender, KeyEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try {

                dataGridView1.Rows.Clear();
                PRE.Boxes.frmSearchBox frm = new PRE.Boxes.frmSearchBox();
                frm.ShowDialog();

                if (frm.laselect.Text == "1")
                {
                    txt_boxid.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    this.boxitems = new BUS.boxitems(Convert.ToInt32(txt_boxid.Text),"");
                    this.boxitems.BindCategoryDetaislFull(dataGridView1);
                 

                    button2.Focus();
                }
                frm = null;
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.Rows.Clear();
                PRE.ITEMFORM.frmSeachItems frm= new PRE.ITEMFORM.frmSeachItems();
                frm.ShowDialog();

                if (frm.laselect.Text == "1")
                {
                  laitemcode.Text = frm.dataGridView1.CurrentRow.Cells[0].Value.ToString();

                  txtitemname.Text = frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                  btn_save.Focus();
                }
                frm = null;
            }
            catch { }
        }


    }
}
