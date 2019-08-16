using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio.TwiML; 
using Twilio.AspNet.Mvc;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace CommunityManagerDashBoard.Controllers
{
    public class SmsController : TwilioController
    {
        public ActionResult SendSms()

        {
            var accountSid = "";
            var authToken = "";
            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber("+16187723175");
            var from = new PhoneNumber("+16364341260");

            var message = MessageResource.Create(
                to: to,
                from: from,
                body: "Boil Order is in place for 24 hours"
                );
            return ActionContext(message.Sid);
        }
    }
}