using BO;
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

namespace PL.Task
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();
        public WorkerInTask? WorkerIntask { get; set; } = null;


        TaskListWindow item;
        public BO.Task? TaskPL
        {
            get { return (BO.Task)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }
        public IEnumerable<BO.TaskInList> TaskList
        {
            get { return (IEnumerable<BO.TaskInList>)GetValue(TaskListProperty); }
            set { SetValue(TaskListProperty, value); }
        }
        public static readonly DependencyProperty TaskListProperty =
           DependencyProperty.Register("TaskList", typeof(IEnumerable<BO.TaskInList>), typeof(TaskListWindow), new PropertyMetadata(null));

        public IEnumerable<BO.TaskInList> TaskList1
        {
            get { return (IEnumerable<BO.TaskInList>)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }

        public static readonly DependencyProperty TaskProperty =
           DependencyProperty.Register("TaskPL", typeof(BO.Task),
               typeof(TaskWindow), new PropertyMetadata(null));

        public TaskWindow(TaskListWindow itemw, int id = 0)
        {
            InitializeComponent();
            DataContext=WorkerIntask;
            try
            {
                TaskPL = ((id != 0) ? s_bl.Task.Read(id)! : new BO.Task { Id =0, Alias = " ", Description = " ", createdAtDate = null, StartDate = null, ScheduledDate = null, DeadlineDate = null, CompleteDate = null, Deliverables = " ", Remarks = " ", Copmlexity = 0 });
            }
            catch (BO.BlDoesNotExistException ex)
            {
                TaskPL = null;

                MessageBox.Show(ex.Message, "operation faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                this.Close();


            }
            item = itemw;
        }
        private void Button_Click_AddUpdate(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)!.Content.ToString() == "Add")
                try
                {
                    int? id = s_bl.Task.Add(TaskPL!);
                    MessageBox.Show($"Task {id} was successfully added", "success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    item.updateListview();
                    this.Close();
                }
                catch (BO.BlAlreadyExistsException ex)
                {
                    MessageBox.Show(ex.Message, "operation faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "operation faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            else
            {
                try
                {
                    s_bl.Task.Update(TaskPL!);
                    MessageBox.Show($"Task {TaskPL?.Id} was successfully updeted", "success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    item.updateListview();
                    this.Close();
                }
                catch (BO.BlDoesNotExistException ex)
                {
                    MessageBox.Show(ex.Message, "operation faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "operation faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
            }

            this.Close();
        }

        private void ChooseWorker(object sender, RoutedEventArgs e)
        {
            new WorkerListWindow(true,this).Show();
            TaskPL!.Worker = WorkerIntask;
            
        }

        

       
    }
}

  




