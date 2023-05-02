using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{
    class itemform : DAT.NewDataAccessLayer
    {
        private int item_code; 
        private string item_name; 
        private int category_id; 
        private string categories;
        private double item_amount;
        private DateTime item_date;
        private decimal item_weight;
        private int item_carat;
        private long shift_id;
        private string p;
       private double qty { get; set; }

        public itemform(int item_code, string item_name, int category_id, string categories, double item_amount, DateTime item_date, decimal item_weight, int item_carat, long shift_id,double qty)/*------Save, Edit Constructor----------*/
        {
            this.item_code = item_code;
            this.item_name = item_name;
            this.category_id = category_id;
            this.categories = categories;
            this.item_amount = item_amount;
            this.item_date = item_date;
            this.item_weight = item_weight;
            this.item_carat = item_carat;
            this.shift_id = shift_id;
            this.qty = qty;
        }

        public itemform(int item_code)
        {
            this.item_code = item_code;
        }

        public itemform()
        {
        }

        public itemform(string itemname)
      {
          this.item_name = itemname;
      }

        public int ITEMCODE//
        {
            get
            {
                return this.item_code;
            }
            set
            {
                this.item_code = value;
            }
        }
        public string ITEMNAME//
        {
            get
            {
                return this.item_name;
            }
            set
            {
                this.item_name = value;
            }
        }
        public int CATEGORYID//
        {
            get
            {
                return this.category_id;
            }
            set
            {
                this.category_id = value;
            }
        }
        public string CATEGORIES//
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;
            }
        }
        public double AMOUNT//
        {
            get
            {
                return this.item_amount;
            }
            set
            {
                this.item_amount = value;
            }
        }
        public DateTime ITEMDATE//
        {
            get
            {
                return this.item_date;
            }
            set
            {
                this.item_date = value;
            }
        }
        public decimal ITEMWEIGHT//
        {
            get
            {
                return this.item_weight;
            }
            set
            {
                this.item_weight = value;
            }
        }
        public int ITEMCAROT//
        {
            get
            {
                return this.item_carat;
            }
            set
            {
                this.item_carat = value;
            }
        }
        public long SHIFTID//
        {
            get
            {
                return this.shift_id;
            }
            set
            {
                this.shift_id = value;
            }
        }

        public bool saveItem(DataGridView dgv)
        {
           
               
                MySqlParameter[] param = new MySqlParameter[11];
                param[0] = new MySqlParameter("@item_code0", MySqlDbType.Int32);
                param[0].Value = item_code;
                param[1] = new MySqlParameter("@item_name0", MySqlDbType.VarChar, 50);
                param[1].Value = item_name;
                param[2] = new MySqlParameter("@category_id0", MySqlDbType.Int32);
                param[2].Value = category_id;
                param[3] = new MySqlParameter("@amount0", MySqlDbType.Double);
                param[3].Value = item_amount;
                param[4] = new MySqlParameter("@date0", MySqlDbType.DateTime);
                param[4].Value = item_date;
                param[5] = new MySqlParameter("@categories0", MySqlDbType.VarChar, 50);
                param[5].Value = categories;
                param[6] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[6].Value = item_weight;
                param[7] = new MySqlParameter("@carat0", MySqlDbType.Int32);
                param[7].Value = item_carat;
                param[8] = new MySqlParameter("@shift_id0", MySqlDbType.Int64);
                param[8].Value = shift_id;
                param[9] = new MySqlParameter("@qty1", MySqlDbType.Double);
                param[9].Value = qty;
                param[10] = new MySqlParameter("@ico", MySqlDbType.Int32);
                param[10].Direction = ParameterDirection.Output;

                comtable = null;
                if (OpenConnection())
                {
                    comtable = SelectData("itemSave", param);
                    if (comtable.Rows.Count>=1)
                    {

                        ShowMessage("Data Saved Successfully", "Warning");
                        CloseConnection();
                        param = null;
                        BindGrid(dgv, comtable);
                        if (dgv.SelectedRows.Count >= 1)
                        {
                            dgv.SelectedRows[0].Selected = false;
                        }
                        return true;
                    }
                    else
                    {
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

        public bool editItem(DataGridView dgv )
        {
           
                MySqlParameter[] param = new MySqlParameter[10];
                param[0] = new MySqlParameter("@item_code0", MySqlDbType.Int32);
                param[0].Value = item_code;
                param[1] = new MySqlParameter("@item_name0", MySqlDbType.VarChar, 50);
                param[1].Value = item_name;
                param[2] = new MySqlParameter("@category_id0", MySqlDbType.Int32);
                param[2].Value = category_id;
                param[3] = new MySqlParameter("@amount0", MySqlDbType.Double);
                param[3].Value = item_amount;
                param[4] = new MySqlParameter("@date0", MySqlDbType.DateTime);
                param[4].Value = item_date;
                param[5] = new MySqlParameter("@categories0", MySqlDbType.VarChar, 50);
                param[5].Value = categories;
                param[6] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[6].Value = item_weight;
                param[7] = new MySqlParameter("@carat0", MySqlDbType.Int32);
                param[7].Value = item_carat;
                param[8] = new MySqlParameter("@shift_id0", MySqlDbType.Int32);
                param[8].Value = shift_id;
                param[9] = new MySqlParameter("@qty1", MySqlDbType.Double);
                param[9].Value = qty;

                comtable = null;
                if (OpenConnection())
                {
                    comtable = SelectData("ItemEdit", param);


                    if (comtable.Rows.Count >= 1)
                    {

                        ShowMessage("Data Edited Successfully", "Warning");
                        CloseConnection();
                        param = null;
                        BindGrid(dgv, comtable);
                        if (dgv.SelectedRows.Count >= 1)
                        {
                            dgv.SelectedRows[0].Selected = false;
                        }
                        return true;
                    }
                    else
                    {
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

        public bool deleteItem()
        {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@item_code0", MySqlDbType.Int32);
                param[0].Value = item_code;
                if (OpenConnection())
                {
                    ExecuteCommand("ItemDelete", param);
                    sqlconnection.Close();
                    param = null;
                    ShowMessage("Data Deleted Successfully", "Warning");
                    return true;
                }
                else
                {
                    param = null;
                    return false;
                }

            
        }


        public DataTable GetItem()
        {
            DataTable dt = new DataTable();



            if (OpenConnection())
            {
                dt = SelectData("ItemAllSelect", null);
                CloseConnection();
            }

            return dt;
        }


        public void BindItemDetaislFull(DataGridView dgv)
        {

            BindGrid(dgv, GetItem());

            if (dgv.Rows.Count >= 1)
            {

                if (dgv.SelectedRows.Count >= 1)
                {
                    dgv.SelectedRows[0].Selected = false;
                }
            }
        }

        public DataTable GetItembyName()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@item_name0", MySqlDbType.VarChar, 50);
            param[0].Value = item_name;

            if (OpenConnection())
            {
                dt = SelectData("ItemSelectbyName", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindItemyDetaisSearch(DataGridView dgv)
        {

            BindGrid(dgv, GetItembyName());

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
