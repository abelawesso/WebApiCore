namespace WebAPICRUD.Application.Dtos
{
    public record CountryDto
    (
        Guid Id,
        string Name,
        DateTime DateOfIndependence,
        string Motto,
        long Population,
        string CurrencyCode,
        DateTimeOffset CreatedOn,
        DateTimeOffset? LastModifiedOn,
        bool IsDeleted,
        DateTimeOffset? DeletedOn
    );
}
