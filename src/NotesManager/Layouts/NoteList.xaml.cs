using NotesManager.DataModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for NoteList.xaml
    /// </summary>
    public partial class NoteList : Page
    {
        public int UserId { get; set; }
        List<string> notesTitles = new List<string>();

        public NoteList(int userId)
        {
            InitializeComponent();
            // w tym miejcu potrzebne zapytanie do bazy z listą wszystkich notatek usera po user id
            // póki co sztuczna lista 

            UserId = userId;
            List<Note> notesList = new List<Note>();

            notesList.Add(new Note(1, "xd", "XD"));
            notesList.Add(new Note(2, "hehe", ":)"));
            notesList.Add(new Note(3, "haha", ":))"));
            notesList.Add(new Note(4, "hyhy", ":)))"));
            notesList.Add(new Note(5, "beka", ":))))"));


            DataContext = new
            {
                Notes = notesList
            };
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            var content = item.Content as Note;
            var id = content.Id;
            NavigationService.Navigate(new NotePage(id, UserId));
        }

        private void AddNoteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NotePage(0, UserId));
        }
    }
}