using System;
using System.Collections.Generic;
using System.Text;

namespace Arvind.Contract
{
    public interface IRepositoryWrapper
    {
        IInstituteRepository Institute { get; }
        IEmployeeRepository Employee { get; }
        void Save();
    }
}
