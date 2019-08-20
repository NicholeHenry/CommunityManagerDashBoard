using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CommunityManagerDashBoard.Controllers
    {
        public class SmsController : TwilioController
        {
            public IActionResult SendSms()

            {
                var accountSid = "";
                var authToken = "";
                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("+");
                var from = new PhoneNumber("+");

                var message = MessageResource.Create(
                    to: to,
                    from: from,
                    body: "Boil Order is in place for 24 hours"
                    );
                return Content(message.Sid);
            }
        }
    }


