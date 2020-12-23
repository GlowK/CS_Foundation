using System;
using Xunit;


namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Test1(){
            //arange and act 
            var x = GetInt();
            SetInt(x);
            //assert

            Assert.Equal(3,x);
        }

        private void SetInt(int x)
        {
            x = 43;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringBehaveLIkeValueType(){
            string name = "kamil";
            name = MakeUpperCase(name);

            Assert.Equal("KAMIL",name);
            
        }

        private string MakeUpperCase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //arange
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New name");
            
            //act
           
            //assert
            Assert.Equal("New name", book1.Name);
           
        }

        private void GetBookSetNameByRef(ref Book book, string name)
        {
            book = new Book(name);
        }


        [Fact]
        public void CsharpIsPassByValue()
        {
            //arange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New name");
            
            //act
           
            //assert
            Assert.Equal("Book 1", book1.Name);
           
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReferance()
        {
            //arange
            var book1 = GetBook("Book 1");
            SetName(book1, "New name");
            
            //act
           
            //assert
            Assert.Equal("New name", book1.Name);
           
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            //act
           
            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
           
        }
        [Fact]
        public void AddGradesOnlyInRange0_100(){
            //arange
            Book book = new Book("First");
            //act
            book.AddGrade(5);
            book.AddGrade(105);
            book.AddGrade(6);
            //Assert
            Assert.Equal(5,book.grades[0]);
            Assert.Equal(6,book.grades[1]);
        }

        [Fact]
        public void TwoVariableCanReferenceSameObject()
        {
            //arange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            //act
           
            //assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
           
        }

        private Book GetBook(string nameOfTheBook)
        {
            return new Book(nameOfTheBook);
        }
    }
}
