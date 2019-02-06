﻿using System.Collections.Generic;
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
        public int UserId { get; set; }

        public NoteList(int userId)
        {
            UserId = userId;
            InitializeComponent();
            DataContext = new NoteViewModel();
            var _dbContext = new NoteDb();

            List<Note> notesList = new List<Note>();

            foreach (var note in _dbContext.Notes)
            {
                notesList.Add(note);
            }

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
            NavigationService.Navigate(new NotePage(id, UserId, content.Title, content.Content));
        }

        private void AddNewNote_Click(object sender, RoutedEventArgs e)
        {
            NewNoteWindow window = new NewNoteWindow();
            window.Show();
        }

        private void AddNoteBtn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NotePage(0, UserId, "", ""));
        }

        private void LogoutBtn_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
    }
}
