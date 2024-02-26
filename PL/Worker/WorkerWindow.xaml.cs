using System.Windows;
using System.Windows.Controls;

namespace PL.Worker
{
    /// <summary>
    ///
    /// </summary>
     
    public partial class WorkerWindow : Window
    {
        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();
        public BO.Worker? WorkerPL
        {
            get { return (BO.Worker)GetValue(WorkerProperty); }
            set { SetValue(WorkerProperty, value); }
        }
        public static readonly DependencyProperty WorkerProperty =
           DependencyProperty.Register("WorkerPL", typeof(BO.Worker),
               typeof(WorkerWindow), new PropertyMetadata(null));
        public WorkerWindow(int id = 0)
        {
            InitializeComponent();
            try
            {
                WorkerPL = ((id != 0) ? s_bl.Worker.Read(id)! : new BO.Worker { Id = 0, Name = " ", Email = " ", Level = 0, Cost = 0, Task = null });
            }
            catch (BO.BlDoesNotExistException ex)
            {
                WorkerPL = null;

                MessageBox.Show(ex.Message, "operation faild", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                this.Close();
            }
        }


       
        private void Button_Click_AddUpdate(object sender, RoutedEventArgs e)
        {
            if ((sender as Button)!.Content.ToString() == "Add")
                try
                {
                    int? id = s_bl.Worker.Add(WorkerPL!);
                    MessageBox.Show($"worker {id} was successfully added", "success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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
                    s_bl.Worker.Update(WorkerPL!);
                    MessageBox.Show($"worker {WorkerPL?.Id} was successfully updeted", "success", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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

        }
    }
}
