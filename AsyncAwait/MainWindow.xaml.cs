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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataFill("alihan", "alihan228", "123");
        }

        private async void DataFill(string name, string login, string password)
        {
            using (var context = new Context())
            {
                var set = context.Set<Seller>();
                var seller = new Seller
                {
                    Name = name,
                    Login = login,
                    Password = password
                };
                set.Add(seller);
                var product1 = context.Set<Product>();
                product1.Add(new Product
                {
                    Name = "Melon",
                    Seller = name,
                    SellerId = seller.Id,
                    StartDay = DateTime.Now,
                    DeletedDate = null,
                    Price = 180,
                    Count = 1,
                });
                await context.SaveChangesAsync();
            }
        }
        private async Task<Seller> FindUser(string login)
        {
            using (var context = new Context())
            {
                return await context.Sellers.FindAsync(login);
            }
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            var cur = FindUser(textBoxLogin.Text);
            var window = new WindowProduct(cur);
            window.Show();
        }
    }
}
