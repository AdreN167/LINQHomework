namespace LINQHomework.Domain
{
    public class TV : Product
    {
        public string Type { get; set; }
        public string MaximumResolution { get; set; }
        public bool IsSmart { get; set; }
        public bool Is3D { get; set; }
        public int Diagonal { get; set; }
        public int HDMICount { get; set; }

        public override string ToString()
        {
            var baseResult = base.ToString();
            var isSmartAsText = (IsSmart) ? "да" : "нет";
            var is3DAsText = (Is3D) ? "да" : "нет";
            return $"{baseResult}Тип: {Type}\nРазрешение: {MaximumResolution}\nДиагональ: {Diagonal}\nКоличество HDMI: {HDMICount}\n3D: {is3DAsText}\nSmartTV: {isSmartAsText}\n";
        }
    }
}
