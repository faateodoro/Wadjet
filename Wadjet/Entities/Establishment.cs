namespace Wadjet.Entities;

public class Establishment
{
    public string Name { get; private set; }
    public string CNPJ { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public int MotorcycleVacancy { get; private set; }
    public int CarVacancy { get; private set; }
    public DateTime CreatedAt { get; private set; }

}
