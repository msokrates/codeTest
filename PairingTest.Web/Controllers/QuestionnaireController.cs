using System.Web.Mvc;
using PairingTest.Web.Models;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace PairingTest.Web.Controllers
{
    public class QuestionnaireController : Controller
    {
        IHttpClientWrapper httpClientWrapper;
        public QuestionnaireController(): this(new HttpClientWrapper(new HttpClient())) { }

        public QuestionnaireController(IHttpClientWrapper httpClientWrapper)
        {
            this.httpClientWrapper = httpClientWrapper;
        }

        /* ASYNC ACTION METHOD... IF REQUIRED... */
        //        public async Task<ViewResult> Index()
        //        {
        //        }

        public ViewResult Index()
        {
            var questionnaire = httpClientWrapper.Get("http://localhost/QuestionServiceWebApi/api/Questions/Get");
            var model = new JavaScriptSerializer().Deserialize<QuestionnaireViewModel>(questionnaire);
            return View(model);
        }
    }
}
