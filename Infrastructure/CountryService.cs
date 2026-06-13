using Microsoft.EntityFrameworkCore;
using WebAPICRUD.Application.Dtos;
using WebAPICRUD.Domain;
using WebAPICRUD.Domain.Persistence;
using WebAPICRUD.Infrastructure.Interfaces;

namespace WebAPICRUD.Infrastructure
{
    public class CountryService(AppDbContext context) : ICountryService
    {
        private readonly AppDbContext _context = context;

        public async Task<CountryDto> CreateCountryAsync(CreateCountry createCountry)
        {
           var country = Country.Create(createCountry.Name, createCountry.DateOfIndependence, createCountry.Motto,
               createCountry.Population, createCountry.CurrencyCode);

           await _context.Countries.AddAsync(country);
          await _context.SaveChangesAsync();
           return await Task.FromResult(new CountryDto(country.Id, country.Name, country.DateOfIndependence, country.Motto, 
               country.Population, country.CurrencyCode,country.CreatedOn,country.LastModifiedOn,country.IsDeleted,country.DeletedOn));
        }

        public async Task DeleteCountryAsync(Guid id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country is null)
            {
                throw new ArgumentNullException($"Country with id {id} not found.");
            }
            country.MarkAsDeleted();
            await _context.SaveChangesAsync();

        }

        public async Task<CountryDto> GetCountryByIdAsync(Guid id)
        {
           var country = await _context.Countries.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
           return await Task.FromResult(new CountryDto(country.Id, country.Name, country.DateOfIndependence, country.Motto, 
               country.Population, country.CurrencyCode,country.CreatedOn,country.LastModifiedOn,country.IsDeleted,country.DeletedOn));
        }

        public async Task<IEnumerable<CountryDto>> ListCountriesAsync()
        {
            var countryList = await _context.Countries.AsNoTracking().ToListAsync();
            return await Task.FromResult(countryList.Select(country => new CountryDto(country.Id, country.Name, country.DateOfIndependence, country.Motto,
                country.Population, country.CurrencyCode, country.CreatedOn, country.LastModifiedOn, country.IsDeleted, country.DeletedOn)).ToList());
        }

        public async Task UpdateCountryAsync(Guid id, UpdateCountry updateCountry)
        {
           var country = await _context.Countries.FindAsync(id);
            if (country is null)
            {
               
               throw new ArgumentNullException($"Country with id {id} not found.");
            }
            country.Update(updateCountry.Name, updateCountry.DateOfIndependence, updateCountry.Motto,
                updateCountry.Population, updateCountry.CurrencyCode);
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            
        }
    }
}
