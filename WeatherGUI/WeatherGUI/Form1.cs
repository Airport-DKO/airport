﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WeatherGUI.Weather;



namespace WeatherGUI
{
    public partial class Form1 : Form
    {
        private Weather.WebServiceWeather w = new Weather.WebServiceWeather();
        delegate void enbl(bool b);
        delegate void rename(string s);

        const int TIME = 60000;

        public Form1()
        {
            InitializeComponent();
            textBox1.MaxLength = 2;
            this.Text = "WeatherGUI";
            button1.Text = "Set";
            button2.Text = "Let it snow";
            button3.Text = "Reset monitor";
            checkBox1.Text = "below zero";
            label1.Text = "Enter temperature:";
            label2.Text = "degrees";
            label3.Text = "Cover snow:";
            label4.Text = "Current temp:";
            label5.Text = "getting...";
            label6.Text = "getting...";
            comboBox1.Items.Add("Tokyo");
            comboBox1.Items.Add("Kyiv");
            comboBox1.Items.Add("Whitecourt");
            comboBox1.Items.Add("Roma");
            comboBox1.Items.Add("Washington");
            comboBox1.Items.Add("Minsk");
            comboBox1.Items.Add("Almaty");
            comboBox1.SelectedIndex = 1;

            //new Thread(() =>
            //{
            //    while (true)
            //    {
            //        try
            //        {
            //            label6.Invoke(new rename((b) => label6.Text = b), w.GetWindFromCity(comboBox1.SelectedItem.ToString()).ToString());

            //        }
            //        catch
            //        {
            //            break;
            //        }
            //        Thread.Sleep(1000);

            //    }
            //}).Start();

            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        label5.Invoke(new rename((b) => label5.Text = b), w.GetTemperature(true).ToString());

                    }
                    catch
                    {
                        break;
                    }
                    Thread.Sleep(TIME);
                    
                }
            }).Start();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) 
                MessageBox.Show("Empty value");
            else
                new Thread(() =>
                {
                    button1.Invoke(new enbl((b) => button1.Enabled = b), false);
                    checkBox1.Invoke(new enbl((b) => checkBox1.Enabled = b), false);
                    textBox1.Invoke(new enbl((b) => textBox1.Enabled = b), false);
                    button1.Invoke(new rename((s) => button1.Text = s), "Setting...");
                    if (checkBox1.Checked == true)
                        w.SetTemperature(0 - Double.Parse(textBox1.Text));
                    else
                        w.SetTemperature(Double.Parse(textBox1.Text));
                    button1.Invoke(new rename((s) => button1.Text = s), "Set");
                    textBox1.Invoke(new enbl((b) => textBox1.Enabled = b), true);
                    checkBox1.Invoke(new enbl((b) => checkBox1.Enabled = b), true);
                    button1.Invoke(new enbl((b) => button1.Enabled = b), true);
                }).Start();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            new Thread(() =>
            {
                button2.Invoke(new enbl((b) => button2.Enabled = b), false);
                button2.Invoke(new rename((s) => button2.Text = s), "Snowing...");
                w.CrapSnow();
                button2.Invoke(new rename((s) => button2.Text = s), "Let it snow");
                button2.Invoke(new enbl((b) => button2.Enabled = b), true);
            }).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        label5.Invoke(new rename((b) => label5.Text = b), w.GetTemperature(true).ToString());

                    }
                    catch
                    {
                        break;
                    }
                    Thread.Sleep(TIME);

                }
            }).Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            w.SetWind(comboBox1.SelectedItem.ToString(), Int32.Parse(textBox2.Text));
        }
    }
}
