using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Stud;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void RegTestSuccess()
        {
            var regWindow = new RegistrationWindow();
            Assert.IsTrue(regWindow.Reg("Цыгулева Анастасия Дмитриевна", DateTime.Parse("17.11.2005"), "227099", "3", "422", "nastia@yandex.ru", "nastia", "nastia1234", "nastia1234"));
        }
        [TestMethod]
        public void RegTestFailure()
        {
            var regWindow = new RegistrationWindow();
            Assert.IsFalse(regWindow.Reg("", DateTime.Parse("01.01.2007"), "", "", "", "", "", "",""));
            //фио
            Assert.IsFalse(regWindow.Reg("", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg(" ", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Арсений", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Georg", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            //дата
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("03.04.2025"), "210000", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("03.05.2025"), "210000", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            //студ билет
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), " ", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "227089", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "2100", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000000", "4", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            //курс
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", " ", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "0", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "-5", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "5", "921", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            //группа
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", " ", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "13", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "12222", "wh@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            //email
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", " ", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "juli@gmail.com", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "julicom", "mee", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "пифуалвот", "mee", "asdfghjk1!", "asdfghjk1!"));
            //логин
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", " ", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "a", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "user", "asdfghjk1!", "asdfghjk1!"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "", "asdfghjk1!", "asdfghjk1!"));
            //пароль
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "", ""));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", " ", " "));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "f56", "f56"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "aaaaaaaaaaaaaaaaaaaa123456", "aaaaaaaaaaaaaaaaaaaa123456"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "asdfghjkiu", "asdfghjkiu"));
            //проверка пароля
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "limit123", " "));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "limit123", ""));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "limit123", "123limit"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "limit123", "limit12"));
            Assert.IsFalse(regWindow.Reg("Бутакова Мария Вячеславовна", DateTime.Parse("22.01.2005"), "210000", "4", "921", "wh@gmail.com", "mee", "limit123", "limi123"));
        }
    }
}
