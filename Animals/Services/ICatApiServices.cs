using Animals.Models;
using System.Collections;

namespace Animals.Services
{
    public interface ICatApiServices
    {
        Task<IEnumerable<Cat>> AllInfoCatsAsync();
        Task<List<Photo>> SearchCat(Cat cat);
    }
}
