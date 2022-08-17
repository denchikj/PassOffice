using System;
using PassOfficeLibrary;

namespace PassOfficeConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Pass pass = new Pass();
            
            string menu = "Программа работы с пропусками\n" +
            "=============================\n" +
            "Выберите пункт меню:\n" +
            "1. Добавить пропуск\n" +
            "2. Удалить пропуск\n" +
            "3. Дата последнего выданного пропуска\n" +
            "4. Пропуска за промежуток\n" +
            "5. Выход из программы";
            
            int passTypes = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine(menu);
                switch (Console.ReadLine())
                {
                    case "1":
                        bool dataSet = false;
                        while (!dataSet)
                        {
                            var id = Guid.NewGuid();

                            Console.WriteLine("Введите имя");
                            string firstName = Console.ReadLine();

                            Console.WriteLine("Введите фамилию");
                            string lastName = Console.ReadLine();

                            Console.WriteLine("Введите отчество");
                            string patronymic = Console.ReadLine();

                            bool passType = false;
                            while (!passType)
                            {
                                Console.WriteLine("Введите тип пропуска: 1 - обычный, 2 - срочный, 3 - транзит");
                                passTypes = Convert.ToInt32(Console.ReadLine());
                                if (passTypes == 1 || passTypes == 2 || passTypes == 3)
                                {
                                    passType = true;
                                }
                            }

                            int number = pass.CheckNumber();

                            Console.WriteLine("Данные верны?\n" +
                                $"Id сотрудника: {Guid.NewGuid()}\n" +
                                $"Номер пропуска: {number++}\n" +
                                $"Имя: {firstName}\n" +
                                $"Фамилия: {lastName}\n" +
                                $"Отчество: {patronymic}\n" +
                                $"Тип пропуска: {passTypes}\n" +
                                $"Дата пропуска: {DateTime.Now}\n" +
                                $"Введите y - да, n - нет");

                            if (Console.ReadLine().ToLower() == "y")
                            {
                                pass.AddPass(id, number, firstName, lastName, patronymic, passTypes);
                                dataSet = true;
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите фамилию человека, чей пропуск нужно удалить");
                        string nameDel = Console.ReadLine();
                        pass.DeletePass(nameDel);
                        break;
                    case "3":
                        try
                        {
                            Console.WriteLine($"Дата последнего выданного пропуска: {pass.LastDate.ToString("d")}\n" +
                            "Нажмите любую клавишу для продолжения");
                        }
                        catch
                        {
                            Console.WriteLine("Список пропусков пустой\n" +
                                "Нажмите любую клавишу для продолжения");
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        DateTime date1, date2;
                        date1 = date2 = new DateTime();
                        bool dateSet = false;
                        while (!dateSet)
                        {
                            try
                            {
                                Console.WriteLine("Введите первую дату в формате дд/мм/гггг");
                                date1 = DateTime.Parse(Console.ReadLine());

                                Console.WriteLine("Введите вторую дату в формате дд/мм/гггг");
                                date2 = DateTime.Parse(Console.ReadLine());

                                if (date2 < date1)
                                {
                                    Console.WriteLine("Последняя дата меньше первой\n" +
                                        "Нажмите любую клавишу для продолжения");
                                    Console.ReadKey();
                                }
                                else
                                {
                                    dateSet = true;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Формат даты неверный, введите даты заново\n" +
                                    "==========================================");
                            }
                        }
                        Console.WriteLine($"Количество пропусков, выданных между {date1.ToString("d")} и {date2.ToString("d")}: {pass.Amount(date1, date2)}\n" +
                            "Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                        break;
                    case "5":
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
