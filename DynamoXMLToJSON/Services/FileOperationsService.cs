using DynamoXMLToJSON.Constants;
using DynamoXMLToJSON.Services.Interfaces;

namespace DynamoXMLToJSON.Services
{
    public class FileOperationsService : IFileOperationsService
    {
        public async Task SaveResultToFile(string resultToSave, string fileName)
        {
            string path = XMLToJSONManagerConstants.FileOperationsResources +
                                                                   fileName +
                          XMLToJSONManagerConstants.FileOperationsJSONExtension;

            await File.WriteAllTextAsync(path, resultToSave);
        }
    }
}
