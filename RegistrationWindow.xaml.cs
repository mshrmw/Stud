using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Stud
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }
        private void HyperlinkClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsValidStudentCardNumber(string number)
        {
            return number.All(char.IsDigit);
        }
        private bool IsRussianLetter(char c)
        {
            return (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'ё' || c == 'Ё';
        }
        private void ButtonReg(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FIO.Text) ||
                string.IsNullOrWhiteSpace(StudentsCardNumber.Text) ||
                string.IsNullOrWhiteSpace(Course.Text) ||
                string.IsNullOrWhiteSpace(Group.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(login.Text) ||
                string.IsNullOrWhiteSpace(password.Password) ||
                string.IsNullOrWhiteSpace(passwordProverka.Password) ||
                DateOfBirth.SelectedDate == null)
            {
                MessageBox.Show("Все обязательные поля должны быть заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            String log = login.Text;
            String pass = password.Password;
            String email = Email.Text;
            int studentCard = Convert.ToInt32(StudentsCardNumber.Text);
            using (var db = new studEntities1())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault(u => u.Login == log);
                if (user != null)
                {
                    MessageBox.Show("Пользователь с такими данными уже существует"); return;
                }
                var emaildb = db.Students.AsNoTracking().FirstOrDefault(s => s.Email == email);
                if (emaildb != null)
                {
                    MessageBox.Show("Пользователь с таким email уже существует");
                }
                var cardNumb = db.Students.AsNoTracking().FirstOrDefault(s => s.StudentCardNumber == studentCard);
                if (cardNumb != null)
                {
                    MessageBox.Show("Пользователь с таким номером студенческого билета уже существует");
                }
            }
            StringBuilder errors = new StringBuilder();
            if(log.Length > 50)
            {
                errors.AppendLine("Логин должен быть меньше 50 символов");
            }
            if (log.Length < 2)
            {
                errors.AppendLine("Логин должен быть больше 1 символа");
            }
            if (pass.Length < 8)
            {
                errors.AppendLine("Пароль должен быть больше 8 символов");
            }
            if (pass.Length > 25)
            {
                errors.AppendLine("Пароль должен быть меньше 25 символов");
            }
            bool englishLetters = true;
            bool number = false;
            for(int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= 'А' && pass[i] <= 'Я') englishLetters = false;
                if (pass[i] >= '0' && pass[i] <= '9') number = true;
            }
            if (!englishLetters) errors.AppendLine("Пароль должен состоять из английских букв");
            if (!number) errors.AppendLine("Пароль должен содержать хотя бы одну цифру");
            if (pass != passwordProverka.Password) errors.AppendLine("Пароль должен совпадать с 'Подтверждение пароля'");
            var nameParts = FIO.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length < 2)
            {
                errors.AppendLine("ФИО должно содержать минимум 2 слова");
            }
            foreach (var part in nameParts)
            {
                if (!part.All(c => IsRussianLetter(c)))
                {
                    errors.AppendLine("ФИО должно состоять из русских букв");
                    break;
                }
            }
            if (DateOfBirth.SelectedDate >= DateTime.Today)
            {
                errors.AppendLine("Дата рождения должна быть раньше текущей даты");
            }
            if (!Regex.IsMatch(StudentsCardNumber.Text, @"^\d{6}$"))
            {
                errors.AppendLine("Номер студенческого билета должен содержать ровно 6 цифр");
            }
            if (!int.TryParse(Course.Text, out int course) || course < 1 || course > 4)
            {
                errors.AppendLine("Курс должен быть числом от 1 до 4");
            }
            if (!Regex.IsMatch(Group.Text, @"^\d{3,4}$"))
            {
                errors.AppendLine("Номер группы должен содержать 3 или 4 цифры");
            }
            if (!IsValidEmail(Email.Text))
            {
                errors.AppendLine("Неверный формат email");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибки в данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                using (var db = new studEntities1())
                {
                    var student = new Students
                    {
                        FirstName = FIO.Text.Split(' ')[0],
                        LastName = FIO.Text.Split(' ')[1],
                        MiddleName = FIO.Text.Split(' ').Length > 2 ? FIO.Text.Split(' ')[2] : null,
                        DateOfBirth = DateOfBirth.SelectedDate.Value,
                        StudentCardNumber = int.Parse(StudentsCardNumber.Text),
                        Course = int.Parse(Course.Text),
                        Groupp = int.Parse(Group.Text),
                        Email = Email.Text,
                        JoinDate = DateTime.Today,
                        Points = 0
                    };
                    db.Students.Add(student);
                    db.SaveChanges();
                    var user = new Users
                    {
                        Login = login.Text,
                        Password = password.Password,
                        Role = "student",
                        IDStudent = student.IDStudent
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    student.IDUser = user.IDUser;
                    db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
