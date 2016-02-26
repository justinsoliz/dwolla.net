using System.Collections.Generic;
using System.Web;
using Dwolla.Helpers;
using Dwolla.Models;
using RestSharp;

namespace Dwolla.Services
{
    public abstract class DwollaService
    {
        protected bool Sandbox;

        protected RestClient Client { get; set; }

        public DwollaService(bool sandbox = false)
        {
            Client = new RestClient(Urls.BaseUrl(Sandbox));
            Sandbox = sandbox;
        }
    }
}
