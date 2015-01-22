namespace MED_TEK
{
    partial class Doctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox groupBox7;
            this.btnMedicatieToevoegen = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.tbHoeveelheid = new System.Windows.Forms.TextBox();
            this.dtpGebruikEind = new System.Windows.Forms.DateTimePicker();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.dtpGebruikStart = new System.Windows.Forms.DateTimePicker();
            this.cbMedicijn = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cbPatientMedicatie = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbSymptomen = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.btnKoppelZiekte = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cbZiekte = new System.Windows.Forms.ComboBox();
            this.cbPatient = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnResetZiekte = new System.Windows.Forms.Button();
            this.btnAddZiekte = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tbZiekte = new System.Windows.Forms.TextBox();
            this.linkAfmelden = new System.Windows.Forms.LinkLabel();
            this.linkProgramAfmelden = new System.Windows.Forms.LinkLabel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbActief = new System.Windows.Forms.CheckBox();
            this.dtpTijd = new System.Windows.Forms.DateTimePicker();
            this.btnClearAfspraak = new System.Windows.Forms.Button();
            this.btnAfspraak = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.dtpAfspraak = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.cbLocAfspraak = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbMedicatie = new System.Windows.Forms.ListBox();
            this.lbZiektes = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbBloedGroep = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpGeboorte = new System.Windows.Forms.DateTimePicker();
            this.tbAdres = new System.Windows.Forms.TextBox();
            this.tbAchternaam = new System.Windows.Forms.TextBox();
            this.tbVoorNamen = new System.Windows.Forms.TextBox();
            this.pbPasfoto = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            groupBox7 = new System.Windows.Forms.GroupBox();
            groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPasfoto)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(this.btnMedicatieToevoegen);
            groupBox7.Controls.Add(this.label32);
            groupBox7.Controls.Add(this.tbHoeveelheid);
            groupBox7.Controls.Add(this.dtpGebruikEind);
            groupBox7.Controls.Add(this.label31);
            groupBox7.Controls.Add(this.label30);
            groupBox7.Controls.Add(this.dtpGebruikStart);
            groupBox7.Controls.Add(this.cbMedicijn);
            groupBox7.Controls.Add(this.label29);
            groupBox7.Controls.Add(this.label28);
            groupBox7.Controls.Add(this.cbPatientMedicatie);
            groupBox7.Location = new System.Drawing.Point(832, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(342, 275);
            groupBox7.TabIndex = 35;
            groupBox7.TabStop = false;
            groupBox7.Text = "Medicatie toevoegen voor patient";
            // 
            // btnMedicatieToevoegen
            // 
            this.btnMedicatieToevoegen.Location = new System.Drawing.Point(166, 232);
            this.btnMedicatieToevoegen.Name = "btnMedicatieToevoegen";
            this.btnMedicatieToevoegen.Size = new System.Drawing.Size(161, 23);
            this.btnMedicatieToevoegen.TabIndex = 21;
            this.btnMedicatieToevoegen.Text = "Medicatie Toevoegen";
            this.btnMedicatieToevoegen.UseVisualStyleBackColor = true;
            this.btnMedicatieToevoegen.Click += new System.EventHandler(this.btnMedicatieToevoegen_Click_1);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(19, 193);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 13);
            this.label32.TabIndex = 39;
            this.label32.Text = "Hoeveelheid";
            // 
            // tbHoeveelheid
            // 
            this.tbHoeveelheid.Location = new System.Drawing.Point(127, 188);
            this.tbHoeveelheid.Name = "tbHoeveelheid";
            this.tbHoeveelheid.Size = new System.Drawing.Size(200, 20);
            this.tbHoeveelheid.TabIndex = 38;
            // 
            // dtpGebruikEind
            // 
            this.dtpGebruikEind.Location = new System.Drawing.Point(127, 158);
            this.dtpGebruikEind.Name = "dtpGebruikEind";
            this.dtpGebruikEind.Size = new System.Drawing.Size(200, 20);
            this.dtpGebruikEind.TabIndex = 37;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(19, 164);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 13);
            this.label31.TabIndex = 36;
            this.label31.Text = "Gebruik Einde";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(19, 130);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(69, 13);
            this.label30.TabIndex = 35;
            this.label30.Text = "Gebruik Start";
            // 
            // dtpGebruikStart
            // 
            this.dtpGebruikStart.Location = new System.Drawing.Point(127, 124);
            this.dtpGebruikStart.Name = "dtpGebruikStart";
            this.dtpGebruikStart.Size = new System.Drawing.Size(200, 20);
            this.dtpGebruikStart.TabIndex = 34;
            // 
            // cbMedicijn
            // 
            this.cbMedicijn.FormattingEnabled = true;
            this.cbMedicijn.Location = new System.Drawing.Point(127, 83);
            this.cbMedicijn.Name = "cbMedicijn";
            this.cbMedicijn.Size = new System.Drawing.Size(200, 21);
            this.cbMedicijn.TabIndex = 33;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(19, 90);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(46, 13);
            this.label29.TabIndex = 32;
            this.label29.Text = "Medicijn";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(19, 44);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(40, 13);
            this.label28.TabIndex = 31;
            this.label28.Text = "Patient";
            // 
            // cbPatientMedicatie
            // 
            this.cbPatientMedicatie.FormattingEnabled = true;
            this.cbPatientMedicatie.Location = new System.Drawing.Point(127, 40);
            this.cbPatientMedicatie.Name = "cbPatientMedicatie";
            this.cbPatientMedicatie.Size = new System.Drawing.Size(200, 21);
            this.cbPatientMedicatie.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.linkAfmelden);
            this.panel1.Controls.Add(this.linkProgramAfmelden);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(groupBox7);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1660, 903);
            this.panel1.TabIndex = 33;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbSymptomen);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.btnKoppelZiekte);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.label22);
            this.groupBox5.Controls.Add(this.cbZiekte);
            this.groupBox5.Controls.Add(this.cbPatient);
            this.groupBox5.Location = new System.Drawing.Point(1205, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(386, 210);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ziekte aan patient koppelen";
            // 
            // tbSymptomen
            // 
            this.tbSymptomen.Location = new System.Drawing.Point(170, 115);
            this.tbSymptomen.Multiline = true;
            this.tbSymptomen.Name = "tbSymptomen";
            this.tbSymptomen.Size = new System.Drawing.Size(200, 48);
            this.tbSymptomen.TabIndex = 23;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(24, 123);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(62, 13);
            this.label33.TabIndex = 22;
            this.label33.Text = "Symptomen";
            // 
            // btnKoppelZiekte
            // 
            this.btnKoppelZiekte.Location = new System.Drawing.Point(209, 181);
            this.btnKoppelZiekte.Name = "btnKoppelZiekte";
            this.btnKoppelZiekte.Size = new System.Drawing.Size(161, 23);
            this.btnKoppelZiekte.TabIndex = 21;
            this.btnKoppelZiekte.Text = "Ziekte koppelen";
            this.btnKoppelZiekte.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(24, 86);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 13);
            this.label23.TabIndex = 3;
            this.label23.Text = "Ziekte naam";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "Patient naam";
            // 
            // cbZiekte
            // 
            this.cbZiekte.FormattingEnabled = true;
            this.cbZiekte.Location = new System.Drawing.Point(170, 78);
            this.cbZiekte.Name = "cbZiekte";
            this.cbZiekte.Size = new System.Drawing.Size(200, 21);
            this.cbZiekte.TabIndex = 1;
            // 
            // cbPatient
            // 
            this.cbPatient.FormattingEnabled = true;
            this.cbPatient.Location = new System.Drawing.Point(170, 39);
            this.cbPatient.Name = "cbPatient";
            this.cbPatient.Size = new System.Drawing.Size(200, 21);
            this.cbPatient.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnResetZiekte);
            this.groupBox3.Controls.Add(this.btnAddZiekte);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.tbZiekte);
            this.groupBox3.Location = new System.Drawing.Point(413, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(369, 122);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nieuwe ziekte toevoegen";
            // 
            // btnResetZiekte
            // 
            this.btnResetZiekte.Location = new System.Drawing.Point(7, 93);
            this.btnResetZiekte.Name = "btnResetZiekte";
            this.btnResetZiekte.Size = new System.Drawing.Size(161, 23);
            this.btnResetZiekte.TabIndex = 20;
            this.btnResetZiekte.Text = "Veld wissen";
            this.btnResetZiekte.UseVisualStyleBackColor = true;
            // 
            // btnAddZiekte
            // 
            this.btnAddZiekte.Location = new System.Drawing.Point(186, 93);
            this.btnAddZiekte.Name = "btnAddZiekte";
            this.btnAddZiekte.Size = new System.Drawing.Size(161, 23);
            this.btnAddZiekte.TabIndex = 19;
            this.btnAddZiekte.Text = "Ziekte toevoegen";
            this.btnAddZiekte.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Naam ziekte";
            // 
            // tbZiekte
            // 
            this.tbZiekte.Location = new System.Drawing.Point(147, 45);
            this.tbZiekte.Name = "tbZiekte";
            this.tbZiekte.Size = new System.Drawing.Size(200, 20);
            this.tbZiekte.TabIndex = 18;
            // 
            // linkAfmelden
            // 
            this.linkAfmelden.AutoSize = true;
            this.linkAfmelden.Location = new System.Drawing.Point(35, 589);
            this.linkAfmelden.Name = "linkAfmelden";
            this.linkAfmelden.Size = new System.Drawing.Size(86, 13);
            this.linkAfmelden.TabIndex = 38;
            this.linkAfmelden.TabStop = true;
            this.linkAfmelden.Text = "Patient afmelden";
            this.linkAfmelden.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAfmelden_LinkClicked_1);
            // 
            // linkProgramAfmelden
            // 
            this.linkProgramAfmelden.AutoSize = true;
            this.linkProgramAfmelden.Location = new System.Drawing.Point(147, 589);
            this.linkProgramAfmelden.Name = "linkProgramAfmelden";
            this.linkProgramAfmelden.Size = new System.Drawing.Size(119, 13);
            this.linkProgramAfmelden.TabIndex = 37;
            this.linkProgramAfmelden.TabStop = true;
            this.linkProgramAfmelden.Text = "Afmelden bij programma";
            this.linkProgramAfmelden.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkProgramAfmelden_LinkClicked_1);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbActief);
            this.groupBox6.Controls.Add(this.dtpTijd);
            this.groupBox6.Controls.Add(this.btnClearAfspraak);
            this.groupBox6.Controls.Add(this.btnAfspraak);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.dtpAfspraak);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.cbLocAfspraak);
            this.groupBox6.Location = new System.Drawing.Point(832, 305);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(342, 159);
            this.groupBox6.TabIndex = 36;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nieuwe afspraak toevoegen";
            // 
            // cbActief
            // 
            this.cbActief.AutoSize = true;
            this.cbActief.Location = new System.Drawing.Point(127, 105);
            this.cbActief.Name = "cbActief";
            this.cbActief.Size = new System.Drawing.Size(103, 17);
            this.cbActief.TabIndex = 26;
            this.cbActief.Text = "Afspraak actief?";
            this.cbActief.UseVisualStyleBackColor = true;
            // 
            // dtpTijd
            // 
            this.dtpTijd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTijd.Location = new System.Drawing.Point(127, 78);
            this.dtpTijd.Name = "dtpTijd";
            this.dtpTijd.Size = new System.Drawing.Size(200, 20);
            this.dtpTijd.TabIndex = 25;
            // 
            // btnClearAfspraak
            // 
            this.btnClearAfspraak.Location = new System.Drawing.Point(30, 128);
            this.btnClearAfspraak.Name = "btnClearAfspraak";
            this.btnClearAfspraak.Size = new System.Drawing.Size(124, 23);
            this.btnClearAfspraak.TabIndex = 24;
            this.btnClearAfspraak.Text = "Alle velden wissen";
            this.btnClearAfspraak.UseVisualStyleBackColor = true;
            // 
            // btnAfspraak
            // 
            this.btnAfspraak.Location = new System.Drawing.Point(166, 130);
            this.btnAfspraak.Name = "btnAfspraak";
            this.btnAfspraak.Size = new System.Drawing.Size(161, 23);
            this.btnAfspraak.TabIndex = 22;
            this.btnAfspraak.Text = "Nieuwe afspraak toevoegen";
            this.btnAfspraak.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(27, 81);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(24, 13);
            this.label27.TabIndex = 7;
            this.label27.Text = "Tijd";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(24, 54);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 13);
            this.label26.TabIndex = 6;
            this.label26.Text = "Datum";
            // 
            // dtpAfspraak
            // 
            this.dtpAfspraak.Location = new System.Drawing.Point(127, 51);
            this.dtpAfspraak.Name = "dtpAfspraak";
            this.dtpAfspraak.Size = new System.Drawing.Size(200, 20);
            this.dtpAfspraak.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(24, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(42, 13);
            this.label25.TabIndex = 3;
            this.label25.Text = "Locatie";
            // 
            // cbLocAfspraak
            // 
            this.cbLocAfspraak.FormattingEnabled = true;
            this.cbLocAfspraak.Location = new System.Drawing.Point(127, 24);
            this.cbLocAfspraak.Name = "cbLocAfspraak";
            this.cbLocAfspraak.Size = new System.Drawing.Size(200, 21);
            this.cbLocAfspraak.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbMedicatie);
            this.groupBox1.Controls.Add(this.lbZiektes);
            this.groupBox1.Location = new System.Drawing.Point(413, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 292);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ziekte Patient";
            // 
            // lbMedicatie
            // 
            this.lbMedicatie.FormattingEnabled = true;
            this.lbMedicatie.Location = new System.Drawing.Point(7, 130);
            this.lbMedicatie.Name = "lbMedicatie";
            this.lbMedicatie.Size = new System.Drawing.Size(356, 134);
            this.lbMedicatie.TabIndex = 1;
            // 
            // lbZiektes
            // 
            this.lbZiektes.FormattingEnabled = true;
            this.lbZiektes.Location = new System.Drawing.Point(6, 25);
            this.lbZiektes.Name = "lbZiektes";
            this.lbZiektes.Size = new System.Drawing.Size(357, 95);
            this.lbZiektes.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbBloedGroep);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpGeboorte);
            this.groupBox2.Controls.Add(this.tbAdres);
            this.groupBox2.Controls.Add(this.tbAchternaam);
            this.groupBox2.Controls.Add(this.tbVoorNamen);
            this.groupBox2.Controls.Add(this.pbPasfoto);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 563);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Patiënt gegevens";
            // 
            // tbBloedGroep
            // 
            this.tbBloedGroep.Location = new System.Drawing.Point(188, 176);
            this.tbBloedGroep.Name = "tbBloedGroep";
            this.tbBloedGroep.ReadOnly = true;
            this.tbBloedGroep.Size = new System.Drawing.Size(150, 20);
            this.tbBloedGroep.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Bloedgroep";
            // 
            // dtpGeboorte
            // 
            this.dtpGeboorte.Location = new System.Drawing.Point(188, 112);
            this.dtpGeboorte.Name = "dtpGeboorte";
            this.dtpGeboorte.Size = new System.Drawing.Size(150, 20);
            this.dtpGeboorte.TabIndex = 14;
            // 
            // tbAdres
            // 
            this.tbAdres.Location = new System.Drawing.Point(188, 146);
            this.tbAdres.Name = "tbAdres";
            this.tbAdres.ReadOnly = true;
            this.tbAdres.Size = new System.Drawing.Size(150, 20);
            this.tbAdres.TabIndex = 11;
            // 
            // tbAchternaam
            // 
            this.tbAchternaam.Location = new System.Drawing.Point(188, 86);
            this.tbAchternaam.Name = "tbAchternaam";
            this.tbAchternaam.ReadOnly = true;
            this.tbAchternaam.Size = new System.Drawing.Size(150, 20);
            this.tbAchternaam.TabIndex = 9;
            // 
            // tbVoorNamen
            // 
            this.tbVoorNamen.Location = new System.Drawing.Point(188, 48);
            this.tbVoorNamen.Name = "tbVoorNamen";
            this.tbVoorNamen.ReadOnly = true;
            this.tbVoorNamen.Size = new System.Drawing.Size(150, 20);
            this.tbVoorNamen.TabIndex = 8;
            // 
            // pbPasfoto
            // 
            this.pbPasfoto.Location = new System.Drawing.Point(35, 222);
            this.pbPasfoto.Name = "pbPasfoto";
            this.pbPasfoto.Size = new System.Drawing.Size(321, 262);
            this.pbPasfoto.TabIndex = 6;
            this.pbPasfoto.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Adres";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Geboortedatum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Achternaam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voornamen";
            // 
            // Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1684, 927);
            this.Controls.Add(this.panel1);
            this.Name = "Doctor";
            this.Text = "Doctor";
            this.Load += new System.EventHandler(this.Doctor_Load);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPasfoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbSymptomen;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Button btnKoppelZiekte;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbZiekte;
        private System.Windows.Forms.ComboBox cbPatient;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnResetZiekte;
        private System.Windows.Forms.Button btnAddZiekte;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbZiekte;
        private System.Windows.Forms.LinkLabel linkAfmelden;
        private System.Windows.Forms.LinkLabel linkProgramAfmelden;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbActief;
        private System.Windows.Forms.DateTimePicker dtpTijd;
        private System.Windows.Forms.Button btnClearAfspraak;
        private System.Windows.Forms.Button btnAfspraak;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.DateTimePicker dtpAfspraak;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cbLocAfspraak;
        private System.Windows.Forms.Button btnMedicatieToevoegen;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbHoeveelheid;
        private System.Windows.Forms.DateTimePicker dtpGebruikEind;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DateTimePicker dtpGebruikStart;
        private System.Windows.Forms.ComboBox cbMedicijn;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cbPatientMedicatie;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbMedicatie;
        private System.Windows.Forms.ListBox lbZiektes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbBloedGroep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpGeboorte;
        private System.Windows.Forms.TextBox tbAdres;
        private System.Windows.Forms.TextBox tbAchternaam;
        private System.Windows.Forms.TextBox tbVoorNamen;
        private System.Windows.Forms.PictureBox pbPasfoto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}