using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using HtmlAgilityPack;
using SharpScraper.Models;

namespace SharpScraper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CyprusOfficialLinks()
        {
            ServicePointManager.Expect100Continue = true;
            var url = "http://www.cyprus.gov.cy/portal/portal.nsf/gwp.getGroup?OpenForm&access=0&SectionId=noneu&CategoryId=Government%20Websites&SelectionId=All%20Websites&print=0&lang=en";


            List<CyprusLinksModel> cyprusLinksModel = new List<CyprusLinksModel>();
            var web = new HtmlWeb();
            var doc = web.Load(url);
            foreach (var item in doc.DocumentNode.SelectNodes("//*[@class='list2']"))
            {
                var node = item.SelectSingleNode(".//a");
                var title = node.InnerText.Trim();
                var linkUrl = node.GetAttributeValue("href", null).Trim();
                
                cyprusLinksModel.Add(new CyprusLinksModel(){
                    title = title,
                    linkUrl = linkUrl
                    });
            }
            return View(cyprusLinksModel);
        }
    }
}