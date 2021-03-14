using System;
using System.Collections.Generic;

#nullable disable

namespace DomainModel.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }

        public virtual Question Question { get; set; }
    }
}
