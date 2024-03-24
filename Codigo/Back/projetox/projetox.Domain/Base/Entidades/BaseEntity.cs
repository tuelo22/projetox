using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Base.Entidades
{
    public abstract class BaseEntity : Notificavel, IDisposable
    {
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public void Dispose()
        {
            
        }
    }
}
