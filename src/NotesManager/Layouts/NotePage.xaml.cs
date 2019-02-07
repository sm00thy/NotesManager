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
        private readonly Notedb _noteDb;
        private readonly INoteRepository _noteRepository;

        public NotePage(Notedb noteDb, INoteRepository noteRepository)
        {
            _noteDb = noteDb;
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
            var con = new Notedb();
            if (note.Id == 0) {
                con.Notes.Add(note);
                await con.SaveChangesAsync();
            }
            else{
                con.Notes.Attach(note);
                await con.SaveChangesAsync();
            }
            NavigationService.Navigate(new NoteList(UserId));
        }

        private async void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var connection = new Notedb();
            var note = await connection.Notes.FindAsync(NoteId);
            connection.Notes.Remove(note);
            await connection.SaveChangesAsync();
            NavigationService.Navigate(new NoteList(UserId));
        }
    }
}
