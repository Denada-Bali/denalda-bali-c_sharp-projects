using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallDataRecords
{
    public partial class CallDataRec : Form
    {
        public CallDataRec()
        {
            InitializeComponent();
        }

        private void CallDataRec_Load(object sender, EventArgs e)
        {

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            DataTable CallDataRrecord = new DataTable();
            CallDataRrecord.Columns.Add("Time of Call");
            CallDataRrecord.Columns.Add("Duration");
            CallDataRrecord.Columns.Add("Destination");
            CallDataRrecord.Columns.Add("Area Code");
            CallDataRrecord.Columns.Add("Connection");
            CallDataRrecord.Columns.Add("PPM");
            CallDataRrecord.Columns.Add("Total");

            DataRow dataRow = CallDataRrecord.NewRow();

            int Duration = int.Parse(textBox3.Text);

            string PREFIX = textBox2.Text;
            string Prefix = PREFIX.Substring(0, 2);
            string AreaCode;

            double ConnectionCharge, PPM, Total;

            switch (Prefix)
            {
                case "02":
                case "03":
                    AreaCode = "Domestic";
                    ConnectionCharge = 0;
                    PPM = 0.5;
                    break;

                case "07":
                    AreaCode = "Mobile";
                    ConnectionCharge = 0;
                    PPM = 5.5;
                    break;

                case "00":
                    AreaCode = "International";
                    ConnectionCharge = 5;
                    PPM = 11.3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid input");
            }

            Total = Duration * PPM + ConnectionCharge;

            dataRow["Time of Call"] = textBox1.Text;
            dataRow["Duration"] = textBox3.Text;
            dataRow["Destination"] = textBox2.Text;
            dataRow["Area Code"] = AreaCode;
            dataRow["Connection"] = ConnectionCharge;
            dataRow["PPM"] = PPM;
            dataRow["Total"] = Total;
            CallDataRrecord.Rows.Add(dataRow);

            AddRecord(textBox1.Text, textBox3.Text, textBox2.Text, AreaCode, ConnectionCharge, PPM, Total);

            foreach (DataRow Drow in CallDataRrecord.Rows)
            {
                int number = dataGridView1.Rows.Add();
                dataGridView1.Rows[number].Cells[0].Value = Drow["Time of Call"].ToString();
                dataGridView1.Rows[number].Cells[1].Value = Drow["Duration"].ToString();
                dataGridView1.Rows[number].Cells[2].Value = Drow["Destination"].ToString();
                dataGridView1.Rows[number].Cells[3].Value = Drow["Area Code"].ToString();
                dataGridView1.Rows[number].Cells[4].Value = Drow["Connection"].ToString();
                dataGridView1.Rows[number].Cells[5].Value = Drow["PPM"].ToString();
                dataGridView1.Rows[number].Cells[6].Value = Drow["Total"].ToString();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static void AddRecord(string timeOfCall, string duration, string destination, string areaCode, double ConnectionCh, double ppm, double total)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("CallDataRecord.txt", true))
                {
                    file.WriteLine(timeOfCall + ", " + duration + ", " + destination + ", " + areaCode + ", " + ConnectionCh + ", " + ppm + ", " + total);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("This application did an oopsie", ex);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
