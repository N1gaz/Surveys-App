using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DomainModel.Entities
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }
        [Required]
        public int Id { get; set; }

        [Required]
        public int SurveyId { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string QuestionText { get; set; }

        [Required]
        public bool IsMultipleAnswersSupports { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
