using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Data;

public class AppDbContext(DbContextOptions options) 
    : IdentityDbContext<User>(options);