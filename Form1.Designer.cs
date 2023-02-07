namespace FirstWinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listBox_IpAddresses = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.checkBoxCaseSensetive = new System.Windows.Forms.CheckBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.textBox2input2 = new System.Windows.Forms.TextBox();
            this.textBox1input1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Sensor_Data = new System.Windows.Forms.TabPage();
            this.SensorNameTextLabe2 = new System.Windows.Forms.ComboBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.panelRange = new System.Windows.Forms.Panel();
            this.textBoxURV = new System.Windows.Forms.MaskedTextBox();
            this.textBoxLRV = new System.Windows.Forms.MaskedTextBox();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSummary = new System.Windows.Forms.Button();
            this.vScrollBar3 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.textBoxRegister = new System.Windows.Forms.TextBox();
            this.CommentsTextLabel = new System.Windows.Forms.TextBox();
            this.SensorNameTextLabel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.MeasureTypeLabel = new System.Windows.Forms.ComboBox();
            this.TextBoxOptions = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RegSaveDel = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.SaveChangesButton = new System.Windows.Forms.RadioButton();
            this.RegisterNewButton = new System.Windows.Forms.RadioButton();
            this.SignalTypeLabel = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1Label = new System.Windows.Forms.DateTimePicker();
            this.checkBox1Registerd = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SerialNumberLabel = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.label14 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.Sensor_Data.SuspendLayout();
            this.panelRange.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1160);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(2370, 54);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(99, 41);
            this.toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Location = new System.Drawing.Point(0, 49);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(2370, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listBox_IpAddresses);
            this.tabPage1.Location = new System.Drawing.Point(10, 58);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2301, 974);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Lists";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listBox_IpAddresses
            // 
            this.listBox_IpAddresses.FormattingEnabled = true;
            this.listBox_IpAddresses.ItemHeight = 41;
            this.listBox_IpAddresses.Location = new System.Drawing.Point(20, 22);
            this.listBox_IpAddresses.Name = "listBox_IpAddresses";
            this.listBox_IpAddresses.Size = new System.Drawing.Size(557, 701);
            this.listBox_IpAddresses.TabIndex = 1;
            this.listBox_IpAddresses.SelectedIndexChanged += new System.EventHandler(this.listBox_IpAddresses_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.checkBoxCaseSensetive);
            this.tabPage2.Controls.Add(this.textBoxResult);
            this.tabPage2.Controls.Add(this.textBox2input2);
            this.tabPage2.Controls.Add(this.textBox1input1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(10, 58);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(2301, 974);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Connection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 41);
            this.label13.TabIndex = 7;
            this.label13.Text = "Port";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(158, 41);
            this.label12.TabIndex = 6;
            this.label12.Text = "IP Address";
            // 
            // checkBoxCaseSensetive
            // 
            this.checkBoxCaseSensetive.AutoSize = true;
            this.checkBoxCaseSensetive.Location = new System.Drawing.Point(19, 228);
            this.checkBoxCaseSensetive.Name = "checkBoxCaseSensetive";
            this.checkBoxCaseSensetive.Size = new System.Drawing.Size(264, 45);
            this.checkBoxCaseSensetive.TabIndex = 5;
            this.checkBoxCaseSensetive.Text = "Stay Connected";
            this.checkBoxCaseSensetive.UseVisualStyleBackColor = true;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(622, 36);
            this.textBoxResult.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(310, 518);
            this.textBoxResult.TabIndex = 3;
            // 
            // textBox2input2
            // 
            this.textBox2input2.Location = new System.Drawing.Point(187, 115);
            this.textBox2input2.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.textBox2input2.Name = "textBox2input2";
            this.textBox2input2.Size = new System.Drawing.Size(373, 47);
            this.textBox2input2.TabIndex = 2;
            // 
            // textBox1input1
            // 
            this.textBox1input1.Location = new System.Drawing.Point(187, 36);
            this.textBox1input1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.textBox1input1.Name = "textBox1input1";
            this.textBox1input1.Size = new System.Drawing.Size(378, 47);
            this.textBox1input1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 385);
            this.button1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(546, 175);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Sensor_Data
            // 
            this.Sensor_Data.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Sensor_Data.Controls.Add(this.SensorNameTextLabe2);
            this.Sensor_Data.Controls.Add(this.saveFileButton);
            this.Sensor_Data.Controls.Add(this.buttonOpenFile);
            this.Sensor_Data.Controls.Add(this.panelRange);
            this.Sensor_Data.Controls.Add(this.buttonSummary);
            this.Sensor_Data.Controls.Add(this.vScrollBar3);
            this.Sensor_Data.Controls.Add(this.vScrollBar2);
            this.Sensor_Data.Controls.Add(this.vScrollBar1);
            this.Sensor_Data.Controls.Add(this.textBoxSummary);
            this.Sensor_Data.Controls.Add(this.textBoxRegister);
            this.Sensor_Data.Controls.Add(this.CommentsTextLabel);
            this.Sensor_Data.Controls.Add(this.SensorNameTextLabel);
            this.Sensor_Data.Controls.Add(this.label8);
            this.Sensor_Data.Controls.Add(this.MeasureTypeLabel);
            this.Sensor_Data.Controls.Add(this.TextBoxOptions);
            this.Sensor_Data.Controls.Add(this.groupBox1);
            this.Sensor_Data.Controls.Add(this.SignalTypeLabel);
            this.Sensor_Data.Controls.Add(this.dateTimePicker1Label);
            this.Sensor_Data.Controls.Add(this.checkBox1Registerd);
            this.Sensor_Data.Controls.Add(this.label7);
            this.Sensor_Data.Controls.Add(this.label6);
            this.Sensor_Data.Controls.Add(this.label5);
            this.Sensor_Data.Controls.Add(this.label4);
            this.Sensor_Data.Controls.Add(this.label3);
            this.Sensor_Data.Controls.Add(this.SerialNumberLabel);
            this.Sensor_Data.Controls.Add(this.label2);
            this.Sensor_Data.Controls.Add(this.label1);
            this.Sensor_Data.Location = new System.Drawing.Point(10, 58);
            this.Sensor_Data.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sensor_Data.Name = "Sensor_Data";
            this.Sensor_Data.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Sensor_Data.Size = new System.Drawing.Size(2301, 974);
            this.Sensor_Data.TabIndex = 0;
            this.Sensor_Data.Text = "Sensor Data";
            // 
            // SensorNameTextLabe2
            // 
            this.SensorNameTextLabe2.FormattingEnabled = true;
            this.SensorNameTextLabe2.Location = new System.Drawing.Point(223, 99);
            this.SensorNameTextLabe2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SensorNameTextLabe2.Name = "SensorNameTextLabe2";
            this.SensorNameTextLabe2.Size = new System.Drawing.Size(546, 49);
            this.SensorNameTextLabe2.TabIndex = 25;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(1387, 720);
            this.saveFileButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(335, 57);
            this.saveFileButton.TabIndex = 24;
            this.saveFileButton.Text = "Save File";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(1387, 805);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(335, 57);
            this.buttonOpenFile.TabIndex = 23;
            this.buttonOpenFile.Text = "Open File";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            // 
            // panelRange
            // 
            this.panelRange.Controls.Add(this.textBoxURV);
            this.panelRange.Controls.Add(this.textBoxLRV);
            this.panelRange.Controls.Add(this.textBoxUnit);
            this.panelRange.Controls.Add(this.label11);
            this.panelRange.Controls.Add(this.label9);
            this.panelRange.Controls.Add(this.label10);
            this.panelRange.Location = new System.Drawing.Point(815, 22);
            this.panelRange.Name = "panelRange";
            this.panelRange.Size = new System.Drawing.Size(500, 250);
            this.panelRange.TabIndex = 4;
            // 
            // textBoxURV
            // 
            this.textBoxURV.Location = new System.Drawing.Point(189, 93);
            this.textBoxURV.Name = "textBoxURV";
            this.textBoxURV.Size = new System.Drawing.Size(250, 47);
            this.textBoxURV.TabIndex = 20;
            // 
            // textBoxLRV
            // 
            this.textBoxLRV.Location = new System.Drawing.Point(189, 21);
            this.textBoxLRV.Name = "textBoxLRV";
            this.textBoxLRV.Size = new System.Drawing.Size(250, 47);
            this.textBoxLRV.TabIndex = 19;
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(189, 169);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(250, 47);
            this.textBoxUnit.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 41);
            this.label11.TabIndex = 15;
            this.label11.Text = "Unit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 41);
            this.label9.TabIndex = 13;
            this.label9.Text = "LRV";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 41);
            this.label10.TabIndex = 14;
            this.label10.Text = "URV";
            // 
            // buttonSummary
            // 
            this.buttonSummary.Location = new System.Drawing.Point(1794, 805);
            this.buttonSummary.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSummary.Name = "buttonSummary";
            this.buttonSummary.Size = new System.Drawing.Size(380, 57);
            this.buttonSummary.TabIndex = 22;
            this.buttonSummary.Text = "SUMMARY";
            this.buttonSummary.UseVisualStyleBackColor = true;
            this.buttonSummary.Click += new System.EventHandler(this.buttonSummary_Click_1);
            // 
            // vScrollBar3
            // 
            this.vScrollBar3.Location = new System.Drawing.Point(2121, 22);
            this.vScrollBar3.Name = "vScrollBar3";
            this.vScrollBar3.Size = new System.Drawing.Size(40, 759);
            this.vScrollBar3.TabIndex = 21;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(1704, 22);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(43, 665);
            this.vScrollBar2.TabIndex = 20;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(715, 530);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(41, 171);
            this.vScrollBar1.TabIndex = 19;
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Location = new System.Drawing.Point(1794, 22);
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.ReadOnly = true;
            this.textBoxSummary.Size = new System.Drawing.Size(367, 755);
            this.textBoxSummary.TabIndex = 5;
            // 
            // textBoxRegister
            // 
            this.textBoxRegister.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRegister.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBoxRegister.Location = new System.Drawing.Point(1367, 22);
            this.textBoxRegister.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxRegister.Multiline = true;
            this.textBoxRegister.Name = "textBoxRegister";
            this.textBoxRegister.ReadOnly = true;
            this.textBoxRegister.Size = new System.Drawing.Size(380, 665);
            this.textBoxRegister.TabIndex = 9;
            // 
            // CommentsTextLabel
            // 
            this.CommentsTextLabel.Location = new System.Drawing.Point(223, 720);
            this.CommentsTextLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CommentsTextLabel.Multiline = true;
            this.CommentsTextLabel.Name = "CommentsTextLabel";
            this.CommentsTextLabel.Size = new System.Drawing.Size(533, 247);
            this.CommentsTextLabel.TabIndex = 7;
            // 
            // SensorNameTextLabel
            // 
            this.SensorNameTextLabel.Location = new System.Drawing.Point(223, 22);
            this.SensorNameTextLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SensorNameTextLabel.Name = "SensorNameTextLabel";
            this.SensorNameTextLabel.Size = new System.Drawing.Size(546, 47);
            this.SensorNameTextLabel.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 463);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 41);
            this.label8.TabIndex = 11;
            this.label8.Text = "Measure Type";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // MeasureTypeLabel
            // 
            this.MeasureTypeLabel.FormattingEnabled = true;
            this.MeasureTypeLabel.Items.AddRange(new object[] {
            "4-20ma",
            "0-10VDC",
            "0.5DC"});
            this.MeasureTypeLabel.Location = new System.Drawing.Point(223, 463);
            this.MeasureTypeLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MeasureTypeLabel.Name = "MeasureTypeLabel";
            this.MeasureTypeLabel.Size = new System.Drawing.Size(546, 49);
            this.MeasureTypeLabel.TabIndex = 10;
            // 
            // TextBoxOptions
            // 
            this.TextBoxOptions.FormattingEnabled = true;
            this.TextBoxOptions.ItemHeight = 41;
            this.TextBoxOptions.Items.AddRange(new object[] {
            "None",
            "Display",
            "HART Protocol"});
            this.TextBoxOptions.Location = new System.Drawing.Point(223, 530);
            this.TextBoxOptions.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextBoxOptions.Name = "TextBoxOptions";
            this.TextBoxOptions.Size = new System.Drawing.Size(533, 168);
            this.TextBoxOptions.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RegSaveDel);
            this.groupBox1.Controls.Add(this.DeleteButton);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.SaveChangesButton);
            this.groupBox1.Controls.Add(this.RegisterNewButton);
            this.groupBox1.Location = new System.Drawing.Point(827, 463);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(488, 429);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // RegSaveDel
            // 
            this.RegSaveDel.Location = new System.Drawing.Point(38, 356);
            this.RegSaveDel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RegSaveDel.Name = "RegSaveDel";
            this.RegSaveDel.Size = new System.Drawing.Size(335, 57);
            this.RegSaveDel.TabIndex = 3;
            this.RegSaveDel.Text = "Rregister New";
            this.RegSaveDel.UseVisualStyleBackColor = true;
            this.RegSaveDel.Click += new System.EventHandler(this.RegSaveDel_Click_1);
            // 
            // DeleteButton
            // 
            this.DeleteButton.AutoSize = true;
            this.DeleteButton.Location = new System.Drawing.Point(44, 216);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(141, 45);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.TabStop = true;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(-328, 951);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(228, 45);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // SaveChangesButton
            // 
            this.SaveChangesButton.AutoSize = true;
            this.SaveChangesButton.Location = new System.Drawing.Point(44, 150);
            this.SaveChangesButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SaveChangesButton.Name = "SaveChangesButton";
            this.SaveChangesButton.Size = new System.Drawing.Size(239, 45);
            this.SaveChangesButton.TabIndex = 1;
            this.SaveChangesButton.TabStop = true;
            this.SaveChangesButton.Text = "Save Changes";
            this.SaveChangesButton.UseVisualStyleBackColor = true;
            // 
            // RegisterNewButton
            // 
            this.RegisterNewButton.AutoSize = true;
            this.RegisterNewButton.Location = new System.Drawing.Point(44, 82);
            this.RegisterNewButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.RegisterNewButton.Name = "RegisterNewButton";
            this.RegisterNewButton.Size = new System.Drawing.Size(230, 45);
            this.RegisterNewButton.TabIndex = 0;
            this.RegisterNewButton.TabStop = true;
            this.RegisterNewButton.Text = "Register New";
            this.RegisterNewButton.UseVisualStyleBackColor = true;
            // 
            // SignalTypeLabel
            // 
            this.SignalTypeLabel.FormattingEnabled = true;
            this.SignalTypeLabel.Items.AddRange(new object[] {
            "Analog",
            "Digital",
            "Fieldbus"});
            this.SignalTypeLabel.Location = new System.Drawing.Point(223, 396);
            this.SignalTypeLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SignalTypeLabel.Name = "SignalTypeLabel";
            this.SignalTypeLabel.Size = new System.Drawing.Size(546, 49);
            this.SignalTypeLabel.TabIndex = 5;
            this.SignalTypeLabel.SelectedIndexChanged += new System.EventHandler(this.SignalTypeLabel_SelectedIndexChanged);
            // 
            // dateTimePicker1Label
            // 
            this.dateTimePicker1Label.Location = new System.Drawing.Point(223, 327);
            this.dateTimePicker1Label.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dateTimePicker1Label.Name = "dateTimePicker1Label";
            this.dateTimePicker1Label.Size = new System.Drawing.Size(546, 47);
            this.dateTimePicker1Label.TabIndex = 4;
            // 
            // checkBox1Registerd
            // 
            this.checkBox1Registerd.AutoSize = true;
            this.checkBox1Registerd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.checkBox1Registerd.Location = new System.Drawing.Point(223, 274);
            this.checkBox1Registerd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox1Registerd.Name = "checkBox1Registerd";
            this.checkBox1Registerd.Size = new System.Drawing.Size(34, 33);
            this.checkBox1Registerd.TabIndex = 3;
            this.checkBox1Registerd.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 720);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 41);
            this.label7.TabIndex = 8;
            this.label7.Text = "Comments";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 530);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 41);
            this.label6.TabIndex = 7;
            this.label6.Text = "Options";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 396);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 41);
            this.label5.TabIndex = 6;
            this.label5.Text = "Signal Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 41);
            this.label4.TabIndex = 5;
            this.label4.Text = "Reg Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 266);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 41);
            this.label3.TabIndex = 4;
            this.label3.Text = "Registerd";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SerialNumberLabel
            // 
            this.SerialNumberLabel.Location = new System.Drawing.Point(210, 212);
            this.SerialNumberLabel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.SerialNumberLabel.Mask = "000-00-0000";
            this.SerialNumberLabel.Name = "SerialNumberLabel";
            this.SerialNumberLabel.Size = new System.Drawing.Size(546, 47);
            this.SerialNumberLabel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 212);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 41);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial Number";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sensor Name";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.Sensor_Data);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Location = new System.Drawing.Point(0, 53);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(2321, 1042);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1669, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 41);
            this.label14.TabIndex = 5;
            this.label14.Text = "File";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2370, 49);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(87, 45);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(104, 45);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2370, 1214);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.Sensor_Data.ResumeLayout(false);
            this.Sensor_Data.PerformLayout();
            this.panelRange.ResumeLayout(false);
            this.panelRange.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private PrintDialog printDialog1;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private CheckBox checkBoxCaseSensetive;
        private TextBox textBoxResult;
        private TextBox textBox2input2;
        private TextBox textBox1input1;
        private Button button1;
        private TabPage Sensor_Data;
        private Panel panelRange;
        private TextBox textBoxUnit;
        private Label label11;
        private Label label9;
        private Label label10;
        private Button buttonSummary;
        private VScrollBar vScrollBar3;
        private VScrollBar vScrollBar2;
        private VScrollBar vScrollBar1;
        private TextBox textBoxSummary;
        private TextBox textBoxRegister;
        private TextBox CommentsTextLabel;
        private TextBox SensorNameTextLabel;
        private Label label8;
        private ComboBox MeasureTypeLabel;
        private ListBox TextBoxOptions;
        private GroupBox groupBox1;
        private Button RegSaveDel;
        private RadioButton DeleteButton;
        private RadioButton radioButton3;
        private RadioButton SaveChangesButton;
        private RadioButton RegisterNewButton;
        private ComboBox SignalTypeLabel;
        private DateTimePicker dateTimePicker1Label;
        private CheckBox checkBox1Registerd;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private MaskedTextBox SerialNumberLabel;
        private Label label2;
        private Label label1;
        private TabControl tabControl2;
        private MaskedTextBox textBoxURV;
        private MaskedTextBox textBoxLRV;
        private ListBox listBox_IpAddresses;
        private Label label13;
        private Label label12;
        private Button buttonOpenFile;
        private Label label14;
        private Button saveFileButton;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ComboBox SensorNameTextLabe2;
    }
}