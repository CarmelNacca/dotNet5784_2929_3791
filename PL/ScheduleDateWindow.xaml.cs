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
    /// Interaction logic for ScheduleDateWindow.xaml
    /// </summary>
    public partial class ScheduleDateWindow : Window
    {
        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();

        public DateTime? dateTask { get; set; } = null;
        TaskListWindow taskList;
        BO.Task task;
        DateTime? dateproject;
        TaskListWindow TaskList;
        public ScheduleDateWindow( TaskListWindow taskList, BO.Task Task,DateTime? date)
        {
            InitializeComponent();
            taskList=TaskList;
            task=Task;
            dateproject=date;
            TaskList = taskList;
        }
        private void selectedDate(object sender, SelectionChangedEventArgs e)
        {
            // משתנה שמכיל את התאריך הנבחר בתאריך האחרון ברשימת התאריכים שנבחרו
            dateTask = ((DatePicker)sender).SelectedDate ?? DateTime.Now;


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<BO.TaskInList>? dependencies=s_bl.Task.Dependencies(task.Id);
            if(dependencies!=null)
            {
                foreach (var task in dependencies)
                {
                    if (s_bl.Task.Read(task.Id)!.ScheduledDate == null)
                    {
                        MessageBox.Show("You hava dependence tasks that there are no ScheduledDate ");
                        this.Close();
                    }
                    else
                    if (s_bl.Task.ForecastOfDate(task.Id)>dateTask)
                    {
                        MessageBox.Show("You hava dependence tasks that there are farecast date later ");
                        this.Close();
                    }
                }
                    
                    
             }else
                if(dateTask<dateproject)
            {
                MessageBox.Show("The date of start project is more later ");
                this.Close();
            }
            else
            if (task.ScheduledDate == null)
            {
                task.ScheduledDate= dateTask;
            s_bl.Task.Update(task);
            this.Close();

            }
            else
            {
                MessageBox.Show("You alredy have scheduledate");
                this.Close();
            }


        }
    }
}
