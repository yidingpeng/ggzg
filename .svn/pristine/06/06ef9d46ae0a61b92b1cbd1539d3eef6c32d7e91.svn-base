using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Procedure
{
    public interface IProcedure
    {
        void Execute();
        void StartExecute();
        void StopExecute();
        event EventHandler BeforeExecute;
        event EventHandler Executing;
        event EventHandler EndExecuted;
    }
}
