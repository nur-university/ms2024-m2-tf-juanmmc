using LogisticsAndDeliveries.Core.Results;

namespace LogisticsAndDeliveries.Domain.Packages
{
    public static class PackageErrors
    {
        public static readonly Error PackageNotFound = new(
            "Package.NotFound",
            "The requested package was not found.",
            ErrorType.NotFound);
    }
}
