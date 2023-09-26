using DynamoXMLToJSON.Controllers;
using DynamoXMLToJSON.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamoXMLToJSONTests
{
    [TestFixture]
    public class FileUploadController_Should
    {
        private readonly Mock<IFileOperationsService> fileOperationsService;
        private readonly FileUploadController fileUploadController;

        public FileUploadController_Should()
        {
            this.fileOperationsService = new Mock<IFileOperationsService>();
            this.fileUploadController = new FileUploadController(this.fileOperationsService.Object);
        }

        [Test]
        public async Task Return_Ok_StatusCode_If_It_Is_Completed_Successfully()
        {
            // Arrange
            XElement xmlElement = new XElement("Root", new XElement("Child"), new XElement("Root"));
            string fileName = "testingFile";

            // Act
            var result = await this.fileUploadController.XMLToJSON(xmlElement, fileName);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task Return_The_Correct_Message_If_It_Is_Completed_Successfully()
        {
            // Arrange
            XElement xmlElement = new XElement("Root", new XElement("Child"), new XElement("Root"));
            string fileName = "testingFile";

            // Act
            var result = await this.fileUploadController.XMLToJSON(xmlElement, fileName);

            // Assert
            Assert.AreEqual($"The operation of saving {fileName} completed successfully.", ((OkObjectResult)result).Value);
        }
    }
}
