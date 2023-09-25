using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamoXMLToJSON.Controllers
{
    public class FileUploadController : Controller
    {
        // POST: FileUploadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XMLToJSON(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
