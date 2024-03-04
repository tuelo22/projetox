namespace projetox.Repository.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XContext _context;

        public UnitOfWork(XContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
