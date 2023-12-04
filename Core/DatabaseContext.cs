using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Windows.Forms;
using TeachersHandsBooks.Core.Tables;

namespace TeachersHandsBooks.Core
{
    class DatabaseContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Displine> Displines { get; set; }
        public DbSet<KTP> kTPs { get; set; }
        public DbSet<DisplineWithGroup> ConnectWithGroup { get; set; }
        public DbSet<DayTable> DayTables { get; set; }
        public DbSet<NumberPair> Pairs { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<CurrentShedule> CurrentsShedules { get; set; }
        //Таблица с изменяемым расписанием
        public DbSet<Changes> ChangesTables { get; set; }
        public DbSet<ModifiedSchedule> Modifieds { get; set; }
        public DatabaseContext() : base(new SQLiteConnection
        {
            ConnectionString = new SQLiteConnectionStringBuilder
            {
                DataSource = Application.StartupPath + "\\TeachersHandBookBd.db",
                //ForeignKeys = true
            }.ConnectionString
        }, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

        }

    }
}
