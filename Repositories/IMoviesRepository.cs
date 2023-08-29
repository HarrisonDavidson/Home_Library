using HomeLibrary.Models;

namespace HomeLibrary.Repositories
{
    public interface IMoviesRepository
    {
        void Add(Movies movies);
        void Delete(int id);
        Movies Get(int id);
        List<Movies> GetAll();
        void Update(Movies movies);
    }
}