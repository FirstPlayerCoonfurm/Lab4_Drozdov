using System;
using Microsoft.Data.Sqlite;
using DB_lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab4_Drozdov
{
    class Program
    {
        static void Main(string[] args)
        {
            Db_method();
            Pars();
        }
        public static void Db_method()
        {
            // Создаем объект подключения SQLite
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = "userdata.db"; // Здесь указывается путь к вашей базе данных

            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                // Создаем экземпляр класса Class1
                var db = new Class1();

                // Теперь вы можете использовать методы и свойства из библиотеки DB_lib
                db.Add(1, "John", "Hello");
                db.GetByID(1);
                db.Update(1, "Greetings");
                db.GetByID(1);
                db.Delete(1);
                db.GetByID(1);
            }
        }
        public static void Pars()
        {
            IWebDriver drw = new ChromeDriver();

            drw.Navigate().GoToUrl("https://habr.com/ru/articles/");

            var artic = drw.FindElements(By.ClassName("borderwrap"));

            Console.WriteLine(artic.Count);

            foreach (var art in artic)
            {
                var id = art.GetAttribute("id");
                var name = art.FindElement(By.ClassName("tm-user-info__username")).Text;
                var text = art.FindElement(By.CssSelector(".article-formatted-body")).Text;

                Console.WriteLine($"{id} - {name} - {text}");
            }
            drw.Quit();
        }
    }
}