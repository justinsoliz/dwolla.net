using System.Collections.Generic;
using System.Web;
using Dwolla.Helpers;
using Dwolla.Models;

namespace Dwolla.Services
{
    public abstract class DwollaService
    {
        protected bool Sandbox;
        public DwollaService(bool sandbox = false)
        {
            Sandbox = sandbox;
        }
    }
}
