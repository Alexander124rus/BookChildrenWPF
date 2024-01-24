using BookChildrenWPF.Model;
using BookChildrenWPF.User_Controls;
using GihanSoft.String;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace BookChildrenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();         
            this.MinHeight = 768;
            this.MinWidth = 1366;
            contentControl.ContentTemplate = (DataTemplate)this.Resources["startView"];
        }

        protected override void OnManipulationBoundaryFeedback(ManipulationBoundaryFeedbackEventArgs e)
        {
            e.Handled = true;
        }
    }
}
