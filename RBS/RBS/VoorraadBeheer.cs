using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBS
{
    public partial class VoorraadBeheer : Form
    {
        //private TabControl tabControl1;
        private TabPage personeelszaken;
        private TabPage klachten;
        private TabPage voorraad;
        private TabPage tafels;

        private void MyTabs()
        {
            
            this.personeelszaken = new TabPage();
            this.klachten = new TabPage();
            this.voorraad = new TabPage();
            this.tafels = new TabPage();
        }

          

        private ProductDAO dao;
        
        public VoorraadBeheer()
        {
            
            InitializeComponent();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            InlogScherm Check = new InlogScherm();
            Check.Show();
            Hide();
        }
    }    
}

