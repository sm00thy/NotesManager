using NotesManager.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        public int NoteId { get; set; }
        public int UserId { get; set; }

        public NotePage(int noteId, int userId)
        {
            InitializeComponent();
            NoteId = noteId;
            UserId = userId;
        }


        private /*async Task*/ void SaveNoteBtnClick(object sender, RoutedEventArgs e)
        {
            var note = new Note(NoteId, noteTitle.Text, noteContent.Text);
            if (note.Id == 0) ;
            //strzał do bazy z createNote
            else;
            //strzał do bazy z updateNote
            NavigationService.Navigate(new NoteList(UserId));
        }
    }
}