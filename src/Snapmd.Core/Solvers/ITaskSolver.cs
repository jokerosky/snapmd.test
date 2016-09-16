using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Snapmd.Core.Entities;

namespace Snapmd.Core.Solvers
{
    public interface ITaskSolver
    {
        TransfusionsResult TryToSolve(Jar first, Jar second, int targetValue);
    }
}
