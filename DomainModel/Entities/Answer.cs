using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    public partial class Answer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int QuestionId { get; set; }
        
        [Required(ErrorMessage = "Answer text is empty")]
        public string AnswerText { get; set; }
        public virtual Question Question { get; set; }
    }
}
