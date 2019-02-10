using NotesManagerLib.DataModels;
using NotesManagerLib.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesManager.Tests.Repositories
{
    [TestFixture]
    public class NoteRepositoryTests
    {
        private readonly INoteRepository _noteRepository;

        public NoteRepositoryTests()
        {
            _noteRepository = new NoteRepository();
        }

        [Test]
        public async Task WhenCreatingNoteAndCallAddMethodShouldAddNoteToDbAndGetNoteFromDbByIdAndThenDeleteIt()
        {
            // Arrange
            var noteToAddId = 0;
            var title = "TestNote";
            var content = "TestContent";
            var userId = 5;
            var noteToAdd = new Note(noteToAddId, title, content, userId);

            // Act
            var noteId = await _noteRepository.AddAsync(noteToAdd);
            var note = await _noteRepository.GetNoteAsync(noteId);
            await _noteRepository.RemoveAsync(note);

            // Assert
            Assert.AreEqual(title, note.Title);
            Assert.AreEqual(content, note.Content);
        }

        [Test]
        public async Task WhenCreatingNoteAndCallAddMethodShouldAddNoteToDbAndGetNoteFromDbThenUpdateItAndDeleteIt()
        {
            // Arrange
            var noteToAddId = 0;
            var title = "TestNote";
            var content = "TestContent";
            var userId = 5;
            var noteToAdd = new Note(noteToAddId, title, content, userId);

            var updatedTitle = "Note after update";
            var updatedContent = "Content after update";

            // Act
            var noteId = await _noteRepository.AddAsync(noteToAdd);
            var note = await _noteRepository.GetNoteAsync(noteId);
            note.Title = updatedTitle;
            note.Content = updatedContent;
            await _noteRepository.UpdateAsync(note);
            var noteAfterUpdate = await _noteRepository.GetNoteAsync(noteId);
            await _noteRepository.RemoveAsync(noteAfterUpdate);

            // Assert
            Assert.AreEqual(updatedTitle, noteAfterUpdate.Title);
            Assert.AreEqual(updatedContent, noteAfterUpdate.Content);
        }
    }
}
