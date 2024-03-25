using DeveloperAssessmentFor_KnilaItSolutions.Data;
using DeveloperAssessmentFor_KnilaItSolutions.Injection;
using DeveloperAssessmentFor_KnilaItSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DeveloperAssessmentFor_KnilaItSolutions.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBooksRepository _BookRepository;

        public BooksController(IBooksRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }
        public IActionResult Adddetails()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Adddetails")]
        public async Task<IActionResult> ValueGet(Book BooksView)
        {
            var Books = new Book
            {
                Publisher = BooksView.Publisher,
                Title = BooksView.Title,
                AuthorFirstName = BooksView.AuthorFirstName,
                AuthorLastName = BooksView.AuthorLastName,
                Price = BooksView.Price
            };

            await _BookRepository.AddBookAsync(Books);
            TempData["SuccessMessage"] = "Value inserted Successfully";
            return RedirectToAction("Adddetails", "Books");
            //return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [ActionName("SortedList")]
        public async Task<IActionResult> GetSortedByPublisherAuthorTitle()
        {
            var sortedBooks = await _BookRepository.GetSortedByPublisherAuthorTitle();
            return View(sortedBooks);
        }

        [HttpGet]
        [ActionName("sortedbyauthortitle")]
        public async Task<IActionResult> GetBooksSortedByAuthorTitle()
        {
            var sortedBooks = await _BookRepository.GetBooksSortedByAuthorTitle();
            return View(sortedBooks);
        }

        //[HttpGet]
        //public async Task<IActionResult> View(Guid id)
        //{
        //    var book = await _BookRepository.GetBookById(id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View("SortedList", book.Price);
        //}

        [HttpGet]
        [ActionName("PriceView")]
        public async Task<IActionResult> GetTotalPriceOfBooks()
        {
            decimal totalPrice = await _BookRepository.GetTotalPriceOfBooks();
            
            return View("PriceView", totalPrice);
        }
        [HttpPost]
        public IActionResult SP_AuthorTitle()
        {
            var books = _BookRepository.SP_GetBooksSortedByAuthorTitle();
            // Process and return the books
            return View("SpAuthorTitle", books);
        }
        [HttpPost]
        public IActionResult SP_PublisherAuthor()
        {
            var books = _BookRepository.SP_GetBooksSortedByPublisherAuthorTitle();
            // Process and return the books
            return View("SPPublisherAuthor", books);
        }
        [HttpPost]
        public async Task<IActionResult> InsertData(List<Book> books)
        {
            
            var insertedBooks = await _BookRepository.BulkInsertBookAsync(books);

            return View("~/Views/Home/Index.cshtml");
            //return View("Index","Home");
        }
        public IActionResult Index()
        {
           
            return View();
        }
        
    }
}
