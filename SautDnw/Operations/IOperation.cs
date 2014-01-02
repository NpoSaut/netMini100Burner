using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SautDnw.Operations
{
    /// <summary>
    /// Атомарная операция
    /// </summary>
    public interface IOperation
    {
        void Execute();
    }
}
