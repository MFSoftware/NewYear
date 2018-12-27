using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewYear
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public int days;
        public int h;
        public int m;
        public int s;

        public string GetDeclension(int number, string nominativ, string genetiv, string plural)
        {
            number = number % 100;
            if (number >= 11 && number <= 19)
                return plural;

            var i = number % 10;
            switch (i)
            {
                case 1:
                    return nominativ;
                case 2:
                case 3:
                case 4:
                    return genetiv;
                default:
                    return plural;
            }
        }

        private void timerYear_Tick(object sender, EventArgs e)
        {
            DateTime NewYear = new DateTime(DateTime.Now.Year, 12, 31);
            DateTime Now = DateTime.Now;

            TimeSpan ts = NewYear - Now;
            days = (int)ts.TotalDays;
            h = (int)ts.TotalHours;
            m = (int)ts.TotalMinutes;
            s = (int)ts.Seconds;

            while (h > 24)
            {
                h = h - 24;
                days = days + 1;
            }

            while (m > 60)
            {
                m = m - 60;
                h = h + 1;
            }

            string ss = GetDeclension(s, "секунда", "секунды", "секунд");
            string ms = GetDeclension(m, "минута", "минуты", "минут");
            string hs = GetDeclension(h, "час", "часа", "часов");
            string dayss = GetDeclension(days, "день", "дня", "дней");

            if (days == 0)
            {
                if (h < 2)
                {
                    label2.Text = string.Format("{0} {1}, {2} {3}", h, hs, m, ms);
                    if (h <= 0)
                    {
                        label2.Text = string.Format("{0} {1}, {2} {3}", m, ms, s, ss);
                        if (m <= 0)
                        {
                            label2.Text = string.Format("{0} {1}", s, ss);
                            if (s <= 0)
                                label2.Text = "С новым годом";
                        }
                    }
                }
                else
                {
                    label2.Text = string.Format("{0} {1}, {2} {3}", h, hs, m, ms);
                }
            }
            else if (days == 1)
            {
                label2.Text = string.Format("{0} {1}, {2} {3}, {4} {5}", days, dayss, h, hs, m, ms);
            }
            else if (days > 1)
            {
                label2.Text = string.Format("{0} {1}, {2} {3}, {4} {5}", days, dayss, h, hs, m, ms);
            }
        }
    }
}
