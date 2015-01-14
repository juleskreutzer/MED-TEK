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
    public partial class Psycholoog : Form
    {
        Connect verbinding;
        public Psycholoog(Connect _verbinding)
        {
            InitializeComponent();
            verbinding = _verbinding;
        }
    }
}
