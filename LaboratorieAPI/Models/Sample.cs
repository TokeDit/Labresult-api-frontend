namespace LaboratorieAPI.Models
{
    public class Sample
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; private set; }
        public float Temperature { get; set; }

        public Sample(int id, string name, DateTime timeStamp, float temperature)
        {
            Id = id;
            Name = name;
            TimeStamp = timeStamp;
            Temperature = temperature;
        }
    }
}
