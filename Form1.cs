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
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace FirstWinFormsApp1
{
    public partial class Form1 : Form


    {

        private System.Windows.Forms.Timer connectionTimer;




        //Constans

        readonly int[] numbers = new int[7] { 5, 3, 7, 25, 65, 32, 43 };
        string[] analogSignals = new string[] { "0-5VDC", "0-10VDC", "0-20mA", "4-20mA", "RTD" };
        string[] digitalSignals = new string[] { "5VDC", "10VDC", "24VDC", "Relay" };
        string[] fieldbusSigals = new string[] { "Modbus RTU", "ModbusTCP", "Profibus", "ProfiNet", "CANBus", "EtherCat", "RS48" };
        string[] MeasurementTypeId = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };
        string[] SignalTypeId = new string[] { "1", "2", "3" };
        string[] MesurementTypeSet = new string[] { "0-5VDC", "0-10VDC", "0-20mA", "4-20mA", "RTD", "5VDC", "10VDC0", "24VDC", "Relay", "Modbus RTU", "ModbusTCP", "Profibus", "ProfiNet", "CANBus", "EtherCat", "RS48" };
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


        string fileNameInstrumentList = "instrumentList.csv";



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

            try
            {
                //ImportToComboBox(comboBoxSenorName, "InstrumentSet", "InstrumentName");
                ImportToComboBox(comboBoxLocation, "InstrumentSet", "Location");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Reload previous sensor names
            string sensorNamesFile = "instrumentList.csv";


            // Save instrument list to file
            using (var outputFile = new StreamWriter(instrumentListFile))
            {
                foreach (Instrument instrument in instrumentList)
                {
                    outputFile.WriteLine(instrument.ToString());
                }
            }
            // Display pop-up message
            DialogResult result = MessageBox.Show("Go to 'Connection' tab to connect FE to BE", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        public Form1()
        {



            InitializeComponent();
            comboBoxInstrumentName.Visible = false;
            comboBoxSenorName.Visible = false;
            textBoxLocation.Visible = false;
            comboBoxLocation.Visible = false;
            textBoxInstrumentID.Visible = false;
            radioButtonInstrumentID.Visible = false;
            buttonOpenFile.Visible = false;
            sqlLabel.Visible = false;
            saveToFileLabel.Visible = false;
            instrumentIDLabel.Visible = false;


            //comboBoxLocation.Visible = false;
            // Set initial value of textBoxLocation to a hyphen (-)
            //textBoxLocation.Text = "-";

            connectionString = ConfigurationManager.ConnectionStrings["instrumentConfDB"].ConnectionString;
            listBox_IpAddresses.Items.Add(DateTime.Now.ToString());
            IPAddress[] addresslist = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in addresslist)
            {
                //listBox_IpAddresses.Items.Add(address.ToString());

                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    listBox_IpAddresses.Items.Add(address.ToString());
                    Dns.GetHostAddresses(Dns.GetHostName());
                }
            }
            // Create and start the timer for checking the connection
            connectionTimer = new System.Windows.Forms.Timer();
            connectionTimer.Interval = 1000; // 1 seconds
            connectionTimer.Tick += new EventHandler(CheckConnectionStatus);
            connectionTimer.Start();

            // Call the CheckConnectionStatus method once to initialize the label visibility
            CheckConnectionStatus(null, null);


        }

        private bool isConnected = false;
        private bool IsConnectedToBackend()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return conn != null;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CheckConnectionStatus(object sender, EventArgs e)
        {

        }


        private void ClearForm()
        {
            //Reset from initial state
            toolStripStatusLabel1.Text = "Cleared";

            //Clear data bindings
            comboBoxSenorName.DataBindings.Clear();
            comboBoxInstrumentName.DataBindings.Clear();
            comboBoxLocation.DataBindings.Clear();
            textBoxInstrumentID.DataBindings.Clear();
            textBoxLocation.DataBindings.Clear();
            radioButtonInstrumentID.DataBindings.Clear();

            textBoxRegister.AppendText("" + "\r\n");

            //Reset other controls to initial state
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
            textBoxLocation.Text = "";
            textBoxInstrumentID.Text = "";
            MeasureTypeLabel.Text = "";
            comboBoxLocation.Text = "";

        }

        private void ClearFormBE()
        {
            textBoxIP.Text = "";
            textBoxPort.Text = "";

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

        private void RegisterNewSensor()
        {
            toolStripStatusLabel1.Text = "OK";
            RegisterIndex++;

            if (SignalTypeLabel.Text == "Analog")
            {
                analogIndex++;

                Instrument instrument = new Instrument(
                                                        Convert.ToString(DateTime.Now) + "\n",
                                                        comboBoxInstrumentName.Text + "\r\n",
                                                        SerialNumberLabel.Text + "\r\n",
                                                        SignalTypeLabel.Text + "\r\n",
                                                        MeasureTypeLabel.Text + "\r\n",
                                                        textBoxInstrumentID.Text + "\r\n",
                                                        TextBoxOptions.Text + "\r\n",
                                                        CommentsTextLabel.Text + "\r\n",
                                                        Convert.ToDouble(textBoxLRV.Text),
                                                        Convert.ToDouble(textBoxURV.Text),
                                                        textBoxUnit.Text + "\r\n",
                                                        textBoxLocation.Text + "\r\n"
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
                                  textBoxLocation.Text + "\n" +
                                  SignalTypeLabel.Text + "\n" +
                                  MeasureTypeLabel.Text + "\n" +
                                  textBoxInstrumentID.Text + "\n" +
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
                                                        textBoxInstrumentID.Text + "\r\n",
                                                        TextBoxOptions.Text + "\r\n",
                                                        CommentsTextLabel.Text + "\r\n",
                                                        lrvValue,
                                                        urvValue,
                                                        textBoxUnit.Text + "\r\n",
                                                        textBoxLocation.Text + "\r\n");


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
                                  textBoxLocation.Text + "\n" +
                                  SignalTypeLabel.Text + "\n" +
                                  MeasureTypeLabel.Text + "\n" +
                                  textBoxInstrumentID.Text + "\n" +
                                  TextBoxOptions.Text + "\n" +
                                  CommentsTextLabel.Text + "\n";



                    string path = @"C:\Users\morte\OneDrive\Dokumenter\Instruments\" + comboBoxInstrumentName.Text + ".txt";
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
                                                        textBoxInstrumentID.Text + "\r\n",
                                                        TextBoxOptions.Text + "\r\n",
                                                        CommentsTextLabel.Text + "\r\n",
                                                        lrvValue,
                                                        urvValue,
                                                        textBoxUnit.Text + "\r\n",
                                                        textBoxLocation.Text + "\r\n");

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
                                  textBoxLocation.Text + "\n" +
                                  SignalTypeLabel.Text + "\n" +
                                  MeasureTypeLabel.Text + "\n" +
                                  textBoxInstrumentID.Text + "\n" +
                                  TextBoxOptions.Text + "\n" +
                                  CommentsTextLabel.Text + "\n";


                    string path = @"C:\Users\morte\OneDrive\Dokumenter\Instruments\" + comboBoxInstrumentName.Text + ".txt";
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
                cmd.Parameters.AddWithValue("@Location", comboBoxLocation.Text);
                cmd.Parameters.AddWithValue("@RegisterDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@SerialNo", SerialNumberLabel.Text);
                cmd.Parameters.AddWithValue("@Comments", CommentsTextLabel.Text);
                cmd.Parameters.AddWithValue("@SignaType_Signal_id", SignalTypeLabel.SelectedValue);
                cmd.Parameters.AddWithValue("@MeasurementType_MeasuremntTypeId", MeasureTypeLabel.SelectedValue);
                cmd.Parameters.AddWithValue("@Lrv", textBoxLRV.Text);
                cmd.Parameters.AddWithValue("@Urv", textBoxURV.Text);
                cmd.Parameters.AddWithValue("@AlarmHigh", textBoxAlarmHigh.Text);
                cmd.Parameters.AddWithValue("@AlarmLow", textBoxAlarmLow.Text);

                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    textBoxInstrumentID.Text = reader["Instrument_id"].ToString();
                    comboBoxSenorName.Text = reader["InstrumentName"].ToString();
                    // Read other columns here...
                }
                reader.Close();
                // Clear existing items in comboBoxSenorName
                comboBoxSenorName.Items.Clear();

                // Populate comboBoxSenorName based on the selected value of comboBoxLocation
                string query = "SELECT InstrumentName FROM InstrumentSet WHERE InstrumentName = @InstrumentName";
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@Location", comboBoxLocation.Text);
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxSenorName.Items.Add(dataReader["InstrumentName"]);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void InstrumentSQL() //Saves to sql
        {
            RegisterIndex++;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string InsertRangeQuery = "INSERT INTO AnalogRangeSet (Lrv, Urv, AlarmHigh, AlarmLow, Unit)"
                                    + "Values(@lrv, @urv, @alarmH, @alarmL, @unit ); SELECT SCOPE_IDENTITY();";

            string insertInstrumentQuery = "INSERT INTO InstrumentSet(InstrumentName, RegisterDate, "
                                + "SerialNo, Comments, SignaType_Signal_id, Location,"
                                + "MeasurementType_MeasuremntTypeID, AnalogRange_RangeId, SerialPortNr) "
                                + "VALUES (@InstrumentName, GETDATE(), @serialNo, @comment, "
                                + "@SignaType_Signal_id, @Location, @MeasurementType_MeasuremntTypeID, @AnalogRange_RangeId, @SerialPortNr);";

            string lrv = textBoxLRV.Text;
            string urv = textBoxURV.Text;
            string alarmH = textBoxAlarmHigh.Text;
            string alarmL = textBoxAlarmLow.Text;
            string unit = textBoxUnit.Text;
            string instrumentName = comboBoxSenorName.Text;
            string serialNo = SerialNumberLabel.Text;
            string comment = CommentsTextLabel.Text;
            string location = comboBoxLocation.Text;
            string signalType = SignalTypeLabel.SelectedItem.ToString();
            string measurementTypeName = MeasureTypeLabel.SelectedItem.ToString(); // Get the measurement type name
            string registerDate = DateTime.Now.ToString(); // current date and time
            int serialPortNr = 3;

            // Get the integer value for SignaType_Signal_id based on the selected value of the SignalTypeLabel combobox
            int signalTypeId;
            switch (signalType)
            {
                case "Analog":
                    signalTypeId = 1;
                    analogIndex++;
                    break;
                case "Digital":
                    signalTypeId = 2;
                    digitalIndex++;
                    break;
                case "Fieldbus":
                    signalTypeId = 3;
                    fieldbusIndex++;
                    break;
                default:
                    signalTypeId = 0;
                    break;
            }

            // Get the integer value for MeasurementType_MeasuremntTypeID based on the selected value of the MeasureTypeLabel combobox
            int measurementTypeId;
            switch (measurementTypeName)
            {
                case "0-5VDC":
                    measurementTypeId = 1;
                    break;
                case "0-10VDC":
                    measurementTypeId = 2;
                    break;
                case "0-20mA":
                    measurementTypeId = 3;
                    break;
                case "4-20mA":
                    measurementTypeId = 4;
                    break;
                case "RTD":
                    measurementTypeId = 5;
                    break;
                case "5VDC":
                    measurementTypeId = 6;
                    break;
                case "10VDC":
                    measurementTypeId = 7;
                    break;
                case "24VDC":
                    measurementTypeId = 8;
                    break;
                case "Relay":
                    measurementTypeId = 9;
                    break;
                case "Modus RTU":
                    measurementTypeId = 10;
                    break;
                case "Modus TCP":
                    measurementTypeId = 11;
                    break;
                case "ProfiBus":
                    measurementTypeId = 12;
                    break;
                case "ProfiNet":
                    measurementTypeId = 13;
                    break;
                case "CANBus":
                    measurementTypeId = 14;
                    break;
                case "EtherCat":
                    measurementTypeId = 15;
                    break;
                case "RS48":
                    measurementTypeId = 16;
                    break;
                default:
                    measurementTypeId = -1;
                    break;
            }
            try
            {
                //Insert Range Command
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(InsertRangeQuery, sqlConnection);

                command.Parameters.AddWithValue("@lrv", lrv);
                command.Parameters.AddWithValue("@urv", urv);
                command.Parameters.AddWithValue("@alarmH", alarmH);
                command.Parameters.AddWithValue("@alarmL", alarmL);
                command.Parameters.AddWithValue("@unit", unit);
                int RangeId = Convert.ToInt32(command.ExecuteScalar());

                //Insert Instrument Command
                SqlCommand command2 = new SqlCommand(insertInstrumentQuery, sqlConnection);
                command2.Parameters.AddWithValue("@InstrumentName", instrumentName);
                command2.Parameters.AddWithValue("@serialNo", serialNo);
                command2.Parameters.AddWithValue("@Location", location);
                command2.Parameters.AddWithValue("@comment", comment);
                command2.Parameters.AddWithValue("@SignaType_Signal_id", signalTypeId);
                command2.Parameters.AddWithValue("@MeasurementType_MeasuremntTypeID", measurementTypeId);
                command2.Parameters.AddWithValue("@AnalogRange_RangeId", RangeId);
                command2.Parameters.AddWithValue("@SerialPortNr", serialPortNr);

                command2.ExecuteNonQuery();
                sqlConnection.Close();
                ClearForm();
                MessageBox.Show("Data saved successfully!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\Users\morte\OneDrive\Dokumenter\Instruments";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            // if the user selects a file, load its data into the appropriate textboxes
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // read the contents of the file
                string fileContents = File.ReadAllText(openFileDialog.FileName);

                // parse the data in the file
                string[] data = fileContents.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                // check if file has 14 lines of data
                if (data.Length == 14)
                {
                    // set the values of the appropriate textboxes on the form
                    comboBoxInstrumentName.Text = data[0];
                    SerialNumberLabel.Text = data[1];
                    dateTimePicker1Label.Value = Convert.ToDateTime(data[2]);
                    textBoxLocation.Text = data[3];
                    SignalTypeLabel.Text = data[4];
                    MeasureTypeLabel.Text = data[5];
                    textBoxInstrumentID.Text = data[6];
                    TextBoxOptions.Text = data[7];
                    CommentsTextLabel.Text = data[8];
                    textBoxLRV.Text = data[9];
                    textBoxURV.Text = data[10];
                    textBoxUnit.Text = data[11];
                    textBoxAlarmHigh.Text = data[12];
                    textBoxAlarmLow.Text = data[13];
                }
                // check if file has 9 lines of data
                else if (data.Length == 9)
                {
                    // set the values of the appropriate textboxes on the form
                    comboBoxInstrumentName.Text = data[0];
                    SerialNumberLabel.Text = data[1];
                    dateTimePicker1Label.Value = Convert.ToDateTime(data[2]);
                    textBoxLocation.Text = data[3];
                    SignalTypeLabel.Text = data[4];
                    MeasureTypeLabel.Text = data[5];
                    textBoxInstrumentID.Text = data[6];
                    TextBoxOptions.Text = data[7];
                    CommentsTextLabel.Text = data[8];
                    // clear the values of the unused textboxes on the form
                    textBoxLRV.Text = "";
                    textBoxURV.Text = "";
                    textBoxUnit.Text = "";
                    textBoxAlarmHigh.Text = "";
                    textBoxAlarmLow.Text = "";
                }
                else
                {
                    // handle the case where the file has an unexpected number of lines
                    // for example, clear all the textboxes on the form
                    ClearForm();
                    MessageBox.Show("The selected file has an unexpected number of lines. It should have either 9 or 14 lines of data.");
                    return;
                }
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

            // check if file has 14 lines of data
            if (data.Length == 14)
            {
                // set the values of the appropriate controls on the form
                comboBoxInstrumentName.Text = data[0];
                SerialNumberLabel.Text = data[1];
                dateTimePicker1Label.Value = Convert.ToDateTime(data[2]);
                textBoxLocation.Text = data[3];
                SignalTypeLabel.Text = data[4];
                MeasureTypeLabel.Text = data[5];
                textBoxInstrumentID.Text = data[6];
                TextBoxOptions.Text = data[7];
                CommentsTextLabel.Text = data[8];
                textBoxLRV.Text = data[9];
                textBoxURV.Text = data[10];
                textBoxUnit.Text = data[11];
                textBoxAlarmHigh.Text = data[12];
                textBoxAlarmLow.Text = data[13];
            }
            // check if file has 9 lines of data
            else if (data.Length == 9)
            {
                // set the values of the appropriate controls on the form
                comboBoxInstrumentName.Text = data[0];
                SerialNumberLabel.Text = data[1];
                dateTimePicker1Label.Value = Convert.ToDateTime(data[2]);
                textBoxLocation.Text = data[3];
                SignalTypeLabel.Text = data[4];
                MeasureTypeLabel.Text = data[5];
                textBoxInstrumentID.Text = data[6];
                TextBoxOptions.Text = data[7];
                CommentsTextLabel.Text = data[8];
                // clear the values of the unused controls on the form
                textBoxLRV.Text = "";
                textBoxURV.Text = "";
                textBoxUnit.Text = "";
                textBoxAlarmHigh.Text = "";
                textBoxAlarmLow.Text = "";
            }
            else
            {
                // handle the case where the file has an unexpected number of lines
                // for example, clear all the controls on the form
                ClearForm();
                MessageBox.Show("The selected file has an unexpected number of lines. It should have either 9 or 14 lines of data.");
                return;
            }

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

            try
            {
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text),
                 Convert.ToInt32(textBoxPort.Text));
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(endpoint);
                textBoxCommunication.AppendText("Connected to server.");

                client.Send(Encoding.ASCII.GetBytes(command));

                byte[] buffer = new byte[1024];
                int bytesReceived = client.Receive(buffer);
                string received = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                textBoxCommunication.AppendText("Received: " + received);
                client.Close();
                textBoxCommunication.AppendText("Disconnected from server.");
                return received;
            }
            catch (Exception ex)
            {
                // Display the error message in a message box
                MessageBox.Show("Error occurred: " + ex.Message);
                return null;
            }
        }


        private bool IsConnected()
        {
            try
            {
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text),
                Convert.ToInt32(textBoxPort.Text));
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(endpoint);
                client.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            textBoxChart.Clear();

            // Reset the X and Y axis values
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.Minimum = Double.NaN;
            chart1.ChartAreas[0].AxisX.Maximum = Double.NaN;


            if (!IsConnected())
            {
                MessageBox.Show("BE is not connected.\r\n");
                return;
            }
            if (timerRedaScaled.Enabled)
            {
                timerRedaScaled.Stop();
            }
            else
            {
                // Create a new file with a unique name
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string fileId = Guid.NewGuid().ToString().Substring(0, 8);
                string fileName = $"output_{timestamp}_{fileId}.csv";

                // Allow the user to select a file name
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.InitialDirectory = @"C:\Users\morte\OneDrive\Dokumenter\InstrumentCSV";
                    saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;

                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        fileName = saveFileDialog1.FileName;
                    }
                    else
                    {
                        return;
                    }
                }

                // Clear the existing chart data
                chart1.Series[0].Points.Clear();

                // Call timer1_Tick to get the first reading and add it to the chart
                timer1_Tick(this, EventArgs.Empty);

                // Start the timer that updates the chart
                timerRedaScaled.Start();

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

                // Show the radioButtonConnection control
                labelConnecionOK.Visible = true;
            }
        }



        private void buttonReadConfiguration_Click(object sender, EventArgs e)
        {
            if (!IsConnected())
            {
                textBoxCommunication.AppendText("BE is not connected.\r\n");
                return;
            }

            string[] sensorConf;
            string received;
            received = sendToBackEnd("readconf");
            sensorConf = received.Split(',');
            textBoxCommunication.AppendText(received + "\r\n");
        }

        private void buttonReadState_Click(object sender, EventArgs e)
        {
            if (!IsConnected())
            {
                textBoxCommunication.AppendText("BE is not connected.\r\n");
                return;
            }

            string[] sensorState;
            string received;
            received = sendToBackEnd("readstatus");
            sensorState = received.Split(",");
            textBoxCommunication.AppendText(received + "\r\n");

        }

        private void buttonReadScaled_Click(object sender, EventArgs e)
        {
            if (!IsConnected())
            {
                textBoxCommunication.AppendText("BE is not connected.\r\n");
                return;
            }

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
            if (!IsConnected())
            {
                textBoxCommunication.AppendText("BE is not connected.\r\n");
                return;
            }

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

        private bool isFirstTick = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateChartData();
        }

        private void UpdateChartData()
        {
            xTimeValue += 1;
            double yValue = 0.0;
            string received;

            try
            {
                received = sendToBackEnd("readscaled");
                string[] receivedParts = received.Split(";");
                if (receivedParts.Length < 2)
                {
                    throw new Exception("Received message has an invalid format");
                }
                string receivedString = receivedParts[1].Remove(receivedParts[1].Length - 2);

                yValue = Convert.ToDouble(receivedString, CultureInfo.InvariantCulture);

                if (isFirstTick)
                {
                    chart1.Series[0].Points.AddXY(xTimeValue - 0, yValue);
                    isFirstTick = false;
                }
                else
                {
                    chart1.Series[0].Points.AddXY(xTimeValue, yValue);
                }
            }
            catch (SocketException ex)
            {
                textBoxCommunication.AppendText("Socket exception: " + ex.Message + "\r\n");
            }
            catch (FormatException ex)
            {
                textBoxCommunication.AppendText("Format exception: " + ex.Message + "\r\n");
            }
            catch (IndexOutOfRangeException ex)
            {
                textBoxCommunication.AppendText("Index out of range exception: " + ex.Message + "\r\n");
            }
            catch (Exception ex)
            {
                textBoxCommunication.AppendText("Error: " + ex.Message + "\r\n");
            }
        }

        private void GetInitialReading()
        {
            try
            {
                string received = sendToBackEnd("readscaled");
                string[] receivedParts = received.Split(";");
                string receivedString = receivedParts[1].Remove(receivedParts[1].Length - 2);
                double yValue = Convert.ToDouble(receivedString, CultureInfo.InvariantCulture);
                chart1.Series[0].Points.AddXY(xTimeValue, yValue);
            }
            catch (Exception ex)
            {
                textBoxCommunication.AppendText("Error: " + ex.Message + "\r\n");
            }
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
            // get the selected file name from the comboBoxInstrumentName control
            string selectedFileName = comboBoxInstrumentName.SelectedItem?.ToString();

            // construct the full file path using the directory path and the selected file name
            string filePath = Path.Combine(@"C:\Users\morte\OneDrive\Dokumenter\Instruments", selectedFileName + ".txt");

            // display a message box to confirm whether the user wants to clear the file
            DialogResult result = MessageBox.Show($"Are you sure you want to change the contents of the file '{selectedFileName}.txt'?", "Confirm Clear", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        // clear the contents of the file
                        File.WriteAllText(filePath, "");



                        // save the data to the file
                        string dateString = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                        if (DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                        {
                            string data = "";
                            switch (SignalTypeLabel.Text)
                            {
                                case "Analog":


                                    Instrument analogInstrument = new Instrument(
                                        Convert.ToString(DateTime.Now) + "\n",
                                        comboBoxInstrumentName.Text + "\r\n",
                                        SerialNumberLabel.Text + "\r\n",
                                        SignalTypeLabel.Text + "\r\n",
                                        MeasureTypeLabel.Text + "\r\n",
                                        textBoxInstrumentID.Text + "\r\n",
                                        TextBoxOptions.Text + "\r\n",
                                        CommentsTextLabel.Text + "\r\n",
                                        Convert.ToDouble(textBoxLRV.Text),
                                        Convert.ToDouble(textBoxURV.Text),
                                        textBoxUnit.Text + "\r\n",
                                        textBoxLocation.Text + "\r\n");

                                    spanValue = urvValue - lrvValue;
                                    instrumentList.Add(analogInstrument);
                                    textBoxRegister.AppendText(analogInstrument.ToString());
                                    textBoxRegister.AppendText("LRV Value: " + analogInstrument.LRV + "\r\n");
                                    textBoxRegister.AppendText("URV Value: " + analogInstrument.URV + "\r\n");
                                    textBoxRegister.AppendText("Span Value: " + spanValue + "\r\n");
                                    textBoxRegister.AppendText("Alarm High: " + textBoxAlarmHigh.Text + "\r\n");
                                    textBoxRegister.AppendText("Alarm Low: " + textBoxAlarmLow.Text + "\r\n");

                                    data = comboBoxInstrumentName.Text + "\n" +
                                           SerialNumberLabel.Text + "\n" +
                                           dateString + "\n" +
                                           textBoxLocation.Text + "\n" +
                                           SignalTypeLabel.Text + "\n" +
                                           MeasureTypeLabel.Text + "\n" +
                                           textBoxInstrumentID.Text + "\n" +
                                           TextBoxOptions.Text + "\n" +
                                           CommentsTextLabel.Text + "\n" +
                                           Convert.ToDouble(textBoxLRV.Text) + "\n" +
                                           Convert.ToDouble(textBoxURV.Text) + "\n" +
                                           textBoxUnit.Text + "\n" +
                                           textBoxAlarmHigh.Text + "\n" +
                                           textBoxAlarmLow.Text + "\n";
                                    break;

                                case "Digital":


                                    Instrument digitalInstrument = new Instrument(
                                        Convert.ToString(DateTime.Now) + "\r\n",
                                        comboBoxInstrumentName.Text + "\r\n",
                                        SerialNumberLabel.Text + "\r\n",
                                        SignalTypeLabel.Text + "\r\n",
                                        MeasureTypeLabel.Text + "\r\n",
                                        textBoxInstrumentID.Text + "\r\n",
                                        TextBoxOptions.Text + "\r\n",
                                        CommentsTextLabel.Text + "\r\n",
                                        lrvValue,
                                        urvValue,
                                        textBoxUnit.Text + "\r\n",
                                        textBoxLocation.Text + "\r\n");

                                    instrumentList.Add(digitalInstrument);
                                    textBoxRegister.AppendText(digitalInstrument.ToString());

                                    data = comboBoxInstrumentName.Text + "\n" +
                                           SerialNumberLabel.Text + "\n" +
                                           dateString + "\n" +
                                           textBoxLocation.Text + "\n" +
                                           SignalTypeLabel.Text + "\n" +
                                           MeasureTypeLabel.Text + "\n" +
                                           textBoxInstrumentID.Text + "\n" +
                                           TextBoxOptions.Text + "\n" +
                                           CommentsTextLabel.Text + "\n";
                                    break;

                                case "Fieldbus":


                                    Instrument fieldbusInstrument = new Instrument(
                                        Convert.ToString(DateTime.Now) + "\r\n",
                                        comboBoxInstrumentName.Text + "\r\n",
                                        SerialNumberLabel.Text + "\r\n",
                                        SignalTypeLabel.Text + "\r\n",
                                        MeasureTypeLabel.Text + "\r\n",
                                        textBoxInstrumentID.Text + "\r\n",
                                        TextBoxOptions.Text + "\r\n",
                                        CommentsTextLabel.Text + "\r\n",
                                        lrvValue,
                                        urvValue,
                                        textBoxUnit.Text + "\r\n",
                                        textBoxLocation.Text + "\r\n");

                                    instrumentList.Add(fieldbusInstrument);
                                    textBoxRegister.AppendText(fieldbusInstrument.ToString());

                                    data = comboBoxInstrumentName.Text + "\n" +
                                           SerialNumberLabel.Text + "\n" +
                                           dateString + "\n" +
                                           textBoxLocation.Text + "\n" +
                                           SignalTypeLabel.Text + "\n" +
                                           MeasureTypeLabel.Text + "\n" +
                                           textBoxInstrumentID.Text + "\n" +
                                           TextBoxOptions.Text + "\n" +
                                           CommentsTextLabel.Text + "\n";
                                    break;
                            }
                            // write the data to the file
                            File.WriteAllText(filePath, data);
                            // show a message box to confirm that changes were saved
                            MessageBox.Show("Changes saved.", "Save Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Invalid datetime format. Please enter a datetime in the format 'dd.MM.yyyy HH:mm:ss'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        // reload the list of files in the directory
                        comboBoxInstrumentName.Items.Clear();
                        string[] files = Directory.GetFiles(@"C:\Users\morte\OneDrive\Dokumenter\Instruments");
                        foreach (string file in files)
                        {
                            string itemName = Path.GetFileNameWithoutExtension(file);
                            if (!comboBoxInstrumentName.Items.Contains(itemName))
                            {
                                comboBoxInstrumentName.Items.Add(itemName);
                            }
                        }

                        // clear all the controls on the form
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("File not found.");
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("An error occurred while clearing the file: " + ex.Message);
                }
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!IsConnected())
            {
                textBoxCommunication.AppendText("BE is not connected.\r\n");
                return;
            }
            if (string.IsNullOrEmpty(textBoxSend.Text))
            {
                MessageBox.Show("Cannot send empty message.\r\n");
                return;
            }
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text),
                Convert.ToInt32(textBoxPort.Text));
                Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                client.Connect(endPoint);

                textBoxCommunication.AppendText("Connected to server..." + "\r\n");

                //Client Send
                client.Send(Encoding.ASCII.GetBytes(textBoxSend.Text));

                //Client Receive
                byte[] buffer = new byte[1024];
                int bytesReceived = client.Receive(buffer);

                textBoxCommunication.AppendText("Received..." + Encoding.ASCII.GetString(buffer, 0, bytesReceived) + "\r\n");

                client.Close();
                textBoxCommunication.AppendText("Connection closed..." + "\r\n");
            }
            catch (Exception ex)
            {
                textBoxCommunication.AppendText("Error: " + ex.Message + "\r\n");
            }

        }



        private void deleButton_Click(object sender, EventArgs e)
        {
            delete_From_file();

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                RegisterNewSensor();
            }
            if (radioButton2.Checked)
            {
                InstrumentSQL();


            }



        }





        private void clearButton_Click(object sender, EventArgs e)
        {
            textBoxRegister.Clear();
            ClearForm();
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
            if (!IsConnected())
            {
                MessageBox.Show("BE is not connected.\r\n");
                return;
            }
            timerRedaScaled.Stop();

            // Show the radioButtonConnection control
            labelConnecionOK.Visible = false;
            MessageBox.Show("Measurment session stopped. File saved.\r\n");
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            if (!IsConnected())
            {
                textBoxCommunication.AppendText("BE is not connected.\r\n");
                return;
            }

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBoxIP.Text),
            Convert.ToInt32(textBoxPort.Text));
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
                        //listBox_IpAddresses.Items.Add("Available COM Ports:");
                        comboBoxComPort.Items.Add(comPort);
                        listBox_IpAddresses.Items.Add(comPort);
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



        private void comboBoxInstrument_Click(object sender, EventArgs e)
        {
            //InstrumentSQL();
        }





        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            load_form_sql();
        }

        private void load_form_sql()
        {
            // Define SQL queries to select all data from database tables.
            string sqlInstrument = "SELECT * FROM InstrumentSet " +
            "JOIN AnalogRangeSet ON InstrumentSet.AnalogRange_RangeId = AnalogRangeSet.RangeId " +
            "JOIN SignalTypeSet ON InstrumentSet.SignaType_Signal_Id = SignalTypeSet.Signal_id " +
            "JOIN MeasurementTypeSet ON InstrumentSet.MeasurementType_MeasuremntTypeId = MeasurementTypeSet.MeasuremntTypeId";


            // Create a SqlConnection object using a connection string to connect to a database.
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Create SqlDataAdapter objects using the SQL queries and SqlConnection object.
                SqlDataAdapter dataAdapterInstrument = new SqlDataAdapter(sqlInstrument, connection);


                // Create a new DataSet object.
                DataSet dataSet = new DataSet();

                // Add a new DataTable object to the DataSet with the name "Instruments".
                dataSet.Tables.Add("Instruments");
                // Fill the "Instruments" DataTable with the data returned from the SQL query using the dataAdapterInstrument.
                dataAdapterInstrument.Fill(dataSet.Tables["Instruments"]);


                // Set the DataSource property
                bindingSourceInstrument.DataSource = dataSet.Tables["Instruments"];
                

                // Set the DataSource property of a ComboBox control called "comboBoxSenorName" to the bindingSourceInstrument object.
                comboBoxSenorName.DataSource = bindingSourceInstrument;

                // Set the DisplayMember property of the comboBoxSenorName control to "InstrumentName" which is a field/column in the "Instruments" DataTable.
                comboBoxSenorName.DisplayMember = "InstrumentName";

                // Set the ValueMember property of the comboBoxSenorName control to "Instrument_id" which is another field/column in the "Instruments" DataTable.
                comboBoxSenorName.ValueMember = "Instrument_id";

                //Data binding for Instrument
                SerialNumberLabel.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "SerialNo"));
                CommentsTextLabel.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "Comments"));
                dateTimePicker1Label.DataBindings.Add(new Binding("Value", bindingSourceInstrument, "RegisterDate"));
                comboBoxLocation.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "Location"));
                textBoxLRV.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "Lrv"));
                textBoxURV.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "Urv"));
                textBoxUnit.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "Unit"));
                textBoxAlarmHigh.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "AlarmHigh"));
                textBoxAlarmLow.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "AlarmLow"));
                MeasureTypeLabel.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "MeasurementTypeName"));
                SignalTypeLabel.DataBindings.Add(new Binding("Text", bindingSourceInstrument, "SignalTypeName"));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBoxInstrumentName.DataBindings.Clear();
                textBoxLocation.DataBindings.Clear();
                comboBoxSenorName.DataBindings.Clear();
                textBoxInstrumentID.DataBindings.Clear();
                ClearForm();
                comboBoxInstrumentName.Visible = true;
                textBoxLocation.Visible = true;
                comboBoxLocation.Visible = false;
                comboBoxSenorName.Visible = false;
                textBoxInstrumentID.Visible = true;
                radioButtonInstrumentID.Visible = true;
                buttonOpenFile.Visible = true;
                sqlLabel.Visible = false;
                saveToFileLabel.Visible = true;
                instrumentIDLabel.Visible = true;
            }
            else
            {
                comboBoxInstrumentName.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBoxSenorName.DataBindings.Clear();
                comboBoxInstrumentName.DataBindings.Clear();
                comboBoxLocation.DataBindings.Clear();
                ClearForm();
                comboBoxSenorName.Visible = true;
                comboBoxInstrumentName.Visible = false;
                comboBoxLocation.Visible = true;
                textBoxInstrumentID.Visible = false;
                radioButtonInstrumentID.Visible = false;
                buttonOpenFile.Visible = false;
                sqlLabel.Visible = true;
                saveToFileLabel.Visible = false;
                instrumentIDLabel.Visible = false;
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


        }
        private void delete_From_file()
        {
            // get the selected file name from the comboBoxInstrumentName control
            string selectedFileName = comboBoxInstrumentName.SelectedItem?.ToString();

            // construct the full file path using the directory path and the selected file name
            string filePath = Path.Combine(@"C:\Users\morte\OneDrive\Dokumenter\Instruments", selectedFileName + ".txt");

            // display a message box to confirm whether the user wants to delete the file
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the file '{selectedFileName}.txt'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        MessageBox.Show("File deleted successfully.");

                        // Reload the list of files in the directory
                        comboBoxInstrumentName.Items.Clear();
                        string[] files = Directory.GetFiles(@"C:\Users\morte\OneDrive\Dokumenter\Instruments");
                        foreach (string file in files)
                        {
                            string itemName = Path.GetFileNameWithoutExtension(file);
                            if (!comboBoxInstrumentName.Items.Contains(itemName))
                            {
                                comboBoxInstrumentName.Items.Add(itemName);
                            }
                        }

                        // clear all the controls on the form
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("File not found.");
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("An error occurred while deleting the file: " + ex.Message);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxLocation.Text = "-";
        }

        private void radioButtonInstrumentID_CheckedChanged(object sender, EventArgs e)
        {
            string uniqueID = GenerateUniqueID();
            textBoxInstrumentID.Text = uniqueID;

            // Reset the radioButtonInstrumentID control
            radioButtonInstrumentID.Checked = false;
        }
        private string GenerateUniqueID()
        {
            return Guid.NewGuid().ToString("N");
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            if (IsConnected())
            {
                isConnected = true;
                MessageBox.Show("Connection successful.");
                textBoxCommunication.AppendText("Connected to BE.\r\n");
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label24.Visible = true;

                // Print connected ComPort and TCPPort in listBox_IpAddresses
                string connectedIP = textBoxIP.Text;
                string connectedPort = textBoxPort.Text;
                listBox_IpAddresses.Items.Add($"Connected to {connectedIP}");
                listBox_IpAddresses.Items.Add($"Port: {connectedPort}");

            }
            else
            {
                isConnected = false;
                MessageBox.Show("Connection failed. Please check the IP address and port number and try again.");

            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSenorName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void diconnectButton_Click(object sender, EventArgs e)
        {
            ClearFormBE();
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            MessageBox.Show("Disconnected from BE.");
            textBoxCommunication.AppendText("Disconnected from BE.\r\n");


        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // check the connection status
            if (isConnected && !IsConnected())
            {
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label24.Visible = false;
                // display a message to the user
                MessageBox.Show("Lost connection to backend!");

                // stop the timer from checking the connection status
                timer1.Stop();
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }

}




