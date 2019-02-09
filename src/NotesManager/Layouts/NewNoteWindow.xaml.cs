using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using NotesManagerLib.DataModels;
using NotesManagerLib.ViewModel;

namespace NotesManager.Layouts
{
    /// <summary>
    /// Interaction logic for NewNoteWindow.xaml
    /// </summary>
    public partial class NewNoteWindow : Window
    {
        public NewNoteWindow()
        {
            InitializeComponent();
        }
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        { }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (titleBlock.Text.Length < 1){
                MessageBox.Show("Title too short");
                return;
            }
            NoteDb _dbContext = new NoteDb();
            var note = new Note(titleBlock.Text, contentBlock.Text);
            _dbContext.Notes.Add(note);
            await _dbContext.SaveChangesAsync();
            this.Hide();
        }

        private void TitleBlock_TextChanged(object sender, TextChangedEventArgs e)
        {}
    }
}
