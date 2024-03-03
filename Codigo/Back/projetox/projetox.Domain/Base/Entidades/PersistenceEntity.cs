using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Base.Entidades
{
    public abstract class PersistenceEntity : Notificavel, IDisposable
    {
        public Guid Id { get; set; }

        protected PersistenceEntity()
        {
            Id = Guid.NewGuid();
        }

        public void Dispose()
        {
            
        }
    }
}
