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
            var _dbContext = new NoteDb();

            foreach (var note in _dbContext.Notes)
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

        private void AddNewNote_Click(object sender, RoutedEventArgs e)
        {
            NewNoteWindow window = new NewNoteWindow();
            window.Show();
        }
    }
}
