using BattleRap.API.Auth.Models;
using BattleRap.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleRap.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                .Navigation(x => x.Info)
                .AutoInclude();

            modelBuilder.Entity<OrganizationInfo>()
                .Navigation(x => x.Address)
                .AutoInclude();

            modelBuilder.Entity<Address>()
                .Navigation(x => x.City)
                .AutoInclude();

            modelBuilder.Entity<City>()
                .Navigation(x => x.State)
                .AutoInclude();

            modelBuilder.Entity<State>()
                .Navigation(x => x.Country)
                .AutoInclude();

            modelBuilder.Entity<OrganizationInfo>()
                .Navigation(x => x.SocialMedias)
                .AutoInclude();

            modelBuilder.Entity<OrganizationSocialMedia>()
                .Navigation(x => x.SocialMediaProfile)
                .AutoInclude();

            modelBuilder.Entity<SocialMediaProfile>()
                .Navigation(x => x.Platform)
                .AutoInclude();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> User { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<OrganizationSuggestion> OrganizationSuggestion { get; set; }
        public DbSet<OrganizationInfo> OrganizationInfo { get; set; }
        public DbSet<OrganizationSocialMedia> OrganizationSocialMedia { get; set; }
        public DbSet<SocialMediaPlatform> SocialMediaPlatform { get; set; }
        public DbSet<SocialMediaProfile> SocialMediaProfile { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Country> Country { get; set; }
    }
}
