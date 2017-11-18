namespace Aircompany.DataAccess.Entities
{
    public class PlaneLocalization
    {
        public int PlaneId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Plane Plane { get; set; }
        public virtual Language Language { get; set; }
    }
}