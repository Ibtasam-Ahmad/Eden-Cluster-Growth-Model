using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdenClusterModel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        // button1_Click is the event handler
        {
            EdenCluster cluster = new EdenCluster(this);
            cluster.Growth(false);
            textBox1.Refresh();
            //this the event that is going to occur
        }
    }
}
