using AssetManagement.Contracts.Category.Response;
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
        public async Task<List<ReportResponse>> GetAsync([FromQuery] string? sort = "category",
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
            return reports.OrderByDescending(r => r.Assigned).ToList();
        }
    }
}
