using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_LIBRARY.BooksDataBase
{
    class Book
    {
        //Храним не само значение чего-либо, а ключ нужной ячейки словаря -> Автор=0000->А.А.Пушкин
        public string[] _AuthorKey;
        public string[] _GenresKey;
        public string _InformationBookKey;
        public string _PublicationKey;
        public Book(string informationBookKey, string[] authorKey, string[] genresKey, string publicationKey)
        {
            _AuthorKey = authorKey;
            _GenresKey = genresKey;
            _InformationBookKey = informationBookKey;
            _PublicationKey = publicationKey;
        }
    }
    class Author
    {
        public int IndexLine;
        public Author(int indexLine)
        {
            IndexLine = indexLine;
        }
    }
    class Genre
    {
        public int IndexLine;
        public Genre(int indexLine)
        {
            IndexLine = indexLine;
        }
    }
    class InformationBook
    {
        public int IndexLine;
        public InformationBook(int indexLine)
        {
            IndexLine = indexLine;
        }
    }
    class PublishingHouse
    {
        public int IndexLine;
        public PublishingHouse(int indexLine)
        {
            IndexLine = indexLine;
        }
    }
    class Publication
    {
        public int IndexLine;
        public Publication(int indexLine)
        {
            IndexLine = indexLine;
        }
    }
}
