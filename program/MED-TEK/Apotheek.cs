﻿using System;
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
    public partial class Apotheek : Form
    {
        Connect verbinding;
        public Apotheek(Connect _verbiding)
        {
            InitializeComponent();
            verbinding = _verbiding;
        }

        private void Apotheek_Load(object sender, EventArgs e)
        {

        }
    }
}
