using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.DirectoryServices;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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

        string fileNameInstrumentList = " ";

        //Font boldFont = new Font("Calibri", 10, FontStyle.Bold);
        //Font regularFont = new Font("Calibri"), 10, FontStyle.Regular);


        DateTime sessionStartTime;

        List<string> servers = new List<string>();

        List<Instrument> instrumentList = new List<Instrument>();
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


            textBoxRegister.AppendText("Cleared");

            //textBoxRegister.AppendText("" + textbox1SensorName.Text + "");
            //textBoxRegister.AppendText("" + MaskedSerialNumberLabel.Text + "");
            //textBoxRegister.AppendText("" + checkBox1Registerd.CheckState + "");
            //textBoxRegister.AppendText("" + dateTimePicker1Label.Text + "");
            //textBoxRegister.AppendText("" + comboSignalTypeLabel.Text +"");
            //textBoxRegister.AppendText("" + listBox1.Text + "");
            //textBoxRegister.AppendText("" + comboSignalTypeLabel.Text +"" );
            SensorNameTextLabel.Text = "";
            SerialNumberLabel.Text = "";
            dateTimePicker1Label.Value = DateTime.Now;
            checkBox1Registerd.Checked = false;
            SignalTypeLabel.SelectedIndex = -1;
            SignalTypeLabel.Text = "";
            TextBoxOptions.SelectedItems.Clear();
            CommentsTextLabel.Text = "";
            textBoxLRV.Text = "0.0";
            textBoxURV.Text = "0.0";
            textBoxUnit.Text = "0.0";
        }

        private void TextboxRegisterText()
        {
            toolStripStatusLabel1.Text = "OK";
            textBoxRegister.AppendText("([" + RegisterIndex + "]\r\n");

            textBoxRegister.AppendText("Sensor Name: " + SensorNameTextLabel.Text + "\r\n");
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
        private Boolean FormDataVerified()
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Compare two inputs

            bool textEqual = false;

            if (checkBoxCaseSensetive.Checked)
            {
                textBoxCommunication.Text = textBoxIP.Text.Equals(textBoxPort.Text) ? "Strings are Equal" : "Strings are not equal";

            }
            else
            {
                textEqual = textBoxIP.Text.Equals(textBoxPort.Text, StringComparison.InvariantCultureIgnoreCase);
            }



            int stringCompareResult;

            stringCompareResult = string.Compare(textBoxIP.Text, textBoxPort.Text, checkBoxCaseSensetive.Checked);

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

        private void RegSaveDel_Click_1(object sender, EventArgs e)
        {
            if (RegisterNewButton.Checked)
            {
                RegisterNewSensor();

            }
            if (SaveChangesButton.Checked) 
            {
                RegisterNewSensor();
            }
            else 
            {
                ClearForm();            
            }
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
                
                lrvValue = Convert.ToDouble(textBoxLRV.Text);
                urvValue = Convert.ToDouble(textBoxURV.Text);
                spanValue = urvValue - lrvValue;
                
                if (spanValue > 0.0)
                {
                    
                                                        
                    textBoxRegister.AppendText("LRV: " + textBoxLRV.Text + "\r\n");
                    textBoxRegister.AppendText("URV: " + textBoxURV.Text + "\r\n");
                    textBoxRegister.AppendText("SPAN: " + spanValue + "\r\n");
                    textBoxRegister.AppendText("LRV: " + textBoxUnit.Text + "\r\n");
                    textBoxRegister.AppendText("[" + RegisterIndex + "]\r\n");
                    textBoxRegister.AppendText("Sensor Name: " + comboBoxInstrumentName.Text + "\r\n");
                    textBoxRegister.AppendText("Serial Number: " + SerialNumberLabel.Text + "\r\n");
                    textBoxRegister.AppendText("Registered: " + checkBox1Registerd.CheckState + "\r\n");
                    textBoxRegister.AppendText("Date: " + dateTimePicker1Label.Text + "\r\n");
                    textBoxRegister.AppendText("Signal Type: " + SignalTypeLabel.Text + "\r\n");
                    textBoxRegister.AppendText("Options: " + TextBoxOptions.Text + "\r\n");
                    textBoxRegister.AppendText("Comments: " + SignalTypeLabel.Text + "\r\n");
                    

                }
                else
                {
                    MessageBox.Show("Range not correct!");
                }


            }

            if (SignalTypeLabel.Text == "Digital")
            {
                digitalIndex++;
                

                Instrument instrument = new Instrument(Convert.ToString(DateTime.Now) + "\r\n",
                                                        comboBoxInstrumentName.Text+"\r\n",
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
    
         */   

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

       


       private bool NewSensorName()
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
       }

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
            var inputFile = new StreamReader(@"C:\tmp\Test.txt");
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
                bool fountInstrumet = false;
                instrumentList.ForEach(delegate (Instrument instrument)
                {
                    
                });
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            string[] weekEnd = new string[2];

            Array.Copy(daysOfWeek, 5, weekEnd, 0, 2);
            foreach (string day in weekEnd) 
            {
                textBox1.AppendText(day+"\r\n");
            }
            Array.Sort(daysOfWeek);
            foreach (string day in daysOfWeek) ;
            {
                textBox1.AppendText(day+ "\r\n");
            }
            textBox1.AppendText(daysOfWeek.ToString());
                
                    
                
           
        }

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
            string caption ="";
            foreach (string conf in sensorConf) 
            {
                caption = conf+"\r\n";
            }
            MessageBox.Show(caption, "Sensor Configuration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private string sendToBackEnd(string command) 
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text),
            Convert.ToInt32(textBoxPort.Text));
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(endpoint);
            textBoxCommunication.AppendText("Connected to server.");
            if (textBoxSend.Text.Length <= 0)
            {
                client.Send(Encoding.ASCII.GetBytes("Test"));
            }
            else
            {
                client.Send(Encoding.ASCII.GetBytes(textBoxSend.Text));
            }

            byte[] buffer = new byte[1024];
            int bytesReceived = client.Receive(buffer);
            string recived = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            textBoxCommunication.AppendText("Received: " + Encoding.ASCII.GetString(buffer, 0, bytesReceived));
            client.Close();
            textBoxCommunication.AppendText("Disconnected from server.");
            return serial.received;
        }
    }
}
