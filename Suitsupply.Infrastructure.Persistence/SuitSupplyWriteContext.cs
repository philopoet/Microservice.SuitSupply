using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Suitsupply.Domain.Contracts;
using Suitsupply.Domain.Suits;

namespace Suitsupply.Infrastructure.Persistence
{

    public class SuitSupplyWriteContext : DbContext, ISuitSupplyUnitOfWork
    {
        public SuitSupplyWriteContext()
        {
            try
            {
                var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
                databaseCreator.CreateTables();
            }
            catch (System.Data.SqlClient.SqlException)
            {

                
            }
         
        }
        public virtual DbSet<Suit> Suit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            try
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                options.UseSqlServer(configuration.GetConnectionString("AlterationServiceWriteContext"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
    
        }
           
        public void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                base.OnModelCreating(modelBuilder);
                //modelBuilder.Entity<Suit>().HasData(
           //         new Suit(10, 20, "blue", "cotton"));
           //     modelBuilder.Entity<Suit>().OwnsOne(su => su.Alteration).HasData(
           //new Alteration(0,0,0,0));
                modelBuilder.Entity<Suit>().OwnsOne(suit => suit.Alteration)
                    .Property(al => al.RightSleeveLength).HasColumnName("AlterationRightSleeveLength").HasDefaultValue(0);
                modelBuilder.Entity<Suit>().OwnsOne(suit => suit.Alteration)
                    .Property(al => al.LeftSleeveLength).HasColumnName("AlterationLeftSleeveLength").HasDefaultValue(0);
                modelBuilder.Entity<Suit>().OwnsOne(suit => suit.Alteration)
                    .Property(al => al.RighTrouserLength).HasColumnName("AlterationRightTrouserLength").HasDefaultValue(0);
                modelBuilder.Entity<Suit>().OwnsOne(suit => suit.Alteration)
                    .Property(al => al.LeftTrouserLength).HasColumnName("AlterationLeftTrouserLength").HasDefaultValue(0);
                modelBuilder.Entity<Suit>().Property(suit => suit.AlteringTailor).HasDefaultValue(Guid.Empty);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
          
            //modelBuilder.Entity<Suit>().Property(p => p.Alteration.RighTrouserLengthAlteration).HasColumnName("AlterationRighTrouserLength");
            //modelBuilder.Entity<Suit>().Property(p => p.Alteration.LeftTrouserLengthAlteration).HasColumnName("LeftTrouserLengthAlteration");
            //modelBuilder.Entity<Suit>().Property(p => p.Alteration.RightSleeveLengthAlteration).HasColumnName("RightSleeveLengthAlteration");
            //modelBuilder.Entity<Suit>().Property(p => p.Alteration.LeftSleeveLengthAlteration).HasColumnName("LeftSleeveLengthAlteration");
        }
    }
}
