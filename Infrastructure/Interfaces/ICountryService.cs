using WebAPICRUD.Application.Dtos;

namespace WebAPICRUD.Infrastructure.Interfaces
{
    public interface ICountryService
    {
        Task<CountryDto> CreateCountryAsync(CreateCountry createCountry);
        Task<CountryDto> GetCountryByIdAsync(Guid id);
        Task<IEnumerable<CountryDto>> ListCountriesAsync();
        Task UpdateCountryAsync(Guid id, UpdateCountry updateCountry);
        Task DeleteCountryAsync(Guid id);
    }
}
