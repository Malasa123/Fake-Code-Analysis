using Fake_Code_Analysis_Implementation_5_03.Filters;
using Fake_Code_Analysis_Implementation_5_03.Models;
using Fake_Code_Analysis_Implementation_5_03.Utils.DAL;
using Fake_Code_Analysis_Implementation_5_03.Utils.ScanServices;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fake_Code_Analysis_Implementation_5_03.Controllers
{
    public class ScansController : ApiController
    {
        private Scan _scanService;
        private Db_Content _Db_Content;

        public ScansController()
        {
            _scanService = new Scan();
            _Db_Content = new Db_Content();
        }
        [ScaningAuthorization]
        public HttpResponseMessage GetScans()
        {

            var AllScans =_Db_Content.GetAllScans();

            if (AllScans == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "problem with the server");
            else
                return Request.CreateResponse(HttpStatusCode.OK, AllScans);
        }

        [HttpPost]
        [ScaningAuthorization]
        public HttpResponseMessage PostScan(CodeFile CodeToScan)
        {
            if (_scanService.IsFileTypeFits(CodeToScan))
            {
                bool IsAdded = _Db_Content.InsertScan(CodeToScan);

                if (IsAdded)
                    return Request.CreateResponse(HttpStatusCode.OK, "Succesfully Checked&Saved");
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Error in Saving Data");

            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "The file dont fit  to our stasndarts");
        }




    }
}
