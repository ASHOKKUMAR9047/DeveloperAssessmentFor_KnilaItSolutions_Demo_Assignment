using DeveloperAssessmentFor_KnilaItSolutions.Models;

namespace DeveloperAssessmentFor_KnilaItSolutions.Injection
{
    public interface IBooksRepository
    {
        Task AddBookAsync(Book BooksView);

        Task<List<Book>> BulkInsertBookAsync(List<Book> books);
        Task<List<Book>> GetSortedByPublisherAuthorTitle();
        Task<List<Book>> GetBooksSortedByAuthorTitle();
        Task<Book> GetBookById(Guid id);
        Task<decimal> GetTotalPriceOfBooks();
        List<Book> SP_GetBooksSortedByAuthorTitle();

        List<Book> SP_GetBooksSortedByPublisherAuthorTitle();
    }
}
