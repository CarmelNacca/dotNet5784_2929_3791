using PL.Task;
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
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        int idWorker = 0;
        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();

        public EmployeeWindow(int id)
        {
            InitializeComponent();
            idWorker= id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (s_bl.Task.Read(idWorker, true) != null)
            { new TaskWindow(null, idWorker, true).Show(); }
            else
            { MessageBox.Show("There is not task now"); }
              
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (s_bl.Task.Read(idWorker, true) != null && s_bl.Task.Read(idWorker, true).Status != BO.Status.Done)
            {
                MessageBox.Show("There is alredy task now");
            }
            else
            {
                new TaskListWindow(s_bl.Worker.Read(idWorker)).Show(); 
               }

        }
    }
}
