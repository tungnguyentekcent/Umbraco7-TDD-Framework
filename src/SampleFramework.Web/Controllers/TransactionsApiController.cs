using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleFramework.Web.Controllers
{
    public class TransactionsApiController : BaseUmbracoApiController
    {
        public IEnumerable<string> GetTransactions()
        {
            return new List<string>
            {
                "Transaction 1",
                "Transaction 2",
                "Transaction 3",
                "Transaction 4",
                "Transaction 5"
            };
        }
    }
}