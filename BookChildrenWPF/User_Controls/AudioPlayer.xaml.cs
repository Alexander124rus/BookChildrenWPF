using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
using System.Security.Policy;

namespace BookChildrenWPF.User_Controls
{
    /// <summary>
    /// Логика взаимодействия для AudioPlayer.xaml
    /// </summary>
    public partial class AudioPlayer : UserControl
    {
        
        private bool userIsDraggingSlider = false;

        
        public AudioPlayer()
        {
            InitializeComponent();
            

            
            //Создание объекта DispatcherTimer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        /// <summary>
        /// Обработчик timer_Tick записывает значение таймера в sliProgress.Value 
        /// для отображения изминения положения объекта Thumb на объекте Track
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((audioElement.Source != null) && (audioElement.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = audioElement.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = audioElement.Position.TotalSeconds;               
            }
        }

        /// <summary>
        /// Обработчик Thumb стартовая позиция
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        /// <summary>
        /// Обработчик Thumb перенос вправо
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            audioElement.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }
        /// <summary>
        /// Обработчик объекта Track для sliProgress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliProgress_Mouse(object sender, MouseButtonEventArgs e)
        {
            userIsDraggingSlider = false;
            audioElement.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        /// <summary>
        /// Обработчик звука
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            audioElement.Volume = (double)SliderValume.Value;
        }
        /// <summary>
        /// Обработчик события MediaEnded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            audioElement.Stop();
        }

        /// <summary>
        /// Обработчик кнопки Play
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Play(object sender, RoutedEventArgs e)
        {
            audioElement.Play();
        }

        /// <summary>
        /// Обработчик кнопки Pause
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Pause(object sender, RoutedEventArgs e)
        {
            audioElement.Pause();
        }

        public string AudioText
        {
            get { return (string)GetValue(AudioTextProperty); }
            set { SetValue(AudioTextProperty, value); }
        }

        public static readonly DependencyProperty AudioTextProperty =
            DependencyProperty.Register("AudioText", typeof(string), typeof(AudioPlayer));

        public string SourceUrl
        {
            get { return (string)GetValue(SourceUrlProperty); }
            set { SetValue(SourceUrlProperty, value); }
        }

        public static readonly DependencyProperty SourceUrlProperty =
            DependencyProperty.Register("SourceUrl", typeof(string), typeof(AudioPlayer));
    }
}
