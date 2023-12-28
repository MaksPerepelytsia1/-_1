using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Оберіть завдання для виконання:");
        Console.WriteLine("1. Завдання 1 (Фірми)");
        Console.WriteLine("2. Завдання 2 (Телефони)");
        Console.WriteLine("3. Завдання 3 (Компанія та працівники)");
        Console.Write("Введіть номер завдання: ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Task1.Run();
                break;
            case "2":
                Task2.Run();
                break;
            case "3":
                Task3.Run();
                break;
            default:
                Console.WriteLine("Неправильний вибір.");
                break;
        }
    }
}

class Task1
{
    public static void Run()
    {
        List<Фірма> фірми = new List<Фірма>
        {
          new Фірма { Назва = "TechGuru", ДатаЗаснування = new DateTime(2020, 1, 1), ПрофільБізнесу = "IT", ПІБДиректора = "John Doe", КількістьСпівробітників = 150, Адреса = "Лондон, UK" },
            new Фірма { Назва = "MarketMasters", ДатаЗаснування = new DateTime(2019, 5, 23), ПрофільБізнесу = "маркетинг", ПІБДиректора = "Jane White", КількістьСпівробітників = 200, Адреса = "Нью-Йорк, USA" },
            new Фірма { Назва = "FoodJoy", ДатаЗаснування = new DateTime(2021, 6, 15), ПрофільБізнесу = "Food", ПІБДиректора = "Emily Black", КількістьСпівробітників = 50, Адреса = "Лондон, UK" },
            new Фірма { Назва = "CreativeSolutions", ДатаЗаснування = new DateTime(2018, 3, 10), ПрофільБізнесу = "маркетинг", ПІБДиректора = "Michael White", КількістьСпівробітників = 300, Адреса = "Париж, France" },
            new Фірма { Назва = "WhiteTech", ДатаЗаснування = new DateTime(2022, 7, 20), ПрофільБізнесу = "IT", ПІБДиректора = "Alex Black", КількістьСпівробітників = 400, Адреса = "Берлін, Germany" }
        };

        // Запити
        // Отримати інформацію про всі фірми
        var всіФірми = фірми;
        Print("Всі фірми", всіФірми);

        // Отримати фірми, які мають назву Food
        var фірмиFood = фірми.Where(f => f.Назва.Contains("Food"));
        Print("Фірми Food", фірмиFood);

        // Отримати фірми, що працюють у галузі маркетингу
        var маркетингФірми = фірми.Where(f => f.ПрофільБізнесу == "маркетинг");
        Print("Фірми маркетингу", маркетингФірми);

        // Отримати фірми, що працюють у галузі маркетингу або IT
        var маркетингІТФірми = фірми.Where(f => f.ПрофільБізнесу == "маркетинг" || f.ПрофільБізнесу == "IT");
        Print("Фірми маркетингу та IT", маркетингІТФірми);

        // Отримати фірми з кількістю співробітників більше 100
        var фірми100Plus = фірми.Where(f => f.КількістьСпівробітників > 100);
        Print("Фірми > 100 співробітників", фірми100Plus);

        // Отримати фірми з кількістю співробітників у діапазоні від 100 до 300
        var фірми100To300 = фірми.Where(f => f.КількістьСпівробітників >= 100 && f.КількістьСпівробітників <= 300);
        Print("Фірми 100-300 співробітників", фірми100To300);

        // Отримати фірми, що знаходяться у Лондоні
        var фірмиЛондон = фірми.Where(f => f.Адреса.Contains("Лондон"));
        Print("Фірми в Лондоні", фірмиЛондон);

        // Отримати фірми, які мають прізвище директора White
        var фірмиДиректорWhite = фірми.Where(f => f.ПІБДиректора.Contains("White"));
        Print("Фірми з директором White", фірмиДиректорWhite);

        // Отримати фірми, які засновані понад два роки тому
        var фірми2Years = фірми.Where(f => (DateTime.Now - f.ДатаЗаснування).TotalDays > 730);
        Print("Фірми > 2 років", фірми2Years);

        // Отримати фірми з дня заснування, яких минуло більше 150 днів
        var фірми150Days = фірми.Where(f => (DateTime.Now - f.ДатаЗаснування).TotalDays > 150);
        Print("Фірми > 150 днів", фірми150Days);

        // Отримати фірми, у яких прізвище директора Black та назва фірми містить слово White
        var фірмиBlackWhite = фірми.Where(f => f.ПІБДиректора.Contains("Black") && f.Назва.Contains("White"));
        Print("Фірми з директором Black і назвою White", фірмиBlackWhite);
    }

    static void Print(string title, IEnumerable<Фірма> фірми)
    {
        Console.WriteLine($"--- {title} ---");
        foreach (var фірма in фірми)
        {
            Console.WriteLine(фірма);
        }
    }
}

