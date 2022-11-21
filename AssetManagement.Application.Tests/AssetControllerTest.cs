using AssetManagement.Data.EF;
using AssetManagement.Domain.Enums.Asset;
using AssetManagement.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Application.Tests
{
    public class AssetControllerTest
    {
        private readonly DbContextOptions _options;
        private readonly AssetManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private List<Asset> _assets;

        public AssetControllerTest()
        {
            //Create InMemory dbcontext options
            _options = new DbContextOptionsBuilder<AssetManagementDbContext>()
                .UseInMemoryDatabase(databaseName: "AssetTestDb").Options;
            //Create InMemory dbcontext with options
            _context = new AssetManagementDbContext(_options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //Create fake data
            SeedData();
        }

        private void SeedData()
        {
            for (int i = 1; i <= 10; i++)
            {
                _context.Assets.Add(new Asset
                {
                    Id = i,
                    Name = "Asset " + i,
                    AssetCode = i.ToString(),
                    Specification = i.ToString(),
                    InstalledDate = DateTime.Now,
                    State = i % 2 == 0 ? State.State1 : State.State2,
                    IsActive = i % 2 == 0 ? true : false,
                });
            }

            _context.SaveChanges();
        }
    }
}
