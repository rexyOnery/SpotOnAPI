using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserState> UserStates { get; set; }
        public DbSet<LocalArea> LocalAreas { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PresidentialCandidate> PresidentialCandidates { get; set; }
        public DbSet<PresidentialVote> PresidentialVotes { get; set; }
        public DbSet<GovernorCandidate> GovernorCandidates { get; set; }
        public DbSet<GovernorVote> GovernorVotes { get; set; }

        private readonly IConfiguration Configuration;
        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        }


    }
}