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

namespace AsyncAwait
{
    /// <summary>
    /// Логика взаимодействия для WindowProduct.xaml
    /// </summary>
    public partial class WindowProduct : Window
    {
        public Task<Seller> cur;

        public Seller currentSeller { get; set; }
        public WindowProduct(Seller current)
        {
            InitializeComponent();
            currentSeller = current;
        }

        public WindowProduct(Task<Seller> cur)
        {
            this.cur = cur;
        }

        private void ProductAdd(object sender, RoutedEventArgs e)
        {
            var window = new WindowProductAction(currentSeller, true);
            window.Show();
        }

        private void ProductSelect(object sender, SelectionChangedEventArgs e)
        {
            var selectedCells = e.AddedItems;
            foreach (var q in selectedCells)
            {
                MessageBox.Show(q.ToString());
            }
        }
    }
}
