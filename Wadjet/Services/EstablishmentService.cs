using Microsoft.EntityFrameworkCore;
using Wadjet.DTO;
using Wadjet.Entities;
using Wadjet.Infra;

namespace Wadjet.Services;

public class EstablishmentService
{
    private readonly ApplicationContext _context;

    public EstablishmentService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Establishment> CreateAsync(EstablishmentForm form)
    {
        if (form == null) throw new ArgumentNullException("Establishment cannot be null.");
        var establishment = new Establishment(form);
        await _context.AddAsync(establishment);
        await _context.SaveChangesAsync();
        return establishment;
    }

    public async Task<IList<Establishment>> GetAllAsync()
    {
        if (!_context.Establishments.Any()) throw new KeyNotFoundException("There's no record on DB.");
        var establishments = await _context.Establishments.ToListAsync();
        return establishments;
    }

    public async Task<IList<Establishment>> GetActiveAsync()
    {
        if (!_context.Establishments.Any()) throw new KeyNotFoundException("There's no record on DB.");
        var establishments = await _context.Establishments.Where(x => x.IsActive == true).ToListAsync();
        return establishments;
    }

    public async Task<Establishment> GetOneAsync(long id)
    {
        if (!_context.Establishments.Any()) throw new KeyNotFoundException("There's no record on DB.");
        var establishment = await _context.Establishments.FirstAsync(x => x.Id == id);
        if (establishment == null) throw new KeyNotFoundException("There's no record on DB.");
        return establishment;
    }

    public async Task RemoveAsync(long id)
    {
        var establishment = await GetOneAsync(id);
        if (establishment == null) throw new KeyNotFoundException("There's no record on DB.");
        establishment.Deactivate();
        _context.Update(establishment);
        await _context.SaveChangesAsync();
    }

    public async Task<Establishment> UpdateAsync(long id, EstablishmentForm form)
    {
        var establishment = await GetOneAsync(id);
        if (establishment == null) throw new KeyNotFoundException("There's no record on DB.");
        establishment.Update(form);
        _context.Update(establishment);
        await _context.SaveChangesAsync();
        return establishment;
    }
}
