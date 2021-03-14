namespace LINQHomework.Domain
{
    public class Smartphone : Product
    {
        public string ScreenResolution { get; set; }
        public string CPUModelName { get; set; }
        public double ScreenSize { get; set; }
        public double CPUFrequency { get; set; }
        public int MainCameraResolution { get; set; }
        public int FrontFacingCameraResolution { get; set; }
        public int InternalMemoryCapacity { get; set; }
        public int RAM { get; set; }

        public override string ToString()
        {
            var baseResult = base.ToString();
            return $"{baseResult}Размер экрана: {ScreenSize}\nРазрешение экрана: {ScreenResolution}\nПроцессор: {CPUModelName}\nЧастота процессора: {CPUFrequency}\nОЗУ: {RAM}\nОбъем встроенной памяти: {InternalMemoryCapacity}\nРазрешение основной камеры: {MainCameraResolution}\nРазрешение фронтальной камеры: {FrontFacingCameraResolution}\n";
        }
    }
}
