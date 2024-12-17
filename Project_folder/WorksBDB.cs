using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project_LIBRARY.BooksDataBase.WorksBDB
{
    internal class WorksBDB
    {
        private Dictionary<string, Book> Books;
        private Dictionary<string, Author> Authors;
        private Dictionary<string, Genre> Genres;
        private Dictionary<string, InformationBook> InformationBooks;
        private Dictionary<string, PublishingHouse> PublishingHouses;
        private Dictionary<string, Publication> Publications;
        public WorksBDB(ref Dictionary<string, Book> books, ref Dictionary<string, Author> authors, ref Dictionary<string, Genre> genres, ref Dictionary<string, InformationBook> informationBooks, ref Dictionary<string, PublishingHouse> publishingHouses, ref Dictionary<string, Publication> publications)
        {
            Books = books;
            Authors = authors;
            Genres = genres;
            InformationBooks = informationBooks;
            PublishingHouses = publishingHouses;
            Publications = publications;
        }
        #region RechangeIdToValue
        //Замена id на значение
        public string ReturnPublication(string keyBook) => ReadSpecificLine(Publications[Books[keyBook]._PublicationKey].IndexLine, "Publication").Replace($"{Books[keyBook]._PublicationKey}#", "");
        public string ReturnPublishingHouse(string keyBook) => ReadSpecificLine(Publications[ReturnPublication(keyBook).Split('#')[1]].IndexLine, "PublishingHouses").Replace($"{Books[keyBook]._PublicationKey}#", "");
        public string[] ReturnAuthors(string keyBook)
        {
            string[] authors = new string[Books[keyBook]._AuthorKey.Length];
            for (int i = 0; i < Books[keyBook]._AuthorKey.Length; i++)
                authors[i] = ReadSpecificLine(Authors[Books[keyBook]._AuthorKey[i]].IndexLine, "Author").Replace($"{Books[keyBook]._AuthorKey[i]}#", "");
            return authors;
        }
        public string[] ReturnGenres(string keyBook)
        {
            string[] genres = new string[Books[keyBook]._GenresKey.Length];
            for (int i = 0; i < Books[keyBook]._GenresKey.Length; i++)
                genres[i] = ReadSpecificLine(Genres[Books[keyBook]._GenresKey[i]].IndexLine, "Genres").Replace($"{Books[keyBook]._GenresKey[i]}#", "");
            return genres;
        }
        public string[] ReturnInformationBook(string keyBook) => ReadSpecificLine(InformationBooks[Books[keyBook]._InformationBookKey].IndexLine, "InformationBook").Replace($"{Books[keyBook]._InformationBookKey}#", "").Split('#');
        #endregion
        public void CreateBooksDataBase()//Заполняем словари id-шниками
        {
            string[] Lines = ReadAllLines("Books");
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Line = Lines[i].Split('#');
                Books.Add(Line[0], new Book(Line[1], Line[2].Split(','), Line[3].Split(','), Line[4]));
            }
            ReadAllLines("Author");
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Line = Lines[i].Split('#');
                Authors.Add(Line[0], new Author(i + 1));
            }
            ReadAllLines("Genres");
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Line = Lines[i].Split('#');
                Genres.Add(Line[0], new Genre(i + 1));
            }
            ReadAllLines("InformationBook");
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Line = Lines[i].Split('#');
                InformationBooks.Add(Line[0], new InformationBook(i + 1));
            }
            ReadAllLines("Publication");
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Line = Lines[i].Split('#');
                Publications.Add(Line[0], new Publication(i + 1));
            }
            ReadAllLines("PublishingHouses");
            for (int i = 0; i < Lines.Length; i++)
            {
                string[] Line = Lines[i].Split('#');
                PublishingHouses.Add(Line[0], new PublishingHouse(i + 1));
            }
        }
        private string[] ReadAllLines(string fileName) => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.txt"));
        private string ReadSpecificLine(int numLine, string fileName)
        {
            using (StreamReader reader = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{fileName}.txt")))
            {
                for (int i = 0; i < numLine - 1; i++)
                    reader.ReadLine();
                return reader.ReadLine();
            }
        }
    }
}
