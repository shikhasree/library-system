using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_management_system
{
	public class Book
	{
		public string title;
		public string author;
		public int id;
		public string language;
		public int copies;
		public bool isAvailable = true;
		public Book(string title, string author)
		{
			this.title = title;
			this.author = author;
		}

		public Book()
		{
		}

		public Book(int id, string title, string author)
		{
			this.id = id;
			this.title = title;
			this.author = author;
		}

		public override string ToString()
		{
			return string.Format("Title: {0} Author: {1} Is available: {2}", title, author, isAvailable);
		}
	}

	class User
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
	}

	class Library
	{
		List<Book> books = new List<Book>();
		List<User> users = new List<User>();
		public Library()
		{
			users.Add(new User(1, "user1"));
			books.Add(new Book(2, "Book1", "auth"));
			
		}

		public void addBook()
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
				books.Add(new Book(bId, btitle, bauthor));
			
		}

		public Book findBook(int id)
		{
			return books.Find(x => x.id == id);
		}

		public User findUser(int id)
		{
			return users.Find(x => x.userId == id);
		}

		public void displayBooks()
		{
			foreach (Book b in books)
			{
				Console.WriteLine(b.ToString());
			}
		}

		public void removeBook()
		{
			
		}

		public void IssueBook(int id, int userId)
		{
			Book book = findBook(id);
			User user = findUser(userId);
			if (book.isAvailable)
			{
				if (user != null)
				{
					user.booklist.Add(book);
					book.isAvailable = false;
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
							lib.addBook();
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
							lib.displayBooks();
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