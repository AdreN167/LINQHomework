using LINQHomework.DataAccessLayer;
using LINQHomework.Domain;
using System;
using System.Collections;
using System.Linq;

namespace LINQHomework.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var computerCategory = new Category
            {
                Name = "Компьютеры"
            };
            var TVCategory = new Category
            {
                Name = "Телевизоры"
            };
            var smartphoneCategory = new Category
            {
                Name = "Смартфоны"
            };
            var officeSuppliseCategory = new Category
            {
                Name = "Канцтовары"
            };
            var appliancesCategory = new Category
            {
                Name = "Бытовая техника"
            };

            var TV = new TV
            {
                CategoryId = TVCategory.Id,
                CompanyName = "Skyworth",
                IsSmart = false,
                Diagonal = 99,
                HDMICount = 2,
                Is3D = true,
                Mark = 4.7,
                MaximumResolution = "1366 x 768",
                Name = "Skyworth 39E30",
                Price = 94900,
                Type = "LED"
            };

            var coumputer = new Computer
            {
                CategoryId = computerCategory.Id,
                CompanyName = "Del",
                CPUFrequency = 3.5,
                CPUModel = "Intel Core i5",
                FormFactor = "Small",
                GPUModel = " Intel UHD Graphics 630",
                RAM = 8,
                Mark = 4.3,
                StorageDevice = 256,
                Price = 248900,
                OS = "Linux",
                Name = "Dell Vostro 3681"
            };

            var smartphone = new Smartphone
            {
                CategoryId = smartphoneCategory.Id,
                Price = 48700,
                Mark = 3.2,
                ScreenSize = 6.5,
                ScreenResolution = "1600 x 720",
                RAM = 2,
                InternalMemoryCapacity = 32,
                CPUModelName = "MT6739",
                CompanyName = "Samsung",
                CPUFrequency = 1.5,
                FrontFacingCameraResolution = 5,
                MainCameraResolution = 12,
                Name = "Samsung Galaxy A02"
            };

            var refrigerator = new Refrigerator
            {
                Name = "Atlant ХМ-4624-141",
                Price = 159800,
                Mark = 4.8,
                CategoryId = appliancesCategory.Id,
                CompanyName = "Atlant",
                IsNoFrostTechnology = false,
                EnergyConsumptionClass = "A+",
                FreezerCapacity = 119,
                RefrigeratorCompartmentsCapacity = 228,
                IsDisplay = true
            };

            var stationeryKnife = new StationeryKnife
            {
                Name = "Comix B2837",
                CompanyName = "Comix",
                BladeWidth = 9,
                CategoryId = officeSuppliseCategory.Id,
                Color = "серый",
                Length = 15,
                Mark = 4.1,
                Price = 640,
                Weight = 100,
                Width = 3
            };

            using (var context = new ShopContext())
            {
                /*context.AddRange(smartphoneCategory, TVCategory, officeSuppliseCategory, computerCategory, appliancesCategory);
                context.AddRange(smartphone, coumputer, TV, refrigerator, stationeryKnife);
                context.SaveChanges();*/

                var isEnd = false;

                while (!isEnd)
                {
                    Console.Clear();

                    ShowMenu("--------------------", "Каталог", "Выход");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        ThrowError("Некорректный ввод!");
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();

                            ShowMenu("----------Категории----------", "Телевизоры", "Смартфоны", "Компьютеры", "Бытовая техника", "Канцтовары");

                            if (!int.TryParse(Console.ReadLine(), out int categoryChoice))
                            {
                                ThrowError("Некорректный ввод!");
                                break;
                            }

                            Console.Write("Цена от: ");

                            if (!int.TryParse(Console.ReadLine(), out int priceFrom))
                            {
                                ThrowError("Некорректный ввод!");
                                break;
                            }

                            Console.Write("Цена до: ");

                            if (!int.TryParse(Console.ReadLine(), out int priceTo))
                            {
                                ThrowError("Некорректный ввод!");
                                break;
                            }

                            var page = 0;
                            var view = 10;
                            var isEndCategory = false;
                            ICollection result = null;

                            while (!isEndCategory)
                            {
                                Console.Clear();

                                switch (categoryChoice)
                                {
                                    case 1:
                                        result = context.TVSets.Where(product => product.Price >= priceFrom && product.Price <= priceTo).Skip(page * view).Take(view).ToList();
                                        break;
                                    case 2:
                                        result = context.Smartphones.Where(product => product.Price >= priceFrom && product.Price <= priceTo).Skip(page * view).Take(view).ToList();
                                        break;
                                    case 3:
                                        result = context.Computers.Where(product => product.Price >= priceFrom && product.Price <= priceTo).Skip(page * view).Take(view).ToList();
                                        break;
                                    case 4:
                                        result = context.Refrigerators.Where(product => product.Price >= priceFrom && product.Price <= priceTo).Skip(page * view).Take(view).ToList();
                                        break;
                                    case 5:
                                        result = context.StationeryKnives.Where(product => product.Price >= priceFrom && product.Price <= priceTo).Skip(page * view).Take(view).ToList();
                                        break;
                                }

                                ShowProducts(result);

                                ShowMenu("--------------------", "Следующая страница", "Предыдущая страница", "Выбрать товар", "Назад");

                                if (!int.TryParse(Console.ReadLine(), out int actionChoice))
                                {
                                    ThrowError("Некорректный ввод!");
                                }

                                switch (actionChoice)
                                {
                                    case 1:
                                        if (result.Count == view)
                                            page++;
                                        break;

                                    case 2:
                                        if (page > 0)
                                            page--;
                                        break;
                                    
                                    case 3:
                                        Console.Write("Введите номер товара: ");

                                        if (!int.TryParse(Console.ReadLine(), out int productChoice) && (productChoice < 1 || productChoice > result.Count))
                                        {
                                            ThrowError("Некорректный ввод!");
                                            break;
                                        }

                                        Console.Clear();

                                        InfoMenu(productChoice, result);

                                        break;

                                    case 4:
                                        isEndCategory = true;
                                        break;

                                    default:
                                        ThrowError("Такого пункта нет!");
                                        break;
                                }
                            }

                            break;

                        case 2:
                            isEnd = true;
                            break;

                        default:
                            ThrowError("Такого пункта нет!");
                            break;
                    }
                }
            }
        }

        private static void ShowMenu(string head, params string[] arguments)
        {
            Console.WriteLine(head);
            for (int i = 0; i < arguments.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {arguments[i]}");
            }
            Console.Write("Ваш выбор: ");
        }

        private static void ThrowError(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
        }

        private static void InfoMenu(int productChoice, ICollection products)
        {
            int count = 0;
            foreach (var product in products)
            {
                if (productChoice - 1 == count)
                {
                    if (product is TV TV)
                    {
                        Console.WriteLine(TV.ToString());
                    }
                    else if (product is Smartphone smartphone)
                    {
                        Console.WriteLine(smartphone.ToString());
                    }
                    else if (product is Computer computer)
                    {
                        Console.WriteLine(computer.ToString());
                    }
                    else if (product is Refrigerator refrigerator)
                    {
                        Console.WriteLine(refrigerator.ToString());
                    }
                    else if (product is StationeryKnife stationeryKnife)
                    {
                        Console.WriteLine(stationeryKnife.ToString());
                    }
                    Console.ReadLine();
                }
                count++;
            }
        }

        private static void ShowProducts(ICollection products)
        {
            foreach (var product in products)
            {
                int count = 1;
                if (product is TV TV)
                {
                    Console.WriteLine($"~~[{count++}]~~");
                    Console.WriteLine($"Модель: {TV.Name}");
                    Console.WriteLine($"Рейтинг: {TV.Mark}");
                    Console.WriteLine($"Цена: {TV.Price}\n");
                }
                else if (product is Smartphone smartphone)
                {
                    Console.WriteLine($"~~[{count++}]~~");
                    Console.WriteLine($"Модель: {smartphone.Name}");
                    Console.WriteLine($"Рейтинг: {smartphone.Mark}");
                    Console.WriteLine($"Цена: {smartphone.Price}\n");
                }
                else if (product is Computer computer)
                {
                    Console.WriteLine($"~~[{count++}]~~");
                    Console.WriteLine($"Модель: {computer.Name}");
                    Console.WriteLine($"Рейтинг: {computer.Mark}");
                    Console.WriteLine($"Цена: {computer.Price}\n");
                }
                else if (product is Refrigerator refrigerator)
                {
                    Console.WriteLine($"~~[{count++}]~~");
                    Console.WriteLine($"Модель: {refrigerator.Name}");
                    Console.WriteLine($"Рейтинг: {refrigerator.Mark}");
                    Console.WriteLine($"Цена: {refrigerator.Price}\n");
                }
                else if (product is StationeryKnife stationeryKnife)
                {
                    Console.WriteLine($"~~[{count++}]~~");
                    Console.WriteLine($"Модель: {stationeryKnife.Name}");
                    Console.WriteLine($"Рейтинг: {stationeryKnife.Mark}");
                    Console.WriteLine($"Цена: {stationeryKnife.Price}\n");
                }
            }
        }
    }
}
