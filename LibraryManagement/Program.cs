using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system
{
	public class Book
	{
		public string Title { get; private set; }
		public string Author { get; private set; }
		public int id;
		public string Language { get; private set; }
		public double Price { get; private set; }
		public int TotalCopies { get; private set; }
		public int AvailableCopies { get;  set; }
		public Book(string title, string author)
		{
			this.Title = title;
			this.Author = author;
		}


		public Book(int id, string title, string author, string language, double price, int copies)
		{
			this.id = id;
			this.Title = title;
			this.Author = author;
			this.Language = language;
			this.Price = price;
			this.TotalCopies = this.AvailableCopies = copies;
		}
        public override bool Equals(object obj)
        {
			if (obj == null || !(obj is Book))
				return false;
			else
            return this.id == ((Book)obj).id;
        }

        public override string ToString()
		{
			return string.Format("Title: {0} Author: {1} Available Copies: {2}", Title, Author, AvailableCopies);
		}
	}

	public class User
	{
		public int userId;
		public string userEmail;
		public List<Book> booklist;
		public User(int userId, string userEmail)
		{
			this.userId = userId;
			this.userEmail = userEmail;
			booklist = new List<Book>();
	
		}
		public List<Book> GetBorrowedBookList()
		{
			return this.booklist;
		}
	}

	public class Library
	{
		List<Book> books = new List<Book>();
		List<User> users = new List<User>();
		public Library()
		{
			//users.Add(new User(1, "user1"));
			//books.Add(new Book(2, "Book 1", "author 1", "English", 50, 2));
			
		}
		public List<Book> GetBooks()
        {
			return this.books;
        }

		public void AddBook(Book book)
		{
			Book book1 = FindBook(book.id);
			if (book1 == null)
				books.Add(book);
			else
				throw new Exception("Book already exist");
			
		}
		public void AddUser(User user)
		{
			User user1 = FindUser(user.userId);
			if (user1 == null)
				users.Add(user);
			else
				throw new Exception("User already exist");

		}

		public Book FindBook(int id)
		{
			return books.Find(x => x.id == id);
		}

		public User FindUser(int id)
		{
			return users.Find(x => x.userId == id);
		}

		public void DisplayBooks()
		{
			foreach (Book b in books)
			{
				Console.WriteLine(b.ToString());
			}
		}

		public void RemoveBook(Book book)
		{
			Book book1 = FindBook(book.id);
			if (book1 != null)
				books.Remove(book);
			else
				throw new Exception("Book doesnt exist");
		}
		

		public void IssueBook(int id, int userId)
		{
			Book book = FindBook(id);
			User user = FindUser(userId);
			if(book == null)
            {
				throw new Exception("Book doesnt exist");
			}
			if (book.AvailableCopies > 0)
			{
				if (user != null)
				{
					user.booklist.Add(book);
					book.AvailableCopies -= 1;
				}
			}
			else
				Console.WriteLine(" Book Not available");
		}
		public void ReturnBook(int bId, int userId)
		{
			Book book = FindBook(bId);
			User user = FindUser(userId);
			if (book == null)
			{
				throw new Exception("Book doesnt exist");
			}
			if (book.AvailableCopies > 0)
			{
				if (user != null)
				{
					user.booklist.Remove(book);
					book.AvailableCopies += 1;
				}
				else
                {
					throw new Exception("User doesnt exist");
				}
			}
			else
				Console.WriteLine(" Book Not available");
		}
	}

	public class Program
	{
		public static void Main(string[] args)
		{
			int choice;
			Library lib = new Library();
			Console.WriteLine("1.Add a book\n2.Remove a book\n3.Issue a book\n4. Exit");
			choice = Convert.ToInt32(Console.ReadLine());
			while (choice != 5)
			{
				switch (choice)
				{
					case 1:
						{
							string btitle;
							string bauthor;
							int bId;

							Console.WriteLine("Enter Id:");
							bId = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter Title:");
							btitle = Console.ReadLine();
							Console.WriteLine("Enter Author:");
							bauthor = Console.ReadLine();
							//lib.addBook();
							break;
						}

					case 2:
						{
							Console.WriteLine("Remove a book");
							break;
						}

					case 3:
						{
							Console.WriteLine(" Book Id: ");
							int bid = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine(" User Id: ");
							int uid = Convert.ToInt32(Console.ReadLine());
							lib.IssueBook(bid, uid);
							break;
						}
					case 4:
						{
							lib.DisplayBooks();
							break;
						}

					default:
						Console.WriteLine("Exit");
						break;
				 }
				Console.WriteLine("Enter choice: ");
				choice = Convert.ToInt32(Console.ReadLine());
			}
		}
	}
}