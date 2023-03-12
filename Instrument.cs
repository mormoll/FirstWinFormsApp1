using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWinFormsApp1
{
    internal class Instrument
    {
        public List<Instrument> instrumentList = new List<Instrument>();

        //Class body

        public DateTime RegisterDate { get; }

        private string sensorName; //field

        public string SensorName // property
        {

            set { sensorName = value; }
            get { return sensorName; }

        }

        public string SerialNumber { get; set; }
        public string SensorSerialNumber { get; set; }
        public string SignalType { get; set; }
        public string MeasureType { get; set; }
        public string Options { get; set; }
        public string Comment { get; set; }

        public double LRV { get; set; }
        public double URV { get; set; }

        public string Unit { get; set; }

        


       /* public Instrument(  string registerDate,
                            string sensorName,
                            string serialNumber,
                            string signalType,
                            string measureType,
                            string options = null,
                            string comment = null,
                            double lrv = 0.0,
                            double urv = 0.0,
                            string unit = null)
        {
            this.RegisterDate = DateTime.Now;
            this.SensorName = sensorName;
            this.SerialNumber = serialNumber;
            this.SignalType = signalType;
            this.MeasureType = measureType;
            this.Options = options;
            this.Comment = comment;
            this.LRV = lrv;
            this.URV = urv;
            this.Unit = unit;
        }
       */

        public Instrument(string registerDate,
                          string sensorName,
                          string serialNumber,
                          string signalType,
                          string measureType,
                          string options = null,
                          string comment = null,
                          double lrv = 0.0,
                          double urv = 0.0,
                          string unit = null)
                            
        {
            this.RegisterDate = Convert.ToDateTime(registerDate);
            this.SensorName = sensorName;
            this.SerialNumber = serialNumber;
            this.SignalType = signalType;
            this.MeasureType = measureType;
            this.Options = options;
            this.Comment = comment;
            this.LRV = lrv;
            this.URV = urv;
            this.Unit = unit;

        }


         

      /*  public void CreateInstrument(
                                string sensorName,
                                string serialNumber,
                                string signalType,
                                string measureType,
                                string options,
                                string lrv,
                                string urv,
                                string comment)
        {
            Instrument newInstrument = new Instrument()
            {
                SensorName = sensorName,
                SerialNumber = serialNumber,
                SignalType = signalType,
                MeasureType = measureType,
                Options = options,
                LRV = lrv,
                URV = urv,
                Comment = comment
            };

            InstrumentList.Add(newInstrument);
        }*/

        public double Span()
        {
            return URV - LRV;

        }

        public override string ToString()
        {
            return RegisterDate.ToString()+ "\r\n"
                                          + "Sensor Name:" + SensorName
                                          + "Serial Number:" + SerialNumber
                                          + "Signal Type:" + SignalType
                                          + "Measure Type:" + MeasureType
                                          + "Optins:" + Options
                                          + "Comments: " + Comment
                                          + "LRV Value: " + Convert.ToString(LRV, CultureInfo.InvariantCulture)
                                          + "URV Value: " + Convert.ToString(URV, CultureInfo.InvariantCulture)
                                          + "Unit: " + Unit;

        }
        




    }
}

