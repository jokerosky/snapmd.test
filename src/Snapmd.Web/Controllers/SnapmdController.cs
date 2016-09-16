using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.Extensions.Options;
using Snapmd.Infrastructure;

namespace Snapmd.Controllers
{
    public class SnapmdController:Controller
    {
        private IOptions<Settings> _settings;

        public SnapmdController(IOptions<Settings> settings)
        {
            _settings = settings;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var path = _settings.Value.Wwwroot + "\\" + _settings.Value.HtmlShell;
            var content = System.IO.File.ReadAllText(path);

            return Content(content, "text/html");
        }
    }
}
