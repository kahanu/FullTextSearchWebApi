using FTS.Library.Search.RnR;
using System.Collections.Generic;

namespace FTS.Library.Contracts
{
    public class GetCustomerListRequest : SearchRequest
    {
    }

    public class GetCustomerListResponse : BaseResponse
    {
        public List<CustomerDto> CustomerList { get; set; } = new List<CustomerDto>();
    }
}
