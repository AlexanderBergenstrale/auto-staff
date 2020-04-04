using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;

using RestSharp;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Sms.Controllers
{
    [ApiController]
    [Route("elks/hmw/sms")]
    public class SmsController : ControllerBase
    {

        private readonly IConfiguration _config;
        private readonly ILogger<SmsController> _logger;

        public SmsController(IConfiguration config, ILogger<SmsController> logger)
        {
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {


            var client = new RestClient("https://api.46elks.com/a1/SMS");
            var request = new RestRequest(Method.POST);

            client.Authenticator = new RestSharp.Authenticators.
                HttpBasicAuthenticator(_config["Credentials:Elk:Username"], _config["Credentials:Elk:Password"]);

            request.AddParameter(
                "to", "+46707863985",
                ParameterType.GetOrPost);

            request.AddParameter(
                "from", "+46766862979",
                 ParameterType.GetOrPost);

            request.AddParameter(
                "message",
                "Hi! This is a message from me! Have åäö a nice day!",
                ParameterType.GetOrPost);

            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        [HttpPost]
        [Route("send")]
        public ActionResult<string> Post(SMSSend package)
        {

            var client = new RestClient("https://api.46elks.com/a1/SMS");
            var request = new RestRequest(Method.POST);

            client.Authenticator = new RestSharp.Authenticators.
                    HttpBasicAuthenticator(_config["Credentials:Elk:Username"],
                    _config["Credentials:Elk:Password"]);

            request.AddParameter(
                "to", package.to,
                ParameterType.GetOrPost);

            request.AddParameter(
                "from", package.from,
                 ParameterType.GetOrPost);

            request.AddParameter(
                "message",
                package.message,
                ParameterType.GetOrPost);

            IRestResponse response = client.Execute(request);

            return response.Content;
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Route("answer")]
        public String Post([FromForm]SMSPayload payload)
        {

            if (payload != null)
            {
                return payload.message;
                //return JsonSerializer.Serialize(payload).ToString();
            }
            else
            {
                return "Empty";
            }

        }

    }



}
