using PsicoSoft.Core.DomainObjects;
using System;

namespace PsicoSoft.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
