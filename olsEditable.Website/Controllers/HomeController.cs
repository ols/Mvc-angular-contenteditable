using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using olsEditable.Website.Models;

namespace olsEditable.Website.Controllers
{
    public class HomeController : Controller
    {
        private IList<TextItem> TextItems;

        public HomeController()
        {
            TextItems = new List<TextItem>
            {
                new TextItem { TextId = 0, Text = "Lorem Ipsum är en utfyllnadstext från tryck- och förlagsindustrin. Lorem ipsum har varit standard ända sedan 1500-talet, när en okänd boksättare tog att antal bokstäver och blandade dem för att göra ett provexemplar av en bok. Lorem ipsum har inte bara överlevt fem århundraden, utan även övergången till elektronisk typografi utan större förändringar. Det blev allmänt känt på 1960-talet i samband med lanseringen av Letraset-ark med avsnitt av Lorem Ipsum, och senare med mjukvaror som Aldus PageMaker." },
                new TextItem { TextId = 1, Text = "Det är ett välkänt faktum att läsare distraheras av läsbar text på en sida när man skall studera layouten. Poängen med Lorem Ipsum är att det ger ett normalt ordflöde, till skillnad från Text här, Text här, och ger intryck av att vara läsbar text. Många publiseringprogram och webbutvecklare använder Lorem Ipsum som test-text, och en sökning efter Lorem Ipsum avslöjar många webbsidor under uteckling. Olika versioner har dykt upp under åren, ibland av olyckshändelse, ibland med flit (mer eller mindre humoristiska)." },
                new TextItem { TextId = 2, Text = "I motsättning till vad många tror, är inte Lorem Ipsum slumpvisa ord. Det har sina rötter i ett stycke klassiskt litteratur på latin från 45 år före år 0, och är alltså över 2000 år gammalt. Richard McClintock, en professor i latin på Hampden-Sydney College i Virginia, översatte ett av de mer ovanliga orden, consectetur, från ett stycke Lorem Ipsum och fann dess ursprung genom att studera användningen av dessa ord i klassisk litteratur. Lorem Ipsum kommer från styckena 1.10.32 och 1.10.33 av de Finibus Bonorum et Malorum (Ytterligheterna av ont och gott) av Cicero," },
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTexts()
        {
            return Json(TextItems, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(int textId, string text)
        {
            var item = TextItems.FirstOrDefault(x => x.TextId == textId);

            if (item == null)
                return Json(new { Success = false, Message = string.Format("Could'nt find any text with id: {0}", textId) });

            item.Text = text;

            return Json(new { Success = true, Message = "Ok" });
        }
    }
}