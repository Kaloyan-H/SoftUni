namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        //------------------------------------
        //CONSTRUCTOR
        //------------------------------------
        [Test]
        public void Test_Constructor_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
            {
                UniversityLibrary library = new UniversityLibrary();
            });
        }
        [Test]
        public void Test_Constructor_Instantiates_TextBooksCollection()
        {
            UniversityLibrary library = new UniversityLibrary();

            FieldInfo textBooksCollectionField = library
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault();

            Assert.AreNotEqual(null, textBooksCollectionField.GetValue(library));
        }

        //-------------------------------------
        //PROPERTIES
        //-------------------------------------
        [Test]
        public void Test_Catalogue_Getter_ReturnsValueCorrectly()
        {
            UniversityLibrary library = new UniversityLibrary();

            FieldInfo textBooksCollectionField = library
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault();

            Assert.AreEqual(textBooksCollectionField.GetValue(library), library.Catalogue);
        }

        //-------------------------------------
        //METHODS
        //-------------------------------------
        [Test]
        public void Test_AddTextBookToLibrary_DoesNotThrown_WithValidParameters()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("TestTitle", "TestAuthor", "TestCategory");

            Assert.DoesNotThrow(() =>
            {
                library.AddTextBookToLibrary(textBook);
            });
        }
        [Test]
        public void Test_AddTextBookToLibrary_WorksCorrectly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("TestTitle", "TestAuthor", "TestCategory");

            string actualOutput = library.AddTextBookToLibrary(textBook);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber}");
            sb.AppendLine($"Category: {textBook.Category}");
            sb.AppendLine($"Author: {textBook.Author}");

            string expectedOutput = sb.ToString().Trim();

            Assert.AreEqual(1, textBook.InventoryNumber);
            Assert.AreEqual(1, library.Catalogue.Count);
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void Test_LoanTextBook_DoesNotThrown_WithValidParameters()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("TestTitle", "TestAuthor", "TestCategory");

            library.AddTextBookToLibrary(textBook);

            Assert.DoesNotThrow(() =>
            {
                library.LoanTextBook(1, "TestStudentName");
            });
        }
        [Test]
        public void Test_LoanTextBook_WorksCorrectly_WhenBookHasNotBeenReturnedYet()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("TestTitle", "TestAuthor", "TestCategory");

            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, "TestStudentName");

            Assert.AreEqual
                ($"TestStudentName still hasn't returned {textBook.Title}!",
                library.LoanTextBook(1, "TestStudentName"));
        }
        [Test]
        public void Test_LoanTextBook_WorksCorrectly_WhenBookIsAvailable()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("TestTitle", "TestAuthor", "TestCategory");

            library.AddTextBookToLibrary(textBook);

            Assert.AreEqual
                ($"{textBook.Title} loaned to TestStudentName.",
                library.LoanTextBook(1, "TestStudentName"));
        }

        [Test]
        public void Test_ReturnTextBook_DoesNotThrow_WithValidParameters()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("TestTitle", "TestAuthor", "TestCategory");

            library.AddTextBookToLibrary(textBook);

            Assert.DoesNotThrow(() =>
            {
                library.ReturnTextBook(1);
            });
        }
        [Test]
        public void Test_ReturnTextBook_WorksCorrectly()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook textBook = new TextBook("TestTitle", "TestAuthor", "TestCategory");

            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, "TestStudentName");
            string actualOutput = library.ReturnTextBook(1);

            Assert.AreEqual(string.Empty, textBook.Holder);
            Assert.AreEqual($"{textBook.Title} is returned to the library.", actualOutput);
        }
    }
}