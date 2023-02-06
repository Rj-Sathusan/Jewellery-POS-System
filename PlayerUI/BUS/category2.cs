using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{

    class category2 : DAT.NewDataAccessLayer
    {
        private int class_id; /////
        private string class_description; /////
        private int class_days; //////
        private double class_amount; /////


        public category2(int class_id, string class_description, int class_days, double class_amount)/*------Save, Edit Constructor----------*/
        {
            this.class_id = class_id;
            this.class_description = class_description;
            this.class_days = class_days;
            this.class_amount = class_amount;
        }

        public category2(string class_description)/*------Get All Constructor----------*/
        {
            this.class_description = class_description;
          
        }

        public category2()/*------Get All Constructor----------*/
        {
           // this.class_description = class_description;

        }
        public void GetCat2byDescription(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@discription0", MySqlDbType.VarChar, 60);
            param[0].Value = this.class_description;

            if (OpenConnection())
            {
                dt = SelectData("Cat2SelectbyDesc", param);
                CloseConnection();
            }

            BindGrid(dgv, dt); dt = null;
        }
        public category2(int class_id)/*------Delete Constructor----------*/
        {
            this.class_id = class_id;
        }

        public int ID
        {
            get
            {
                return this.class_id;
            }
            set
            {
                this.class_id = value;
            }
        }

        public string DESCRIPTION
        {
            get
            {
                return this.class_description;
            }
            set
            {
                this.class_description = value;
            }
        }

        public int DAYS
        {
            get
            {
                return this.class_days;
            }
            set
            {
                this.class_days = value;
            }
        }

      
        public double AMOUNT
        {
            get
            {
                return this.class_amount;
            }
            set
            {
                this.class_amount = value;
            }
        }

        public bool Saveshop(DataGridView dgv)
        {

            try
            {
                comtable = null;
                MySqlParameter[] param = new MySqlParameter[4];
                param[0] = new MySqlParameter("@f_id", MySqlDbType.Int32);
                param[0].Value = class_id;         
                param[1] = new MySqlParameter("@description1", MySqlDbType.VarChar,10);
                param[1].Value = class_description;
                param[2] = new MySqlParameter("@days1", MySqlDbType.Int32);
                param[2].Value = class_days;
                param[3] = new MySqlParameter("@amount1", MySqlDbType.Double);
                param[3].Value = class_amount;

                if (OpenConnection())
                {

                    comtable = SelectData("Cat2Save", param);

                    if (comtable.Rows.Count>=1)
                    {
                        BindGrid(dgv,comtable);
                        ShowMessage("Data Saved Successfully", "Warning");
                        CloseConnection();
                        param = null;
                        if (dgv.SelectedRows.Count >= 1)
                        {

                            dgv.SelectedRows[0].Selected = false;
                        }
                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry :  '"+class_description+"'", "Error");
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

        public bool Editshop(DataGridView dgv)
        {

            try
            {
                comtable = null;
                MySqlParameter[] param = new MySqlParameter[4];
                param[0] = new MySqlParameter("@f_id", MySqlDbType.Int32);
                param[0].Value = class_id;

                param[1] = new MySqlParameter("@description1", MySqlDbType.VarChar, 10);
                param[1].Value = class_description;
                param[2] = new MySqlParameter("@days1", MySqlDbType.Int32);
                param[2].Value = class_days;
                param[3] = new MySqlParameter("@amount1", MySqlDbType.Double);
                param[3].Value = class_amount;

                if (OpenConnection())
                {
                   

                    comtable = SelectData("Cat2Edit", param);

                    if (comtable.Rows.Count >= 1)
                    {
                        BindGrid(dgv, comtable);
                        ShowMessage("Data Edited Successfully", "Warning");
                        CloseConnection();
                        param = null;
                        if (dgv.SelectedRows.Count >= 1)
                        {

                            dgv.SelectedRows[0].Selected = false;
                        }
                        return true;
                    }
                    else
                    {

                        ShowMessage("Duplicate entry :  '" + class_description + "'", "Error");
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

        public bool Deleteshop()
        {
            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@f_id", MySqlDbType.Int32);
                param[0].Value = class_id;
                if (OpenConnection())
                {
                    ExecuteCommand("Cat2Delete", param);
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
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }

       

        public BUS.category2 Get(string reference)
        {
            BUS.category2 category2;


            comtable = null;
            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@des1", MySqlDbType.VarChar, 50);
            param[0].Value = reference;


            DataTable table = comtable;
            table = SelectData("Cat2SelectFull", param);
            comtable = null;

            if (table.Rows.Count == 0)
            {
                category2 = null;
            }
            else
            {
                category2 = new BUS.category2()
                {
                    ID = Convert.ToInt32(table.Rows[0].ItemArray[0].ToString()),
                    DESCRIPTION = table.Rows[0].ItemArray[1].ToString(),
                    DAYS = Convert.ToInt32(table.Rows[0].ItemArray[2].ToString()),
                    AMOUNT = Convert.ToDouble(table.Rows[0].ItemArray[2].ToString())
                };
            }
            return category2;
        }

        public DataTable GetShopFull()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@des1", MySqlDbType.VarChar,50);
            param[0].Value = class_description;

            if (OpenConnection())
            {
                dt = SelectData("Cat2SelectFull", param);
                CloseConnection();
            }

            return dt;
        }

        public DataTable GetShop()
        {
            DataTable dt = new DataTable();



            if (OpenConnection())
            {
                dt = SelectData("Cat2Select", null);
                CloseConnection();
            }

            return dt;
        }

        public void BindCategoryDetaisl(DataGridView dgv)
        {

            BindGrid(dgv, GetShop());
        }

        public void BindCategoryDetaislFull(DataGridView dgv)
        {

            BindGrid(dgv, GetShopFull());
        }

       
    }
}
