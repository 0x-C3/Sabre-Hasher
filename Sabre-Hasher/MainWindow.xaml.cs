﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sabre_Hasher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime TimerStart { get; set; }
        public uint lastInibinHash;
        public DispatcherTimer BINTimeElapsed = new DispatcherTimer(DispatcherPriority.Normal);
        public MainWindow()
        {
            InitializeComponent();
            UpdateTextbox(richTextBox, "1.0.0.0 = ", Color.FromRgb(9, 113, 198));
            UpdateTextbox(richTextBox, "First release of this tool", Color.FromRgb(155, 101, 7));
        }

        private void buttonBINHash_Click(object sender, RoutedEventArgs e)
        {
            gridBIN.Visibility = Visibility.Visible;
            gridInibin.Visibility = Visibility.Hidden;
            gridRAF.Visibility = Visibility.Hidden;
            gridBone.Visibility = Visibility.Hidden;
            gridBruteforceBIN.Visibility = Visibility.Hidden;
        }

        private void buttonInibinHash_Click(object sender, RoutedEventArgs e)
        {
            gridInibin.Visibility = Visibility.Visible;
            gridBIN.Visibility = Visibility.Hidden;
            gridRAF.Visibility = Visibility.Hidden;
            gridBone.Visibility = Visibility.Hidden;
            gridBruteforceBIN.Visibility = Visibility.Hidden;
        }

        private void buttonRAFHash_Click(object sender, RoutedEventArgs e)
        {
            gridRAF.Visibility = Visibility.Visible;
            gridInibin.Visibility = Visibility.Hidden;
            gridBIN.Visibility = Visibility.Hidden;
            gridBone.Visibility = Visibility.Hidden;
            gridBruteforceBIN.Visibility = Visibility.Hidden;
        }

        private void buttonBoneHash_Click(object sender, RoutedEventArgs e)
        {
            gridBone.Visibility = Visibility.Visible;
            gridInibin.Visibility = Visibility.Hidden;
            gridBIN.Visibility = Visibility.Hidden;
            gridRAF.Visibility = Visibility.Hidden;
            gridBruteforceBIN.Visibility = Visibility.Hidden;
        }

        private void textBINInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBlockBINRemainder.Text = (27 - textBINInput.Text.Length) + "/27";
            textBINOutput.Text = BinHash.GetHash(textBINInput.Text).ToString();
        }

        private void buttonBINAdd_Click(object sender, RoutedEventArgs e)
        {
            textBINSaved.Text += textBINInput.Text + "  -  " + textBINOutput.Text + Environment.NewLine;
        }

        private void textBoneInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBlockBoneRemainder.Text = (27 - textBoneInput.Text.Length) + "/100";
            textBoneOutput.Text = BoneHash.GetHash(textBoneInput.Text).ToString();
        }

        private void buttonBoneAdd_Click(object sender, RoutedEventArgs e)
        {
            textBoneSaved.Text += textBoneInput.Text + "  -  " + textBoneOutput.Text + Environment.NewLine;
        }

        private void textRAFInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBlockRAFRemainder.Text = (100 - textRAFInput.Text.Length) + "/100";
            textRAFOutput.Text = RafHash.GetHash(textRAFInput.Text).ToString();
        }

        private void buttonRAFAdd_Click(object sender, RoutedEventArgs e)
        {
            textRAFSaved.Text += textRAFInput.Text + "  -  " + textRAFOutput.Text + Environment.NewLine;
        }

        private void textInibinSecondaryInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBlockInibinRemainder2.Text = (27 - textInibinSecondaryInput.Text.Length) + "/27";
            textInibinOutput.Text = InibinHash.GetHash(textInibinPrimaryInput.Text, textInibinSecondaryInput.Text).ToString();
            lastInibinHash = Convert.ToUInt32(textInibinOutput.Text);
        }

        private void textInibinPrimaryInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBlockInibinRemainder.Text = (27 - textInibinPrimaryInput.Text.Length) + "/27";
            textInibinOutput.Text = InibinHash.GetHash(textInibinPrimaryInput.Text, textInibinSecondaryInput.Text).ToString();
            lastInibinHash = Convert.ToUInt32(textInibinOutput.Text);
        }

        private void buttonInibinAdd_Click(object sender, RoutedEventArgs e)
        {
            textInibinSaved.Text += textInibinPrimaryInput.Text + " = " + textInibinSecondaryInput.Text + "  -  " + lastInibinHash + Environment.NewLine;
        }
        private int c = 0;
        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(c == 3)
            {
                System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.Doggy);
                sp.Play();
                c=0;
            }
            c++;
        }
        /// <summary>
        /// Function used to Append colored messages into the RichTextBox
        /// </summary>
        /// <param name="rtbOutput">"RichTextBox to get the input into"</param>
        /// <param name="message">"Message to append"</param>
        /// <param name="color">"Color of the Message"</param>
        private void UpdateTextbox(RichTextBox rtbOutput, string message, Color color)
        {
            rtbOutput.Dispatcher.Invoke((Action)(() =>
            {
                TextRange range = new TextRange(rtbOutput.Document.ContentEnd, rtbOutput.Document.ContentEnd);
                range.Text = message;
                range.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((Color)color));
            })
            );
        }

        private void buttonBruteforceBIN_Click(object sender, RoutedEventArgs e)
        {
            gridBruteforceBIN.Visibility = Visibility.Visible;
            gridBone.Visibility = Visibility.Hidden;
            gridInibin.Visibility = Visibility.Hidden;
            gridBIN.Visibility = Visibility.Hidden;
            gridRAF.Visibility = Visibility.Hidden;
        }

        private void buttonBruteforceBINHash_Click(object sender, RoutedEventArgs e)
        {
            this.TimerStart = DateTime.Now;
            BINTimeElapsed.Tick += BINTimeElapsed_Tick;
            BINTimeElapsed.Interval = new TimeSpan(0, 0, 0, 1);
            BINTimeElapsed.Start();
            System.ComponentModel.BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();
            bw.RunWorkerAsync(textBruteforceBINOutput.Text = BinHash.BruteforceLength(Convert.ToUInt32(textBruteforceBINInput.Text), Convert.ToInt32(textBrutefoceBINLength.Text)));
            image1.Visibility = Visibility.Visible;
            BINTimeElapsed.Stop();
        }

        private void BINTimeElapsed_Tick(object sender, EventArgs e)
        {
            /*if(textBruteforceBINOutput.Text != "")
            {
                BINTimeElapsed.Stop();
            }*/
            var currentValue = DateTime.Now - TimerStart;
            textBruteforceBINTime.Text = "Time Elapsed: Days: " 
                + currentValue.Days.ToString() + " Hours: " 
                + currentValue.Hours.ToString() + " Minutes: " 
                + currentValue.Minutes.ToString() + " Seconds: " 
                + currentValue.Seconds.ToString();
        }
    }
}
