namespace LaboratorieAPI.Models
{
    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; private set; }
        public float Tempreture { get; set; }

        public Sample(int id, string name, DateTime timeStamp, float tempreture)
        {
            Id = id;
            Name = name;
            TimeStamp = DateTime.UtcNow;
            Tempreture = tempreture;
        }
    }
}
