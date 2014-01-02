using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SautDnw.Operations;

namespace SautDnw.Phases
{
    /// <summary>
    /// Фаза, состоящая из нескольких последовательно выполняемых операций
    /// </summary>
    public class OperationListPhase : IPhase
    {
        public IList<IOperation> OperatoinList { get; set; }

        /// <summary>Инициализирует новый экземпляр класса с указанным через params списком операций</summary>
        public OperationListPhase(params IOperation[] Ops) { OperatoinList = Ops; }

        /// <summary>Инициализирует новый экземпляр класса с указанным списком операций</summary>
        public OperationListPhase(IEnumerable<IOperation> Ops) : this(Ops.ToArray()) { }

        public void Execute()
        {
            foreach (var operation in OperatoinList)
                operation.Execute();
        }
    }
}
