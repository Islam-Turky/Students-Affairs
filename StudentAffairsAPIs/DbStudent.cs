namespace StudentAffairsAPIs
{
    public class DbStudent : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbStudent(DbContextOptions<DbStudent> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(e => e.Id);
            modelBuilder.Entity<Student>().Property(e => e.Id).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.Age).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.Mobile).HasMaxLength(12);
            modelBuilder.Entity<Student>().Property(e => e.Id).HasMaxLength(5);
            modelBuilder.Entity<Student>().Property(e => e.Age).HasMaxLength(3);
            modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(50);
        }
    }
}
