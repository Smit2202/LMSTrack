using Microsoft.AspNetCore.Mvc;
using static LMSTrack.Model.ModelClass; 

namespace LMSTrack.Services.LMSServices
{
    public interface ILMSServices
    {
        Task<List<Book>> GetBooks();
        Task<Book?> GetBook(int id);
        Task<List<Book>> PostBook(Book book);
        Task<List<Book>> PutBook(int id, Book book);
        Task<List<Book>> DeleteBook(int id);
    }
}
