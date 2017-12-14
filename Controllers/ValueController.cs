using Notifications.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Notifications.Controllers
{

    public class ValuesController : ApiController
    {

        NotificationRepo objRepo = new NotificationRepo();


        // GET api/values
        public IEnumerable<Notifications.Models.Notifications> Get()
        {
            return objRepo.GetData();
        }
    }
}
