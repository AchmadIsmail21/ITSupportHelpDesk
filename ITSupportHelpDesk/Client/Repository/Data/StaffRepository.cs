using API.Model;
using Client.Base;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Repository.Data
{
    public class StaffRepository : GeneralRepository<Staff, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        private readonly IHttpContextAccessor _contextAccessor;

        public StaffRepository(Address address, string request = "Staffs/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public async Task<List<Staff>> GetStaffs() {
            List<Staff> staffs = new List<Staff>();
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                staffs = JsonConvert.DeserializeObject<List<Staff>>(apiResponse);
            }
            return staffs;
        }

        public async Task<Staff> GetStaffById(int staffId) {
            Staff staff = null;
            using (var response = await httpClient.GetAsync(request + "GetStaffById/" + staffId)) {
                string apiResponse = await response.Content.ReadAsStringAsync();

                staff = JsonConvert.DeserializeObject<Staff>(apiResponse);
            }
            return staff;

        }
    }
}
