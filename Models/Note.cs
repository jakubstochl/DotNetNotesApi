using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetNotesApi.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public long NoteTypeId { get; set; }
        [ForeignKey("NoteTypeId")]
        public NoteType Type { get; set; }
    }
}