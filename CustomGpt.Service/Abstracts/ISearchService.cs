namespace CustomGpt.Service.Abstracts
{
    public interface ISearchService
    {
        Task SearchAsync(string searchQuery);
    }
}
