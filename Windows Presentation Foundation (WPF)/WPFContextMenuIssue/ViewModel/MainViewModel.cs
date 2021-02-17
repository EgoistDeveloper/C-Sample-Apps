using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFContextMenuIssue.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Books = new ObservableCollection<Book>() 
            { 
                new Book
                {
                    Name = "Alis Harikalar Hiyarında",
                    Author = "Ben"
                },
                new Book
                {
                    Name = "Küçük Prens",
                    Author = "Sen"
                },
                new Book
                {
                    Name = "Küçük Kara Balık",
                    Author = "Biz"
                }
            };

            OpenBookCommand = new RelayParameterizedCommand(OpenBook);
        }

        public ObservableCollection<Book> Books { get; set; }

        public ICommand OpenBookCommand { get; set; }

        public void OpenBook(object sender)
        {
            var book = (Book)((Button)sender).DataContext;

            MessageBox.Show($"Selected Book: {book.Name} - {book.Author}");
        }
    }
}
