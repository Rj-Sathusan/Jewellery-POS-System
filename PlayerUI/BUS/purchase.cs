using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Jewellery_System.BUS
{
    class purchase : DAT.NewDataAccessLayer
    {
        private long purchase_BillNo;
        private int primary_key;
        private string purchase_customer_id;
        private string purchase_customer_name;
        private string purchase_item_name;
        private string purchase_item_code;
        private int purchase_carrot;
        private decimal purchase_weight;
        private double purchase_quantity;
        private decimal purchase_total_weight;
        private double purchase_unit_price;
        private double purchase_totel;
        private double purchase_discount;
        private double purchase_net_totel;
        private decimal purchase_making;
        private decimal purchase_wasting;
        private DateTime purchase_purchase_date;
        private long bill_no;
        private string sup_bill_no;
        private int customer_id;
        private string purchase_type;
        private long shiftid;


        public double _totalwastagegold { get; set; }
        public double _totalwastagePuregold { get; set; }
        public double _allnettotal { get; set; }
        public double _total_makng{ get; set; }
        public double _total_makng_expenses{ get; set; }
        public string  wastagetxt { get; set; }
        public string  makingtxt { get; set; }
        private double bill_net_totel { get; set; }
        private double bill_totel { get; set; }
        private double bill_discount { get; set; }
        public string ITEM_CODE
        {
            get { return this.purchase_item_code; }
            set { this.purchase_item_code = value; }
        }
        public long BILL_No
        {
            get { return this.purchase_BillNo; }
            set { this.purchase_BillNo = value; }
        }
        public string CUSTOMER_ID
        {
            get { return this.purchase_customer_id; }
            set { this.purchase_customer_id = value; }
        }
        public string CUSTOMER_NAME
        {
            get { return this.purchase_customer_name; }
            set { this.purchase_customer_name = value; }
        }
        public string ITEM_NAME
        {
            get { return this.purchase_item_name; }
            set { this.purchase_item_name = value; }
        }
        public int CARROT
        {
            get { return this.purchase_carrot; }
            set { this.purchase_carrot = value; }
        }
        public decimal WEIGHT
        {
            get { return this.purchase_weight; }
            set { this.purchase_weight = value; }
        }
        public double QUANTITY
        {
            get { return this.purchase_quantity; }
            set { this.purchase_quantity = value; }
        }
        public decimal TOTALWEIGHT
        {
            get { return this.purchase_total_weight; }
            set { this.purchase_total_weight = value; }
        }
        public double UNIT_PRICE
        {
            get { return this.purchase_unit_price; }
            set { this.purchase_unit_price = value; }
        }
        public double TOTEL
        {
            get { return this.purchase_totel; }
            set { this.purchase_totel = value; }
        }
        public double DISCOUNT
        {
            get { return this.purchase_discount; }
            set { this.purchase_discount = value; }
        }
        public double NET_TOTEL
        {
            get { return this.purchase_net_totel; }
            set { this.purchase_net_totel = value; }
        }
        public decimal MAKING
        {
            get { return this.purchase_making; }
            set { this.purchase_making = value; }
        }
        public decimal WASTING
        {
            get { return this.purchase_wasting; }
            set { this.purchase_wasting = value; }
        }
        public DateTime PURCHASE_DATE
        {
            get { return this.purchase_purchase_date; }
            set { this.purchase_purchase_date = value; }
        }

        public bool Savepurchase()
        {
            try
            {
                MySqlParameter[] param = new MySqlParameter[22];
                param[0] = new MySqlParameter("@billNo0", MySqlDbType.Int64);
                param[0].Value = purchase_BillNo;
                param[1] = new MySqlParameter("@customer_id0", MySqlDbType.VarChar, 60);
                param[1].Value = purchase_customer_id;
                param[2] = new MySqlParameter("@customer_name0", MySqlDbType.VarChar, 60);
                param[2].Value = purchase_customer_name;
                param[3] = new MySqlParameter("@item_name0", MySqlDbType.VarChar, 60);
                param[3].Value = purchase_item_name;
                param[4] = new MySqlParameter("@carrot0", MySqlDbType.Int32);
                param[4].Value = purchase_carrot;
                param[5] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[5].Value = purchase_weight;
                param[6] = new MySqlParameter("@quantity0", MySqlDbType.Double);
                param[6].Value = purchase_quantity;
                param[7] = new MySqlParameter("@totalweight0", MySqlDbType.Double);
                param[7].Value = purchase_total_weight;
                param[8] = new MySqlParameter("@unit_price0", MySqlDbType.Double);
                param[8].Value = purchase_unit_price;
                param[9] = new MySqlParameter("@totel0", MySqlDbType.Double);
                param[9].Value = purchase_totel;
                param[10] = new MySqlParameter("@discount0", MySqlDbType.Double);
                param[10].Value = purchase_discount;
                param[11] = new MySqlParameter("@net_totel0", MySqlDbType.Double);
                param[11].Value = purchase_net_totel;
                param[12] = new MySqlParameter("@making0", MySqlDbType.Decimal);
                param[12].Value = purchase_making;
                param[13] = new MySqlParameter("@wasting0", MySqlDbType.Decimal);
                param[13].Value = purchase_wasting;
                param[14] = new MySqlParameter("@purchase_date0", MySqlDbType.DateTime);
                param[14].Value = purchase_purchase_date;
                param[15] = new MySqlParameter("@purchase_item_code0", MySqlDbType.Int32);
                param[15].Value = purchase_item_code;
                param[16] = new MySqlParameter("@purchase_totel_wasting0", MySqlDbType.Double);
                param[16].Value = _totalwastagegold;
                param[17] = new MySqlParameter("@purchase_totel_making0", MySqlDbType.Double);
                param[17].Value = _total_makng_expenses;
                param[18] = new MySqlParameter("@purchase_shiftid0", MySqlDbType.Int64);
                param[18].Value = shiftid;
                param[19] = new MySqlParameter("@purchase_wastingtxt0", MySqlDbType.VarChar, 60);
                param[19].Value = wastagetxt;
                param[20] = new MySqlParameter("@purchase_makingtxt0", MySqlDbType.VarChar, 60);
                param[20].Value = makingtxt;
                param[21] = new MySqlParameter("@purchase_type0", MySqlDbType.VarChar, 60);
                param[21].Value = purchase_type;
               

                Console.WriteLine(purchase_item_code);
                if (OpenConnection())
                {
                    if (ExecuteCommand("purchaseSave", param))
                    {

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

        public bool Editpurchase()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[22];
                param[0] = new MySqlParameter("@primary_key0", MySqlDbType.Int32);
                param[0].Value = primary_key;
                param[1] = new MySqlParameter("@customer_id0", MySqlDbType.VarChar, 60);
                param[1].Value = purchase_customer_id;
                param[2] = new MySqlParameter("@customer_name0", MySqlDbType.VarChar, 60);
                param[2].Value = purchase_customer_name;
                param[3] = new MySqlParameter("@item_name0", MySqlDbType.VarChar, 60);
                param[3].Value = purchase_item_name;
                param[4] = new MySqlParameter("@carrot0", MySqlDbType.Int32);
                param[4].Value = purchase_carrot;
                param[5] = new MySqlParameter("@weight0", MySqlDbType.Decimal);
                param[5].Value = purchase_weight;
                param[6] = new MySqlParameter("@quantity0", MySqlDbType.Double);
                param[6].Value = purchase_quantity;
                param[7] = new MySqlParameter("@totalweight0", MySqlDbType.Double);
                param[7].Value = purchase_total_weight;
                param[8] = new MySqlParameter("@unit_price0", MySqlDbType.Double);
                param[8].Value = purchase_unit_price;
                param[9] = new MySqlParameter("@totel0", MySqlDbType.Double);
                param[9].Value = purchase_totel;
                param[10] = new MySqlParameter("@discount0", MySqlDbType.Double);
                param[10].Value = purchase_discount;
                param[11] = new MySqlParameter("@net_totel0", MySqlDbType.Double);
                param[11].Value = purchase_net_totel;
                param[12] = new MySqlParameter("@making0", MySqlDbType.Decimal);
                param[12].Value = purchase_making;
                param[13] = new MySqlParameter("@wasting0", MySqlDbType.Decimal);
                param[13].Value = purchase_wasting;
                param[14] = new MySqlParameter("@purchase_date0", MySqlDbType.DateTime);
                param[14].Value = purchase_purchase_date;
                param[15] = new MySqlParameter("@purchase_item_code0", MySqlDbType.Int32);
                param[15].Value = purchase_item_code;
                param[16] = new MySqlParameter("@purchase_totel_wasting0", MySqlDbType.Double);
                param[16].Value = _totalwastagegold;
                param[17] = new MySqlParameter("@purchase_totel_making0", MySqlDbType.Double);
                param[17].Value = _total_makng_expenses;
                param[18] = new MySqlParameter("@purchase_shiftid0", MySqlDbType.Int64);
                param[18].Value = shiftid;
                param[19] = new MySqlParameter("@purchase_wastingtxt0", MySqlDbType.VarChar, 60);
                param[19].Value = wastagetxt;
                param[20] = new MySqlParameter("@purchase_makingtxt0", MySqlDbType.VarChar, 60);
                param[20].Value = makingtxt;
                param[21] = new MySqlParameter("@billNo0", MySqlDbType.Int64);
                param[21].Value = purchase_BillNo;
               
                if (OpenConnection())
                {
                    if (ExecuteCommand("purchaseEdit", param))
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

        public bool Deletepurchase()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                param[0] = new MySqlParameter("@purchase_billNo0", MySqlDbType.Int32);
                param[0].Value = purchase_BillNo;
                if (OpenConnection())
                {
                    if (ExecuteCommand("purchaseDelete", param))
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

        public purchase(int primarykey,long billno, string purchase_item_code, string f_customer_id, string f_customer_name, string f_item_name, 
            int f_purchase_carat, decimal f_purchase_weight, double f_purchase_quantity,
            decimal f_purchase_total_weight, double f_purchase_unit_price, double f_purchase_total_price, 
            double f_purchase_discount,double f_purchase_net_total_price, decimal f_purchase_making,
            decimal f_purchase_wasting, DateTime f_purchase_date, double totalwastagegold, double totalwastagourgold, string wastagetxt, string makingtxt, double allnet, double maexpensess, double bill_net_totel, double bill_discount, String purchase_type)
        {
            this.primary_key = primarykey;
            this.purchase_BillNo = billno;
            this.purchase_customer_id = f_customer_id;
            this.purchase_customer_name = f_customer_name;
            this.purchase_item_name = f_item_name;
            this.purchase_carrot = f_purchase_carat;
            this.purchase_weight = f_purchase_weight;
            this.purchase_quantity = f_purchase_quantity;
            this.purchase_total_weight = f_purchase_total_weight;
            this.purchase_unit_price = f_purchase_unit_price;
            this.purchase_totel = f_purchase_total_price;
            this.purchase_discount = f_purchase_discount;
            this.purchase_net_totel = f_purchase_net_total_price;
            this.purchase_making = f_purchase_making;
            this.purchase_wasting = f_purchase_wasting;
            this.purchase_purchase_date = f_purchase_date;
            this.purchase_item_code = purchase_item_code;

            this._totalwastagegold = totalwastagegold;
            this._totalwastagePuregold = totalwastagourgold;
            this.wastagetxt = wastagetxt;
            this.makingtxt = makingtxt;
            this._allnettotal = allnet;
            this._total_makng_expenses = maexpensess;
            this.bill_discount = bill_discount;
            this.bill_net_totel = bill_net_totel;
            this.purchase_type = purchase_type;
        }

        public purchase(long f_purchase_id)
        {
            this.purchase_BillNo = f_purchase_id;
        }
          
        public purchase(string f_customer_name)
        {
            this.purchase_customer_name = f_customer_name;
        }
        public purchase()
        {
        }

        public purchase(string putype,int cuid,string suinno,long shifid)
        {
            this.purchase_type = putype;
            this.customer_id = cuid;
            this.sup_bill_no = suinno;
            this.shiftid = shifid;
        }

        public purchase(long bill_no, Double bill_net_totel, Double bill_discount)
        {
            this.purchase_BillNo = bill_no;
            this.bill_discount = bill_discount;
            this.bill_net_totel = bill_net_totel;
        }

        public DataTable GetpurcaseDetails()
        {
            comtable = null;


            if (OpenConnection())
            {
                comtable = SelectData("purcaseDetails", null);
                sqlconnection.Close();
            }

            return comtable;
        }

        public void BindpurcaseDetails(DataGridView dgv)
        {

            BindGrid(dgv, GetpurcaseDetails());
        }

        public DataTable GetPurchasebyName()
        {
            DataTable dt = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];

            param[0] = new MySqlParameter("@customer_name0", MySqlDbType.VarChar, 60);
            param[0].Value = purchase_customer_name;

            if (OpenConnection())
            {
                dt = SelectData("GetPurchasebyName", param);
                CloseConnection();
            }

            return dt;
        }

        public void BindPurchaseDetailsName(DataGridView dgv)
        {

            BindGrid(dgv, GetPurchasebyName());
        }

        public bool GetpurchaseNo(TextBox txt)
        {

            
                MySqlParameter[] param = new MySqlParameter[6];
                param[0] = new MySqlParameter("@cuid1", MySqlDbType.Int32);
                param[0].Value = customer_id;
                param[1] = new MySqlParameter("@putype1", MySqlDbType.VarChar,50);
                param[1].Value = purchase_type;
                param[2] = new MySqlParameter("@suinno1", MySqlDbType.VarChar, 50);
                param[2].Value = sup_bill_no;
                param[3] = new MySqlParameter("@addate", MySqlDbType.Date);
                param[3].Value = DateTime.Now;
                param[4] = new MySqlParameter("@shid1", MySqlDbType.Int64);
                param[4].Value = shiftid;
                param[5] = new MySqlParameter("@billno1", MySqlDbType.Int64);
                param[5].Direction=ParameterDirection.Output;



                if (OpenConnection())
                {

                    if (ExecuteCommand("GetPurchaseNo", param))
                    {
                        txt.Text = param[5].Value.ToString();
                        CloseConnection();
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


        public bool summerysave()
        {

            try
            {
                MySqlParameter[] param = new MySqlParameter[4];
                param[0] = new MySqlParameter("@billNo0", MySqlDbType.Int64);
                param[0].Value = purchase_BillNo;
                param[1] = new MySqlParameter("@bill_net_totel0", MySqlDbType.Double);
                param[1].Value = bill_net_totel;
                param[2] = new MySqlParameter("@bill_discount0", MySqlDbType.Double);
                param[2].Value = bill_discount;
                param[3] = new MySqlParameter("@purchase_shiftid0", MySqlDbType.Int64);
                param[3].Value = shiftid;

                if (OpenConnection())
                {
                    if (ExecuteCommand("summarySave", param))
                    {

                        ShowMessage("Summary Save Successfully", "Warning");
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


      

    }
}
