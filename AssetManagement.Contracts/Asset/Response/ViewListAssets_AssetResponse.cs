﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Contracts.Asset.Response
{
    public class ViewListAssets_AssetResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AssetCode { get; set; }
        public string CategoryName { get; set; }
        public string State { get; set; }
    }
}