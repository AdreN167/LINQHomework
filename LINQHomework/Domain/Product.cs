using System;

namespace LINQHomework.Domain
{
    public class Product : Entity
    {
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public int Price { get; set; }
        public double Mark { get; set; }

        public override string ToString()
        {
            return $"Модель: {Name}\nКомпания: {CompanyName}\nЦена: {Price}\nРейтинг: {Mark}\n";
        }
    }
}
