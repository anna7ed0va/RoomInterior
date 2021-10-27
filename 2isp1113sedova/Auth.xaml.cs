using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace _2isp1113sedova
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Entities db = new Entities();
        public Auth()
        {
            InitializeComponent();

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var Model1 = db.User.FirstOrDefault
                (i => i.Login == txbLogin.Text && i.Password == psbPassword.Password);


            if (psbPassword.Password == psbPasswordRepeat.Password)
            {
                if (db == null)
                {
                    System.Windows.MessageBox.Show("Пользователь не найден, повторите попытку", "Пользователь не найден", MessageBoxButton.OK);
                }
                else if (Model1.IdRole == 1)
                {
                    _2isp1113sedova.Admin.AdminMain adminMain = new _2isp1113sedova.Admin.AdminMain();
                    adminMain.Show();
                    System.Windows.Application.Current.MainWindow.Close();
                }
                //else if (Model1.IdRole == 2)
                //{
                //    Manager.ManagerWindow managerWindow = new Manager.ManagerWindow();
                //    managerWindow.Show();
                //    System.Windows.Application.Current.MainWindow.Close();
                //}
                //else if (Model1.IdRole == 3)
                //{
                //    User.UserWindow userWindow = new User.UserWindow(Model1.IdUser);
                //    userWindow.Show();
                //    System.Windows.Application.Current.MainWindow.Close();
                //}
            }
            else
            {
                System.Windows.MessageBox.Show("Пароль не совпадает, повторите попытку", "Ошибка ввода пароля", MessageBoxButton.OK);
            }
           

        }
        }
    }


