using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jewellery_System.PRE.Menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void category01ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CATEGORY1.frmAddCatergory cat1 = new CATEGORY1.frmAddCatergory();
            cat1.Show();


        }

        private void category02ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CATEGORY2.frmCategoryByDays cat1 = new CATEGORY2.frmCategoryByDays();
            cat1.Show();
        }

        private void itemFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ITEMFORM.ITEMFORM itemform = new ITEMFORM.ITEMFORM(1);
            itemform.Show();
        }

        private void priceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PRICE.Price priceform = new PRICE.Price(1);
            priceform.Show();
        }

        private void boxesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Boxes.Box boxform = new Boxes.Box(1);
            boxform.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CUSTOMER.CUSTOMER customerform = new CUSTOMER.CUSTOMER(1);
            customerform.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PURCHASE.PURCHASE purchaseform = new PURCHASE.PURCHASE();
            purchaseform.Show();
        }

        private void jewelleryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            JEWELLERY.Jewellery jewelform = new JEWELLERY.Jewellery();
            jewelform.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PURCHASE.List purchaseformList = new PURCHASE.List(1);
            purchaseformList.Show();
        }

        private void boxitemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PRE.BOXITEMS.BoxItems purchaseformList = new PRE.BOXITEMS.BoxItems(1);
            purchaseformList.Show();
        }
    }
}
