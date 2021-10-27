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

namespace _2isp1113sedova.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminAddProduct.xaml
    /// </summary>
    public partial class AdminAddProduct : Window
    {
        public Entities db = new Entities();
        public AdminAddProduct()
        {
            {
                InitializeComponent();
            }

            var result = MessageBox.Show("Вы хотите добавить материал?", "Подтверждение", MessageBoxButton.YesNo);

            Product prodAdd = new Product();
            prodAdd.NameProduct = txbNameProduct.Text;
            prodAdd.IdCategory = cmbCategory.SelectedIndex + 1;
            prodAdd.Price = Convert.ToDecimal(txbPrice.Text);

            private void btnImageAdd_Click(object sender, RoutedEventArgs e)
            {
                OpenFileDialog openFD = new OpenFileDialog();
                if (openFD.ShowDialog() == true)
                {
                    string FileName = openFD.FileName;
                    imgImageProduct.Source = new BitmapImage(new Uri(openFD.FileName));
                    PathProduct = openFD.FileName;
                }
                db.Product.Add(prodAdd);
                db.SaveChanges();
                MessageBox.Show("Товар успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
    }
}
