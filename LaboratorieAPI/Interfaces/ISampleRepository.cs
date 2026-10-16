using LaboratorieAPI.Models;

namespace LaboratorieAPI.Interfaces;

public interface ISampleRepository
{
    IEnumerable<Sample> GetAll();
    Sample? GetById(int id);
    Sample Add(Sample item);
}
