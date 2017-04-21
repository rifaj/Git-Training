using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Akka.Sample.API.Controllers
{
    public class ValuesController : ApiController
    {
        public async Task<SomeResult> Post(SomeRequest someRequest)
        {
            //send a message based on your incoming arguments to one of the actors you created earlier
            //and await the result by sending the message to `Ask`
            var result = await MyActor.Ask<SomeResult>(new SomeMessage(someRequest.SomeArg1, someRequest.SomeArg2));
            return result;
        }
    }
}
