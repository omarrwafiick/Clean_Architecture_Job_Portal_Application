using DomainLayer.Models; 
using Microsoft.EntityFrameworkCore; 
namespace InfrastructureLayer.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
        } 
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatus { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             
            modelBuilder.Entity<JobApplication>()
                .HasOne(j => j.JobPost)
                .WithMany(jp => jp.Applications)
                .HasForeignKey(j => j.JobPostId)
            .OnDelete(DeleteBehavior.Restrict);

            #region Seeding
            modelBuilder.Entity<Role>().HasData(
               new Role { Id = Guid.NewGuid(), Name = "Admin" },
               new Role { Id = Guid.NewGuid(), Name = "Employer" },
               new Role { Id = Guid.NewGuid(), Name = "Candidate" }
            );

            modelBuilder.Entity<ApplicationStatus>().HasData(
               new ApplicationStatus { Id = Guid.NewGuid(), Name = "Pending" },
               new ApplicationStatus { Id = Guid.NewGuid(), Name = "Reviewed" },
               new ApplicationStatus { Id = Guid.NewGuid(), Name = "Shortlisted" },
               new ApplicationStatus { Id = Guid.NewGuid(), Name = "Rejected" },
               new ApplicationStatus { Id = Guid.NewGuid(), Name = "Hired" }
            );

            modelBuilder.Entity<JobType>().HasData(
               new JobType { Id = Guid.NewGuid(), Name = "FullTime" },
               new JobType { Id = Guid.NewGuid(), Name = "PartTime" },
               new JobType { Id = Guid.NewGuid(), Name = "Contract" },
               new JobType { Id = Guid.NewGuid(), Name = "Internship" },
               new JobType { Id = Guid.NewGuid(), Name = "Freelance" }
            );

            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = Guid.Parse("c1111111-aaaa-4bbb-cccc-111111111111"),
                   Name = "TechNova Inc.",
                   Website = "https://technova.com",
                   Description = "An innovative tech company building AI tools."
               },
               new Company
               {
                   Id = Guid.Parse("c2222222-aaaa-4bbb-cccc-222222222222"),
                   Name = "HealthCare Plus",
                   Website = "https://healthcareplus.org",
                   Description = "A healthcare organization focused on digital transformation."
               },
               new Company
               {
                   Id = Guid.Parse("c3333333-aaaa-4bbb-cccc-333333333333"),
                   Name = "FinPro Solutions",
                   Website = "https://finprosolutions.com",
                   Description = "Leading fintech platform provider."
               }
            );
            #endregion
        }
    } 
}
//1.Domain Layer(The core)
//Contains only pure business logic and models (like JobPost, JobApplication).

//Doesn’t depend on any other layer.

//It’s like your clean recipe — reusable and independent.

//Knows nothing about how data is saved, how UI looks, or anything else.

//🧠 2. Application Layer (The brain)
//Contains interfaces and use cases (like IJobApplicationService, IRepository<T>).

//Knows about the Domain — uses the models from it.

//But does NOT care how the work is done — just defines what needs to happen.

//Think of it as the planner or blueprint.

//🏗️ 3. Infrastructure Layer (The worker)
//Implements the interfaces from Application.

//Like MainRepository<T> implements IRepository<T>.

//Talks to the database using DbContext.

//Knows about Application and Domain because it needs both to do the job.

//🌐 4. Presentation Layer (The face/UI — e.g., Web API)
//Calls the services in the Application layer (like IJobApplicationService).

//Knows about all layers because it coordinates everything.

//🧭 Flow (Step-by-step):
//markdown
//Copy
//Edit
//1. Presentation Layer (Controller) calls → IJobApplicationService

//2. Application Layer defines IJobApplicationService (Interface)
//   and uses IRepository<JobApplication>

//3. Infrastructure Layer implements:
//    -JobApplicationService(maybe here in your case)
//    -IRepository < T > → MainRepository < T >

//4.MainRepository < T > talks to DbContext → saves data to database
