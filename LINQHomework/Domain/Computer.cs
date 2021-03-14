namespace LINQHomework.Domain
{
    public class Computer : Product
    {
        public string FormFactor { get; set; }
        public string CPUModel { get; set; }
        public double CPUFrequency { get; set; }
        public int RAM { get; set; }
        public int StorageDevice { get; set; }
        public string GPUModel { get; set; }
        public string OS { get; set; }

        public override string ToString()
        {
            var baseResult = base.ToString();
            return $"{baseResult}Формфактор: {FormFactor}\nПроцессор: {CPUModel}\nЧастота процессора: {CPUFrequency}\nОЗУ: {RAM}\nОбъем диска: {StorageDevice}\nВидеокарта: {GPUModel}\nОперационная система: {OS}\n";
        }
    }
}
