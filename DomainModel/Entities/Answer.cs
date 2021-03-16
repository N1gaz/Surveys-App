using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    ///<summary>
    ///This class contains database entity.
    ///Entity contains Answers.
    ///It was generated using Scaffold-DbContext.
    ///</summary>
    public partial class Answer
    {
        /// <summary>
        /// Table field primary key.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Required. Foreign key references to Questions table.
        /// </summary>
        [Required]
        public int QuestionId { get; set; }

        /// <summary>
        /// Required. Contains answerText.
        /// </summary>
        
        [Required(ErrorMessage = "Answer text is empty")]
        public string AnswerText { get; set; }

        /// <summary>
        /// Contains reference to question
        /// </summary>
        public virtual Question Question { get; set; }
    }
}
