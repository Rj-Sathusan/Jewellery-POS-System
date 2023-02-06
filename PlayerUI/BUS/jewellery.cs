using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Text;
 using System.Threading.Tasks;
 using MySql.Data.MySqlClient;
 using System.Windows.Forms;
 using System.Data;

namespace Jewellery_System.BUS
{
    class jewellery : DAT.NewDataAccessLayer
    {
        private int jewellery_id;
        private int jewellery_tagno;
        private double jewellery_weight;

        public int ID
        {
            get { return this.jewellery_id;}
            set { this.jewellery_id = value;}
        }
        public int TAGNO
        {
            get { return this.jewellery_tagno;}
            set { this.jewellery_tagno = value;}
        }
        public double WEIGHT
        {
            get { return this.jewellery_weight; }
            set { this.jewellery_weight = value;}
        }

        public bool Savejewellery()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[3];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = jewellery_id;
                param[1] = new MySqlParameter("@tagno0", MySqlDbType.Int32);
                param[1].Value = jewellery_tagno;
                param[2] = new MySqlParameter("@weight0", MySqlDbType.Double);
                param[2].Value = jewellery_weight;
             
                if (OpenConnection())
                {
                    if(ExecuteCommand("jewellerySave", param))
                    {

                        ShowMessage("Data Saved Successfully", "Warning");
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
            catch(Exception ex) { MessageBox.Show(ex.Message); return false; }
        }



        public bool Editjewellery()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[3];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = jewellery_id;
                param[1] = new MySqlParameter("@tagno0", MySqlDbType.Int32);
                param[1].Value = jewellery_tagno;
                param[2] = new MySqlParameter("@weight0", MySqlDbType.Double);
                param[2].Value = jewellery_weight;
                if (OpenConnection())
                {
                    if(ExecuteCommand("jewelleryEdit", param))
                    {

                        ShowMessage("Data Edited Successfully", "Warning");
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



        public bool Deletejewellery()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@id0", MySqlDbType.Int32);
                param[0].Value = jewellery_id;
                if (OpenConnection())
                {
                    if(ExecuteCommand("jewelleryDelete", param))
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



        public jewellery(int jewelleryid,int jewellerytagno,double jewelleryweight)
        {
            this.jewellery_id = jewelleryid;
            this.jewellery_tagno = jewellerytagno;
            this.jewellery_weight = jewelleryweight;
        }
        public jewellery(int jewelleryid)
        {
            this.jewellery_id = jewelleryid;          
        }

        public void tagsearch(int jewellerytagno)
        {
            this.jewellery_tagno = jewellerytagno;
            
        }
        

        public jewellery()
        {}


        // ============================================ Get all details in Shop ==============================//////

        public DataTable Getjew()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("jewellerySelect", null);
                sqlconnection.Close();
            }

            return comtable;
        }
        public void BindCategory2Details(DataGridView dgv)
        {

            BindGrid(dgv, Getjew());
        }

        public DataTable GetJewelbyTag()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@tagno0", MySqlDbType.Int32);
            param[0].Value = jewellery_tagno;

            if (OpenConnection())
            {
                dt = SelectData("JewelSelectbyTag", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindJewelDetaisSearch(DataGridView dgv)
        {

            BindGrid(dgv, GetJewelbyTag());
        }

    }
}