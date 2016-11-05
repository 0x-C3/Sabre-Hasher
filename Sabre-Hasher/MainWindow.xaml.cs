using System;
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

namespace Sabre_Hasher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public uint lastInibinHash;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonBINHash_Click(object sender, RoutedEventArgs e)
        {
            gridBIN.Visibility = Visibility.Visible;
            gridInibin.Visibility = Visibility.Hidden;
            gridRAF.Visibility = Visibility.Hidden;
            gridBone.Visibility = Visibility.Hidden;
        }

        private void buttonInibinHash_Click(object sender, RoutedEventArgs e)
        {
            gridInibin.Visibility = Visibility.Visible;
            gridBIN.Visibility = Visibility.Hidden;
            gridRAF.Visibility = Visibility.Hidden;
            gridBone.Visibility = Visibility.Hidden;
        }

        private void buttonRAFHash_Click(object sender, RoutedEventArgs e)
        {
            gridRAF.Visibility = Visibility.Visible;
            gridInibin.Visibility = Visibility.Hidden;
            gridBIN.Visibility = Visibility.Hidden;
            gridBone.Visibility = Visibility.Hidden;
        }

        private void buttonBoneHash_Click(object sender, RoutedEventArgs e)
        {
            gridBone.Visibility = Visibility.Visible;
            gridInibin.Visibility = Visibility.Hidden;
            gridBIN.Visibility = Visibility.Hidden;
            gridRAF.Visibility = Visibility.Hidden;
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
    }
}
