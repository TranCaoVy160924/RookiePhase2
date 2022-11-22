using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Contracts.Asset.Response
{
    public class ViewListAssets_ListResponse
    {
        public List<ViewListAssets_AssetResponse> Assets { get; set; }
        public int Total { get; set; }
    }
}
