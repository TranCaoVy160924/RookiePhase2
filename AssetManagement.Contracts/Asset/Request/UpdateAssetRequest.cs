using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Domain.Enums.Asset;

namespace AssetManagement.Contracts.Asset.Request
{
    public class UpdateAssetRequest
    {
        public string Name { get; set; }
        public string Specification { get; set; }
        public DateTime InstalledDate { get; set; }
        public State State { get; set; }
    }
}