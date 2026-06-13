using WebAPICRUD.Domain.BaseEntity;

namespace WebAPICRUD.Domain
{
    public sealed class Country : EntityBase
    {
        public string Name { get; set; }
        public DateTime DateOfIndependence { get; set; }
        public string Motto { get; set; }
        public long Population { get; set; }
        public string CurrencyCode { get; set; }

        public Country() 
        {
            Name = string.Empty;
            DateOfIndependence = DateTime.MinValue;
            Motto = string.Empty;
            CurrencyCode = string.Empty;
        }

        public Country(string name, DateTime dateOfIndependence, string motto, long population, string currencyCode)
        {
            Name = name;
            DateOfIndependence = dateOfIndependence;
            Motto = motto;
            Population = population;
            CurrencyCode = currencyCode;
        }

        /** This method can be used to create a new country instance. It also validates the properties before creating a new country instance.
         */
        public static Country Create(string name, DateTime dateOfIndependence, string motto, long population, string currencyCode)
        {
            ValidateCountry(name, dateOfIndependence, motto, population, currencyCode);
            return new Country(name, dateOfIndependence, motto, population, currencyCode);
        }

        /** This method can be used to update the country properties. It also validates the properties before updating.
         */
        public void Update(string name, DateTime dateOfIndependence, string motto, long population, string currencyCode)
        { 
            ValidateCountry(name, dateOfIndependence, motto, population, currencyCode);                           
            Name = name;
            DateOfIndependence = dateOfIndependence;
            Motto = motto;
            Population = population;
            CurrencyCode = currencyCode;
            UpdateLastModified();
        }

        /** This method can be used to validate the country properties before updating or creating a new country instance.
         */
        public static void ValidateCountry(string name, DateTime dateOfIndependence, string motto, long population, string currencyCode)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Country name is required.", nameof(name));
            if (dateOfIndependence == DateTime.MinValue)
                throw new ArgumentException("Date of independence is required.", nameof(dateOfIndependence));
            if (string.IsNullOrWhiteSpace(motto))
                throw new ArgumentException("Motto is required.", nameof(motto));
            if (population < 0)
                throw new ArgumentException("Population cannot be negative.", nameof(population));
            if (string.IsNullOrWhiteSpace(currencyCode))
                throw new ArgumentException("Currency code is required.", nameof(currencyCode));
        }
    }
}   
           
   