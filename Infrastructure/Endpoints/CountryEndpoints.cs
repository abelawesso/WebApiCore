using WebAPICRUD.Application.Dtos;
using WebAPICRUD.Infrastructure.Interfaces;

namespace WebAPICRUD.Infrastructure.Endpoints
{
    public static class CountryEndpoints
    {

        /** * This method maps the endpoints for country-related operations to the provided IEndpointRouteBuilder.
         * It defines routes for creating, retrieving, updating, and deleting countries, and associates them with the appropriate HTTP methods and handlers.
         *
         * @param app The IEndpointRouteBuilder to which the country endpoints will be mapped.
         */

        public static void MapCountryEndpoints(this IEndpointRouteBuilder app)
        {
            var route = app.MapGroup("/countries").WithTags("Countries");

            route.MapPost("/", async (CreateCountry createCountry, ICountryService countryService) =>
            {
                var result = await countryService.CreateCountryAsync(createCountry);
                return Results.Created($"/countries/{result.Id}", result);
            });

            route.MapGet("/{id:guid}", async (Guid id, ICountryService countryService) =>
            {
                var result = await countryService.GetCountryByIdAsync(id);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            });
            route.MapGet("/", async (ICountryService countryService) =>
            {
                var result = await countryService.ListCountriesAsync();
                return Results.Ok(result);
            });

            route.MapPut("/{id:guid}", async (Guid id, UpdateCountry updateCountry, ICountryService countryService) =>
            {
                try
                {
                    await countryService.UpdateCountryAsync(id, updateCountry);
                    return Results.NoContent();
                }
                catch (ArgumentNullException)
                {
                    return Results.NotFound();
                }
            });

            route.MapDelete("/{id:guid}", async (Guid id, ICountryService countryService) =>
            {
                try
                {
                    await countryService.DeleteCountryAsync(id);
                    return Results.NoContent();
                }
                catch (ArgumentNullException)
                {
                    return Results.NotFound();
                }
            });
        }
    }
}
