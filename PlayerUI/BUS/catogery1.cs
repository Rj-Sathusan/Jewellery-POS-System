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
    class catogery1 : DAT.NewDataAccessLayer
    {
        private int Catogery1_id;
        private string Catogery1_discription;

        public int ID
        {
            get { return this.Catogery1_id; }
            set { this.Catogery1_id = value; }
        }
        public string DISCRIPTION
        {
            get { return this.Catogery1_discription; }
            set { this.Catogery1_discription = value; }
        }

        public bool SaveCatogery1(DataGridView dgv)
        {

            try
            {
                comtable = null;
                MySqlParameter[] param = new MySqlParameter[2];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = Catogery1_id;
                param[1] = new MySqlParameter("@discription0", MySqlDbType.VarChar, 60);
                param[1].Value = Catogery1_discription;
                if (OpenConnection())
                {
                    comtable = SelectData("Catogery1Save", param);
                    if(comtable.Rows.Count>=1)
                    {

                        BindGrid(dgv, comtable);
                        ShowMessage("Data Saved Successfully", "Warning");
                        CloseConnection();

                        if (dgv.SelectedRows.Count >= 1)
                        {
                            dgv.SelectedRows[0].Selected = false;
                        }
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

        public bool EditCatogery1(DataGridView dgv)
        {

            try
            {
                comtable = null;
                MySqlParameter[] param = new MySqlParameter[2];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = Catogery1_id;
                param[1] = new MySqlParameter("@discription0", MySqlDbType.VarChar, 60);
                param[1].Value = Catogery1_discription;
                if (OpenConnection())
                {
                    comtable = SelectData("Catogery1Edit", param);
                  
                   
                    if (comtable.Rows.Count >= 1)
                    {

                        BindGrid(dgv, comtable);
                        ShowMessage("Data Edited Successfully", "Warning");
                        CloseConnection();

                        if (dgv.SelectedRows.Count >= 1)
                        {
                            dgv.SelectedRows[0].Selected = false;
                        }
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

        public bool DeleteCatogery1()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = Catogery1_id;
                if (OpenConnection())
                {
                    if(ExecuteCommand("Catogery1Delete", param))
                    {

                        ShowMessage("Data Deleted Successfully", "Warning");
                        CloseConnection();
                        param = null;

                        return true;
                    }
                    else
                    {

                       // ShowMessage("Duplicate entry", "Error");
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


        public catogery1(int Catogery1id, string Catogery1discription)
        {
            this.Catogery1_id = Catogery1id;
            this.Catogery1_discription = Catogery1discription;
        }

        public catogery1(int Catogery1id)
        {
            this.Catogery1_id = Catogery1id;
        }

        public catogery1(string CatDescription)
        {
            this.Catogery1_discription = CatDescription;
        }



        public catogery1()
        { }

        // ============================================ Get all details in Shop ==============================//////

        public DataTable Getcat1()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("CAT1Select", null);
                CloseConnection();
            }

            return comtable;
        }
        public void BindCategory2Details(DataGridView dgv)
        {

            BindGrid(dgv, Getcat1());
            if (dgv.SelectedRows.Count >= 1)
            {
                dgv.SelectedRows[0].Selected = false;
            }

        }

        public DataTable GetCat1byDescription()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@discription0", MySqlDbType.VarChar, 60);
            param[0].Value = Catogery1_discription;

            if (OpenConnection())
            {
                dt = SelectData("Cat1SelectbyDesc", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindItemyDetaisSearch(DataGridView dgv)
        {

            BindGrid(dgv, GetCat1byDescription());
        }

    }
}
