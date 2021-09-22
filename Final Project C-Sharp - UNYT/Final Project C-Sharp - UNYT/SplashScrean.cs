using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_C_Sharp___UNYT
{
    public partial class SplashScrean : Form
    {
        public SplashScrean()
        {
            InitializeComponent();
        }

        private void SplashScrean_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //Sets the transparency of Panel
            panel4.BackColor = Color.FromArgb(150, Color.MidnightBlue);
            panel3.BackColor = Color.FromArgb(150, Color.MidnightBlue);
            panel2.BackColor = Color.FromArgb(100, Color.MidnightBlue);
            
            // splashPanel.BackColor = Color.FromArgb(200, Color.MidnightBlue);

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            ProgressBarPanel.Width += 2;  // this condition sets the progress bar speed
            if (ProgressBarPanel.Width > 850) // this condition put the progressBar width grater than 850 
            {
                Login login = new Login(); // call Login class
                timer1.Stop();
                login.Show();
                this.Hide();
                
            }
        }
    }
}
