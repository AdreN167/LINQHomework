namespace LINQHomework.Domain
{
    public class StationeryKnife : Product
    {
        public string Color { get; set; }
        public int BladeWidth { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        public override string ToString()
        {
            var baseResult = base.ToString();
            return $"{baseResult}Цвет: {Color}\nШирина лезвия (мм): {BladeWidth}\nШирина (см): {Width}\nДлина (см): {Length}\nВес (г): {Weight}\n";
        }
    }
}
