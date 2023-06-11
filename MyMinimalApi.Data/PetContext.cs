﻿using Microsoft.EntityFrameworkCore;
using MyMinimalApi.Data.Models;

namespace MyMinimalApi.Data;
public class PetContext : DbContext {
    public PetContext(DbContextOptions<PetContext> options) : base(options) { }

    public DbSet<Pet> Pets { get; set; }
}
