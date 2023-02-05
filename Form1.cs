using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace FirstWinFormsApp1
{
    public partial class Form1 : Form


    {
        //Contents

        readonly int[] numbers = new int[7] { 5, 3, 7, 25, 65, 32, 43 };
        string[] analogSignals = new string[] { "0-5DC", "0-10VDC", "0-20mA", "4-20mA", "RTD" };
        string[] digitalSignals = new string[] { "5VDC", "10VDC0", "24VDC", "Relay" };
        string[] fieldbusSigals = new string[] { "Modbus RTU", "ModbusTCP", "Profibus", "ProfiNet", "CANBus", "ErherCat", "RS48" };


        //Variables
        char ch = 'a';

        double lrvValue = 0.0;
        double urvValue = 0.0;
        double spanValue = 0.0;

        int RegisterIndex = 0;
        int analogIndex = 0;
        int digitalIndex = 0;
        int fieldbusIndex = 0;

        //Font boldFont = new Font("Calibri", 10, FontStyle.Bold);
        //Font regularFont = new Font("Calibri"), 10, FontStyle.Regular);


        DateTime sessionStartTime;



        List<string> servers = new List<string>();


        public Form1()
        {


            InitializeComponent();

            IPAddress[] addresslist = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in addresslist)
            {
                servers.Add(address.ToString());

                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    servers.Add(address.ToString());
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


        private void Form1_Click(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal) { }
            this.WindowState = FormWindowState.Maximized;
            {
                if (this.WindowState != FormWindowState.Maximized) { }

            }
            this.WindowState = FormWindowState.Normal;


        }



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



        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 2)

            {
                listBox_IpAddresses.Items.Clear();
                listBox_IpAddresses.Items.AddRange(servers.ToArray());
            }
        }



        private void textbox1SensorName_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Sensor Name";
        }

        private void Sensor_Data_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void MaskedSerialNumberLabel_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter Serial Number";
        }

        private void checkBox1Registerd_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Registerd";
        }

        private void dateTiimePicker1Label_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Pick Date";
        }

        private void comboSignalTypeLabel_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Pick Signal Type";
        }

        private void listBox1_Mouse_Hoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Options";
        }



        private void CommentsLabel_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Write Comments";
        }

        private void RegisterNewButton_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Register New";
        }

        private void SaveChangesButton_Mouse_Hoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Save Changes";
        }

        private void DeleteButton_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Delete";
        }

        private void RegSaveDel_MouseHoover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Register New";
        }

        private void DeleteButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void SaveChangesButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void RegisterNewButton_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void RegSaveDel_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void CommentsLabel_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void comboSignalTypeLabel_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void comboSignalTypeLabel_SelectedIndexChanged(object sender, EventArgs e)
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

        private void dateTimePicker1Label_MouseLeav(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void checkBox1Registerd_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void MaskedSerialNumberLabel_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void texbox1SensorName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }


        private void SensorNameTextLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegSaveDel_Click_1(object sender, EventArgs e)
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

        private void buttonSummary_Click_1(object sender, EventArgs e)
        {
            //DateTime sessionTime;

            System.TimeSpan sessionTime = DateTime.Now.Subtract(sessionStartTime);
            textBoxSummary.AppendText("Session tome; " + sessionTime.TotalSeconds.ToString() + "s \r\n");
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
    }
}
