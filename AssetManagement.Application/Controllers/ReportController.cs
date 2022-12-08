using AssetManagement.Contracts.Category.Response;
using AssetManagement.Contracts.Common;
using AssetManagement.Contracts.Report.Response;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AssetManagement.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AssetManagementDbContext _dbContext;

        public ReportController(IMapper mapper, AssetManagementDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<ViewListPageResult<ReportResponse>>> GetAsync([FromQuery] string? sort = "category",
            [FromQuery] string? order = "ASC")
        {
            //Paging by category
            List<Category> categories = await _dbContext.Categories.Include(c => c.Assets)
                                                                   .Skip(0)
                                                                   .Take(3)
                                                                   .ToListAsync();
            //Map to report
            List<ReportResponse> reports = _mapper.Map<List<ReportResponse>>(categories);
            //Sort report
            switch (sort)
            {
                case "total":
                    {
                        if (order == "ASC") reports = reports.OrderBy(r => r.Total).ToList();
                        else reports = reports.OrderByDescending(r => r.Total).ToList();
                    }
                    break;
                case "available":
                    {
                        if (order == "ASC") reports = reports.OrderBy(r => r.Available).ToList();
                        else reports = reports.OrderByDescending(r => r.Available).ToList();
                    }
                    break;
                case "notAvailable":
                    {
                        if (order == "ASC") reports = reports.OrderBy(r => r.NotAvailable).ToList();
                        else reports = reports.OrderByDescending(r => r.NotAvailable).ToList();
                    }
                    break;
                case "recycled":
                    {
                        if (order == "ASC") reports = reports.OrderBy(r => r.Recycled).ToList();
                        else reports = reports.OrderByDescending(r => r.Recycled).ToList();
                    }
                    break;
                case "waitingForRecycling":
                    {
                        if (order == "ASC") reports = reports.OrderBy(r => r.WaitingForRecycling).ToList();
                        else reports = reports.OrderByDescending(r => r.WaitingForRecycling).ToList();
                    }
                    break;
                default:
                    {
                        if (order == "ASC") reports = reports.OrderBy(r => r.Category).ToList();
                        else reports = reports.OrderByDescending(r => r.Category).ToList();
                    }
                    break;
            }

            return Ok(new ViewListPageResult<ReportResponse>
            {
                Data = reports,
                Total = reports.Count
            });
        }
    }
}
