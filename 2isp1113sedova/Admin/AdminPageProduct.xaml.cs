﻿using System;
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

namespace _2isp1113sedova.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminPageProduct.xaml
    /// </summary>
    public partial class AdminPageProduct : Page
    {
        List<Product> listProduct = new List<Product>();
        private int numPage = 0;
        List<string> listSort = new List<string>()
 {
 "Наименование (по возрастанию)",
 "Наименование (по убыванию)",
 "Стоимость(по возрастанию)",
 "Стоимость(по убыванию)"
 };
        List<string> listFiltr = new List<string>();
        void Filtr()
        {
            listProduct = DB.entities.Product.ToList();
            //Сортировка
            var selectSort = cmbSortingPrice.SelectedIndex;
            switch (selectSort)
            {
                case 0:
                    listProduct = listProduct.OrderBy(i => i.NameProduct).ToList(); // по возрастанию
                    break;
                case 1:
                    listProduct = listProduct.OrderByDescending(i => i.NameProduct).ToList(); // по убыванию
                    break;
                case 2:
                    listProduct = listProduct.OrderBy(i => i.Price).ToList();
                    break;
                case 3:
                    listProduct = listProduct.OrderByDescending(i => i.Price).ToList();
                    break;
                default:
                    listProduct = listProduct.OrderBy(i => i.IdProduct).ToList();
                    break;
            }
            //Фильтрация
            var selectFiltr = cmbFiltrationCategory.SelectedIndex;
            if (selectFiltr != 0)
            {
                listProduct = listProduct.Where(i => i.IdCategory == selectFiltr).ToList();
            }
            // Вывод по страницам
            listProduct = listProduct.Skip(10 * numPage).Take(10).ToList();
            // переопределение источника данных для ListView
            LvProduct.ItemsSource = listProduct;
        }
        public AdminePageProduct()
        {
            InitializeComponent();
            LvProduct.ItemsSource = DB.entities.Product.ToList();

            var category = DB.entities.Category.ToList();
            foreach (var i in category)
            {
                listFiltr.Add(i.NameCategory);
            }
            listFiltr.Insert(0, "Все категории");
            cmbFiltrationCategory.ItemsSource = listFiltr;
            cmbFiltrationCategory.SelectedIndex = 0;

            cmbSortingPrice.ItemsSource = listSort;
            cmbSortingPrice.SelectedIndex = 0;
        }

        private void btnBackFrm_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }
        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listProduct = listProduct.Where(i => i.NameProduct.ToLower().Contains(txbSearch.Text.ToLower())).ToList();
        }
        private void cmbFiltrationCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtr();
        }
        private void cmbSortingPrice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtr();
        }
        private void LvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtr();
        }
        private void btnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (listProduct.Count > 0)
            {
                numPage++;
                tbckPage.Text = (numPage + 1).ToString();
            }
            Filtr();
        }
        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            if (numPage > 0)
            {
                numPage--;
                tbckPage.Text = (numPage + 1).ToString();
            }
            Filtr();
        }
        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AdminAddProduct addProd = new AdminAddProduct();
            addProd.Show();
        }
    }
}
