namespace DynamoXMLToJSON.Services.Interfaces
{
    public interface IFileOperationsService
    {
        Task SaveResultToFile(string resultToSave, string fileName);
    }
}
