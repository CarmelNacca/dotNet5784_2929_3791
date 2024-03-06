using DalApi;
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

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskListWindow.xaml
    /// </summary>
    public partial class TaskListWindow : Window
    {
        public BO.ExpiriencePl level { get; set; } = BO.ExpiriencePl.All;
        public BO.StatusPl status { get; set; } = BO.StatusPl.All;

        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();
        public TaskListWindow()
        {
            InitializeComponent();
            TaskList = s_bl.Task.ReadAll();
        }
        public IEnumerable<BO.TaskInList> TaskList
        {
            get { return (IEnumerable<BO.TaskInList>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }
        public static readonly DependencyProperty TaskListProperty =
           DependencyProperty.Register("TaskList", typeof(IEnumerable<BO.TaskInList>), typeof(TaskListWindow), new PropertyMetadata(null));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TaskWindow(this).Show();

        }
       

        public void updateListview()//Updates the table so that it is displayed after a change - addition or update
        {
            TaskList = s_bl.Task.ReadAll();
        }
        private void filter(object sender, SelectionChangedEventArgs e)
        {
            if(level!=BO.ExpiriencePl.All)
            {
                var grouped = s_bl.Task.ReadAll(fanc);
                TaskList= grouped;
            }
            else { s_bl.Task.ReadAll(); }
            bool fanc(BO.Task t)
            {
                return (t.Copmlexity == (BO.Expirience)level);
            }

        }

       

        private void SelectTaskToUpdate(object sender, MouseButtonEventArgs e)
        {

            BO.TaskInList? task = (sender as ListView)?.SelectedItem as BO.TaskInList;

            new TaskWindow(this, task!.Id).Show();
        }

        private void FilterStatus(object sender, SelectionChangedEventArgs e)
        {
            if (status != BO.StatusPl.All)
            {
                var grouped = s_bl.Task.ReadAll(fanc);
                TaskList = grouped;
            }
            else {
                s_bl.Task.ReadAll();
            }
            bool fanc(BO.Task t)
            {
                return (t.Status == (BO.Status)status);
            }
        }
    }
}

