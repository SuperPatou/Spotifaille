using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace Spotifaille
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isMuted = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            if(openFileDialog.ShowDialog() == true)
            {
                MusicMedia.Source = new System.Uri(openFileDialog.FileName);
                MusicMedia.Play();
            }

            PlayButton.IsEnabled = true;
            MuteButton.IsEnabled = true;
            PauseButton.IsEnabled = true;
            SliderMusic.IsEnabled = true;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MusicMedia.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            MusicMedia.Stop();
        }

        private void Mute_Click(object sender, RoutedEventArgs e)
        {
            if (isMuted){
                isMuted = false;
            }
            else
            {
                isMuted = true;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var value = SliderMusic.Value;
            MusicMedia.SpeedRatio = value;
        }
    }
}
