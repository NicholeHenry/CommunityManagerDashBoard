using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CommunityManagerDashBoard.Controllers
    {
        [Authorize(Roles="Administration, Manager")]
        public class SmsController : TwilioController
        {
            public IActionResult SendSms()

            {
                var accountSid = "AccountSid";
                var authToken = "AuthToken";

                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber("ToNumber");
                var from = new PhoneNumber("FromNumber");
                
                var message = MessageResource.Create(
                    to: to,
                    from: from,
                    body: "Boil Order in place for 24 hours."
                    );

                return Content(message.Sid);
            }
        }
    }


