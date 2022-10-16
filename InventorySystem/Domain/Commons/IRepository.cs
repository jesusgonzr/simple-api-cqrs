using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySystem.Domain.Commons
{
    /// <summary>
    /// IRepository inteface.
    /// </summary>
    /// <typeparam name="T">Clase del tipo IAggregateRoot.</typeparam>
    public interface IRepository<T>
        where T : IAggregateRoot
    {
    }
}
