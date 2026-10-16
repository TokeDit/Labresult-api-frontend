using LaboratorieAPI.Interfaces;
using LaboratorieAPI.Models;

namespace LaboratorieAPI.Repositories;

public class SampleRepository : ISampleRepository
{
    private readonly object _lock = new();
    private readonly List<Sample> _items = new List<Sample>()
    {
       new Sample(1, "yeast", DateTime.UtcNow , 90),
       new Sample(2, "bioChemicals", DateTime.UtcNow, 40),
       new Sample(3, "enzyme culture", DateTime.UtcNow, 37),
       new Sample(4, "bacteria strain A", DateTime.UtcNow, 28),
       new Sample(5, "protein extract", DateTime.UtcNow, 4),
       new Sample(6, "fermentation batch 1", DateTime.UtcNow, 32),
       new Sample(7, "control sample", DateTime.UtcNow, 20)
    };
    private int _nextId = 8;

    public IEnumerable<Sample> GetAll()
    {
        return _items.AsReadOnly();
    }

    public Sample? GetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public Sample Add(Sample item)
    {
        lock (_lock)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return item;
        }
    }
}
