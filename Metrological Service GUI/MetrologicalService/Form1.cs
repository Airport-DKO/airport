﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace MetrologicalService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        System.Timers.Timer modTimer1 = new System.Timers.Timer(200);
        System.Timers.Timer modTimer2 = new System.Timers.Timer(5000);
        DateTime timer = new DateTime();
        double ModelingSpeed = 1;

        MetrologWebService.MetrologService a = new MetrologWebService.MetrologService();

        private void Form1_Load(object sender, EventArgs e)
        {
            modTimer1.Elapsed += timer_Elapsed1;
            modTimer1.Start();
            timer = DateTime.UtcNow.AddHours(3);
            ModelingSpeed = 1/(a.GetCurrentTick());
            textBoxSpeed.Text = ModelingSpeed.ToString();

            timer = a.GetCurrentTime();
            timeLabel.Text = timer.ToString("HH:mm:ss");
            dateLabel.Text = timer.ToString("dd.MM.yyyy");

            modTimer2.Elapsed += timer_Elapsed2;
            modTimer2.Start();
        }

        private void timer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            timer = timer.AddSeconds(1 * ModelingSpeed / 5);
            timeLabel.Text = timer.ToString("HH:mm:ss");
            dateLabel.Text = timer.ToString("dd.MM.yyyy");
        }

        private void timer_Elapsed2(object sender, ElapsedEventArgs e)
        {
            timer = a.GetCurrentTime();
            timeLabel.Text = timer.ToString("HH:mm:ss");
            dateLabel.Text = timer.ToString("dd.MM.yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double eee = (double)Convert.ToDouble(textBoxSpeed.Text);
                bool valid = double.TryParse(textBoxSpeed.Text.ToString(), out eee);

                if (valid && eee > 0 && eee <= 60)
                {
                    ModelingSpeed = eee;
                    a.RefreshTick(1 / eee);
                }
                else
                {
                    MessageBox.Show("Неверно введено число, требуется значение больше 0 и не более 60");
                }
            }
            catch
            {
                MessageBox.Show("Неверно введено число, требуется значение больше 0 и не более 60");
            }
        }

        private void textBoxSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ',' || e.KeyChar == '.') && !textBoxSpeed.Text.Contains(',') && (textBoxSpeed.Text.Length != 0) && (textBoxSpeed.SelectionLength == 0))
            {
                e.KeyChar = ',';
            }
            else if (!(Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModelingSpeed = 1;
            a.Reset();
            timer = DateTime.UtcNow.AddHours(3);
            timeLabel.Text = timer.ToString("HH:mm:ss");
            dateLabel.Text = timer.ToString("dd.MM.yyyy");
            textBoxSpeed.Text = "1";
        }
    }
}