using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library_management_system;
using System.Linq;
using System.Collections.Generic;


namespace LibraryTest1
{
    [TestClass]
    public class LibraryTest
    {
        Library lib;
        [TestInitialize]
        public void initialize()
        {
            lib = new Library();
        }
        [TestMethod]
        public void AddbookShouldReturnConfirmation()
        {
            //arrange
            lib = new Library();
            //act
            lib.AddBook(new Book(1, "Book 1", "author 1", "English", 50, 2));
            //assert
            var bookList = lib.GetBooks();
            var addedBook = bookList.Where(x => x.Title == "Book 1").FirstOrDefault();
            Assert.IsNotNull(addedBook);
            Assert.AreEqual("English", addedBook.Language);

        }
        [TestMethod]
        public void BorrowingBookShouldReflectInUsersBooklist()
        {
            //arrange
            Book b1;
            User user;
            GetLibraryWithSingleAndOneBook(out b1, out user);
            //act
            lib.IssueBook(b1.id, user.userId);
            var bookList = user.GetBorrowedBookList();
            var addedBook = bookList.Where(x => x.Title == "Book 1").FirstOrDefault();
            //assert
            Assert.IsNotNull(addedBook);
            Assert.AreEqual("English", addedBook.Language);

        }

        private void GetLibraryWithSingleAndOneBook(out Book b1, out User user)
        {
            lib = new Library();
            b1 = new Book(1, "Book 1", "author 1", "English", 50, 2);
            lib.AddBook(b1);
            user = new User(2, "user@gmail.com");
            lib.AddUser(user);
        }
        private void GetLibraryWithTwoUsersAndOneBookWithTwoCopies(out Book b1, out User user1,out User user2)
        {
            lib = new Library();
            b1 = new Book(1, "Book 1", "author 1", "English", 50, 2);
            lib.AddBook(b1);
            user1 = new User(1, "user1@gmail.com");
            user2 = new User(2, "user2@gmail.com");
            lib.AddUser(user1);
            lib.AddUser(user2);
        }

        [TestMethod]
        public void ReturnedBookShouldNotBeInUsersBookList()
        {
            //arrange
            Book b1;
            User user;
            GetLibraryWithSingleAndOneBook(out b1, out user);
            
            lib.IssueBook(b1.id, user.userId);
            //act
            lib.ReturnBook(b1.id, user.userId);
            
            var bookList = user.GetBorrowedBookList();
            var returnBook = bookList.Where(x => x.Title == "Book 1").FirstOrDefault();
            //assert
            Assert.IsNull(returnBook);
            

            
        }
        [TestMethod]
        public void CheckIfBookIsAvailableShouldReturnSubscription()
        {
            

        }
        [TestMethod]
        public void UserShouldReturnBorrowedBookList()
        {
            //arrange
            Book b1;
            User user;
            GetLibraryWithSingleAndOneBook(out b1, out user);

            lib.IssueBook(b1.id, user.userId);
            //act
 
            var bookList = user.GetBorrowedBookList();
            //assert
            CollectionAssert.AreEqual(bookList,new List<Book>(){ b1 });

        }
        [TestMethod]
        public void GetPriceForAddedBookShouldReturnActualPrice()
        {
            //arrange
            lib = new Library();
            const int book1Price = 150;
            const int book2Price = 250;
            //act
            lib.AddBook(new Book(1, "Book 1", "author 1", "English", book1Price, 2));
            lib.AddBook(new Book(2, "Book 2", "author 2", "Spanish", book2Price, 1));
            var bookList = lib.GetBooks();
            var addedBook1 = bookList.Where(x => x.id == 1).FirstOrDefault();
            var addedBook2 = bookList.Where(x => x.id == 2).FirstOrDefault();

            //assert

            Assert.IsNotNull(addedBook1);
            Assert.IsNotNull(addedBook2);
            Assert.AreEqual(book1Price, addedBook1.Price);
            Assert.AreEqual(book2Price, addedBook2.Price);

        }



    }
}
