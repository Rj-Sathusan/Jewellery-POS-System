using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace PlayerUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            //panelMediaSubMenu.Visible = false;
            ItemPanel.Visible = false;
            Categorypanel.Visible = false;
            panel2.Visible = false;
            //panelToolsSubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMedia_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelMediaSubMenu);
        }

        #region MediaSubMenu
        private void button2_Click(object sender, EventArgs e)
        {
            //openChildForm(new Form2());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelPlaylistSubMenu);
        }

        #region PlayListManagemetSubMenu
        private void button8_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelToolsSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            //openChildForm(new Form3());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnEqualizer_Click(object sender, EventArgs e)
        {
           // openChildForm(new Form3());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayDate();
            GetGoldRate();

        }

        private void DisplayDate()
        {
            // Get today's date
            DateTime today = DateTime.Today;

            // Display the date in the label
            label3.Text = today.ToString("MM/dd/yyyy");
        }



private async void GetGoldRate()
{
    try
    {
        // URL to retrieve the gold rate from the website
        string url = "https://ideabeam.com/finance/rates/goldprice.php";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

                // Use a regular expression to extract the gold rate from the HTML string
                string pattern = @"22 Carat 8 Grams \( 1 Pawn \) Gold Price today in Sri Lanka is Rs. (\d+,\d+)";
                Match match = Regex.Match(result, pattern);

                if (match.Success)
                {
                    string goldRate = match.Groups[1].Value;
                    label1.Text = "Rs. " + goldRate;
                }
                else
                {
                    throw new Exception("Gold rate not found in the HTML response.");
                }
            }
            else
            {
                throw new Exception("Error getting response from the website.");
            }
        }
    }
    catch (Exception ex)
    {
        label1.Text = "Error Retry ";
        
    }
}

private void label3_Click(object sender, EventArgs e)
{

}

private void pictureBox1_Click(object sender, EventArgs e)
{

}

private void button2_Click_1(object sender, EventArgs e)
{
    //showSubMenu(panelToolsSubMenu);
}

private void panel1_Paint(object sender, PaintEventArgs e)
{

}

private void panel2_Paint(object sender, PaintEventArgs e)
{

}

        private void panelPlaylistSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
        
        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTNventas_Click(object sender, EventArgs e)
        {
            //showSubMenu(panelMediaSubMenu);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void purchase_menu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnproductos_Click_1(object sender, EventArgs e)
        {
            Application.Restart();

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            showSubMenu(panel2);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            showSubMenu(ItemPanel);

        }

        private void Category_Click(object sender, EventArgs e)
        {
            showSubMenu(Categorypanel);

        }

        private void Category_Click_1(object sender, EventArgs e)
        {
            showSubMenu(Categorypanel);

        }

        private void BTNventas_Click_1(object sender, EventArgs e)
        {

            openChildForm(new Jewellery_System.PRE.PURCHASE.List());
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            openChildForm(new PlayerUI.PRE.user());

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.CUSTOMER.CUSTOMER());

        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.JEWELLERY.Jewellery());

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.ITEMFORM.ITEMFORM());

        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.Boxes.frmSearchBox());

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.BOXITEMS.BoxItems());

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.Boxes.Box());

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.CATEGORY1.frmAddCatergory());

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            openChildForm(new Jewellery_System.PRE.CATEGORY2.frmCategoryByDays());

        }

    }
}
