using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{
    class customer : DAT.NewDataAccessLayer
    {
        private string customer_id;
        private string customer_name;
        private string customer_address;
        private string customer_phoneno;
        private string customer_nicno;
        private string customer_type;
        private string p;
        public long shiftid { get; set; }

        public customer(string customer_id, string customer_name, string customer_address, string customer_phoneno, string customer_nicno, string customer_type,long sid)
        {
            this.customer_id = customer_id;
            this.customer_name = customer_name;
            this.customer_address = customer_address;
            this.customer_phoneno = customer_phoneno;
            this.customer_nicno = customer_nicno;
            this.customer_type = customer_type;
           this. shiftid = sid;
        }

        public customer(string cid)
        {
            this.customer_id = cid;
        }
       
        public customer()
        {
        }

        public customer(string c_id,string cname)
      {
          this.customer_id = null;
          this.customer_name = cname;
      }

        public void tagsearch(string cname)
        {
            this.customer_name = cname;

        }
        

        public string CUSTOMER_ID { get { return this.customer_id; } set { this.customer_id = value; } }
        public string CUSTOMER_NAME { get { return this.customer_name; } set { this.customer_name = value; } }
        public string CUSTOMER_ADDRESS { get { return this.customer_address; } set { this.customer_address = value; } }
        public string CUSTOMER_PHONENO { get { return this.customer_phoneno; } set { this.customer_phoneno = value; } }
        public string CUSTOMER_NICNO { get { return this.customer_nicno; } set { this.customer_nicno = value; } }
        public string CUSTOMER_TYPE { get { return this.customer_type; } set { this.customer_type = value; } }

        public bool Savecustomer(DataGridView dgv)
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[7];
                param[0] = new MySqlParameter("@cust_id", MySqlDbType.VarChar, 30);
                param[0].Value = customer_id;
                param[1] = new MySqlParameter("@cust_name", MySqlDbType.VarChar, 60);
                param[1].Value = customer_name;
                param[2] = new MySqlParameter("@cust_address", MySqlDbType.VarChar, 100);
                param[2].Value = customer_address;
                param[3] = new MySqlParameter("@cust_phoneno", MySqlDbType.VarChar, 50);
                param[3].Value = customer_phoneno;
                param[4] = new MySqlParameter("@cust_nicno", MySqlDbType.VarChar, 15);
                param[4].Value = customer_nicno;
                param[5] = new MySqlParameter("@cust_type", MySqlDbType.VarChar, 10);
                param[5].Value = customer_type;
                param[6] = new MySqlParameter("@sid", MySqlDbType.Int64);
                param[6].Value = shiftid;

                comtable = null;
                if (OpenConnection())
                {
                    comtable = SelectData("CustomerSave", param);
                    if (comtable.Rows.Count>=1)
                    {
                        CloseConnection();
                        ShowMessage("Data Saved Successfully", "Warning");
                       

                       
                        BindGrid(dgv, comtable);
                        if (dgv.SelectedRows.Count >= 1)
                        {
                            dgv.SelectedRows[0].Selected = false;
                        }
                        param = null;

                        return true;
                    }
                    else
                    {
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

        public bool Editcustomer( DataGridView dgv)
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[6];
                param[0] = new MySqlParameter("@cust_id", MySqlDbType.VarChar, 30);
                param[0].Value = customer_id;
                param[1] = new MySqlParameter("@cust_name", MySqlDbType.VarChar, 60);
                param[1].Value = customer_name;
                param[2] = new MySqlParameter("@cust_address", MySqlDbType.VarChar, 100);
                param[2].Value = customer_address;
                param[3] = new MySqlParameter("@cust_phoneno", MySqlDbType.VarChar, 50);
                param[3].Value = customer_phoneno;
                param[4] = new MySqlParameter("@cust_nicno", MySqlDbType.VarChar, 15);
                param[4].Value = customer_nicno;
                param[5] = new MySqlParameter("@cust_type", MySqlDbType.VarChar, 10);
                param[5].Value = customer_type;
                comtable = null;
                if (OpenConnection())
                {
                    comtable = SelectData("CustomerEdit", param);
                    if (comtable.Rows.Count>=1)
                    {
                        
                        CloseConnection();
                        ShowMessage("Data Edited Successfully", "Warning");
                        BindGrid(dgv, comtable);
                        if (dgv.SelectedRows.Count >= 1)
                        {
                            dgv.SelectedRows[0].Selected = false;
                        }
                        param = null;

                        return true;
                    }
                    else
                    {
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

        public bool Deletecustomer()
        {
            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@cust_id", MySqlDbType.VarChar, 30);
                param[0].Value = customer_id;
                if (OpenConnection())
                {
                    ExecuteCommand("CustomerDelete", param);
                    CloseConnection();
                    ShowMessage("Data Deleted Successfully", "Warning");
                    param = null; 
                    return true;
                }
                else
                { 
                    param = null;
                    return false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

        public DataTable GetCustomerFull()
        {
            DataTable dt = new DataTable();
            if (OpenConnection())
            {
                dt = SelectData("CustomerSelectAll", null);
                CloseConnection();
            }

            return dt;
        }

        public void BindCustomerDetails(DataGridView dgv)
        {

            BindGrid(dgv, GetCustomerFull());

            if (dgv.Rows.Count >= 1)
            {

                if (dgv.SelectedRows.Count >= 1)
                {
                    dgv.SelectedRows[0].Selected = false;
                }
            }
        }

        public DataTable GetCustomerbyName(string cuname)
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@cust_name", MySqlDbType.VarChar, 60);
            param[0].Value = cuname;

            if (OpenConnection())
            {
                dt = SelectData("CustomerSelectbyName", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindCustomeryDetaisSearch(DataGridView dgv,string cuname)
        {

            BindGrid(dgv, GetCustomerbyName(cuname));
            if (dgv.Rows.Count >= 1)
            {

                if (dgv.SelectedRows.Count >= 1)
                {
                    dgv.SelectedRows[0].Selected = false;
                }
            }
        }

    }
}
