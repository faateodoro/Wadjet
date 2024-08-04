using Wadjet.DTO;

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
    public bool IsActive { get; private set; } = true;

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

    public Establishment(EstablishmentForm form)
    {
        ValidateStringFields(form);
        MotorcycleVacancy = form.MotorcycleVacancy;
        CarVacancy = form.CarVacancy;
    }

    public void Deactivate()
    {
        if (IsActive) IsActive = false; 
    }

    public void Update(EstablishmentForm form)
    {
        if (!string.IsNullOrWhiteSpace(form.Name)) Name = form.Name;
        if (!string.IsNullOrWhiteSpace(form.CNPJ)) CNPJ = form.CNPJ;
        if (!string.IsNullOrWhiteSpace(form.Address)) Address = form.Address;
        if (!string.IsNullOrWhiteSpace(form.Phone)) Phone = form.Phone;
        if (form.MotorcycleVacancy != 0) MotorcycleVacancy = form.MotorcycleVacancy;
        if (form.CarVacancy != 0) CarVacancy = form.CarVacancy;
    }

    private void ValidateStringFields(EstablishmentForm form)
    {
        if (!string.IsNullOrWhiteSpace(form.Name))
        {
            try
            {
                Name = form.Name;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Name is missing");
            }
        }

        if (!string.IsNullOrWhiteSpace(form.CNPJ))
        {
            try
            {
                CNPJ = form.CNPJ;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("CNPJ is missing");
            }
        }

        if (!string.IsNullOrWhiteSpace(form.Address))
        {
            try
            {
                Address = form.Address;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Address is missing");
            }
        }

        if (!string.IsNullOrWhiteSpace(form.Phone))
        {
            try
            {
                Phone = form.Phone;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Phone is missing");
            }
        }
    }
}
