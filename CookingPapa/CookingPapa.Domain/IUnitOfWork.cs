using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Domain.Models;

namespace CookingPapa.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repository Constructors

        #endregion

        int Complete();
    }
}
