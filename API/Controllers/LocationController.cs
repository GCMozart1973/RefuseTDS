using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Entities;
using API.Data;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class LocationController(DataContext context) : BaseApiController
    {
        [HttpGet("getRefuseCompanies")]
        public async Task<ActionResult<List<RefuseCompany>>> GetRefuseCompanies()
        {
            var companies = await context.RefuseCompany.ToListAsync();
            return companies;
        }

        [HttpGet("getRefuseLocations")]
        public async Task<ActionResult<List<RefuseLocation>>> GetRefuseLocations(long companyID)
        {
            var locations = await context.RefuseLocation.ToListAsync();
            return locations;
        }

        [HttpGet("getRefuseRegions")]
        public async Task<ActionResult<List<RefuseRegion>>> GetRefuseRegions(long refuseCompanyId)
        {
            var regions = await context.RefuseRegion.ToListAsync();
            return regions;
        }


    }
}