class Task2
{
    public static void Run()
    {
        List<Телефон> телефони = new List<Телефон>
        {
           new Телефон { Назва = "iPhone 13", Виробник = "Apple", Ціна = 800, ДатаВипуску = new DateTime(2021, 9, 24) },
            new Телефон { Назва = "Galaxy S21", Виробник = "Samsung", Ціна = 700, ДатаВипуску = new DateTime(2021, 1, 29) },
            new Телефон { Назва = "Pixel 5", Виробник = "Google", Ціна = 600, ДатаВипуску = new DateTime(2020, 10, 15) },
            // Додайте більше телефонів за потребою
        };

        // Порахуйте кількість телефонів
        Console.WriteLine($"Кількість телефонів: {телефони.Count}");

        // Порахуйте кількість телефонів із ціною більше 100
        Console.WriteLine($"Телефони з ціною більше 100: {телефони.Count(t => t.Ціна > 100)}");

        // Порахуйте кількість телефонів з ціною в діапазоні від 400 до 700
        Console.WriteLine($"Телефони з ціною від 400 до 700: {телефони.Count(t => t.Ціна >= 400 && t.Ціна <= 700)}");

        // Порахуйте кількість телефонів конкретної виробника (наприклад, Apple)
        Console.WriteLine($"Телефони від Apple: {телефони.Count(t => t.Виробник == "Apple")}");

        // Знайдіть телефон із мінімальною ціною
        var minPricePhone = телефони.OrderBy(t => t.Ціна).FirstOrDefault();
        Console.WriteLine($"Телефон з мінімальною ціною: {minPricePhone}");

        // Знайдіть телефон із максимальною ціною
        var maxPricePhone = телефони.OrderByDescending(t => t.Ціна).FirstOrDefault();
        Console.WriteLine($"Телефон з максимальною ціною: {maxPricePhone}");

        // Відобразіть інформацію про найстаріший телефон
        var oldestPhone = телефони.OrderBy(t => t.ДатаВипуску).FirstOrDefault();
        Console.WriteLine($"Найстаріший телефон: {oldestPhone}");

        // Відобразіть інформацію про найсвіжіший телефон
        var newestPhone = телефони.OrderByDescending(t => t.ДатаВипуску).FirstOrDefault();
        Console.WriteLine($"Найновіший телефон: {newestPhone}");

        // Знайдіть середню ціну телефону
        var averagePrice = телефони.Average(t => t.Ціна);
        Console.WriteLine($"Середня ціна телефону: {averagePrice}");

        // Відобразіть п'ять найдорожчих телефонів
        var top5Expensive = телефони.OrderByDescending(t => t.Ціна).Take(5);
        Console.WriteLine("П'ять найдорожчих телефонів:");
        foreach (var телефон in top5Expensive)
        {
            Console.WriteLine(телефон);
        }

        // Відобразіть п'ять найдешевших телефонів
        var top5Cheapest = телефони.OrderBy(t => t.Ціна).Take(5);
        Console.WriteLine("П'ять найдешевших телефонів:");
        foreach (var телефон in top5Cheapest)
        {
            Console.WriteLine(телефон);
        }

        // Відобразіть три найстаріші телефони
        var top3Oldest = телефони.OrderBy(t => t.ДатаВипуску).Take(3);
        Console.WriteLine("Три найстаріші телефони:");
        foreach (var телефон in top3Oldest)
        {
            Console.WriteLine(телефон);
        }

        // Відобразіть три найновіші телефони
        var top3Newest = телефони.OrderByDescending(t => t.ДатаВипуску).Take(3);
        Console.WriteLine("Три найновіші телефони:");
        foreach (var телефон in top3Newest)
        {
            Console.WriteLine(телефон);
        }

        // Відобразіть статистику щодо кількості телефонів кожного виробника
        Console.WriteLine("Статистика за виробниками:");
        var manufacturerStats = телефони.GroupBy(t => t.Виробник).Select(g => new { Виробник = g.Key, Кількість = g.Count() });
        foreach (var stat in manufacturerStats)
        {
            Console.WriteLine($"{stat.Виробник} – {stat.Кількість}");
        }

        // Відобразіть статистику щодо кількості моделей телефонів
        Console.WriteLine("Статистика за моделями:");
        var modelStats = телефони.GroupBy(t => t.Назва).Select(g => new { Модель = g.Key, Кількість = g.Count() });
        foreach (var stat in modelStats)
        {
            Console.WriteLine($"{stat.Модель} – {stat.Кількість}");
        }

        // Відобразіть статистику телефонів за роками
        Console.WriteLine("Статистика за роками:");
        var yearStats = телефони.GroupBy(t => t.ДатаВипуску.Year).Select(g => new { Рік = g.Key, Кількість = g.Count() });
        foreach (var stat in yearStats)
        {
            Console.WriteLine($"{stat.Рік} - {stat.Кількість}");
        }
    }
}

