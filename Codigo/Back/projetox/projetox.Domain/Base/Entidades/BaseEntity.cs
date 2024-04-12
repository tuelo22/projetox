using projetox.Domain.Notification.Entidades;

namespace projetox.Domain.Base.Entidades
{
    /// <summary>
    /// Entidade basica que generaliza notificação e ID para as entidades que possuem persistencia.
    /// </summary>
    public abstract class BaseEntity : Notificavel
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
