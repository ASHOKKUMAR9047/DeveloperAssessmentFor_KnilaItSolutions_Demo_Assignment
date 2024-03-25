using DeveloperAssessmentFor_KnilaItSolutions.Data;
using DeveloperAssessmentFor_KnilaItSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DeveloperAssessmentFor_KnilaItSolutions.Injection
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DbConnector _dbConnector;
        public BooksRepository(DbConnector dbConnector)
        {

            _dbConnector = dbConnector;

        }
       
        public async Task AddBookAsync(Book BooksView)
        {
            await _dbConnector.Books.AddAsync(BooksView);
            await _dbConnector.SaveChangesAsync();
        }

        public async Task<List<Book>> GetSortedByPublisherAuthorTitle()
        {
            return await _dbConnector.Books.OrderBy(b => b.Publisher)
                .ThenBy(b => b.AuthorLastName).ThenBy(b => b.AuthorFirstName)
                .ThenBy(b => b.Title).ToListAsync();
        }

        public async Task<List<Book>> GetBooksSortedByAuthorTitle()
        {
            return await _dbConnector.Books.OrderBy(b => b.AuthorLastName)
                .ThenBy(b => b.AuthorFirstName).ThenBy(b => b.Title).ToListAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _dbConnector.Books.FindAsync(id);
        }

        public async Task<decimal> GetTotalPriceOfBooks()
        {
            return await _dbConnector.Books.SumAsync(book => book.Price);
        }

        public  List<Book> SP_GetBooksSortedByAuthorTitle()
        {
            return _dbConnector.Books.FromSqlRaw("EXEC SP_GetBooksSortedByAuthorTitle").ToList();
        }
        public List<Book> SP_GetBooksSortedByPublisherAuthorTitle()
        {
            return _dbConnector.Books.FromSqlRaw("EXEC SP_GetBooksSortedByPublisherAuthorTitle").ToList();
        }

        public async Task<List<Book>> BulkInsertBookAsync(List<Book> books)
        {
            if(books !=null)
            {
                foreach (var book in books)
                {
                    var Books = new Bulkdata
                    {
                        Publisher = book.Publisher,
                        Title = book.Title,
                        AuthorFirstName = book.AuthorFirstName,
                        AuthorLastName = book.AuthorLastName,
                        Price = book.Price
                    };
                    _dbConnector.Bulkdatas.AddRange(Books); // Assuming 'Bulkdata' is the DbSet<Book> property representing your 'Bulkdata' table
                    await _dbConnector.SaveChangesAsync();
                }
                
                
            }
            

            return books;
        }

    }
}
