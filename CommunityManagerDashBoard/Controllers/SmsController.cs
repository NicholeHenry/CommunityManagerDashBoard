using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace CommunityManagerDashBoard.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult Index(SmsRequest incomingMessage)
        {
            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("The Copy cat says:" + incomingMessage.Body);
            return TwiML(messagingResponse);
        }
    }
}