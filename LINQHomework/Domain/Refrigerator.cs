namespace LINQHomework.Domain
{
    public class Refrigerator : Product
    {
        public int RefrigeratorCompartmentsCapacity { get; set; }
        public int FreezerCapacity { get; set; }
        public bool IsNoFrostTechnology { get; set; }
        public bool IsDisplay { get; set; }
        public string EnergyConsumptionClass { get; set; }

        public override string ToString()
        {
            var baseResult = base.ToString();
            var isNoFrostTechnologyAsText = (IsNoFrostTechnology) ? "да" : "нет";
            var isDisplayAsText = (IsDisplay) ? "да" : "нет";
            return $"{baseResult}Объем холодильно камеры: {RefrigeratorCompartmentsCapacity}\nОбъем морозильной камеры: {FreezerCapacity}\nКласс энергопотребления: {EnergyConsumptionClass}\nNo Frost технология: {isNoFrostTechnologyAsText}\nДисплей: {isDisplayAsText}\n";
        }
    }
}
