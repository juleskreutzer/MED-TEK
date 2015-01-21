using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MED_TEK
{
    public partial class Doctor : Form
    {
        Connect verbinding;
        public Doctor(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }

        private void Doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
