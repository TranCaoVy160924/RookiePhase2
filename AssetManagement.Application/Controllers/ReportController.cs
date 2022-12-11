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
            //Get all
            IQueryable<Category> categories = _dbContext.Categories.Where(c => !c.IsDeleted);
            
            //Sort categories
            switch (sort)
            {
                case "total":
                    {
                        if (order == "ASC") categories = categories.OrderBy(c => c.Assets.Count(a => !a.IsDeleted));
                        else categories = categories.OrderByDescending(c => c.Assets.Count(a => !a.IsDeleted));
                    }
                    break;
                case "available":
                    {
                        if (order == "ASC") categories = categories.OrderBy(c => c.Assets.Count(a => !a.IsDeleted && a.State == Domain.Enums.Asset.State.Available));
                        else categories = categories.OrderByDescending(c => c.Assets.Count(a => !a.IsDeleted &&  a.State == Domain.Enums.Asset.State.Available));
                    }
                    break;
                case "notAvailable":
                    {
                        if (order == "ASC") categories = categories.OrderBy(c => c.Assets.Count(a => !a.IsDeleted &&  a.State == Domain.Enums.Asset.State.NotAvailable));
                        else categories = categories.OrderByDescending(c => c.Assets.Count(a => !a.IsDeleted && a.State == Domain.Enums.Asset.State.NotAvailable));
                    }
                    break;
                case "recycled":
                    {
                        if (order == "ASC") categories = categories.OrderBy(c => c.Assets.Count(a => !a.IsDeleted && a.State == Domain.Enums.Asset.State.Recycled));
                        else categories = categories.OrderByDescending(c => c.Assets.Count(a => !a.IsDeleted && a.State == Domain.Enums.Asset.State.Recycled));
                    }
                    break;
                case "waitingForRecycling":
                    {
                        if (order == "ASC") categories = categories.OrderBy(c => c.Assets.Count(a => !a.IsDeleted && a.State == Domain.Enums.Asset.State.WaitingForRecycling));
                        else categories = categories.OrderByDescending(c => c.Assets.Count(a => !a.IsDeleted && a.State == Domain.Enums.Asset.State.WaitingForRecycling));
                    }
                    break;
                default:
                    {
                        if (order == "ASC") categories = categories.OrderBy(c => c.Name);
                        else categories = categories.OrderByDescending(c => c.Name);
                    }
                    break;
            }
            //Get sorted list (skip & take if paging)
            List<Category> sortedCategories = await categories.Include(c => c.Assets).ToListAsync();
            //Map to report
            List<ReportResponse> reports = _mapper.Map<List<ReportResponse>>(sortedCategories);
            return Ok(new ViewListPageResult<ReportResponse>
            {
                //Paging
                Data = reports.ToList(),
                Total = reports.Count
            });
        }
    }
}
