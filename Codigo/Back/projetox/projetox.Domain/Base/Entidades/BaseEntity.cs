using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Base.Entidades
{
    public abstract class BaseEntity : Notificavel, IDisposable
    {
        public Guid Id { get; protected set; }

        public void Dispose()
        {
            
        }
    }
}
