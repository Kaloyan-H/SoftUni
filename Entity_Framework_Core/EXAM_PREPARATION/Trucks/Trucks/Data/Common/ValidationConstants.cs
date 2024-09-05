namespace Trucks.Data.Common;

public static class ValidationConstants
{
    // Truck
    public const int TruckRegistrationNumberLength = 8;
    public const int TruckVinNumberLength = 17;
    public const int TruckTankCapacityMaxValue = 1420;
    public const int TruckTankCapacityMinValue = 950;
    public const int TruckCargoCapacityMaxValue = 29000;
    public const int TruckCargoCapacityMinValue = 5000;

    // Client
    public const int ClientNameMaxLength = 40;
    public const int ClientNameMinlength = 3;
    public const int ClientNationalityMaxLength = 40;
    public const int ClientNationalityMinLength = 2;

    // Despatcher
    public const int DespatcherNameMaxLength = 40;
    public const int DespatcherNameMinLength = 2;
}
