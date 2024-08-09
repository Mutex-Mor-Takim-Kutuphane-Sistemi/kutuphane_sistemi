using Microsoft.EntityFrameworkCore;
using System;


namespace Purple_Kutphane_Sistemi.Data
{

    public class DbBaglanti : DbContext
    {
        public DbBaglanti(DbContextOptions<DbBaglanti> options) : base(options)
        {

        }
    }
}
