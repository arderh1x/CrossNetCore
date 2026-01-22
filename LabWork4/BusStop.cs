namespace LabWork4
{
    public class BusStop(string name, string route, bool isActive, int cost)
    {
        public string Name { get; set; } = name;
        public string BusRoute { get; set; } = route;
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime AddingDate { get; set; } = GetRandomDate();
        public bool IsActive { get; set; } = isActive;
        public int Cost { get; set; } = cost;

        private static DateTime GetRandomDate(){
            var rnd = new Random();
            var start = new DateTime(2020, 1, 1);
            var range = (DateTime.Now - start).Days;
            return start.AddDays(rnd.Next(range)).AddHours(rnd.Next(0, 24)).AddMinutes(rnd.Next(0, 60));
        }

        public override string ToString(){
            return $"Зупинка {Name} з ID: {ID} \nМаршрут: {BusRoute} \nСтворена {AddingDate}, коштувало поставити {Cost}$" +
                $" та на даний момент {(IsActive ? "є активною" : "не є активною")}";
        }

        public override bool Equals(object? obj) { return this?.ID == (obj as BusStop)?.ID; }
        public override int GetHashCode() { return ID.GetHashCode(); }
    }
}
