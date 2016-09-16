using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Snapmd.Core.Entities;
using Snapmd.Core.Solvers;
using Snapmd.Infrastructure;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Snapmd.Controllers.api
{
    [Route("api/[controller]")]
    public class SolverController : Controller
    {
        private ITaskSolver _solver;

        public SolverController(ITaskSolver solver)
        {
            _solver = solver;
        }

        // Post: api/solver
        [HttpPost]
        public object Post([FromBody]TaskSearchParams param)
        {
            if( param.jar1Capacity.HasValue &&
                param.jar2Capacity.HasValue &&
                param.targetAmount.HasValue)
            {
                var jar1 = new Jar(param.jar1Capacity.Value);
                var jar2 = new Jar(param.jar2Capacity.Value);

                var result = _solver.TryToSolve(jar1, jar2, param.targetAmount.Value);

                return result;
            }
            
            var response = BadRequest("One or more of input parameters are empty");
            Response.StatusCode = response.StatusCode.Value;
            return response.Value;
        }
    }
}
