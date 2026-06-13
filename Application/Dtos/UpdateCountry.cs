namespace WebAPICRUD.Application.Dtos
{
    public sealed record UpdateCountry(
        string Name,
        DateTime DateOfIndependence,
        string Motto,
        long Population,
        string CurrencyCode
    );
}
