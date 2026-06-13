namespace WebAPICRUD.Application.Dtos
{
    public sealed record CreateCountry(
        string Name,
        DateTime DateOfIndependence,
        string Motto,
        long Population,
        string CurrencyCode
    );
}
