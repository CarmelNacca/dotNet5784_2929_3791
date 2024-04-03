
using BO;
using DO;
using PL.Task;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace PL.Worker
{
    /// <summary>
    /// Interaction logic for WorkerWindow.xaml
    /// hiii
    /// </summary>
    public partial class WorkerListWindow : Window
    {
        public BO.ExpiriencePl level { get; set; } = BO.ExpiriencePl.All;
        bool chooseWorker = false;
        WorkerInTask? workerInTask;
        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();
        int id;
        public WorkerInTask? SelectedWorker { get; private set; }
        
        public  WorkerListWindow(bool chooseworker=false,WorkerInTask? worker=null)
        {
            InitializeComponent();
            WorkerList = s_bl.Worker.ReadAll();
            chooseWorker=chooseworker;
            workerInTask = worker;
            

        }

        public IEnumerable<BO.Worker> WorkerList
        {
            get { return (IEnumerable<BO.Worker>)GetValue(WorkerListProperty); }
            set { SetValue(WorkerListProperty, value); }
        }

        public static readonly DependencyProperty WorkerListProperty =
            DependencyProperty.Register("WorkerList", typeof(IEnumerable<BO.Worker>), typeof(WorkerListWindow), new PropertyMetadata(null));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new WorkerWindow(this).Show();

        }

        private void SelectWorkerToUpdate(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(!chooseWorker) 
            { 
            BO.Worker? worker = (sender as ListView)?.SelectedItem as BO.Worker;

            new WorkerWindow(this,worker!.Id).Show();
            }
            else
            {
                BO.Worker? worker = (sender as ListView)?.SelectedItem as BO.Worker;
                workerInTask = new BO.WorkerInTask( worker!.Id,worker.Name);
                this.Close();
            }
            


        }
        public void updateListview ()//Updates the table so that it is displayed after a change - addition or update
        {
            WorkerList =s_bl.Worker.ReadAll();
        }
        
        
        private void filter(object sender, SelectionChangedEventArgs e)
        {
          
            WorkerList = (level == BO.ExpiriencePl.All) ?
                s_bl?.Worker.ReadAll()! : s_bl?.Worker.ReadAll(item => item.Level == (BO.Expirience)level)!;
           
            
        }
        private void OnWorkerSelected(object sender, RoutedEventArgs e)
        {
            // כאשר נבחר עובד, עדכן את ה-SelectedWorker
            SelectedWorker = (sender as ListView)?.SelectedItem as WorkerInTask; // קבל את העובד מהבחירה של המשתמש;
            Close();
        }
    }


}
