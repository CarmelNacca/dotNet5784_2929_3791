using BO;
using DO;
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

namespace PL.Task//carmel
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();

        TaskListWindow item;
        public BO.Task? TaskPL
        {
            get { return (BO.Task)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }

        public static readonly DependencyProperty TaskProperty =
           DependencyProperty.Register("TaskPL", typeof(BO.Task),
               typeof(TaskWindow), new PropertyMetadata(null));
        //public IEnumerable<int> WorkerList
        //{
        //    get { return (IEnumerable<int>)GetValue(WorkerListProperty); }
        //    set { SetValue(WorkerListProperty, value); }
        //}

        //public static readonly DependencyProperty WorkerListProperty =
        //    DependencyProperty.Register("WorkerList", typeof(IEnumerable<int>), typeof(TaskWindow), new PropertyMetadata(null));
        private BO.Status selectedStatus=BO.Status.Unscheduled;

        public TaskWindow(TaskListWindow? itemw, int id = 0,bool tasknow=false)
        {
            
            InitializeComponent();
            //WorkerList = s_bl.Worker.ReadAllForTask2();
            try
            {
                TaskPL = ((id != 0) ? s_bl.Task.Read(id,tasknow)! : new BO.Task { Id =0, Description = " ", createdAtDate = DateTime.Today, StartDate = null, ScheduledDate = null, DeadlineDate = null, CompleteDate = null, Deliverables = " ", Remarks = " ", Copmlexity = 0 ,Status=0});
                TaskPL.Status= ((id != 0) ? s_bl.Task.UpdateStatus(TaskPL.Id):BO.Status.Unscheduled);
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
                    if (item != null)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TaskListWindow(null,true,this).Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to end the task?", " ", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    {
                        TaskPL.CompleteDate = DateTime.Today;
                        s_bl.Task.Update(TaskPL);
                        MessageBox.Show($"Task {TaskPL?.Id} was successfully end", "success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        this.Close();
                    }
                    break;
                case MessageBoxResult.No:
                    break;

            }
           
        }

       
    }
   




}


  




