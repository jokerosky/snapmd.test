using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Snapmd.Core.Solvers;
using Snapmd.Core.Entities;

namespace Snapmd.Core.Tests
{

    [TestFixture]
    public class TaskSolverTests
    {
        /// <summary>
        /// Actually it is integrational test
        /// </summary>
        [Test]
        public void Should_tell_whether_the_task_has_decision_and_get_2_solutions()
        {
            var solver = new BilliardsTaskSolver();
            var jar1 = new Jar(5);
            var jar2 = new Jar(3);
            var jar3 = new Jar(10);

            //bad way
            var result = solver.TryToSolve(jar1, jar2, 8);
            Assert.IsFalse(result.IsPossible);

            result = solver.TryToSolve(jar1, jar3, 7);
            Assert.IsFalse(result.IsPossible);

            //good way
            result = solver.TryToSolve(jar1, jar2, 4);
            Assert.IsTrue(result.IsPossible);

            Assert.IsTrue(result.TransfusionsFirstWay.Count > 0);
            Assert.IsTrue(result.TransfusionsSecondWay.Count > 0);

            result = solver.TryToSolve(jar2, jar3, 4);
            Assert.IsTrue(result.IsPossible);

            Assert.IsTrue(result.TransfusionsFirstWay.Count > 0);
            Assert.IsTrue(result.TransfusionsSecondWay.Count > 0);
        }
    }
}
