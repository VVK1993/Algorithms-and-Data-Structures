using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgTrains.Interfaces
{
    interface ITaskPerformer
    {
        string TaskDescription { get; }
        string FileName { get; }
        Task PerformTask();
    }
}
