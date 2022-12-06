using AssetManagement.Domain.Enums.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Contracts.ReturnRequest.Response
{
    public class ViewListReturnRequestResponse
    {
        public int Id { get; set; }

        public int? NoNumber { get; set; }

        public string AssetCode { get; set; }

        public string AssetName { get; set; }

        public string RequestBy { get; set; }

        public DateTime AssignedDate { get; set; }
        
        public string AcceptedBy { get; set; }

        public DateTime ReturnedDate { get; set; }

        public State State { get; set; }
    }
}
