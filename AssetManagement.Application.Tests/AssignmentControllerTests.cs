using AssetManagement.Application.Controllers;
using AssetManagement.Contracts.Asset.Response;
using AssetManagement.Contracts.Assignment.Response;
using AssetManagement.Contracts.AutoMapper;
using AssetManagement.Data.EF;
using AssetManagement.Domain.Models;
using AutoMapper;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AssetManagement.Application.Tests
{
    public class AssignmentControllerTests
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private List<Assignment> _assignments;

        public AssignmentControllerTests()
        {
            // Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssetTestDb").Options;

            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AssignmentProfile())).CreateMapper();

            // Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [Fact]
        public void GetAssignmentListByAssetCodeId_ReturnResults()
        {
            // Arrange 
            var assignmentController = new AssignmentController(_context, _mapper);

            // Act 
            var result = assignmentController.GetAssignmentsByAssetCodeId(1);

            var list = _context.Assignments.Where(x => x.AssetId == 1).ToList();

            var expected = _mapper.Map<List<AssignmentResponse>>(list);

            foreach (var item in expected)
            {
                item.AssignedTo = _context.Users.Find(new Guid(item.AssignedTo)).UserName;
                item.AssignedBy = _context.Users.Find(new Guid(item.AssignedBy)).UserName;
            }

            var okobjectResult = (OkObjectResult)result;
            var resultValue = (List<AssignmentResponse>)okobjectResult.Value;

            Assert.IsType<List<AssignmentResponse>>(resultValue);
            Assert.NotEmpty(resultValue);
            Assert.Equal(resultValue.Count(), expected.Count());
        }

        [Fact]
        public void GetAssignmentListByAssetCodeId_ReturnEmptyResult()
        {
            // Arrange 
            var assignmentController = new AssignmentController(_context, _mapper);

            // Act 
            var result = assignmentController.GetAssignmentsByAssetCodeId(2);

            var list = _context.Assignments.Where(x => x.AssetId == 2).ToList();

            var expected = _mapper.Map<List<AssignmentResponse>>(list);

            foreach (var item in expected)
            {
                item.AssignedTo = _context.Users.Find(new Guid(item.AssignedTo)).UserName;
                item.AssignedBy = _context.Users.Find(new Guid(item.AssignedBy)).UserName;
            }

            var okobjectResult = (OkObjectResult)result;
            var resultValue = (List<AssignmentResponse>)okobjectResult.Value;

            Assert.IsType<List<AssignmentResponse>>(resultValue);
            Assert.Empty(resultValue);
            Assert.Equal(resultValue.Count(), expected.Count());
        }

    }
}
