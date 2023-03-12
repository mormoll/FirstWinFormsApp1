using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.DirectoryServices;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace FirstWinFormsApp1
{
    public partial class Form1 : Form


    {
        //Constans

        readonly int[] numbers = new int[7] { 5, 3, 7, 25, 65, 32, 43 };
        string[] analogSignals = new string[] { "0-5DC", "0-10VDC", "0-20mA", "4-20mA", "RTD" };
        string[] digitalSignals = new string[] { "5VDC", "10VDC0", "24VDC", "Relay" };
        string[] fieldbusSigals = new string[] { "Modbus RTU", "ModbusTCP", "Profibus", "ProfiNet", "CANBus", "ErherCat", "RS48" };

        string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        //Variables
        char ch = 'a';

        double lrvValue = 0.0;
        double urvValue = 0.0;
        double spanValue = 0.0;

        int RegisterIndex = 0;
        int analogIndex = 0;
        int digitalIndex = 0;
        int fieldbusIndex = 0;

        // Declare SerialPort as a static variable
        //static SerialPort = serialPort;

        string fileNameInstrumentList = " ";
        //string[] ComPorts = System.IO.Ports.SerialPort.GetPortNames();
        //Font boldFont = new Font("Calibri", 10, FontStyle.Bold);
        //Font regularFont = new Font("Calibri"), 10, FontStyle.Regular);


        DateTime sessionStartTime;

        int xTimeValue = 0;

        List<string> servers = new List<string>();

        List<Instrument> instrumentList = new List<Instrument>();

        private List<string> previousInstrumentNames;




        // Global Variables
        //static SerialPort serialPort = new SerialPort();
        // Declare SerialPort as a static variable
        // static SerialPort serialPort;

        /*// Form constructor
      public Form1()
        {
            InitializeComponent();

            // Find available COM ports
            string[] portNames = SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                MessageBox.Show("No serial ports found.");
            }
            else
            {
                // Display the list of available COM ports in the combo box
                foreach (string portName in portNames)
                {
                    comboBoxComPort.Items.Add(portName);
                }
            }
        }
     */


        private void Form_Load(object sender, EventArgs e)
        {
            sessionStartTime = DateTime.Now;
            toolStripStatusLabel1.Text = "Ready";
            panelRange.Visible = false;
            SignalTypeLabel.SelectedIndex = 0;



            //Load instrument.csv file
            string instrumentLine = "";
            string[] instrumentLineParts;
            var inputFile = new StreamReader(File.OpenRead(fileNameInstrumentList));

            if (inputFile != null)
            {
                while (inputFile.EndOfStream)
                {
                    instrumentLine = inputFile.ReadLine();
                    instrumentLineParts = instrumentLine.Split(';');

                    Instrument instrument = new Instrument(instrumentLineParts[0],
                                                           instrumentLineParts[1],
                                                           instrumentLineParts[2],
                                                           instrumentLineParts[3],
                                                           instrumentLineParts[4],
                                                           instrumentLineParts[5],
                                                           instrumentLineParts[6],
                                                           Convert.ToDouble(instrumentLineParts[7], CultureInfo.InvariantCulture),
                                                           Convert.ToDouble(instrumentLineParts[8], CultureInfo.InvariantCulture),
                                                           instrumentLineParts[9]);

                    instrumentList.Add(instrument);
                    comboBoxInstrumentName.Items.Add(instrumentLineParts[1]);

                    textBoxRegister.Text = instrument.ToString();


                }
            }
            inputFile.Close();

        }
        public Form1()
        {


            InitializeComponent();

            IPAddress[] addresslist = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in addresslist)
            {
                listBox_IpAddresses.Items.Add(address.ToString());

                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    listBox_IpAddresses.Items.Add(address.ToString());
                }
            }
        }

        /*
                    private void Form1_Mouse_Enter(object sender, EventArgs e)

                    this.BackColor= SystemColors.Window;
                    Trace.WriteLine(this.BackColor.ToString());
                    toolStripStatusLabel1.Text = this.BackColor.ToString();
                }
                private void Form1_Mouse_Leave(object sender, EventArgs e)
                {
                    this.BackColor = SystemColors.Control;
                    Trace.WriteLine(this.BackColor.ToString());
                    toolStripStatusLabel1.Text = "";

                }
        */

        /*
                private void RegSaveDel_Click(object sender, EventArgs e)
                {


                    if (RegisterNewButton.Checked)

                    {
                        //Data from form is registerd to textBoxRegister
                        if (FormDataVerified())
                        {
                            RegisterIndex++;
                            checkBox1Registerd.Checked = true;
                            TextboxRegisterText();
                            switch (SignalTypeLabel.Text)
                            {
                                case "Analog":
                                    analogIndex++;
                                    break;
                                case "Digital":
                                    digitalIndex++;
                                    break;
                                case "Fieldbus":
                                    fieldbusIndex++;
                                    break;

                                default: break;
                            }

                        }


                    }

                    else if (SaveChangesButton.Checked)
                    {
                        RegisterIndex++;
                        checkBox1Registerd.Checked = true;
                        TextboxRegisterText();
                    }

                    else if (DeleteButton.Checked)
                    {
                        //Reset from initial state
                        ClearForm();

                    }


                }
        */
        private void ClearForm()
        {
            //Reset from initial state
            toolStripStatusLabel1.Text = "Cleared";


            textBoxRegister.AppendText("" + "\r\n");

            //textBoxRegister.AppendText("" + textbox1SensorName.Text + "");
            //textBoxRegister.AppendText("" + MaskedSerialNumberLabel.Text + "");
            //textBoxRegister.AppendText("" + checkBox1Registerd.CheckState + "");
            //textBoxRegister.AppendText("" + dateTimePicker1Label.Text + "");
            //textBoxRegister.AppendText("" + comboSignalTypeLabel.Text +"");
            //textBoxRegister.AppendText("" + listBox1.Text + "");
            //textBoxRegister.AppendText("" + comboSignalTypeLabel.Text +"" );
            //SensorNameTextLabel.Text = "";
            SerialNumberLabel.Text = "";
            comboBoxInstrumentName.Text = "";
            dateTimePicker1Label.Value = DateTime.Now;
            checkBox1Registerd.Checked = false;
            SignalTypeLabel.SelectedIndex = -1;
            SignalTypeLabel.Text = "";
            TextBoxOptions.SelectedItems.Clear();
            CommentsTextLabel.Text = "";
            textBoxLRV.Text = "";
            textBoxURV.Text = "";
            textBoxUnit.Text = "";
            textBoxAlarmHigh.Text = "";
            textBoxAlarmLow.Text = "";
            CommentsTextLabel.Text = "";
        }

        private void TextboxRegisterText()
        {
            toolStripStatusLabel1.Text = "OK";
            textBoxRegister.AppendText("([" + RegisterIndex + "]\r\n");

            //textBoxRegister.AppendText("Sensor Name: " + SensorNameTextLabel.Text + "\r\n");
            textBoxRegister.AppendText("Serial Number: " + SerialNumberLabel.Text + "\r\n");
            textBoxRegister.AppendText("Registered: " + checkBox1Registerd.CheckState + "\r\n");
            textBoxRegister.AppendText("Date: " + dateTimePicker1Label.Text + "\r\n");
            textBoxRegister.AppendText("Signal Type: " + SignalTypeLabel.Text + "\r\n");
            textBoxRegister.AppendText("Options: " + TextBoxOptions.Text + "\r\n");
            textBoxRegister.AppendText("Comments: " + SignalTypeLabel.Text + "\r\n");

            if (SignalTypeLabel.Text == "Analog")
            {
                lrvValue = Convert.ToDouble(textBoxLRV.Text);
                urvValue = Convert.ToDouble(textBoxURV.Text);
                spanValue = urvValue - lrvValue;
                if (spanValue > 0.0)
                {
                    textBoxRegister.AppendText("LRV: " + textBoxLRV.Text + "\r\n");
                    textBoxRegister.AppendText("URV: " + textBoxURV.Text + "\r\n");
                    textBoxRegister.AppendText("SPAN: " + spanValue + "\r\n");
                    textBoxRegister.AppendText("LRV: " + textBoxUnit.Text + "\r\n");
                }
                else
                {
                    MessageBox.Show("Range nor correct!");
                }
            }

        }
        /* private Boolean FormDataVerified()
         {
             //Sensor Name Check
             if (SensorNameTextLabel.Text.Length == 0)
             {
                 SensorNameTextLabel.Focus();
                 return false;
             }

             //Check Range
             lrvValue = Convert.ToDouble(textBoxLRV.Text, CultureInfo.InvariantCulture);
             urvValue = Convert.ToDouble(textBoxURV.Text, CultureInfo.InvariantCulture);
             spanValue = urvValue - lrvValue;
             if (spanValue > 0.0)
             {
                 return true;
             }
             else { return false; }
         }*/

        private void button1_Click(object sender, EventArgs e)
        {
            //Compare two inputs

            bool textEqual = false;

            if (checkBoxStayConnected.Checked)
            {
                textBoxCommunication.Text = textBoxIP.Text.Equals(textBoxPort.Text) ? "Strings are Equal" : "Strings are not equal";

            }
            else
            {
                textEqual = textBoxIP.Text.Equals(textBoxPort.Text, StringComparison.InvariantCultureIgnoreCase);
            }



            int stringCompareResult;

            stringCompareResult = string.Compare(textBoxIP.Text, textBoxPort.Text, checkBoxStayConnected.Checked);

            if (stringCompareResult > 0)
            {
                textBoxCommunication.AppendText(string.Format("{0} is after {1}", textBoxIP.Text, textBoxPort.Text));

            }
            else if (stringCompareResult < 0)
            {
                textBoxCommunication.AppendText(string.Format("{0} is before {1}", textBoxIP.Text, textBoxPort.Text));
            }
            else
            {
                textBoxCommunication.AppendText(string.Format("{0} is equal to {1}", textBoxIP.Text, textBoxPort.Text));
            }

            if (textBoxIP.Text.IndexOf(":") > 0)
            {
                string[] textSeperatePart = textBoxIP.Text.Split(";");

                foreach (String part in textSeperatePart)
                {
                    textBoxCommunication.AppendText(part + "\r+n");
                }

            }


            //if (textBox1input1.Text.Equals(textBox2input2.Text,StringComparison.InvariantCultureIgnoreCase))
            //{
            // textBoxResult.Text = "String are equal";


            // }
            //else
            // {
            //     textBoxResult.Text = "Strings are not equal";
            //}




            //Int64 testIntLong = Convert.ToInt64(textBox1input1.Text);

            //int testInt = (int)testIntLong;

            //textBoxResult.AppendText("" + testInt);
        }



        private void RegisterNewSensor()
        {
            toolStripStatusLabel1.Text = "OK";
            RegisterIndex++;





            /*textBoxRegister.AppendText("([" + RegisterIndex + "]\r\n");
              textBoxRegister.AppendText("Sensor Name: " + SensorNameTextLabel.Text + "\r\n");
              textBoxRegister.AppendText("Serial Number: " + SerialNumberLabel.Text + "\r\n");
              textBoxRegister.AppendText("Registered: " + checkBox1Registerd.CheckState + "\r\n");
              textBoxRegister.AppendText("Date: " + dateTimePicker1Label.Text + "\r\n");
              textBoxRegister.AppendText("Signal Type: " + SignalTypeLabel.Text + "\r\n");
              textBoxRegister.AppendText("Options: " + TextBoxOptions.Text + "\r\n");
              textBoxRegister.AppendText("Comments: " + SignalTypeLabel.Text + "\r\n")
            */

            if (SignalTypeLabel.Text == "Analog")
            {
                analogIndex++;

                Instrument instrument = new Instrument(Convert.ToString(DateTime.Now) + "\r\n",
                                                    comboBoxInstrumentName.Text + "\r\n",
                                                    SerialNumberLabel.Text + "\r\n",
                                                    SignalTypeLabel.Text + "\r\n",
                                                    MeasureTypeLabel.Text + "\r\n",
                                                    TextBoxOptions.Text + "\r\n",
                                                    CommentsTextLabel.Text + "\r\n",
                                                    lrvValue = Convert.ToDouble(textBoxLRV.Text),
                                                    urvValue = Convert.ToDouble(textBoxURV.Text),
                                                    textBoxUnit.Text + "\r\n");
                //textBoxRegister.AppendText("[" + RegisterIndex + "]\r\n");
                //Instrument instrument = new Instrument("RegisterDate", "SensorName", "serialNumber", "signalType", "measureType", "options", "comment", 0.0, 0.0, "unit");


                spanValue = urvValue - lrvValue;
                instrumentList.Add(instrument);
                textBoxRegister.AppendText(instrument.ToString());
                textBoxRegister.AppendText("Span Value: " + spanValue + "\r\n");
                textBoxRegister.AppendText("Alarm High: " + textBoxAlarmHigh.Text + "\r\n");
                textBoxRegister.AppendText("Alarm Low: " + textBoxAlarmLow.Text + "\r\n");
                ClearForm();
                /*else 
                {
                    MessageBox.Show("Range not correct!");
                }*/


            }

            if (SignalTypeLabel.Text == "Digital")
            {
                digitalIndex++;


                Instrument instrument = new Instrument(Convert.ToString(DateTime.Now) + "\r\n",
                                                        comboBoxInstrumentName.Text + "\r\n",
                                                        SerialNumberLabel.Text + "\r\n",
                                                        SignalTypeLabel.Text + "\r\n",
                                                        MeasureTypeLabel.Text + "\r\n",
                                                        TextBoxOptions.Text + "\r\n",
                                                        CommentsTextLabel.Text + "\r\n",
                                                        lrvValue,
                                                        urvValue,
                                                        textBoxUnit.Text + "\r\n");
                //textBoxRegister.AppendText("[" + RegisterIndex + "]\r\n");
                //Instrument instrument = new Instrument("RegisterDate", "SensorName", "serialNumber", "signalType", "measureType", "options", "comment", 0.0, 0.0, "unit");


                instrumentList.Add(instrument);
                textBoxRegister.AppendText(instrument.ToString());
                ClearForm();
            }
            if (SignalTypeLabel.Text == "Fieldbus")
            {
                fieldbusIndex++;

                Instrument instrument = new Instrument(Convert.ToString(DateTime.Now) + "\r\n",
                                                        comboBoxInstrumentName.Text + "\r\n",
                                                        SerialNumberLabel.Text + "\r\n",
                                                        SignalTypeLabel.Text + "\r\n",
                                                        MeasureTypeLabel.Text + "\r\n",
                                                        TextBoxOptions.Text + "\r\n",
                                                        CommentsTextLabel.Text + "\r\n",
                                                        lrvValue,
                                                        urvValue,
                                                        textBoxUnit.Text + "\r\n");

                //Instrument instrument = new Instrument("RegisterDate", "SensorName", "serialNumber", "signalType", "measureType", "options", "comment", 0.0, 0.0, "unit");


                instrumentList.Add(instrument);
                textBoxRegister.AppendText(instrument.ToString());
                ClearForm();
            }



            /*  Instrument instrument = new Instrument(Convert.ToString(DateTime.Now),
                                                      comboBoxInstrumentName.Text,
                                                      SerialNumberLabel.Text,
                                                      SignalTypeLabel.Text,
                                                      MeasureTypeLabel.Text,
                                                      TextBoxOptions.Text,
                                                      CommentsTextLabel.Text,
                                                      lrvValue,
                                                      urvValue,
                                                      textBoxUnit.Text );


           /*   if (SignalTypeLabel.Text == "Analog")
              {
                  lrvValue = Convert.ToDouble(textBoxLRV.Text);
                  urvValue = Convert.ToDouble(textBoxURV.Text);
                  spanValue = urvValue - lrvValue;
                  if (spanValue > 0.0)
                  {
                      textBoxRegister.AppendText("LRV: " + textBoxLRV.Text + "\r\n");
                      textBoxRegister.AppendText("URV: " + textBoxURV.Text + "\r\n");
                      textBoxRegister.AppendText("SPAN: " + spanValue + "\r\n");
                      textBoxRegister.AppendText("LRV: " + textBoxUnit.Text + "\r\n");
                  }
                  else
                  {
                      MessageBox.Show("Range not correct!");
                  }


              }
              Instrument instrument = new Instrument(Convert.ToString(DateTime.Now),
                                                      comboBoxInstrumentName.Text,
                                                      SerialNumberLabel.Text,
                                                      SignalTypeLabel.Text,
                                                      MeasureTypeLabel.Text,
                                                      TextBoxOptions.Text,
                                                      CommentsTextLabel.Text,
                                                      lrvValue,
                                                      urvValue,
                                                      textBoxUnit.Text );

              //Instrument instrument = new Instrument("RegisterDate", "SensorName", "serialNumber", "signalType", "measureType", "options", "comment", 0.0, 0.0, "unit");


              instrumentList.Add(instrument);
              textBoxRegister.AppendText(instrument.ToString());


          }

          private void buttonSummary_Click_1(object sender, EventArgs e)
          {
              //DateTime sessionTime;

              System.TimeSpan sessionTime = DateTime.Now.Subtract(sessionStartTime);
              textBoxSummary.AppendText("Session time; " + sessionTime.TotalSeconds.ToString() + "s \r\n");
              textBoxSummary.AppendText("Number of sensors regirsterd:" + RegisterIndex + "\r\n");
              textBoxSummary.AppendText("Number og digital sensor: " + digitalIndex + "\r\n");
              textBoxSummary.AppendText("Number of analog sensors: " + analogIndex + "\r\n");
              textBoxSummary.AppendText("Number of fieldbus sensors: " + fieldbusIndex + "\r\n");
          }

          private void SignalTypeLabel_SelectedIndexChanged(object sender, EventArgs e)
          {
              MeasureTypeLabel.Items.Clear();
              switch (SignalTypeLabel.Text)
              {
                  case "Analog":
                      MeasureTypeLabel.Items.AddRange(analogSignals);
                      panelRange.Visible = true;
                      break;
                  case "Digital":
                      MeasureTypeLabel.Items.AddRange(digitalSignals);
                      panelRange.Visible = false;
                      break;
                  case "Fieldbus":
                      panelRange.Visible = false;

                      break;
                  default:
                      break;
              }
          }

          private void button1_Click_1(object sender, EventArgs e)
          {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text),
              Convert.ToInt32(textBoxPort.Text));
              Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
              client.Connect(endpoint);
              textBoxCommunication.AppendText("Connected to server.");
              if(textBoxSend.Text.Length <= 0) 
              {
                  client.Send(Encoding.ASCII.GetBytes("Test"));
              }
              else { 
                  client.Send(Encoding.ASCII.GetBytes(textBoxSend.Text)); 
              }

              byte[] buffer = new byte[1024];
              int bytesReceived = client.Receive(buffer);
              textBoxCommunication.AppendText("Received: " + Encoding.ASCII.GetString(buffer, 0, bytesReceived));
              client.Close();
              textBoxCommunication.AppendText("Disconnected from server.");

              /*  //Compare two inputs

                bool textEqual = false;

                if (checkBoxCaseSensetive.Checked)
                {
                    textBoxResult.Text = textBox1input1.Text.Equals(textBox2input2.Text) ? "Strings are Equal" : "Strings are not equal";

                }
                else
                {
                    textEqual = textBox1input1.Text.Equals(textBox2input2.Text, StringComparison.InvariantCultureIgnoreCase);
                }



                int stringCompareResult;

                stringCompareResult = string.Compare(textBox1input1.Text, textBox2input2.Text, checkBoxCaseSensetive.Checked);

                if (stringCompareResult > 0)
                {
                    textBoxResult.AppendText(string.Format("{0} is after {1}", textBox1input1.Text, textBox2input2.Text));

                }
                else if (stringCompareResult < 0)
                {
                    textBoxResult.AppendText(string.Format("{0} is before {1}", textBox1input1.Text, textBox2input2.Text));
                }
                else
                {
                    textBoxResult.AppendText(string.Format("{0} is equal to {1}", textBox1input1.Text, textBox2input2.Text));
                }

                if (textBox1input1.Text.IndexOf(":") > 0)
                {
                    string[] textSeperatePart = textBox1input1.Text.Split(";");

                    foreach (String part in textSeperatePart)
                    {
                        textBoxResult.AppendText(part + "\r+n");
                    }
                }*/
        }

        /*  private void SensorData_SelectedIndexChanged_1(object sender, EventArgs e)
          {
              if (SensorData.SelectedIndex ==2) 
              {
                  listBox_IpAddresses.Items.Clear();  
                  listBox_IpAddresses.Items.AddRange(servers.ToArray());
              }

          }
          */

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxRegister.TextLength > 0)
            {
                StreamWriter outputFile = new StreamWriter("register.csv");
                outputFile.Write(textBoxRegister.Text);
                outputFile.Close();
            }
        }




        /*  private bool NewSensorName()
          {
             bool newSensorName = true;
             //check to see if instrument already is in the list.
             instrumentList.ForEach(delegate (Instrument instr)
             {
                 if (instr.SensorName == SensorNameTextLabel.Text)
                 {
                     MessageBox.Show("Sensor Name already exist!");
                     newSensorName = false;
                     SensorNameTextLabel.Focus();
                 }
             });
             return newSensorName;
          }*/

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
        public bool NewInstrument(string sensorName)
        {
            bool newInstrument = true;
            instrumentList.ForEach(delegate (Instrument instrument)
            {
                if (instrument.SensorName == sensorName)
                {
                    newInstrument = false;
                }
            });
            return newInstrument;
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            var inputFile = new StreamReader("register.csv");
            textBoxRegister.Text = inputFile.ReadToEnd();
            inputFile.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBoxRegister.TextLength > 0)
            {
                StreamWriter outputFile = new StreamWriter("register.csv");
                outputFile.Write(textBoxRegister.Text);
                outputFile.Close();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StreamWriter outputFile = new StreamWriter(fileNameInstrumentList);
            instrumentList.ForEach(delegate (Instrument instrument)
            {
                outputFile.Write(instrument.ToString);
            });
            outputFile.Close();
        }

        private void comboBoxInstrumentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInstrumentName.SelectedIndex > -1)
            {
                bool foundInstrument = false;
                string selectedInstrumentName = comboBoxInstrumentName.SelectedItem.ToString();

                // Check if the selected instrument name is in the previous instrument names
                foreach (string instrumentName in previousInstrumentNames)
                {
                    if (instrumentName == selectedInstrumentName)
                    {
                        foundInstrument = true;
                        break;
                    }
                }

                if (foundInstrument)
                {
                    // Reload the instrument names from the previous instrument names list
                    comboBoxInstrumentName.Items.Clear();
                    comboBoxInstrumentName.Items.AddRange(previousInstrumentNames.ToArray());
                }
                else
                {
                    // Do something else
                }
            }
        }

        /*private void button2_Click_2(object sender, EventArgs e)
        {
            string[] weekEnd = new string[2];

            Array.Copy(daysOfWeek, 5, weekEnd, 0, 2);
            foreach (string day in weekEnd)
            {
                textBox1.AppendText(day + "\r\n");
            }
            Array.Sort(daysOfWeek);
            foreach (string day in daysOfWeek) ;
            {
                textBox1.AppendText("day" + "\r\n");
            }
            textBox1.AppendText(daysOfWeek.ToString());




        }*/

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] sensorConf;
            string recived;
            recived = sendToBackEnd("readconf");
            sensorConf = recived.Split(',');
            textBoxCommunication.AppendText(recived + "\r\n");
            string caption = "";
            foreach (string conf in sensorConf)
            {
                caption = conf + "\r\n";
            }
            MessageBox.Show(caption, "Sensor Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private string sendToBackEnd(string command)
        {

            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), Convert.ToInt32(textBoxPort.Text));
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(endpoint);
            textBoxCommunication.AppendText("Connected to server.");

            client.Send(Encoding.ASCII.GetBytes(command));


            byte[] buffer = new byte[1024];
            int bytesReceived = client.Receive(buffer);
            string recived = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            textBoxCommunication.AppendText("Received: " + Encoding.ASCII.GetString(buffer, 0, bytesReceived));
            client.Close();
            textBoxCommunication.AppendText("Disconnected from server.");
            return recived;
        }

        private void textBoxRegister_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (timerRedaScaled.Enabled)
            {
                timerRedaScaled.Stop();
            }
            else
            {
                timer1_Tick(this, EventArgs.Empty);
                timerRedaScaled.Start();


                // Clear the existing text in the textbox
                textBoxChart.Clear();

                // Create a new file with a unique name
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileId = Guid.NewGuid().ToString().Substring(0, 8);
                string fileName = $"output_{timestamp}_{fileId}.txt";
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine("This is a new file created at " + DateTime.Now.ToString());
                }

                // Write the X and Y values to the output file and textbox every time the timer elapses
                timerRedaScaled.Tick += (s, ev) =>
                {
                    // Write the current X and Y values to the output file
                    using (StreamWriter writer = new StreamWriter(fileName, true))
                    {
                        foreach (DataPoint point in chart1.Series[0].Points)
                        {
                            writer.WriteLine(point.XValue.ToString("F2") + " " + point.YValues[0].ToString("F2"));
                        }
                    }

                    // Append the current X and Y values to the textbox
                    foreach (DataPoint point in chart1.Series[0].Points)
                    {
                        textBoxChart.AppendText(point.XValue.ToString("F2") + " " + point.YValues[0].ToString("F2") + Environment.NewLine);
                    }
                };
            }
        }



        private void buttonReadConfiguration_Click(object sender, EventArgs e)
        {
            string[] sensorConf;
            string received;
            received = sendToBackEnd("readconf");
            sensorConf = received.Split(',');
            textBoxCommunication.AppendText(received + "\r\n");
        }

        private void buttonReadState_Click(object sender, EventArgs e)
        {
            string[] sensorState;
            string received;
            received = sendToBackEnd("readstatus");
            sensorState = received.Split(",");
            textBoxCommunication.AppendText(received + "\r\n");

        }

        private void buttonReadScaled_Click(object sender, EventArgs e)
        {
            string[] sensorScaled;
            string received;
            received = sendToBackEnd("readscaled");
            sensorScaled = received.Split(",");
            textBoxCommunication.AppendText(received + "\r\n");
        }
        public static class Prompt
        {
            /*
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form();
                prompt.Width = 600;
                prompt.Height = 350;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 200, PasswordChar = '*' };
                System.Windows.Forms.Button okButton = new System.Windows.Forms.Button() { Text = "OK", Left = 150, Width = 50, Top = 80 };
                okButton.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(okButton);
                prompt.AcceptButton = okButton;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }
            
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form();
                prompt.Width = 600;
                prompt.Height = 350;
                prompt.Text = caption;

                System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label() { Left = 50, Top = 20, Text = text };
                prompt.Controls.Add(textLabel);

                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 200, PasswordChar = '*' };
                prompt.Controls.Add(textBox);

                System.Windows.Forms.Button okButton = new System.Windows.Forms.Button() { Text = "OK", Left = 260, Width = 50, Top = 50 };
                okButton.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; };
                prompt.Controls.Add(okButton);
                prompt.AcceptButton = okButton;
                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }*/

            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form();
                prompt.Width = 400;
                prompt.Height = 350;
                prompt.Text = caption;

                System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label() { Left = 50, Top = 20, Text = text, Font = new Font("Arial", 10) };
                textLabel.Size = new Size(450, 50);
                prompt.Controls.Add(textLabel);

                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 70, Width = 600, PasswordChar = '*', Font = new Font("Arial", 10) };
                textBox.Size = new Size(200, 100);
                prompt.Controls.Add(textBox);

                System.Windows.Forms.Button okButton = new System.Windows.Forms.Button() { Text = "OK", Left = 50, Width = 100, Top = 150, Font = new Font("Arial", 10) };
                okButton.Size = new Size(100, 70);
                okButton.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; };
                prompt.Controls.Add(okButton);

                prompt.AcceptButton = okButton;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
            }






        }
        private void button6_Click(object sender, EventArgs e)
        {
            // Prompt the user for a password
            string password = Prompt.ShowDialog("Enter Password", "Password");

            // Check if the password is correct
            if (password != "password")
            {
                // Display an error message and return
                MessageBox.Show("Incorrect Password! Press Write configuration again");
                return;
            }

            // If the password is correct, continue with the existing code
            string[] writeconf;
            string received;
            received = sendToBackEnd("writeconf>" +
            ">" + comboBoxInstrumentName.Text +
                                             ";" + textBoxLRV.Text +
                                             ";" + textBoxURV.Text +
                                             ";" + textBoxAlarmLow.Text +
                                             ";" + textBoxAlarmHigh.Text);

            writeconf = received.Split(",");
            textBoxCommunication.AppendText(received + "\r\n");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            xTimeValue += 5;
            double yValue = 0.0;
            string received;

            received = sendToBackEnd("readscaled");
            string[] receivedParts = received.Split(";");
            string recievedString = receivedParts[1].Remove(receivedParts[1].Length - 2);

            yValue = Convert.ToDouble(recievedString, CultureInfo.InvariantCulture);

            chart1.Series[0].Points.AddXY(xTimeValue, yValue);

        }


        private void buttonSummary_Click(object sender, EventArgs e)
        {

            //System.TimeSpan sessionTime = DateTime.Now.Subtract(sessionStartTime);
            //string formattedSessionTime = sessionTime.TotalSeconds.ToString("0.00", CultureInfo.InvariantCulture);
            textBoxSummary.Clear();
            //textBoxSummary.AppendText("Session time; " + formattedSessionTime + "s \r\n");
            textBoxSummary.AppendText("Number of sensors regirsterd:" + RegisterIndex + "\r\n");
            textBoxSummary.AppendText("Number og digital sensor: " + digitalIndex + "\r\n");
            textBoxSummary.AppendText("Number of analog sensors: " + analogIndex + "\r\n");
            textBoxSummary.AppendText("Number of fieldbus sensors: " + fieldbusIndex + "\r\n");
        }

        private void SignalTypeLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeasureTypeLabel.Items.Clear();

            switch (SignalTypeLabel.Text)
            {
                case "Analog":
                    MeasureTypeLabel.Items.AddRange(analogSignals);
                    panelRange.Visible = true;
                    //analogIndex++;
                    break;

                case "Digital":
                    MeasureTypeLabel.Items.AddRange(digitalSignals);
                    panelRange.Visible = false;
                    //digitalIndex++;
                    break;

                case "Fieldbus":
                    MeasureTypeLabel.Items.AddRange(fieldbusSigals);
                    panelRange.Visible = false;
                    //fieldbusIndex++;
                    break;

                default:
                    break;

            }
        }



        private void textBoxLRV_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }



        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            RegisterNewSensor();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), Convert.ToInt32(textBoxPort.Text));
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(endPoint);

            textBoxCommunication.AppendText("Connected to server..." + "\r\n");

            //Cliet Send
            client.Send(Encoding.ASCII.GetBytes(textBoxSend.Text));

            //Cliet receive
            byte[] buffer = new byte[1024];
            int bytesReceived = client.Receive(buffer);

            textBoxCommunication.AppendText("Received..." + Encoding.ASCII.GetString(buffer, 0, bytesReceived) + "\r\n");
            client.Close();
            textBoxCommunication.AppendText("Connection closed..." + "\r\n");

        }



        private void deleButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            RegisterNewSensor();

        }





        private void clearButton_Click(object sender, EventArgs e)
        {
            textBoxRegister.Clear();

            // Save values from controls to variables
            string instrumentName = comboBoxInstrumentName.Text;
            string serialNumber = SerialNumberLabel.Text;
            bool isRegistered = checkBox1Registerd.Checked;
            DateTime registrationDate = dateTimePicker1Label.Value;
            string signalType = SignalTypeLabel.Text;
            string measureType = MeasureTypeLabel.Text;
            string options = TextBoxOptions.Text;
            string comments = CommentsTextLabel.Text;
            double lrv = double.Parse(textBoxLRV.Text);
            double urv = double.Parse(textBoxURV.Text);
            string unit = textBoxUnit.Text;
            double alarmHigh = double.Parse(textBoxAlarmHigh.Text);
            double alarmLow = double.Parse(textBoxAlarmLow.Text);

            // Save variables to file or database
            // ...

            // Display success message
            MessageBox.Show("Sensor registered successfully.");

            // Clear controls
            comboBoxInstrumentName.SelectedIndex = -1;
            SerialNumberLabel.Text = "";
            checkBox1Registerd.Checked = false;
            dateTimePicker1Label.Value = DateTime.Now;
            SignalTypeLabel.Text = "";
            MeasureTypeLabel.Text = "";
            TextBoxOptions.Text = "";
            CommentsTextLabel.Text = "";
            textBoxLRV.Text = "";
            textBoxURV.Text = "";
            textBoxUnit.Text = "";
            textBoxAlarmHigh.Text = "";
            textBoxAlarmLow.Text = "";
        }

        /*
        private void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string message = serialPort.ReadLine();
            textBoxComReceived.AppendText(message);
        }*/

        private void comboBoxComPort_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadCOMPorts()
        {
            // Send the "comports" command to the BE and receive the list of COM ports
            byte[] sendBuffer = Encoding.ASCII.GetBytes("comports");
            byte[] receiveBuffer = new byte[1024];
            using (var client = new TcpClient("localhost", 12345))
            {
                client.GetStream().Write(sendBuffer, 0, sendBuffer.Length);
                int bytesRead = client.GetStream().Read(receiveBuffer, 0, receiveBuffer.Length);
                string comPortString = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);

                // Split the received COM port string at the semicolon delimiter and populate the combo box
                string[] comPorts = comPortString.Split(';');
                foreach (string port in comPorts)
                {
                    if (!string.IsNullOrWhiteSpace(port))
                    {
                        comboBoxComPort.Items.Add(port);
                    }
                }
            }
        }
        private void disconnectButtonAddXY_Click(object sender, EventArgs e)
        {
            timerRedaScaled.Stop();
        }



        private void MeasureTypeLabel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //client socket
            TcpClient client = new TcpClient();

            try
            {

                // Connect to the server
                client.Connect("127.0.0.1", 5000);

                // Send a command to get the available COM ports
                byte[] sendBuffer = Encoding.ASCII.GetBytes("comports");
                client.GetStream().Write(sendBuffer, 0, sendBuffer.Length);

                // Receive the COM port list from the server
                byte[] receiveBuffer = new byte[1024];
                int bytesRead = client.GetStream().Read(receiveBuffer, 0, receiveBuffer.Length);
                string comPortString = Encoding.ASCII.GetString(receiveBuffer, 0, bytesRead);

                // Split the COM port list at the semicolon delimiter
                string[] comPorts = comPortString.Split(';');

                // Populate the combo box with the available COM ports
                foreach (string comPort in comPorts)
                {
                    if (!string.IsNullOrWhiteSpace(comPort))
                    {
                        comboBoxComPort.Items.Add(comPort);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }

        private void checkBoxStayConnected_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void listBox_IpAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1Label_ValueChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Date/Time";
        }

        private void Sensor_Data_Click(object sender, EventArgs e)
        {

        }






        /*  private void connectButton_Click(object sender, EventArgs e)
          {
              if (comboBoxComPort.Text != "")
              {
                  serialPort.PortName = comboBoxComPort.Text;
              }
              else
              {
                  return;
              }
              if (comboBoxBaudRate.Text != "")
              {
                  serialPort.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);
              }
              else
              {
                  return;
              }
              serialPort.Open();
          }*/
    }

}
