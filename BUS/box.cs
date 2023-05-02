using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{
    class box : DAT.NewDataAccessLayer
    {
        private int Box_id;
        private decimal Box_weight;
        private long shiftid;

        public int ID
        {
            get { return this.Box_id; }
            set { this.Box_id = value; }
        }
        public decimal WEIGHT
        {
            get { return this.Box_weight; }
            set { this.Box_weight = value; }
        }

        public bool SaveBox(DataGridView dgv)
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[4];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = Box_id;
                param[1] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[1].Value = Box_weight;
                param[2] = new MySqlParameter("@sid", MySqlDbType.Int64);
                param[2].Value = shiftid;
                param[3] = new MySqlParameter("@adate", MySqlDbType.Date);
                param[3].Value = DateTime.Now;
                comtable = null;
                if (OpenConnection())
                {
                    comtable = SelectData("BoxSave", param);

                    if (comtable.Rows.Count>=1)
                    {

                       CloseConnection();
                       ShowMessage("Data Saved Successfully", "Warning");

                       BindGrid(dgv, comtable);
                       if (dgv.SelectedRows.Count >= 1)
                       {
                           dgv.SelectedRows[0].Selected = false;
                       }
                       param = null; comtable = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public bool EditBox(DataGridView dgv)
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = Box_id;
                param[1] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[1].Value = Box_weight;
                comtable = null;
                if (OpenConnection())
                {
                    comtable = SelectData("BoxEdit", param);
                    if (comtable.Rows.Count>=1)
                    {
                        CloseConnection();
                        ShowMessage("Data Edited Successfully", "Warning");
                        BindGrid(dgv, comtable);
                        if (dgv.SelectedRows.Count >= 1)
                        {
                            dgv.SelectedRows[0].Selected = false;
                        }
                        param = null; comtable = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public bool DeleteBox()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@id0", MySqlDbType.VarChar, 60);
                param[0].Value = Box_id;
                if (OpenConnection())
                {
                    if (ExecuteCommand("BoxDelete", param))
                    {

                        ShowMessage("Data Deleted Successfully", "Warning");
                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry", "Error");
                        param = null;
                        return false;
                    }

                }
                else
                {
                    ShowMessage("Server Not Connected", "Error");

                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }


        public box(int Boxid, decimal Boxweight,long _shiftid)
        {
            this.Box_id = Boxid;
            this.Box_weight = Boxweight;
            this.shiftid = _shiftid;
        }

        public box(int Boxid)
        {
            this.Box_id = Boxid;
        }



        public box()
        { }

        // ============================================ Get all details in Shop ==============================//////

        public DataTable Getbox()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("BoxSelect", null);
                sqlconnection.Close();
            }

            return comtable;
        }
        public void BindBoxDetails(DataGridView dgv)
        {

            BindGrid(dgv, Getbox());
        }

        public void GetMaxBoxId(TextBox txt)
        {
            DataTable dt = new DataTable();

            if (OpenConnection())
            {
                dt = SelectData("BoxMaxId",null);
                CloseConnection();
            }

            txt.Text =(Convert.ToInt32( dt.Rows[0].ItemArray[0].ToString()) + 1).ToString();
            dt = null;
        }

        public DataTable GetBoxbyID()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@id0", MySqlDbType.VarChar, 60);
            param[0].Value = Box_id;

            if (OpenConnection())
            {
                dt = SelectData("BoxSelectbyID", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindItemyDetaisSearch(DataGridView dgv)
        {

            BindGrid(dgv, GetBoxbyID());
        }


    }
}
