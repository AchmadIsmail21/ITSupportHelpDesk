using API.Model;
using Client.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repository
{
    public class StaffCaseRepository : GeneralRepository<StaffCase, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public StaffCaseRepository(Address address, string request = "StaffCases/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }
    }
}