class Task3
{
    public static void Run()
    {
        Company company = new Company();
        // Додавання зразкових даних до компанії
        company.Employees.AddRange(new List<Employer>
        {
           new President { Name = "John Smith", BirthDate = new DateTime(1975, 5, 24), HireDate = new DateTime(2000, 1, 20), Salary = 9000, Education = "вища" },
            new Manager { Name = "Susan Johnson", BirthDate = new DateTime(1980, 7, 16), HireDate = new DateTime(2005, 2, 12), Salary = 7000, Education = "вища" },
            new Manager { Name = "James Williams", BirthDate = new DateTime(1990, 3, 8), HireDate = new DateTime(2010, 3, 15), Salary = 6800, Education = "вища" },
            new Worker { Name = "Володимир Петров", BirthDate = new DateTime(1992, 10, 19), HireDate = new DateTime(2012, 4, 1), Salary = 4000, Education = "середня" },
            new Worker { Name = "Елена Коваленко", BirthDate = new DateTime(1988, 10, 30), HireDate = new DateTime(2008, 8, 20), Salary = 4200, Education = "вища" },
            // Додайте більше працівників з унікальними іменами, датами народження та іншими даними
        });

        // Число робітників підприємства
        int workersCount = company.Employees.OfType<Worker>().Count();
        Console.WriteLine($"Кількість робітників: {workersCount}");

        // Об’єм заробітної платні
        decimal totalSalary = company.Employees.Sum(e => e.Salary);
        Console.WriteLine($"Загальна зарплата: {totalSalary}");

        // 10 робітників з найбільшим стажем
        var experiencedWorkers = company.Employees.OfType<Worker>()
            .OrderBy(e => e.HireDate)
            .Take(10)
            .OrderBy(e => e.BirthDate)
            .FirstOrDefault(e => e.Education.ToLower().Contains("вища"));
        Console.WriteLine($"Наймолодший робітник із вищою освітою та великим стажем: {experiencedWorkers?.Name}");

        // Самий молодий та найстарший менеджер
        var youngestManager = company.Employees.OfType<Manager>().OrderBy(e => e.BirthDate).LastOrDefault();
        var oldestManager = company.Employees.OfType<Manager>().OrderBy(e => e.BirthDate).FirstOrDefault();
        Console.WriteLine($"Наймолодший менеджер: {youngestManager?.Name}");
        Console.WriteLine($"Найстарший менеджер: {oldestManager?.Name}");

        // Робітники, що народилися у жовтні
        var octoberWorkers = company.Employees.OfType<Worker>().Where(e => e.BirthDate.Month == 10);
        Console.WriteLine("Робітники, народжені у жовтні:");
        foreach (var worker in octoberWorkers)
        {
            Console.WriteLine(worker.Name);
        }

        // Усі Володимири, наймолодший отримує премію
        var vladimirs = company.Employees.Where(e => e.Name.Contains("Володимир")).OrderBy(e => e.BirthDate);
        var youngestVladimir = vladimirs.LastOrDefault();
        if (youngestVladimir != null)
        {
            decimal bonus = youngestVladimir.Salary / 3;
            Console.WriteLine($"Вітаємо {youngestVladimir.Name}! Ви отримуєте премію: {bonus}");
        }

        // Вивести імена всіх Володимирів
        Console.WriteLine("Володимири на підприємстві:");
        foreach (var vladimir in vladimirs)
        {
            Console.WriteLine(vladimir.Name);
        }
    }
}

public class Фірма
{
    public string Назва { get; set; }
    public DateTime ДатаЗаснування { get; set; }
    public string ПрофільБізнесу { get; set; }
    public string ПІБДиректора { get; set; }
    public int КількістьСпівробітників { get; set; }
    public string Адреса { get; set; }

    public override string ToString()
    {
        return $"Назва: {Назва}, Дата заснування: {ДатаЗаснування.ToShortDateString()}, Профіль: {ПрофільБізнесу}, Директор: {ПІБДиректора}, Співробітники: {КількістьСпівробітників}, Адреса: {Адреса}";
    }
}

public class Телефон
{
    public string Назва { get; set; }
    public string Виробник { get; set; }
    public decimal Ціна { get; set; }
    public DateTime ДатаВипуску { get; set; }

    public override string ToString()
    {
        return $"{Назва} від {Виробник}, Ціна: {Ціна} (Дата випуску: {ДатаВипуску.ToShortDateString()})";
    }
}

public class Company
{
    public List<Employer> Employees { get; set; }

    public Company()
    {
        Employees = new List<Employer>();
    }
}

public abstract class Employer
{
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public string Education { get; set; }
}

public class President : Employer { }
public class Manager : Employer { }
public class Worker : Employer { }
