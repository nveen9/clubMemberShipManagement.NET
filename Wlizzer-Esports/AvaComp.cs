using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wlizzer_Esports
{
    public partial class AvaComp : Form
    {
        public AvaComp()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonJoin_Click(object sender, EventArgs e)
        {
            Comp cp = new Comp();
            this.Hide();
            cp.Show();
        }
    }
}
