namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class Tests
    {
        private string testBookName = "TestBookName";
        private string testAuthor = "TestAuthor";

        [SetUp]
        public void SetUp()
        {

        }

        //==========================================================
        //                      CONSTRUCTOR
        //==========================================================

        [Test]
        public void Test_Constructor_DoesNotThrow_WithValidParameters()
        {
            Assert.DoesNotThrow(() =>
            {
                Book book = new Book(testBookName, testAuthor);
            }, "Book contructor throws with valid parameters.");
        }
        [Test]
        public void Test_Constructor_Throws_WithNullBookName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, testAuthor);
            }, "Book contructor doesn't throw when BookName is null.");
        }
        [Test]
        public void Test_Constructor_Throws_WithEmptyBookName()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("", testAuthor);
            }, "Book contructor doesn't throw when BookName is empty.");
        }
        [Test]
        public void Test_Constructor_Throws_WithNullAuthor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(testBookName, null);
            }, "Book contructor doesn't throw when Author is null.");
        }
        [Test]
        public void Test_Constructor_Throws_WithEmptyAuthor()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(testBookName, "");
            }, "Book contructor doesn't throw when BookName is empty.");
        }
        [Test]
        public void Test_Constructor_InstantiatesObject()
        {
            Book book = new Book(testBookName, testAuthor);

            Assert.IsNotNull(book, "Book contructor doesn't instantiate the object.");
        }

        //==========================================================
        //                       PROPERTIES
        //==========================================================

        //------------
        //| BookName |
        //------------
        [Test]
        public void Test_BookName_Setter_DoesNotThrow_WithValidValue()
        {
            Assert.DoesNotThrow(() =>
            {
                Book book = new Book(testBookName, testAuthor);
            }, "BookName setter throws when value is valid.");
        }
        [Test]
        public void Test_BookName_Setter_Throws_WithNullValue()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(null, testAuthor);
            }, "BookName setter doesn't throw when value is null.");
        }
        [Test]
        public void Test_BookName_Setter_Throws_WithEmptyValue()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("", testAuthor);
            }, "BookName setter doesn't throw when value is empty.");
        }
        [Test]
        public void Test_BookName_Getter_ReturnsValueCorrectly()
        {
            Book book = new Book(testBookName, testAuthor);

            Assert.AreEqual(testBookName, book.BookName
                , "BookName getter doesn't return value correctly.");
        }

        //----------
        //| Author |
        //----------
        [Test]
        public void Test_Author_Setter_DoesNotThrow_WithValidValue()
        {
            Assert.DoesNotThrow(() =>
            {
                Book book = new Book(testBookName, testAuthor);
            }, "Author setter throws when value is valid.");
        }
        [Test]
        public void Test_Author_Setter_Throws_WithNullValue()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(testBookName, null);
            }, "Author setter doesn't throw when value is null.");
        }
        [Test]
        public void Test_Author_Setter_Throws_WithEmptyValue()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(testBookName, "");
            }, "Author setter doesn't throw when value is empty.");
        }
        [Test]
        public void Test_Author_Getter_ReturnsValueCorrectly()
        {
            Book book = new Book(testBookName, testAuthor);

            Assert.AreEqual(testAuthor, book.Author
                , "Author getter doesn't return value correctly.");
        }

        //-----------------
        //| FootnoteCount |
        //-----------------
        [Test]
        public void Test_FootnoteCount_Getter_ReturnsValueCorrectly()
        {
            Book book = new Book(testBookName, testAuthor);
            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            Dictionary<int, string> footnoteDictionary = new Dictionary<int, string>
            {
                { 1, "Test" },
                { 2, "Test" },
                { 3, "Test" },
            };

            fieldInfo.SetValue(book, footnoteDictionary);

            Assert.AreEqual(footnoteDictionary.Count, book.FootnoteCount);
        }

        //==========================================================
        //                         METHODS
        //==========================================================

        //---------------
        //| AddFootnote |
        //---------------
        [Test]
        public void Test_AddFootnote_DoesNotThrow_WithValidParameters()
        {
            Book book = new Book(testBookName, testAuthor);
            Assert.DoesNotThrow(() =>
            {
                book.AddFootnote(1, "Test");
            }, "AddFootnote method throws with valid parameters.");
        }
        [Test]
        public void Test_AddFootnote_Throws_WhenFootnoteAlreadyExists()
        {
            Book book = new Book(testBookName, testAuthor);
            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            fieldInfo.SetValue(book, new Dictionary<int, string>
            {
                { 1, "Test" },
                { 2, "Test" },
                { 3, "Test" },
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AddFootnote(1, "Test");
            }, "AddFootnote method doesn't throw when footnote already exists.");
        }
        [Test]
        public void Test_AddFootnote_WorksCorrectly()
        {
            Book book = new Book(testBookName, testAuthor);
            book.AddFootnote(1, "Test");

            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            Dictionary<int, string> footnoteDictionary = (Dictionary<int, string>)fieldInfo.GetValue(book);

            Assert.AreEqual(footnoteDictionary.First(), new KeyValuePair<int, string>(1, "Test"),
                "AddFootnote method doesn't work correctly.");
        }

        //----------------
        //| FindFootnote |
        //----------------
        [Test]
        public void Test_FindFootnote_DoesNotThrow_WithValidParameters()
        {
            Book book = new Book(testBookName, testAuthor);
            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            fieldInfo.SetValue(book, new Dictionary<int, string>
            {
                { 1, "Test" },
                { 2, "Test" },
                { 3, "Test" },
            });

            Assert.DoesNotThrow(() =>
            {
                book.FindFootnote(1);
            }, "FindFootnote method throws with valid parameters.");
        }
        [Test]
        public void Test_FindFootnote_Throws_WhenFootnoteDoesNotExist()
        {
            Book book = new Book(testBookName, testAuthor);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(1);
            }, "FindFootnote method doesn't throw when footnote doesn't exist.");
        }
        [Test]
        public void Test_FindFootnote_WorksCorrectly()
        {
            Book book = new Book(testBookName, testAuthor);
            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            fieldInfo.SetValue(book, new Dictionary<int, string>
            {
                { 1, "Test" },
                { 2, "Test" },
                { 3, "Test" },
            });

            Assert.AreEqual("Footnote #1: Test", book.FindFootnote(1),
                "FindFootnote method doesn't work correctly.");
        }

        //-----------------
        //| AlterFootnote |
        //-----------------
        [Test]
        public void Test_AlterFootnote_DoesNotThrow_WithValidParameters()
        {
            Book book = new Book(testBookName, testAuthor);
            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            fieldInfo.SetValue(book, new Dictionary<int, string>
            {
                { 1, "Test" },
                { 2, "Test" },
                { 3, "Test" },
            });

            Assert.DoesNotThrow(() =>
            {
                book.AlterFootnote(1, "TestAltered");
            }, "AlterFootnote method throws with valid parameters.");
        }
        [Test]
        public void Test_AlterFootnote_Throws_WhenFootnoteDoesNotExist()
        {
            Book book = new Book(testBookName, testAuthor);

            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(1, "TestAltered");
            }, "AlterFootnote method doesn't throw when footnote doesn't exist.");
        }
        [Test]
        public void Test_AlterFootnote_WorksCorrectly()
        {
            Book book = new Book(testBookName, testAuthor);
            FieldInfo fieldInfo = book
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Dictionary<int, string>));

            fieldInfo.SetValue(book, new Dictionary<int, string>
            {
                { 1, "Test" },
                { 2, "Test" },
                { 3, "Test" },
            });

            book.AlterFootnote(1, "TestAltered");

            Dictionary<int, string> footnoteDictionary = (Dictionary<int, string>)fieldInfo.GetValue(book);

            Assert.AreEqual(footnoteDictionary.First().Value, "TestAltered",
                "AlterFootnote method doesn't work correctly.");
        }
    }
}

