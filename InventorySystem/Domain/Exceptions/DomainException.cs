using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Exceptions
{
    /// <summary>
    /// Excepciones gestionadas por el dominio.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        public DomainException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public DomainException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner exception.</param>
        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
