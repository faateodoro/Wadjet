namespace Wadjet.Entities;

public class Establishment
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string CNPJ { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public int MotorcycleVacancy { get; private set; }
    public int CarVacancy { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.Now;

    [Obsolete]
    protected Establishment() { }

    public Establishment(string name, string cNPJ, string address, string phone, int motorcycleVacancy, int carVacancy)
    {
        Name = name;
        CNPJ = cNPJ;
        Address = address;
        Phone = phone;
        MotorcycleVacancy = motorcycleVacancy;
        CarVacancy = carVacancy;
    }
}
