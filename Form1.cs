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
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Specialized;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Web;
using System.Collections.Generic;

namespace FirstWinFormsApp1
{
    public partial class Form1 : Form


    {
        //Constans

        readonly int[] numbers = new int[7] { 5, 3, 7, 25, 65, 32, 43 };
        string[] analogSignals = new string[] { "0-5VDC", "0-10VDC", "0-20mA", "4-20mA", "RTD" };
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

        string fileNameInstrumentList = "instrumentList.csv";
        //string[] ComPorts = System.IO.Ports.SerialPort.GetPortNames();
        //Font boldFont = new Font("Calibri", 10, FontStyle.Bold);
        //Font regularFont = new Font("Calibri"), 10, FontStyle.Regular);


        DateTime sessionStartTime;

        int xTimeValue = 0;

        List<string> servers = new List<string>();

        List<Instrument> instrumentList = new List<Instrument>();

        string connectionString;


        private void Form_Load(object sender, EventArgs e)
        {
            sessionStartTime = DateTime.Now;
            toolStripStatusLabel1.Text = "Ready";
            panelRange.Visible = false;
            SignalTypeLabel.SelectedIndex = 0;

            // Load instrumentList.csv file
            string instrumentListFile = "instrumentList.csv";
            if (File.Exists(instrumentListFile))
            {
                string[] instrumentListLines = File.ReadAllLines(instrumentListFile);
                foreach (string instrumentLine in instrumentListLines)
                {
                    string[] instrumentLineParts = instrumentLine.Split(';');

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

            try
            {
                ImportToComboBox(comboBoxSenorName, "InstrumentSet", "InstrumentName");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Reload previous sensor names
            string sensorNamesFile = "instrumentList.csv";
            if (File.Exists(sensorNamesFile))
            {
                string[] sensorNames = File.ReadAllLines(sensorNamesFile);
                foreach (string sensorName in sensorNames)
                {
                    comboBoxInstrumentName.Items.Add(sensorName);
                }
            }

            // Save instrument list to file
            using (var outputFile = new StreamWriter(instrumentListFile))
            {
                foreach (Instrument instrument in instrumentList)
                {
                    outputFile.WriteLine(instrument.ToString());
                }
            }
        }
        public Form1()
        {


            InitializeComponent();
            comboBoxInstrumentName.Visible = false;
            comboBoxSenorName.Visible = false;

            connectionString = ConfigurationManager.ConnectionStrings["instrumentConfDB"].ConnectionString;

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

        private void ClearForm()
        {
            //Reset from initial state
            toolStripStatusLabel1.Text = "Cleared";


            textBoxRegister.AppendText("" + "\r\n");


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
            comboBoxSenorName.Text = "";
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

            if (SignalTypeLabel.Text == "Analog")
            {
                analogIndex++;

                Instrument instrument = new Instrument(
                                                        Convert.ToString(DateTime.Now) + "\n" ,
                                                        comboBoxInstrumentName.Text + "\r\n",
                                                        SerialNumberLabel.Text + "\r\n",
                                                        SignalTypeLabel.Text + "\r\n",
                                                        MeasureTypeLabel.Text + "\r\n",
                                                        TextBoxOptions.Text + "\r\n",
                                                        CommentsTextLabel.Text + "\r\n",
                                                        Convert.ToDouble(textBoxLRV.Text),
                                                        Convert.ToDouble(textBoxURV.Text),
                                                        textBoxUnit.Text + "\r\n"
                                                        );

                spanValue = urvValue - lrvValue;
                instrumentList.Add(instrument);
                textBoxRegister.AppendText(instrument.ToString());
                textBoxRegister.AppendText("LRV Value: " + instrument.LRV + "\r\n");
                textBoxRegister.AppendText("URV Value: " + instrument.URV + "\r\n");
                textBoxRegister.AppendText("Span Value: " + spanValue + "\r\n");
                textBoxRegister.AppendText("Alarm High: " + textBoxAlarmHigh.Text + "\r\n");
                textBoxRegister.AppendText("Alarm Low: " + textBoxAlarmLow.Text + "\r\n");

                // save instrument data to file
                string dateString = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                if (DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    string data = 
                                  comboBoxInstrumentName.Text + "\n" +
                                  SerialNumberLabel.Text + "\n" +
                                  dateString + "\n" +
                                  SignalTypeLabel.Text + "\n" +
                                  MeasureTypeLabel.Text + "\n" +
                                  TextBoxOptions.Text + "\n" +
                                  CommentsTextLabel.Text + "\n" +
                                  Convert.ToDouble(textBoxLRV.Text) + "\n" +
                                  Convert.ToDouble(textBoxURV.Text) + "\n" +
                                  textBoxUnit.Text + "\n" +
                                  textBoxAlarmHigh.Text + "\n" +
                                  textBoxAlarmLow.Text + "\n";

                    string path = @"C:\Users\morte\OneDrive\Dokumenter\Instruments\" + comboBoxInstrumentName.Text + ".txt";
                    File.AppendAllText(path, data);
                }
                else
                {
                    MessageBox.Show("Invalid datetime format. Please enter a datetime in the format 'dd.MM.yyyy HH:mm:ss'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

                instrumentList.Add(instrument);
                textBoxRegister.AppendText(instrument.ToString());

                // save instrument data to file
                string dateString = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                if (DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    string data =
                                  comboBoxInstrumentName.Text + "\n" +
                                  SerialNumberLabel.Text + "\n" +
                                  dateString + "\n" +
                                  SignalTypeLabel.Text + "\n" +
                                  MeasureTypeLabel.Text + "\n" +
                                  TextBoxOptions.Text + "\n" +
                                  CommentsTextLabel.Text + "\n";
                                  

                    string path = @"C:\Users\morte\OneDrive\Dokumenter\Instruments\AFsignals" + comboBoxInstrumentName.Text + ".txt";
                    File.AppendAllText(path, data);
                }
                else
                {
                    MessageBox.Show("Invalid datetime format. Please enter a datetime in the format 'dd.MM.yyyy HH:mm:ss'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

                instrumentList.Add(instrument);
                textBoxRegister.AppendText(instrument.ToString());

                // save instrument data to file
                string dateString = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                if (DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    string data =
                                  comboBoxInstrumentName.Text + "\n" +
                                  SerialNumberLabel.Text + "\n" +
                                  dateString + "\n" +
                                  SignalTypeLabel.Text + "\n" +
                                  MeasureTypeLabel.Text + "\n" +
                                  TextBoxOptions.Text + "\n" +
                                  CommentsTextLabel.Text + "\n";


                    string path = @"C:\Users\morte\OneDrive\Dokumenter\Instruments\AFsignals" + comboBoxInstrumentName.Text + ".txt";
                    File.AppendAllText(path, data);
                }
                else
                {
                    MessageBox.Show("Invalid datetime format. Please enter a datetime in the format 'dd.MM.yyyy HH:mm:ss'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // check which radio button is checked before connecting to SQL server
            if (radioButton2.Checked)
            {
                InstrumentSQL();
                InstrumentSQLProcedure();
            }

            ClearForm();
        }
        private void InstrumentSQLProcedure()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("InsertNewInstrumentWithRange", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InstrumentName", comboBoxSenorName.Text);
                cmd.Parameters.AddWithValue("@RegisterDate", DateTime.Now);
                cmd.Parameters.AddWithValue("SerialNo", SerialNumberLabel.Text);
                cmd.Parameters.AddWithValue("@Comments", CommentsTextLabel.Text);
                cmd.Parameters.AddWithValue("@SignaType_Signal_id", 2);
                cmd.Parameters.AddWithValue("@MeasurementType_MeasuremntTypeId", 7);
                cmd.Parameters.AddWithValue("@Lrv", textBoxLRV.Text);
                cmd.Parameters.AddWithValue("@Urv", textBoxURV.Text);
                cmd.Parameters.AddWithValue("@AlarmHigh", textBoxAlarmHigh.Text);
                cmd.Parameters.AddWithValue("@AlarmLow", textBoxAlarmLow.Text);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void InstrumentSQL()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string InsertRangeQuery = "INSERT INTO AnalogRangeSet (Lrv, Urv, AlarmHigh, AlarmLow)"
                                    + "Values(@lrv, @urv, @alarmH, @alarmL); SELECT SCOPE_IDENTITY();";

            string insertInstrumentQuery = "INSERT INTO InstrumentSet(InstrumentName, RegisterDate, "
                                          + "SerialNo, Comments, SignaType_Signal_id, "
                                          + "MeasurementType_MeasuremntTypeID, AnalogRange_RangeId) "
                                          + "VALUES (@InstrumentName, GETDATE(), @SerialNo, @Comment, "
                                          + "@SignaType_Signal_id, @MeasurementType_MeasuremntTypeID, @RangeId);";

            string lrv = textBoxLRV.Text;
            string urv = textBoxURV.Text;
            string alarmH = textBoxAlarmHigh.Text;
            string alarmL = textBoxAlarmLow.Text;
            string instrumentName = comboBoxSenorName.Text;
            string serialNo = SerialNumberLabel.Text;
            string comment = CommentsTextLabel.Text;
            int signalType = 2;
            int measurementType = 7;

            //Insert Range Command
            sqlConnection.Open();

            SqlCommand command = new SqlCommand(InsertRangeQuery, sqlConnection);

            command.Parameters.AddWithValue("@lrv", lrv);
            command.Parameters.AddWithValue("@urv", urv);
            command.Parameters.AddWithValue("@alarmH", alarmH);
            command.Parameters.AddWithValue("@alarmL", alarmL);
            int RangeId = Convert.ToInt32(command.ExecuteScalar());

            //Insert Instrument Command
            SqlCommand command2 = new SqlCommand(insertInstrumentQuery, sqlConnection);
            command2.Parameters.AddWithValue("@instrumentName", instrumentName);
            command2.Parameters.AddWithValue("@serialNo", serialNo);
            command2.Parameters.AddWithValue("@comment", comment);
            command2.Parameters.AddWithValue("@SignaType_Signal_id", signalType);
            command2.Parameters.AddWithValue("@MeasurementType_MeasuremntTypeID", measurementType);
            command2.Parameters.AddWithValue("@RangeId", RangeId);
            command2.ExecuteNonQuery();
            sqlConnection.Close();


        }
        private void saveDataToFile()
        {
            //string data = instrument.ToString() + "\r\n";
            //string path = @"C:\Users\morte\OneDrive\Dokumenter\Instruments\" + comboBoxInstrumentName.Text + ".txt";
            //File.AppendAllText(path, data);
            /* string data = DateTime.Now.ToString() + "\r\n" +
                 comboBoxInstrumentName.Text + "\r\n" +
                 SerialNumberLabel.Text + "\r\n" +
                 SignalTypeLabel.Text + "\r\n" +
                 MeasureTypeLabel.Text + "\r\n" +
                 TextBoxOptions.Text + "\r\n" +
                 CommentsTextLabel.Text + "\r\n" +
                 textBoxLRV.Text + "\r\n" +
                 textBoxURV.Text + "\r\n" +
                 textBoxUnit.Text + "\r\n" +
                 textBoxAlarmLow.Text + "\r\n" +
                 textBoxAlarmHigh.Text + "\r\n";

             string fileName = comboBoxInstrumentName.Text + ".txt";
             string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Instruments");
             string path = Path.Combine(folderPath, fileName);

             if (!Directory.Exists(folderPath))
             {
                 Directory.CreateDirectory(folderPath);
             }

             File.AppendAllText(path, data);
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxRegister.TextLength > 0)
            {
                StreamWriter outputFile = new StreamWriter("register.csv");
                outputFile.Write(textBoxRegister.Text);
                outputFile.Close();
                //updatecomboBox_InstrumentList();
            }
        }

        /*  private void updatecomboBox_InstrumentList()
          {
              comboBoxInstrumentName.Items.Clear();
              comboBoxInstrumentName.Items.AddRange(Instrument.ToString().ToArray());
              comboBoxInstrumentName.DropDownHeight = comboBox_InstrumentList.ItemHeight * comboBox_InstrumentList.Items.Count;
              comboBoxInstrumentName.DisplayMember = "SensorName";
          }*/



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

        private void LoadInstrumentData()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "instrumentData.txt");
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] fields = line.Split('\r');
                    comboBoxInstrumentName.Items.Add(fields[1].Trim());
                }
            }
        }

        private void comboBoxInstrumentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get all files in the instrument directory
            string path = @"C:\Users\morte\OneDrive\Dokumenter\Instruments";
            string[] files = Directory.GetFiles(path);

            // iterate over each file and add it to the comboBoxInstrumentName if it's not already in the list
            foreach (string file in files)
            {
                string itemName = Path.GetFileNameWithoutExtension(file);
                if (!comboBoxInstrumentName.Items.Contains(itemName))
                {
                    comboBoxInstrumentName.Items.Add(itemName);
                }
            }


            // get the selected filename from the ComboBox
            string selectedFileName = null;
            if (comboBoxInstrumentName.SelectedItem != null)
            {
                selectedFileName = comboBoxInstrumentName.SelectedItem.ToString();
            }
            else
            {
                // handle the case where no filename is selected
                // for example, clear all the controls on the form
                ClearForm();
                return;
            }

            // construct the path to the file
            string filePath = Path.Combine(@"C:\Users\morte\OneDrive\Dokumenter\Instruments", selectedFileName + ".txt");

            // read the contents of the file
            string fileContents = File.ReadAllText(filePath);

            // parse the data in the file
            string[] data = fileContents.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // set the values of the appropriate controls on the form
            
            comboBoxInstrumentName.Text = data[0];
            SerialNumberLabel.Text = data[1];
            dateTimePicker1Label.Value = Convert.ToDateTime(data[2]);
            SignalTypeLabel.Text = data[3];
            MeasureTypeLabel.Text = data[4];
            TextBoxOptions.Text = data[5];
            CommentsTextLabel.Text = data[6];
            textBoxLRV.Text = data[7];
            textBoxURV.Text = data[8];
            textBoxUnit.Text = data[9];
            textBoxAlarmHigh.Text = data[10];
            textBoxAlarmLow.Text = data[11];
            
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
            string password = Prompt.ShowDialog("Enter Password", "Password");

            if (password != "password")
            {
                MessageBox.Show("Incorrect Password! Press Write configuration again");
                return;
            }

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
            if (radioButton1.Checked)
            {
                RegisterNewSensor();
            }
            if (radioButton2.Checked)
            {
                //InstrumentSQL();
                InstrumentSQLProcedure();
            }



        }





        private void clearButton_Click(object sender, EventArgs e)
        {
            textBoxRegister.Clear();
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

        private void testButton_Click(object sender, EventArgs e)
        {

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text), Convert.ToInt32(textBoxPort.Text));
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                // Connect to the server
                client.Connect(endPoint);

                // Send a command to get the available COM ports
                byte[] sendBuffer = Encoding.ASCII.GetBytes("comports");
                client.Send(sendBuffer);

                // Receive the COM port list from the server
                byte[] receiveBuffer = new byte[1024];
                int bytesRead = client.Receive(receiveBuffer);
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

        private void dateTimePicker1Label_ValueChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Date/Time";
        }

        public void ImportToComboBox(System.Windows.Forms.ComboBox cbToFill, string tableName, string dbVariable)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string sqlQuery = "SELECT " + dbVariable
                            + " FROM " + tableName
                            + " ORDER BY " + dbVariable
                            + " ASC";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                string sqlQueryResult;
                while (sqlDataReader.Read())
                {
                    sqlQueryResult = sqlDataReader[0].ToString();
                    cbToFill.Items.Add(sqlQueryResult);
                }
            }

            sqlConnection.Close();
        }

        private void comboBoxInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxInstrument_Click(object sender, EventArgs e)
        {
            //InstrumentSQL();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }



        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            string sql = "SELECT * FROM InstrumentSet";
            SqlConnection connection = new SqlConnection(connectionString);
            //SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, connection);
                DataSet dataSet = new DataSet();
                dataSet.Tables.Add("Instruments");
                dataAdapter.Fill(dataSet.Tables["Instruments"]);
                bindingSourceInstrument.DataSource = dataSet.Tables["Instruments"];
                comboBoxSenorName.DataSource = bindingSourceInstrument;
                comboBoxSenorName.DisplayMember = "InstrumentName";
                comboBoxSenorName.ValueMember = "Instrument_id";
                SerialNumberLabel.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "SerialNo"));
                CommentsTextLabel.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "Comments"));
                dateTimePicker1Label.DataBindings.Add(new Binding("Value", bindingSourceInstrument, "RegisterDate"));
                /*
                SqlCommand cmd = new SqlCommand("InsertNewInstrumentWithRange", sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InstrumentName", comboBoxSenorName.Text);
                cmd.Parameters.AddWithValue("@RegisterDate", DateTime.Now);
                cmd.Parameters.AddWithValue("SerialNo",SerialNumberLabel.Text);
                cmd.Parameters.AddWithValue("@Comments", CommentsTextLabel.Text);
                cmd.Parameters.AddWithValue("@SignaType_Signal_id", 2);
                cmd.Parameters.AddWithValue("@MeasurementType_MeasuremntTypeId", 7);
                cmd.Parameters.AddWithValue("@Lrv", textBoxLRV.Text);
                cmd.Parameters.AddWithValue("@Urv", textBoxURV.Text);
                cmd.Parameters.AddWithValue("@AlarmHigh", textBoxAlarmHigh.Text);
                cmd.Parameters.AddWithValue("@AlarmLow", textBoxAlarmLow.Text);

                sqlConnection.Open();
                cmd.ExecuteNonQuery();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ClearForm();

            if (radioButton1.Checked)

            {
                comboBoxInstrumentName.Visible = true;
                comboBoxSenorName.Visible = false;
            }
            else
            {
                comboBoxInstrumentName.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            ClearForm();
            if (radioButton2.Checked)
            {
                comboBoxSenorName.Visible = true;
                comboBoxInstrumentName.Visible = false;
            }
            else
            {
                comboBoxSenorName.Visible = false;
            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            IEnumerable<double> instrumentListQuery =
                from instrument in instrumentList
                where instrument.SerialNumber.StartsWith('1')
                select instrument.URV;

            double average = instrumentListQuery.Count();
            listBox_IpAddresses.Items.Add("Average URV:" + average.ToString());


            foreach (double urv in instrumentListQuery)
            {
                listBox_IpAddresses.Items.Add(urv.ToString());
            }


            /*IEnumerable<string> analogSignalQuery = analogSignals
                                .Where(analogSignal => analogSignal.StartsWith('0'))
                                .OrderByDescending(analogSignal => analogSignal);
                                
                                

            /*
            IEnumerable<string> analogSignalQuery =
                from analogSignal in analogSignals
                where analogSignal.StartsWith('0')
                orderby analogSignal descending
                select analogSignal;
            */
            /*
            foreach (string signal in analogSignalQuery)
            {
                listBox_IpAddresses.Items.Add(signal);
            }
            */


        }


    }
}




