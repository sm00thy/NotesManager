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
        private readonly INoteRepository _noteRepository = new NoteRepository();
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
            if (note.Id == 0) 
                await _noteRepository.AddAsync(note);  
            else
                await _noteRepository.UpdateAsync(note);

            NavigationService.Navigate(new NoteList(UserId));
        }

        private async void DeleteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var note = await _noteRepository.GetNoteAsync(NoteId);
            if (!Equals(note, null))
            {
                await _noteRepository.RemoveAsync(note);
            }
            NavigationService.Navigate(new NoteList(UserId));
        }
    }
}
