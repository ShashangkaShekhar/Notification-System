using NotifSystem.Web.Hubs;
using NotifSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NotifSystem.Web.Controllers.api
{
    public class ValuesController : ApiController
    {
        private NotifEntities context = new NotifEntities();

        [HttpPost]
        public HttpResponseMessage SendNotification(NotifModels obj)
        {
            NotificationHub objNotifHub = new NotificationHub();
            Notification objNotif = new Notification();
            objNotif.SentTo = obj.UserID;

            context.Configuration.ProxyCreationEnabled = false;
            context.Notifications.Add(objNotif);
            context.SaveChanges();

            objNotifHub.SendNotification(objNotif.SentTo);

            var query = (from t in context.Notifications
                         select t).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, new { query });
        }
    }
}