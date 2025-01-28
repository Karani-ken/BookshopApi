using AutoMapper;
using BookshopApi.Models;
using BookshopApi.Requests;
using BookshopApi.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookInterface _bookService;

        public BookController(IMapper mapper, IBookInterface bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }
        //add book

        [HttpPost]
        public async Task<ActionResult<string>> AddBook(AddBook newBook)
        {
            var BookToAdd = _mapper.Map<Book>(newBook);
            var res = await _bookService.AddBook(BookToAdd);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var Books = await _bookService.GetAllBooks();
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<int>> GetBookbyId(int id)
        {
            var selectedBook = await _bookService.GetBookById(id);
            if (selectedBook == null)
            {
                return NotFound("Book not found");
            }

            return Ok(selectedBook);
        }
    }
}
