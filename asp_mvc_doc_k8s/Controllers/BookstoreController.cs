



namespace asp_mvc_doc_k8s.Controllers;

using asp_mvc_doc_k8s.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class BookstoreController : ControllerBase
{
    private static List<Book> _books = new List<Book> {
            new Book{Id=1, Title="The Catcher in the Rye",Author="J.D. Salinger",Price=9.99m},
            new Book{Id=2,Title="To kill a Mockingbird",Author="Harper Lee",Price=11.99m},
            new Book{Id=3,Title="1984",Author="George Orwell",Price=7.99m}
        };

    [HttpGet]
    public IActionResult GetAllBooks() { return Ok(_books); }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook([FromBody] Book book)
    {
        book.Id = _books.Count + 1;
        _books.Add(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] Book book)
    {
        var existingBook = _books.FirstOrDefault(b => b.Id == id);
        if (existingBook == null)
        {
            return NotFound();
        }
        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.Price = book.Price;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            return NotFound();
        }
        _books.Remove(book);
        return NoContent();
    }
}
