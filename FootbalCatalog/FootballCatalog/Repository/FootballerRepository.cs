﻿using FootballCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballCatalog.Repository;

public class FootballerRepository : IFootballerRepository
{
    private readonly ApplicationDbContext DbContext;

    public FootballerRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<Footballer> CreateAsync(Footballer footballer)
    {
        await DbContext.Footballers.AddAsync(footballer);
        await DbContext.SaveChangesAsync();
        return footballer;
    }

    public async Task<Footballer> UpdateAsync(Footballer footballer)
    {
        DbContext.Footballers.Update(footballer);
        await DbContext.SaveChangesAsync();
        return footballer;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var t = await FindByIdAsync(id);
        DbContext.Footballers.Remove(t);
        await DbContext.SaveChangesAsync();
    }

    public async Task<Footballer> FindByIdAsync(int id)
    {
        return await DbContext.Footballers.Where(footballer => footballer.Id == id).FirstAsync();
    }

    public async Task<List<Footballer>> GetAllAsync()
    {
        return await DbContext.Footballers
            .Include(footballer => footballer.Gender)
            .Include(footballer => footballer.Country)
            .Include(footballer => footballer.Team)
            .ToListAsync();
    }
}