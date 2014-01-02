using System;

namespace SautDnw.Operations
{
    public class WaitOperation : IOperation
    {
        public TimeSpan Delay { get; set; }

        public WaitOperation(TimeSpan Delay) { this.Delay = Delay; }

        public void Execute() { System.Threading.Thread.Sleep(Delay); }
    }
}