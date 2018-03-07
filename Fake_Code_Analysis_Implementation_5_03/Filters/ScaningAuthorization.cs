using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Fake_Code_Analysis_Implementation_5_03.Utils.DAL;
using System.Net;
using System.Net.Http;

namespace Fake_Code_Analysis_Implementation_5_03.Filters
{
    public class ScaningAuthorization : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HandleAthorizaion(actionContext);
        }
        private void HandleAthorizaion(HttpActionContext actionContext)
        {
            var Db_Content = new Db_Content();
            var UserId = actionContext.Request.Headers.GetValues("UID").FirstOrDefault();
            int parsedId;
            if (int.TryParse(UserId, out parsedId))
            {
                var currentUser = Db_Content.GetUser(parsedId);
                if (currentUser  != null)
                {
                    if (!currentUser.IsAllowed)
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized - This Is User dosent have the needed premission");
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Unauthorized - This Is User does not exist in the system");
                }
            }
            else
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "UnAthorize - Missing Token");
            }
        }
    }
}