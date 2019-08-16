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
            var accountSid = "AC036b227040b660aca69fa3b328a4b403";
            var authToken = "825c478b0b61ecc651a0a9060c8e53da";
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