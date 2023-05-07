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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            printDialog1 = new PrintDialog();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            tabPage1 = new TabPage();
            label23 = new Label();
            button1 = new Button();
            label16 = new Label();
            listBox_IpAddresses = new ListBox();
            tabPage2 = new TabPage();
            label21 = new Label();
            label19 = new Label();
            diconnectButton = new Button();
            testConnectionButton = new Button();
            testButton = new Button();
            comboBoxBaudRate = new ComboBox();
            comboBoxComPort = new ComboBox();
            label20 = new Label();
            Comport = new Label();
            buttonWriteConf = new Button();
            buttonReadScaled = new Button();
            buttonReadState = new Button();
            buttonReadConfiguration = new Button();
            textBoxSend = new TextBox();
            label13 = new Label();
            label12 = new Label();
            textBoxCommunication = new TextBox();
            textBoxPort = new TextBox();
            textBoxIP = new TextBox();
            buttonSend = new Button();
            Sensor_Data = new TabPage();
            label22 = new Label();
            comboBoxLocation = new ComboBox();
            radioButtonInstrumentID = new RadioButton();
            textBoxInstrumentID = new TextBox();
            label18 = new Label();
            textBoxLocation = new TextBox();
            textLabelLocation = new Label();
            panel1 = new Panel();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label17 = new Label();
            comboBoxSenorName = new ComboBox();
            clearButton = new Button();
            registerNewButton = new Button();
            deleButton = new Button();
            saveChangesButton = new Button();
            comboBoxInstrumentName = new ComboBox();
            buttonOpenFile = new Button();
            panelRange = new Panel();
            label15 = new Label();
            label14 = new Label();
            textBoxAlarmLow = new TextBox();
            textBoxAlarmHigh = new TextBox();
            textBoxURV = new MaskedTextBox();
            textBoxLRV = new MaskedTextBox();
            textBoxUnit = new TextBox();
            label11 = new Label();
            label9 = new Label();
            label10 = new Label();
            buttonSummary = new Button();
            textBoxSummary = new TextBox();
            textBoxRegister = new TextBox();
            CommentsTextLabel = new TextBox();
            label8 = new Label();
            MeasureTypeLabel = new ComboBox();
            TextBoxOptions = new ListBox();
            SignalTypeLabel = new ComboBox();
            dateTimePicker1Label = new DateTimePicker();
            checkBox1Registerd = new CheckBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            SerialNumberLabel = new MaskedTextBox();
            label2 = new Label();
            label1 = new Label();
            tabControl2 = new TabControl();
            tabPage3 = new TabPage();
            label24 = new Label();
            groupBox2 = new GroupBox();
            labelConnecionOK = new Label();
            textBoxChart = new TextBox();
            disconnectButtonAddXY = new Button();
            buttonAddXY = new Button();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            timerRedaScaled = new System.Windows.Forms.Timer(components);
            bindingSource1 = new BindingSource(components);
            bindingSourceInstrument = new BindingSource(components);
            bindingSourceAnalogRange = new BindingSource(components);
            bindingSourceMeasurementType = new BindingSource(components);
            bindingSourceSignalType = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            statusStrip1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            Sensor_Data.SuspendLayout();
            panel1.SuspendLayout();
            panelRange.SuspendLayout();
            tabControl2.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceInstrument).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceAnalogRange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceMeasurementType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSignalType).BeginInit();
            SuspendLayout();
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(40, 40);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 1387);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(0, 0, 15, 0);
            statusStrip1.Size = new Size(2415, 54);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(99, 41);
            toolStripStatusLabel1.Text = "Ready";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(40, 40);
            toolStrip1.Location = new Point(0, 45);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0);
            toolStrip1.Size = new Size(2415, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label23);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label16);
            tabPage1.Controls.Add(listBox_IpAddresses);
            tabPage1.Location = new Point(10, 58);
            tabPage1.Margin = new Padding(2, 3, 2, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(2, 3, 2, 3);
            tabPage1.Size = new Size(2328, 1027);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Lists";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label23.ForeColor = Color.GreenYellow;
            label23.Location = new Point(30, 201);
            label23.Name = "label23";
            label23.Size = new Size(221, 41);
            label23.TabIndex = 25;
            label23.Text = "BE Connected";
            label23.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(30, 115);
            button1.Name = "button1";
            button1.Size = new Size(188, 58);
            button1.TabIndex = 3;
            button1.Text = "LINQuery";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(257, 26);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(285, 41);
            label16.TabIndex = 2;
            label16.Text = "Networkinformation";
            // 
            // listBox_IpAddresses
            // 
            listBox_IpAddresses.FormattingEnabled = true;
            listBox_IpAddresses.ItemHeight = 41;
            listBox_IpAddresses.Location = new Point(257, 115);
            listBox_IpAddresses.Margin = new Padding(2, 3, 2, 3);
            listBox_IpAddresses.Name = "listBox_IpAddresses";
            listBox_IpAddresses.Size = new Size(1422, 701);
            listBox_IpAddresses.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label21);
            tabPage2.Controls.Add(label19);
            tabPage2.Controls.Add(diconnectButton);
            tabPage2.Controls.Add(testConnectionButton);
            tabPage2.Controls.Add(testButton);
            tabPage2.Controls.Add(comboBoxBaudRate);
            tabPage2.Controls.Add(comboBoxComPort);
            tabPage2.Controls.Add(label20);
            tabPage2.Controls.Add(Comport);
            tabPage2.Controls.Add(buttonWriteConf);
            tabPage2.Controls.Add(buttonReadScaled);
            tabPage2.Controls.Add(buttonReadState);
            tabPage2.Controls.Add(buttonReadConfiguration);
            tabPage2.Controls.Add(textBoxSend);
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(textBoxCommunication);
            tabPage2.Controls.Add(textBoxPort);
            tabPage2.Controls.Add(textBoxIP);
            tabPage2.Controls.Add(buttonSend);
            tabPage2.Location = new Point(10, 58);
            tabPage2.Margin = new Padding(2, 3, 2, 3);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(2, 3, 2, 3);
            tabPage2.Size = new Size(2328, 1027);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Connection";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label21.ForeColor = Color.GreenYellow;
            label21.Location = new Point(499, 198);
            label21.Name = "label21";
            label21.Size = new Size(221, 41);
            label21.TabIndex = 24;
            label21.Text = "BE Connected";
            label21.Visible = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(166, -65);
            label19.Name = "label19";
            label19.Size = new Size(113, 41);
            label19.TabIndex = 23;
            label19.Text = "label19";
            // 
            // diconnectButton
            // 
            diconnectButton.Location = new Point(279, 189);
            diconnectButton.Name = "diconnectButton";
            diconnectButton.Size = new Size(188, 58);
            diconnectButton.TabIndex = 22;
            diconnectButton.Text = "Disconnect";
            diconnectButton.UseVisualStyleBackColor = true;
            diconnectButton.Click += diconnectButton_Click;
            // 
            // testConnectionButton
            // 
            testConnectionButton.Location = new Point(66, 189);
            testConnectionButton.Name = "testConnectionButton";
            testConnectionButton.Size = new Size(172, 58);
            testConnectionButton.TabIndex = 21;
            testConnectionButton.Text = "Connect";
            testConnectionButton.UseVisualStyleBackColor = true;
            testConnectionButton.Click += testConnectionButton_Click;
            // 
            // testButton
            // 
            testButton.Location = new Point(1899, 38);
            testButton.Margin = new Padding(2, 3, 2, 3);
            testButton.Name = "testButton";
            testButton.Size = new Size(243, 57);
            testButton.TabIndex = 9;
            testButton.Text = "Get Com Ports";
            testButton.UseVisualStyleBackColor = true;
            testButton.Click += testButton_Click;
            // 
            // comboBoxBaudRate
            // 
            comboBoxBaudRate.FormattingEnabled = true;
            comboBoxBaudRate.Items.AddRange(new object[] { "2400", "4800", "9600", "19200", "38400", "57600" });
            comboBoxBaudRate.Location = new Point(1557, 115);
            comboBoxBaudRate.Margin = new Padding(2, 3, 2, 3);
            comboBoxBaudRate.Name = "comboBoxBaudRate";
            comboBoxBaudRate.Size = new Size(300, 49);
            comboBoxBaudRate.TabIndex = 11;
            // 
            // comboBoxComPort
            // 
            comboBoxComPort.FormattingEnabled = true;
            comboBoxComPort.Location = new Point(1557, 46);
            comboBoxComPort.Margin = new Padding(2, 3, 2, 3);
            comboBoxComPort.Name = "comboBoxComPort";
            comboBoxComPort.Size = new Size(300, 49);
            comboBoxComPort.TabIndex = 10;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(1409, 115);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(152, 41);
            label20.TabIndex = 18;
            label20.Text = "Baud Rate";
            // 
            // Comport
            // 
            Comport.AutoSize = true;
            Comport.Location = new Point(1409, 55);
            Comport.Margin = new Padding(2, 0, 2, 0);
            Comport.Name = "Comport";
            Comport.Size = new Size(143, 41);
            Comport.TabIndex = 17;
            Comport.Text = "Com Port";
            // 
            // buttonWriteConf
            // 
            buttonWriteConf.Location = new Point(66, 596);
            buttonWriteConf.Margin = new Padding(7, 8, 7, 8);
            buttonWriteConf.Name = "buttonWriteConf";
            buttonWriteConf.Size = new Size(546, 82);
            buttonWriteConf.TabIndex = 6;
            buttonWriteConf.Text = "Write Configuration";
            buttonWriteConf.UseVisualStyleBackColor = true;
            buttonWriteConf.Click += button6_Click;
            // 
            // buttonReadScaled
            // 
            buttonReadScaled.Location = new Point(66, 806);
            buttonReadScaled.Margin = new Padding(7, 8, 7, 8);
            buttonReadScaled.Name = "buttonReadScaled";
            buttonReadScaled.Size = new Size(546, 82);
            buttonReadScaled.TabIndex = 8;
            buttonReadScaled.Text = "Read Scaled";
            buttonReadScaled.UseVisualStyleBackColor = true;
            buttonReadScaled.Click += buttonReadScaled_Click;
            // 
            // buttonReadState
            // 
            buttonReadState.Location = new Point(66, 711);
            buttonReadState.Margin = new Padding(7, 8, 7, 8);
            buttonReadState.Name = "buttonReadState";
            buttonReadState.Size = new Size(546, 82);
            buttonReadState.TabIndex = 7;
            buttonReadState.Text = "Read State";
            buttonReadState.UseVisualStyleBackColor = true;
            buttonReadState.Click += buttonReadState_Click;
            // 
            // buttonReadConfiguration
            // 
            buttonReadConfiguration.Location = new Point(66, 492);
            buttonReadConfiguration.Margin = new Padding(7, 8, 7, 8);
            buttonReadConfiguration.Name = "buttonReadConfiguration";
            buttonReadConfiguration.Size = new Size(546, 82);
            buttonReadConfiguration.TabIndex = 5;
            buttonReadConfiguration.Text = "Read Configuration";
            buttonReadConfiguration.UseVisualStyleBackColor = true;
            buttonReadConfiguration.Click += buttonReadConfiguration_Click;
            // 
            // textBoxSend
            // 
            textBoxSend.Location = new Point(66, 295);
            textBoxSend.Margin = new Padding(2, 3, 2, 3);
            textBoxSend.Name = "textBoxSend";
            textBoxSend.Size = new Size(495, 47);
            textBoxSend.TabIndex = 3;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(19, 115);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(131, 41);
            label13.TabIndex = 7;
            label13.Text = "TCP Port";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(19, 36);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(158, 41);
            label12.TabIndex = 6;
            label12.Text = "IP Address";
            // 
            // textBoxCommunication
            // 
            textBoxCommunication.Location = new Point(770, 36);
            textBoxCommunication.Margin = new Padding(7, 8, 7, 8);
            textBoxCommunication.Multiline = true;
            textBoxCommunication.Name = "textBoxCommunication";
            textBoxCommunication.Size = new Size(478, 851);
            textBoxCommunication.TabIndex = 3;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(187, 115);
            textBoxPort.Margin = new Padding(7, 8, 7, 8);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(373, 47);
            textBoxPort.TabIndex = 2;
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(187, 36);
            textBoxIP.Margin = new Padding(7, 8, 7, 8);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(378, 47);
            textBoxIP.TabIndex = 1;
            textBoxIP.TextChanged += textBoxIP_TextChanged;
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(66, 355);
            buttonSend.Margin = new Padding(7, 8, 7, 8);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(172, 77);
            buttonSend.TabIndex = 4;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += buttonSend_Click;
            // 
            // Sensor_Data
            // 
            Sensor_Data.BackColor = Color.WhiteSmoke;
            Sensor_Data.Controls.Add(label22);
            Sensor_Data.Controls.Add(comboBoxLocation);
            Sensor_Data.Controls.Add(radioButtonInstrumentID);
            Sensor_Data.Controls.Add(textBoxInstrumentID);
            Sensor_Data.Controls.Add(label18);
            Sensor_Data.Controls.Add(textBoxLocation);
            Sensor_Data.Controls.Add(textLabelLocation);
            Sensor_Data.Controls.Add(panel1);
            Sensor_Data.Controls.Add(comboBoxSenorName);
            Sensor_Data.Controls.Add(clearButton);
            Sensor_Data.Controls.Add(registerNewButton);
            Sensor_Data.Controls.Add(deleButton);
            Sensor_Data.Controls.Add(saveChangesButton);
            Sensor_Data.Controls.Add(comboBoxInstrumentName);
            Sensor_Data.Controls.Add(buttonOpenFile);
            Sensor_Data.Controls.Add(panelRange);
            Sensor_Data.Controls.Add(buttonSummary);
            Sensor_Data.Controls.Add(textBoxSummary);
            Sensor_Data.Controls.Add(textBoxRegister);
            Sensor_Data.Controls.Add(CommentsTextLabel);
            Sensor_Data.Controls.Add(label8);
            Sensor_Data.Controls.Add(MeasureTypeLabel);
            Sensor_Data.Controls.Add(TextBoxOptions);
            Sensor_Data.Controls.Add(SignalTypeLabel);
            Sensor_Data.Controls.Add(dateTimePicker1Label);
            Sensor_Data.Controls.Add(checkBox1Registerd);
            Sensor_Data.Controls.Add(label7);
            Sensor_Data.Controls.Add(label6);
            Sensor_Data.Controls.Add(label5);
            Sensor_Data.Controls.Add(label4);
            Sensor_Data.Controls.Add(label3);
            Sensor_Data.Controls.Add(SerialNumberLabel);
            Sensor_Data.Controls.Add(label2);
            Sensor_Data.Controls.Add(label1);
            Sensor_Data.Location = new Point(10, 58);
            Sensor_Data.Margin = new Padding(2, 3, 2, 3);
            Sensor_Data.Name = "Sensor_Data";
            Sensor_Data.Padding = new Padding(2, 3, 2, 3);
            Sensor_Data.Size = new Size(2328, 1027);
            Sensor_Data.TabIndex = 0;
            Sensor_Data.Text = "Configuration";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label22.ForeColor = Color.GreenYellow;
            label22.Location = new Point(29, 246);
            label22.Name = "label22";
            label22.Size = new Size(221, 41);
            label22.TabIndex = 39;
            label22.Text = "BE Connected";
            label22.Visible = false;
            // 
            // comboBoxLocation
            // 
            comboBoxLocation.FormattingEnabled = true;
            comboBoxLocation.Location = new Point(709, 423);
            comboBoxLocation.Name = "comboBoxLocation";
            comboBoxLocation.Size = new Size(492, 49);
            comboBoxLocation.TabIndex = 38;
            // 
            // radioButtonInstrumentID
            // 
            radioButtonInstrumentID.AutoSize = true;
            radioButtonInstrumentID.Location = new Point(422, 113);
            radioButtonInstrumentID.Name = "radioButtonInstrumentID";
            radioButtonInstrumentID.Size = new Size(357, 45);
            radioButtonInstrumentID.TabIndex = 37;
            radioButtonInstrumentID.TabStop = true;
            radioButtonInstrumentID.Text = "Generate InstrumentID";
            radioButtonInstrumentID.UseVisualStyleBackColor = true;
            radioButtonInstrumentID.CheckedChanged += radioButtonInstrumentID_CheckedChanged;
            // 
            // textBoxInstrumentID
            // 
            textBoxInstrumentID.Location = new Point(709, 169);
            textBoxInstrumentID.Name = "textBoxInstrumentID";
            textBoxInstrumentID.Size = new Size(488, 47);
            textBoxInstrumentID.TabIndex = 36;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(422, 175);
            label18.Name = "label18";
            label18.Size = new Size(199, 41);
            label18.TabIndex = 35;
            label18.Text = "Instrument ID";
            // 
            // textBoxLocation
            // 
            textBoxLocation.Location = new Point(707, 423);
            textBoxLocation.Multiline = true;
            textBoxLocation.Name = "textBoxLocation";
            textBoxLocation.Size = new Size(494, 47);
            textBoxLocation.TabIndex = 34;
            // 
            // textLabelLocation
            // 
            textLabelLocation.AutoSize = true;
            textLabelLocation.Location = new Point(422, 426);
            textLabelLocation.Name = "textLabelLocation";
            textLabelLocation.Size = new Size(131, 41);
            textLabelLocation.TabIndex = 33;
            textLabelLocation.Text = "Location";
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(label17);
            panel1.Location = new Point(22, 30);
            panel1.Margin = new Padding(7, 8, 7, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 186);
            panel1.TabIndex = 32;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(18, 105);
            radioButton2.Margin = new Padding(7, 8, 7, 8);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(299, 45);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "instrumentConfDB";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged_1;
            radioButton2.Click += radioButton2_CheckedChanged;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(18, 44);
            radioButton1.Margin = new Padding(7, 8, 7, 8);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(100, 45);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "File";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(7, -5);
            label17.Margin = new Padding(7, 0, 7, 0);
            label17.Name = "label17";
            label17.Size = new Size(129, 41);
            label17.TabIndex = 0;
            label17.Text = "File / DB";
            // 
            // comboBoxSenorName
            // 
            comboBoxSenorName.FormattingEnabled = true;
            comboBoxSenorName.Location = new Point(705, 3);
            comboBoxSenorName.Margin = new Padding(2, 3, 2, 3);
            comboBoxSenorName.Name = "comboBoxSenorName";
            comboBoxSenorName.Size = new Size(492, 49);
            comboBoxSenorName.TabIndex = 31;
            comboBoxSenorName.SelectedIndexChanged += comboBoxSenorName_SelectedIndexChanged;
            comboBoxSenorName.Click += comboBoxInstrument_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(15, 469);
            clearButton.Margin = new Padding(2, 3, 2, 3);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(335, 57);
            clearButton.TabIndex = 30;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // registerNewButton
            // 
            registerNewButton.Location = new Point(1615, 443);
            registerNewButton.Margin = new Padding(2, 3, 2, 3);
            registerNewButton.Name = "registerNewButton";
            registerNewButton.Size = new Size(279, 57);
            registerNewButton.TabIndex = 14;
            registerNewButton.Text = "Register New";
            registerNewButton.UseVisualStyleBackColor = true;
            registerNewButton.Click += registerButton_Click;
            // 
            // deleButton
            // 
            deleButton.Location = new Point(1615, 599);
            deleButton.Margin = new Padding(2, 3, 2, 3);
            deleButton.Name = "deleButton";
            deleButton.Size = new Size(279, 57);
            deleButton.TabIndex = 16;
            deleButton.Text = "Delete";
            deleButton.UseVisualStyleBackColor = true;
            deleButton.Click += deleButton_Click;
            // 
            // saveChangesButton
            // 
            saveChangesButton.Location = new Point(1615, 536);
            saveChangesButton.Margin = new Padding(2, 3, 2, 3);
            saveChangesButton.Name = "saveChangesButton";
            saveChangesButton.Size = new Size(279, 57);
            saveChangesButton.TabIndex = 15;
            saveChangesButton.Text = "Save Changes";
            saveChangesButton.UseVisualStyleBackColor = true;
            saveChangesButton.Click += saveChangesButton_Click;
            // 
            // comboBoxInstrumentName
            // 
            comboBoxInstrumentName.FormattingEnabled = true;
            comboBoxInstrumentName.Location = new Point(709, 44);
            comboBoxInstrumentName.Margin = new Padding(2, 3, 2, 3);
            comboBoxInstrumentName.Name = "comboBoxInstrumentName";
            comboBoxInstrumentName.Size = new Size(492, 49);
            comboBoxInstrumentName.TabIndex = 1;
            comboBoxInstrumentName.SelectedIndexChanged += comboBoxInstrumentName_SelectedIndexChanged;
            comboBoxInstrumentName.MouseHover += comboBoxInstrumentName_SelectedIndexChanged;
            // 
            // buttonOpenFile
            // 
            buttonOpenFile.Location = new Point(15, 313);
            buttonOpenFile.Margin = new Padding(2, 3, 2, 3);
            buttonOpenFile.Name = "buttonOpenFile";
            buttonOpenFile.Size = new Size(335, 57);
            buttonOpenFile.TabIndex = 18;
            buttonOpenFile.Text = "Open File";
            buttonOpenFile.UseVisualStyleBackColor = true;
            buttonOpenFile.Click += buttonOpenFile_Click;
            // 
            // panelRange
            // 
            panelRange.Controls.Add(label15);
            panelRange.Controls.Add(label14);
            panelRange.Controls.Add(textBoxAlarmLow);
            panelRange.Controls.Add(textBoxAlarmHigh);
            panelRange.Controls.Add(textBoxURV);
            panelRange.Controls.Add(textBoxLRV);
            panelRange.Controls.Add(textBoxUnit);
            panelRange.Controls.Add(label11);
            panelRange.Controls.Add(label9);
            panelRange.Controls.Add(label10);
            panelRange.Location = new Point(1377, 22);
            panelRange.Margin = new Padding(2, 3, 2, 3);
            panelRange.Name = "panelRange";
            panelRange.Size = new Size(522, 385);
            panelRange.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(36, 306);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(157, 41);
            label15.TabIndex = 24;
            label15.Text = "Alarm Low";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(36, 241);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(166, 41);
            label14.TabIndex = 23;
            label14.Text = "Alarm High";
            // 
            // textBoxAlarmLow
            // 
            textBoxAlarmLow.Location = new Point(238, 301);
            textBoxAlarmLow.Margin = new Padding(2, 3, 2, 3);
            textBoxAlarmLow.Name = "textBoxAlarmLow";
            textBoxAlarmLow.Size = new Size(252, 47);
            textBoxAlarmLow.TabIndex = 13;
            // 
            // textBoxAlarmHigh
            // 
            textBoxAlarmHigh.Location = new Point(238, 235);
            textBoxAlarmHigh.Margin = new Padding(2, 3, 2, 3);
            textBoxAlarmHigh.Name = "textBoxAlarmHigh";
            textBoxAlarmHigh.Size = new Size(252, 47);
            textBoxAlarmHigh.TabIndex = 12;
            // 
            // textBoxURV
            // 
            textBoxURV.Location = new Point(238, 93);
            textBoxURV.Margin = new Padding(2, 3, 2, 3);
            textBoxURV.Name = "textBoxURV";
            textBoxURV.Size = new Size(252, 47);
            textBoxURV.TabIndex = 10;
            // 
            // textBoxLRV
            // 
            textBoxLRV.Location = new Point(238, 22);
            textBoxLRV.Margin = new Padding(2, 3, 2, 3);
            textBoxLRV.Name = "textBoxLRV";
            textBoxLRV.Size = new Size(252, 47);
            textBoxLRV.TabIndex = 9;
            // 
            // textBoxUnit
            // 
            textBoxUnit.Location = new Point(238, 169);
            textBoxUnit.Margin = new Padding(2, 3, 2, 3);
            textBoxUnit.Name = "textBoxUnit";
            textBoxUnit.Size = new Size(252, 47);
            textBoxUnit.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(36, 169);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(73, 41);
            label11.TabIndex = 15;
            label11.Text = "Unit";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(44, 27);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(69, 41);
            label9.TabIndex = 13;
            label9.Text = "LRV";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(36, 93);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(76, 41);
            label10.TabIndex = 14;
            label10.Text = "URV";
            // 
            // buttonSummary
            // 
            buttonSummary.Location = new Point(1916, 795);
            buttonSummary.Margin = new Padding(2, 3, 2, 3);
            buttonSummary.Name = "buttonSummary";
            buttonSummary.Size = new Size(379, 57);
            buttonSummary.TabIndex = 19;
            buttonSummary.Text = "SUMMARY";
            buttonSummary.UseVisualStyleBackColor = true;
            buttonSummary.Click += buttonSummary_Click;
            // 
            // textBoxSummary
            // 
            textBoxSummary.Location = new Point(1903, 6);
            textBoxSummary.Margin = new Padding(2, 3, 2, 3);
            textBoxSummary.Multiline = true;
            textBoxSummary.Name = "textBoxSummary";
            textBoxSummary.ReadOnly = true;
            textBoxSummary.Size = new Size(366, 756);
            textBoxSummary.TabIndex = 5;
            // 
            // textBoxRegister
            // 
            textBoxRegister.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxRegister.ForeColor = SystemColors.InfoText;
            textBoxRegister.Location = new Point(15, 557);
            textBoxRegister.Margin = new Padding(2, 3, 2, 3);
            textBoxRegister.Multiline = true;
            textBoxRegister.Name = "textBoxRegister";
            textBoxRegister.ReadOnly = true;
            textBoxRegister.Size = new Size(335, 376);
            textBoxRegister.TabIndex = 9;
            // 
            // CommentsTextLabel
            // 
            CommentsTextLabel.Location = new Point(707, 800);
            CommentsTextLabel.Margin = new Padding(2, 3, 2, 3);
            CommentsTextLabel.Multiline = true;
            CommentsTextLabel.Name = "CommentsTextLabel";
            CommentsTextLabel.Size = new Size(492, 163);
            CommentsTextLabel.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(413, 565);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(272, 41);
            label8.TabIndex = 11;
            label8.Text = "Measurement Type";
            // 
            // MeasureTypeLabel
            // 
            MeasureTypeLabel.FormattingEnabled = true;
            MeasureTypeLabel.Items.AddRange(new object[] { "4-20ma", "0-10VDC", "0.5DC" });
            MeasureTypeLabel.Location = new Point(707, 562);
            MeasureTypeLabel.Margin = new Padding(2, 3, 2, 3);
            MeasureTypeLabel.Name = "MeasureTypeLabel";
            MeasureTypeLabel.Size = new Size(502, 49);
            MeasureTypeLabel.TabIndex = 6;
            // 
            // TextBoxOptions
            // 
            TextBoxOptions.FormattingEnabled = true;
            TextBoxOptions.ItemHeight = 41;
            TextBoxOptions.Items.AddRange(new object[] { "None", "Display", "HART Protocol" });
            TextBoxOptions.Location = new Point(707, 635);
            TextBoxOptions.Margin = new Padding(2, 3, 2, 3);
            TextBoxOptions.Name = "TextBoxOptions";
            TextBoxOptions.ScrollAlwaysVisible = true;
            TextBoxOptions.Size = new Size(492, 127);
            TextBoxOptions.TabIndex = 7;
            // 
            // SignalTypeLabel
            // 
            SignalTypeLabel.FormattingEnabled = true;
            SignalTypeLabel.Items.AddRange(new object[] { "Analog", "Digital", "Fieldbus" });
            SignalTypeLabel.Location = new Point(707, 494);
            SignalTypeLabel.Margin = new Padding(2, 3, 2, 3);
            SignalTypeLabel.Name = "SignalTypeLabel";
            SignalTypeLabel.Size = new Size(502, 49);
            SignalTypeLabel.TabIndex = 5;
            SignalTypeLabel.SelectedIndexChanged += SignalTypeLabel_SelectedIndexChanged;
            // 
            // dateTimePicker1Label
            // 
            dateTimePicker1Label.Location = new Point(707, 360);
            dateTimePicker1Label.Margin = new Padding(2, 3, 2, 3);
            dateTimePicker1Label.Name = "dateTimePicker1Label";
            dateTimePicker1Label.Size = new Size(502, 47);
            dateTimePicker1Label.TabIndex = 4;
            dateTimePicker1Label.ValueChanged += dateTimePicker1Label_ValueChanged;
            dateTimePicker1Label.MouseHover += SignalTypeLabel_SelectedIndexChanged;
            // 
            // checkBox1Registerd
            // 
            checkBox1Registerd.AutoSize = true;
            checkBox1Registerd.ForeColor = SystemColors.ActiveCaptionText;
            checkBox1Registerd.Location = new Point(707, 309);
            checkBox1Registerd.Margin = new Padding(2, 3, 2, 3);
            checkBox1Registerd.Name = "checkBox1Registerd";
            checkBox1Registerd.Size = new Size(34, 33);
            checkBox1Registerd.TabIndex = 3;
            checkBox1Registerd.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(422, 795);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(163, 41);
            label7.TabIndex = 8;
            label7.Text = "Comments";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(422, 640);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(124, 41);
            label6.TabIndex = 7;
            label6.Text = "Options";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(422, 494);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(169, 41);
            label5.TabIndex = 6;
            label5.Text = "Signal Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(422, 366);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(139, 41);
            label4.TabIndex = 5;
            label4.Text = "Reg Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(422, 304);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(143, 41);
            label3.TabIndex = 4;
            label3.Text = "Registerd";
            // 
            // SerialNumberLabel
            // 
            SerialNumberLabel.Location = new Point(707, 240);
            SerialNumberLabel.Margin = new Padding(2, 3, 2, 3);
            SerialNumberLabel.Mask = "000-00-0000";
            SerialNumberLabel.Name = "SerialNumberLabel";
            SerialNumberLabel.Size = new Size(490, 47);
            SerialNumberLabel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(422, 240);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(206, 41);
            label2.TabIndex = 1;
            label2.Text = "Serial Number";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(413, 52);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(249, 41);
            label1.TabIndex = 0;
            label1.Text = "Instrument Name";
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(Sensor_Data);
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Controls.Add(tabPage1);
            tabControl2.Controls.Add(tabPage3);
            tabControl2.Location = new Point(0, 55);
            tabControl2.Margin = new Padding(2, 3, 2, 3);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(2348, 1095);
            tabControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(label24);
            tabPage3.Controls.Add(groupBox2);
            tabPage3.Controls.Add(chart1);
            tabPage3.Location = new Point(10, 58);
            tabPage3.Margin = new Padding(2, 3, 2, 3);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(2, 3, 2, 3);
            tabPage3.Size = new Size(2328, 1027);
            tabPage3.TabIndex = 3;
            tabPage3.Text = "Chart";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label24.ForeColor = Color.GreenYellow;
            label24.Location = new Point(2021, 17);
            label24.Name = "label24";
            label24.Size = new Size(221, 41);
            label24.TabIndex = 25;
            label24.Text = "BE Connected";
            label24.Visible = false;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.WhiteSmoke;
            groupBox2.Controls.Add(labelConnecionOK);
            groupBox2.Controls.Add(textBoxChart);
            groupBox2.Controls.Add(disconnectButtonAddXY);
            groupBox2.Controls.Add(buttonAddXY);
            groupBox2.Location = new Point(1982, 156);
            groupBox2.Margin = new Padding(2, 3, 2, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 3, 2, 3);
            groupBox2.Size = new Size(330, 722);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            // 
            // labelConnecionOK
            // 
            labelConnecionOK.AutoSize = true;
            labelConnecionOK.ForeColor = Color.ForestGreen;
            labelConnecionOK.Location = new Point(50, 179);
            labelConnecionOK.Name = "labelConnecionOK";
            labelConnecionOK.Size = new Size(239, 41);
            labelConnecionOK.TabIndex = 16;
            labelConnecionOK.Text = "Generating chart";
            labelConnecionOK.Visible = false;
            labelConnecionOK.Click += labelConnecionOK_Click;
            // 
            // textBoxChart
            // 
            textBoxChart.Location = new Point(39, 223);
            textBoxChart.Margin = new Padding(2, 3, 2, 3);
            textBoxChart.Multiline = true;
            textBoxChart.Name = "textBoxChart";
            textBoxChart.Size = new Size(255, 489);
            textBoxChart.TabIndex = 14;
            // 
            // disconnectButtonAddXY
            // 
            disconnectButtonAddXY.BackColor = Color.IndianRed;
            disconnectButtonAddXY.Location = new Point(63, 109);
            disconnectButtonAddXY.Margin = new Padding(2, 3, 2, 3);
            disconnectButtonAddXY.Name = "disconnectButtonAddXY";
            disconnectButtonAddXY.Size = new Size(189, 57);
            disconnectButtonAddXY.TabIndex = 2;
            disconnectButtonAddXY.Text = "Disconnect";
            disconnectButtonAddXY.UseVisualStyleBackColor = false;
            disconnectButtonAddXY.Click += disconnectButtonAddXY_Click;
            // 
            // buttonAddXY
            // 
            buttonAddXY.BackColor = Color.YellowGreen;
            buttonAddXY.Location = new Point(63, 46);
            buttonAddXY.Margin = new Padding(2, 3, 2, 3);
            buttonAddXY.Name = "buttonAddXY";
            buttonAddXY.Size = new Size(189, 57);
            buttonAddXY.TabIndex = 1;
            buttonAddXY.Text = "Connect";
            buttonAddXY.UseVisualStyleBackColor = false;
            buttonAddXY.Click += button10_Click;
            // 
            // chart1
            // 
            chart1.BackColor = Color.WhiteSmoke;
            chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.AxisX.Title = "Seconds";
            chartArea2.AxisX.TitleFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartArea2.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea2.AxisY.Title = "Lux";
            chartArea2.AxisY.TitleFont = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chartArea2.CursorX.IntervalOffset = 5D;
            chartArea2.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea2);
            chart1.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chart1.Legends.Add(legend2);
            chart1.Location = new Point(2, 3);
            chart1.Margin = new Padding(2, 3, 2, 3);
            chart1.Name = "chart1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "Live Uppdate";
            series2.YValuesPerPoint = 2;
            chart1.Series.Add(series2);
            chart1.Size = new Size(2324, 1021);
            chart1.TabIndex = 0;
            chart1.Text = "chart1";
            title2.Name = "Ligth Value";
            chart1.Titles.Add(title2);
            chart1.Click += chart1_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(40, 40);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 0, 0, 0);
            menuStrip1.Size = new Size(2415, 45);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(87, 45);
            fileToolStripMenuItem.Text = "&File";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(104, 45);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(266, 54);
            aboutToolStripMenuItem.Text = "&About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // timerRedaScaled
            // 
            timerRedaScaled.Interval = 5000;
            timerRedaScaled.Tick += timer1_Tick;
            // 
            // bindingSource1
            // 
            bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
            // 
            // timer1
            // 
            timer1.Interval = 5000;
            timer1.Tick += timer1_Tick_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2415, 1441);
            Controls.Add(tabControl2);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2, 3, 2, 3);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            Sensor_Data.ResumeLayout(false);
            Sensor_Data.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelRange.ResumeLayout(false);
            panelRange.PerformLayout();
            tabControl2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceInstrument).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceAnalogRange).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceMeasurementType).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSourceSignalType).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private PrintDialog printDialog1;
        private StatusStrip statusStrip1;
        private ToolStrip toolStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBoxCommunication;
        private TextBox textBoxPort;
        private TextBox textBoxIP;
        private Button buttonSend;
        private TabPage Sensor_Data;
        private Panel panelRange;
        private TextBox textBoxUnit;
        private Label label9;
        private Label label10;
        private Button buttonSummary;
        private TextBox textBoxSummary;
        private TextBox textBoxRegister;
        private TextBox CommentsTextLabel;
        private Label label8;
        private ComboBox MeasureTypeLabel;
        private ListBox TextBoxOptions;
        private GroupBox groupBox1;
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ComboBox comboBoxInstrumentName;
        private OpenFileDialog openFileDialog1;
        private TextBox textBoxSend;
        private Label label15;
        private Label label14;
        private TextBox textBoxAlarmLow;
        private TextBox textBoxAlarmHigh;
        private Label label11;
        private Button buttonWriteConf;
        private Button buttonReadScaled;
        private Button buttonReadState;
        private Button buttonReadConfiguration;
        private TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Button buttonAddXY;
        private GroupBox groupBox2;
        private System.Windows.Forms.Timer timerRedaScaled;
        private Button saveChangesButton;
        private Button deleButton;
        private Button registerNewButton;
        private Label label20;
        private Label Comport;
        private Button clearButton;
        private ComboBox comboBoxBaudRate;
        private ComboBox comboBoxComPort;
        private Button disconnectButtonAddXY;
        private Button testButton;
        private TextBox textBoxChart;
        private Label label16;
        private BindingSource bindingSource1;
        private ComboBox comboBoxSenorName;
        private Panel panel1;
        private Label label17;
        private BindingSource bindingSourceInstrument;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button button1;
        private TextBox textBoxLocation;
        private Label textLabelLocation;
        private BindingSource bindingSourceAnalogRange;
        private BindingSource bindingSourceMeasurementType;
        private BindingSource bindingSourceSignalType;
        private TextBox textBoxInstrumentID;
        private Label label18;
        private RadioButton radioButtonInstrumentID;
        private Button testConnectionButton;
        private Label labelConnecionOK;
        private ComboBox comboBoxLocation;
        private Button diconnectButton;
        private Label label21;
        private Label label19;
        private Label label22;
        private Label label23;
        private Label label24;
        private System.Windows.Forms.Timer timer1;
    }
}