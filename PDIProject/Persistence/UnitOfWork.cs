namespace PDIProject.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PDIDataContext _context;

        public UnitOfWork(PDIDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
