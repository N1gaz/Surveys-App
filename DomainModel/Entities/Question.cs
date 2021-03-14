using System;
using System.Collections.Generic;

#nullable disable

namespace DomainModel.Entities
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int Number { get; set; }
        public string QuestionText { get; set; }
        public bool IsMultipleAnswersSupports { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
