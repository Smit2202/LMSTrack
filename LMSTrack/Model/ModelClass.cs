namespace LMSTrack.Model
{
    public class ModelClass
    {
        // Book model
        public class Book
        {
            public int BookId { get; set; }
            public int bId { get; set; }
            public string? Title { get; set; }
            public string? Author { get; set; }
            public bool Availability { get; set; } // Indicates whether the book is available or not
        }

        // User model
        public class User
        {
            public int UserId { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
        }
    }
}
