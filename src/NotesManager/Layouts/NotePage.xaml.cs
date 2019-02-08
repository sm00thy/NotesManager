using NotesManagerLib.DataModels;
using NotesManagerLib.Repositories;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        private readonly INoteRepository _noteRepository;
        public NotePage( INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public int NoteId { get; set; }
        public int UserId { get; set; }

        public NotePage()
        {
            InitializeComponent();
        }
        public NotePage(int noteId, int userId, string _noteTitle, string _noteContent)
        {
            InitializeComponent();
            NoteId = noteId;
            UserId = userId;

            noteTitle.Text = _noteTitle;
            noteContent.Text = _noteContent;
        }

        private async void SaveNoteBtnClick(object sender, RoutedEventArgs e)
        {
            var note = new Note(NoteId, noteTitle.Text,
                                noteContent.Text, UserId);
            var notedb = new Notedb();
            if (note.Id == 0) {
                notedb.Notes.Add(note);
                await notedb.SaveChangesAsync();
            }
            else{
                var tempNote = await notedb.Notes
                    .FirstOrDefaultAsync(x => x.Id == NoteId);
                tempNote.Title = noteTitle.Text;
                tempNote.Content = noteContent.Text;
                await notedb.SaveChangesAsync();
            }
            NavigationService.Navigate(new NoteList(UserId));
        }

        private async void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var notedb = new Notedb();
            var note = await notedb.Notes.FindAsync(NoteId);
            if (!Equals(note, null))
            {
                notedb.Notes.Remove(note);
                await notedb.SaveChangesAsync();
            }
            NavigationService.Navigate(new NoteList(UserId));
        }
    }
}
