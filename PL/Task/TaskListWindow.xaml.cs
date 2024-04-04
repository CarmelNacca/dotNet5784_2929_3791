using DalApi;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

using DalApi;
using DO;


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
        BO.Worker? worker;
        bool dependencies=false;
        TaskWindow? TaskWindow;
        List<BO.TaskInList> tasks = new List<BO.TaskInList> { };
        bool updateDates=false;
        DateTime? dateProject=null;

       
        public TaskListWindow(BO.Worker? w = null, bool dependency = false,TaskWindow? t=null,bool updateDate=false,DateTime? date=null)
        {
            InitializeComponent();
            worker = w;
            TaskWindow= t;
            dependencies = dependency;
            updateDates = updateDate;
            dateProject = date;
            if (worker != null)
            {
                bool helpChooseTask(BO.Task task)
                {
                    var Task = s_bl.Task.Read(task.Id);
                    return (Task.Copmlexity == worker.Level && Task.Worker == null);
                }
                TaskList = s_bl.Task.ReadAll(helpChooseTask);
            }
            else if(updateDates) 
            {
                bool helpupdateDates(BO.Task task)
                {
                    
                    return (task.ScheduledDate==null);
                }
                TaskList = s_bl.Task.ReadAll(helpupdateDates);


            }
            else {  TaskList = s_bl.Task.ReadAll();}
           
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
            if(dependencies ==true)
            {
                TaskWindow.TaskPL.Dependencies = tasks;
                this.Close();
            }
            else
            if (updateDates) 
            {
                bool helpupdateDates(BO.Task task)
                {

                    return (task.ScheduledDate == null);
                }
                if(s_bl.Task.ReadAll(helpupdateDates)==null)
                {
                   //לעדכן תאריך פרויקט
                }
            }
            else
            { 
            new TaskWindow(this).Show();
            }
        }


        public void updateListview()//Updates the table so that it is displayed after a change - addition or update
        {
            if (worker != null)
            {
                bool helpChooseTask(BO.Task task)
                {
                    var Task = s_bl.Task.Read(task.Id);
                    return (Task.Copmlexity == worker.Level && Task.Worker == null);
                }
                TaskList = s_bl.Task.ReadAll(helpChooseTask);
            }
            TaskList = s_bl.Task.ReadAll();
        }
        private void filter(object sender, SelectionChangedEventArgs e)
        {
            if (worker != null)
            {
                var tasks = s_bl.Task.ReadAll(fanc);
                TaskList = tasks;
                bool fanc(BO.Task t)
                {
                    return (t.Copmlexity == worker.Level);
                }
            }
            else
            {

                if (level != BO.ExpiriencePl.All)
                {
                    var tasks = s_bl.Task.ReadAll(fanc);
                    TaskList = tasks;
                }
                else
                {
                    var tasks = s_bl.Task.ReadAll();
                    TaskList = tasks;
                }
                bool fanc(BO.Task t)
                {
                    return (t.Copmlexity == (BO.Expirience)level);
                }
            }

        }



        private void SelectTaskToUpdate(object sender, MouseButtonEventArgs e)
        {
            BO.TaskInList? task = (sender as ListView)?.SelectedItem as BO.TaskInList;
            if (dependencies == true)
            {
                MessageBoxResult result = MessageBox.Show("Would you want to add dependency?", " ", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        {
                            tasks.Add(task);
                            bool helpDependencies(BO.Task task)
                            {
                                foreach (var existingTask in tasks)
                                {
                                    // Assuming that "Id" is a unique identifier for tasks
                                    if (existingTask.Id == task.Id)
                                    {
                                        return false; // Task already exists in the list
                                    }
                                }
                                return true;
                            }
                            TaskList = s_bl.Task.ReadAll(helpDependencies);
                            break;
                        }
                    case MessageBoxResult.No:
                        {
                            break;
                        }


                }
            }
            else
             if (worker != null)
                {
                    var Task = s_bl.Task.Read(task.Id);
                    Task.Worker = new BO.WorkerInTask(worker.Id, worker.Name);
                    Task.StartDate = DateTime.Today;
                    s_bl.Task.Update(Task);
                    this.Close();
                }
               
            
            else
             if(updateDates)
                {
                new ScheduleDateWindow(this, s_bl.Task.Read(task.Id),dateProject).Show();
                bool helpupdateDates(BO.Task task)
                {

                   return (task.ScheduledDate == null);
                   
                }
                TaskList = s_bl.Task.ReadAll(helpupdateDates);
                

            }
            else
            {

               new TaskWindow(this, task!.Id).Show();
            }
        } 
                private void FilterStatus(object sender, SelectionChangedEventArgs e)
                {
                    if (worker != null)
                    {
                        var tasks = s_bl.Task.ReadAll(fanc);
                        TaskList = tasks;
                        bool fanc(BO.Task t)
                        {
                            return (t.Status == BO.Status.Unscheduled);
                        }
                    }
                    else {
                        if (status != BO.StatusPl.All)
                        {
                            var tasks = s_bl.Task.ReadAll(fanc);
                            TaskList = tasks;
                        }
                        else {
                            var tasks = s_bl.Task.ReadAll();
                            TaskList = tasks;

                        }
                        bool fanc(BO.Task t)
                        {
                            return (t.Status == (BO.Status)status);
                        } }
                }


            }
        }

