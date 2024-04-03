using PL.Task;
using PL.Worker;
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
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public DateTime? dateProject { get; set; } = null;

        public ManagerWindow()
        {
            InitializeComponent();
         
        }
        

        private void BtnTask(object sender, RoutedEventArgs e)
        {
            new TaskListWindow().Show();
        }
        private void BtnWorker(object sender, RoutedEventArgs e)
        {
            new WorkerListWindow().Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to initialize data?", " ", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        BlApi.Factory.Get().InitializeDB();
                    }
                    break;
                case MessageBoxResult.No:
                    break;

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to reset data?", " ", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        BlApi.Factory.Get().ResetDB();
                    }
                    break;
                case MessageBoxResult.No:
                    break;

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(dateProject==null)
            {
                MessageBox.Show("Enter date of start project");
            }
            else
            {
                new TaskListWindow(null,null,null,true).Show();
            }
        }
    }
}
