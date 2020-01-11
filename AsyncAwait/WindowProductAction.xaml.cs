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
    /// Логика взаимодействия для WindowProductAction.xaml
    /// </summary>
    public partial class WindowProductAction : Window
    {
        private readonly bool isAdded = true;
        private Product Item;
        private Seller currentSeller;

        public WindowProductAction(Seller current, bool isAdd, Product product = null)
        {
            InitializeComponent();
            isAdded = isAdd;
            Item = product;
            currentSeller = current;
        }

        private async void ProductSaveChanges(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxNameProduct.Text) || !String.IsNullOrWhiteSpace(textBoxPriceProduct.Text) || !String.IsNullOrWhiteSpace(textBoxCountProduct.Text))
            {
                using (var context = new Context())
                {
                    var set = context.Set<Product>();
                    if (int.TryParse(textBoxPriceProduct.Text, out var price))
                    {
                        MessageBox.Show("Неправильный ввод цены!");
                        return;
                    }
                    if (int.TryParse(textBoxCountProduct.Text, out var count))
                    {
                        MessageBox.Show("Неправильный ввод количества!");
                        return;
                    }
                    if (isAdded)
                    {
                        var product = new Product
                        {
                            Name = textBoxNameProduct.Text,
                            Price = price,
                            Count = count,
                            Seller = currentSeller.Name,
                            SellerId = currentSeller.Id,
                            DeletedDate = null,
                            StartDay = DateTime.Now,
                        };
                        set.Add(product);
                        await context.SaveChangesAsync();
                    }
                    else
                    {
                        set.Remove(Item);
                        Item.Name = textBoxNameProduct.Text;
                        Item.Price = price;
                        Item.Count = count;
                        Item.StartDay = DateTime.Now;
                        set.Add(Item);
                        await context.SaveChangesAsync();
                    }
                }
            }
            else
            { 
                MessageBox.Show("Неправильный ввод!");
            }
        }
    }
}
