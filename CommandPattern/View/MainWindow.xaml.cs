using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModelChild vm = null;

        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModelChild();
            this.DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Windows event", "WPF");
        }
    }
}
