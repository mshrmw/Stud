using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
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

namespace Stud
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void loginGotFocus(object sender, RoutedEventArgs e)
        {
            if (login.Text == "Введите логин")
            {
                login.Text = "";
            }
        }
        private void HyperlinkClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
        private void ButtonWelcome(object sender, RoutedEventArgs e)
        {
            Auth(login.Text, password.Password);
        }

        public bool Auth(String log, String pass)
        {
            if (string.IsNullOrEmpty(log) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Введите логин и пароль");
                return false;
            }

            using (var db = new studEntities1())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == log && u.Password == pass);

                if (user == null)
                {
                    MessageBox.Show("Пользлователь с такими данными не найден!");
                    return false;
                }
                if (user.Role == "student")
                {
                    MessageBox.Show("Успешный вход в систему!");
                    StudentsWindow studentsWindow = new StudentsWindow();
                    studentsWindow.Show();
                }
                else if (user.Role == "coordinator")
                {
                    MessageBox.Show("Успешный вход в систему!");
                    CoordinatorWindow coordinatorWindow = new CoordinatorWindow();
                    coordinatorWindow.Show();
                }
                else if (user.Role == "admin")
                {
                    MessageBox.Show("Успешный вход в систему!");
                    CoordinatorWindow coordinatorWindow = new CoordinatorWindow();
                    coordinatorWindow.Show();
                }
                this.Close();
                return true;
            }
        }
    }
}
