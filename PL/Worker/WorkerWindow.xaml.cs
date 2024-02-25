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

namespace PL.Worker
{
    /// <summary>
    ///
    /// </summary>
   
    public partial class WorkerWindow : Window
    { 
        static readonly BlApi.IBL s_bl = BlApi.Factory.Get();

        public static readonly DependencyProperty WorkerProperty =
           DependencyProperty.Register("WorkerList", typeof(IEnumerable<BO.Worker>),
               typeof(WorkerWindow), new PropertyMetadata(null));
        public WorkerWindow(int id=0)
        {
            InitializeComponent();
            try
            {
                Worker = (id != 0) ? s_bl.Worker.Read(id)! : new BO.Worker { Id = 0, Name = " ", Email = " ", Level = 0, Cost = 0, Task = null };
            }
            catch(BO.BlDoesNotExistException ex)
            {
                WorkerProperty = null;

                MessageBox.Show(ex.Message,"operation faild",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
