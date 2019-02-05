using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NotesManagerLib.DataModels;
using NotesManagerLib.ViewModel;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for NoteList.xaml
    /// </summary>
    /// 
    public partial class NoteList : Page
    {
        List<Note> notes = new List<Note>();
        List<string> notesTitles = new List<string>();

        public NoteList()
        {
            InitializeComponent();
            DataContext = new NoteViewModel();

            // w tym miejcu potrzebne zapytanie do bazy z listą wszystkich notatek usera
            // póki co sztuczna lista 
            notes.Add(new Note(1, "xd", "XD"));
            notes.Add(new Note(2, "hehe", ":)"));
            notes.Add(new Note(3, "haha", ":))"));
            notes.Add(new Note(4, "hyhy", ":)))"));
            notes.Add(new Note(5, "beka", ":))))"));

            foreach (var note in notes)
            {
                notesTitles.Add(note.Title);
            }

            notesList.ItemsSource = notesTitles;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                MessageBox.Show("Note selected", "NotesManager");
            }
        }

        private void addNewNote_Click(object sender, RoutedEventArgs e)
        {
            NewNoteWindow window = new NewNoteWindow();
            window.Show();
        }
    }
}
