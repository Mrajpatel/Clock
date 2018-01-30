using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// This class creates an windows form that works like a digital clock 
/// using inbuilt timer and DateTime object
/// </summary>
namespace Clock
{
    public partial class Clock : Form
    {
        //timer object
        Timer t = new Timer();
        public Clock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Set the time interval and start the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clock_Load(object sender, EventArgs e)
        {
            //set the interval to 1 sec
            t.Interval = 1000; //1 second
            //eventhandler whenever the tick is called
            t.Tick += new EventHandler(this.t_Tick);
            //start the timer
            t.Start();
        }

        /// <summary>
        /// Timer tick function that prints the time each time in label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t_Tick(object sender, EventArgs e)
        {
            //get the current time and store it into the variables
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int seconds = DateTime.Now.Second;

            string timer = ""; //showing current time
            
            //if the time is in single digit make it in 2 digit to format it properly
            if (hour < 10)
            {
                if (hour == 0)
                {
                    hour = 12;
                    timer +=  hour;
                }
                else
                {
                    timer += "0" + hour;
                }
                label1.Text = "AM";
            }
            else 
            {
                hour = hour - 12;
                if (hour == 0)
                {
                    hour = 12;
                    timer += hour;
                }
                else
                {
                    timer += "0" + hour;
                }
                label1.Text = "PM";
            }
            timer += ":";

            //handle the minute
            if (minute < 10) timer += "0" + minute;
            else timer += minute;
            timer += ":";

            //handle the seconds
            if (seconds < 10) timer += "0" + seconds;
            else timer += seconds;
            
            //show the timer in the lable
            time.Text = timer;
        }

        /// <summary>
        /// Close the form whenever the clickevent called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
