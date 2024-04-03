using BlApi;
using Dal;
using PL.Task;
using PL.Worker;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();

        public int? Password
        {
            get { return (int?)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public static readonly DependencyProperty PasswordProperty =
           DependencyProperty.Register("Password", typeof(int?),
               typeof(ManagerWindow), new PropertyMetadata(null));
        public int Password2
        {
            get { return (int)GetValue(PasswordProperty2); }
            set { SetValue(PasswordProperty2, value); }
        }

        public static readonly DependencyProperty PasswordProperty2 =
           DependencyProperty.Register("Password2", typeof(int),
               typeof(ManagerWindow), new PropertyMetadata(null));
        public MainWindow()
        {
            InitializeComponent();
            Password = null;
            Password2 = 0;
        }
         
        private void BtnTask(object sender, RoutedEventArgs e)
        {
            new TaskListWindow().Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to initialize data?"," ", MessageBoxButton.YesNo);
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

        private void BtnWorker(object sender, RoutedEventArgs e)
        {
            new WorkerListWindow().Show();

        }

        private void Button_Click_Manager(object sender, RoutedEventArgs e)
        {
            if(Password==1111)
                new ManagerWindow().Show();
            else
            {
                MessageBox.Show("wrong password");
            }
            
        }

        private void Button_Click_Worker(object sender, RoutedEventArgs e)
        {
            if (s_bl.Worker.Read(Password2) != null)
            { new EmployeeWindow(Password2).Show(); }
            else
            {
                MessageBox.Show("Enter id of exsisting worker ");
            }
            
           
            
        }
    }
}