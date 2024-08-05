using LedgerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LedgerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseParticipant> ExpensesParticipant { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<Group>()
                .HasKey(g => g.GroupID);

            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany(g => g.GroupMembers)
                .HasForeignKey(gm => gm.GroupID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction

            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.User)
                .WithMany(u => u.GroupMembers)
                .HasForeignKey(gm => gm.UserID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction

            modelBuilder.Entity<GroupMember>()
                .HasKey(gm => new { gm.UserID, gm.GroupID });

            modelBuilder.Entity<Expense>()
                .HasKey(e => e.ExpenseID);

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.PaidByUser)
                .WithMany(p => p.PaidExpenses)
                .HasForeignKey(e => e.PaidByUserID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction

            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Group)
                .WithMany(g => g.Expenses)
                .HasForeignKey(e => e.GroupID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction

            modelBuilder.Entity<ExpenseParticipant>()
                .HasOne(ep => ep.Expense)
                .WithMany(e => e.ExpenseParticipants)
                .HasForeignKey(ep => ep.ExpenseID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction

            modelBuilder.Entity<ExpenseParticipant>()
                .HasOne(ep => ep.ParticipantUser)
                .WithMany(u => u.ExpenseParticipants)
                .HasForeignKey(ep => ep.ParticipantUserID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction

            modelBuilder.Entity<ExpenseParticipant>()
                .HasKey(ep => new { ep.ExpenseID, ep.ParticipantUserID });

            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentID);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Payer)
                .WithMany()
                .HasForeignKey(p => p.PayerID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Payee)
                .WithMany()
                .HasForeignKey(p => p.PayeeID)
                .OnDelete(DeleteBehavior.Restrict); // Changed to NoAction
        }
    }
}
