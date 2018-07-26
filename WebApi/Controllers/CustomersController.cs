using ExpressionBuilder.Generics;
using FTS.Ef;
using FTS.Library.Contracts;
using FTS.Library.Search;
using System;
using System.Linq;
using System.Web.Http;

namespace WebApi.Controllers
{
    /// <summary>
    /// This project is used with the WideWorldImporters database that is freely downloadable.
    /// A full text catalog was created on the Sales.Customers table and only on some of the text fields.
    /// </summary>
    public class CustomersController : ApiController
    {
        [HttpPost]
        public GetCustomerListResponse Search([FromBody]GetCustomerListRequest request)
        {
            const string message = "Could not find customer.";
            try
            {
                var response = new GetCustomerListResponse();

                using (var db = new EntityDb()) {
                    var customerList = db.Customers.AsQueryable();

                    // This is the two lines needed from the Expression Builder project
                    // to build the Lambda query.
                    var search = new SearchFilter<Customer>();
                    Filter<Customer> filter = search.Filter(request.SearchCriteria);

                    var results = customerList.Where(filter)
                                .Select(c => new CustomerDto
                            {
                                CustomerId = c.CustomerID,
                                CustomerName = c.CustomerName,
                                PhoneNumber = c.PhoneNumber,
                                DeliveryAddressLine1 = c.DeliveryAddressLine1,
                                DeliveryAddressLine2 = c.DeliveryAddressLine2,
                                DeliveryPostalCode = c.DeliveryPostalCode,
                                PostalAddressLine1 = c.PostalAddressLine1,
                                PostalAddressLine2 = c.PostalAddressLine2
                            }).ToList();

                    response.CustomerList = results;
                }

                response.Success = true;
                return response;
            }
            catch (Exception)
            {
                return new GetCustomerListResponse { Success = false, Message = message };
            }
        }
    }
}
