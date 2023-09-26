using DynamoXMLToJSON.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;

namespace DynamoXMLToJSON.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IFileOperationsService fileOperationService;

        public FileUploadController(IFileOperationsService fileOperationService)
        {
            this.fileOperationService = fileOperationService;
        }

        [HttpPost]
        [Route("api/XMLToJSON")]
        public async Task<ActionResult> XMLToJSON([FromBody] XElement xml, [FromHeader] string fileName)
        {
            try
            {
                // Convert to XmlNode
                XmlReader xmlReader = xml.CreateReader();
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlReader);

                string jsonText = JsonConvert.SerializeXmlNode(doc);

                await this.fileOperationService.SaveResultToFile(jsonText, fileName);

                return Ok($"The operation of saving {fileName} completed successfully.");
            }
            catch (Exception ex)
            {
                string message = $"The end point returned exception with message: {ex.Message}";
                return BadRequest(message);
            }
        }
    }
}