namespace Wadjet.DTO;

public class EstablishmentForm
{
    public string? Name { get; private set; }
    public string? CNPJ { get; private set; }
    public string? Address { get; private set; }
    public string? Phone { get; private set; }
    public int MotorcycleVacancy { get; private set; }
    public int CarVacancy { get; private set; }

    public EstablishmentForm(string name, string cNPJ, string address, string phone, int motorcycleVacancy, int carVacancy)
    {
        Name = name;
        CNPJ = cNPJ;
        Address = address;
        Phone = phone;
        MotorcycleVacancy = motorcycleVacancy;
        CarVacancy = carVacancy;
    }
}
