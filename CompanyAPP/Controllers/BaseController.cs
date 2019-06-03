using CompanyAPP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAPP.Controllers
{
    public class BaseController : ControllerBase
    {
        protected CompanyDBContext _context;
    }
}
