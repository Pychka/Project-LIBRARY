using System.IO;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Project_LIBRARY.BooksDataBase;
using Project_LIBRARY.BooksDataBase.WorksBDB;

namespace Project_LIBRARY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Book> Books = [];
        private Dictionary<string, Author> Authors = [];
        private Dictionary<string, Genre> Genres = [];
        private Dictionary<string, InformationBook> InformationBooks = [];
        private Dictionary<string, PublishingHouse> PublishingHouses = [];
        private Dictionary<string, Publication> Publications = [];
        WorksBDB works;
        public MainWindow()
        {
            InitializeComponent();
            works = new(ref Books, ref Authors, ref Genres, ref InformationBooks, ref PublishingHouses, ref Publications);
            works.CreateBooksDataBase();
            TextBlock authors = new TextBlock
            {
                Text = $"Автор(ы): {works.ReturnAuthors("0000")[0]}, {works.ReturnAuthors("0000")[1]}",
                Style = FindResource("Text") as Style
            };
            TextBlock genres = new TextBlock
            {
                Text = $"Категории: {works.ReturnGenres("0000")[0]}, {works.ReturnGenres("0000")[1]}",
                Style = FindResource("Text") as Style
            };
            TextBlock Description = new TextBlock
            {
                Text = $"{works.ReturnInformationBook("0000")[1]}",
                Style = FindResource("Text") as Style
            };
            TextBlock nameBook = new TextBlock
            {
                Text = $"{works.ReturnInformationBook("0000")[0]}",
                Style = FindResource("Headers") as Style
            };
            TextBlock Publication = new TextBlock
            {
                Text = $"Издание: {works.ReturnPublication("0000").Replace("#0000", "")}",
                Style = FindResource("Text") as Style
            };
            TextBlock publishingHouse = new TextBlock
            {
                Text = $"Издательство: {works.ReturnPublishingHouse("0000")}",
                Style = FindResource("Text") as Style
            };
            StackPanel sp = new StackPanel();
            sp.Children.Add(nameBook);
            sp.Children.Add(authors);
            sp.Children.Add(publishingHouse);
            sp.Children.Add(Publication);
            sp.Children.Add(genres);
            sp.Children.Add(new TextBlock { Style=FindResource("Headers") as Style, Text= "Описание:" });
            sp.Children.Add(Description);
            Button bt = new Button
            {
                Width = 400,
                Height = 200,
                Style = FindResource("visitingСardBt") as Style
            };
            bt.Content = sp;
            Gay.Children.Add(bt);
        }
    }
}