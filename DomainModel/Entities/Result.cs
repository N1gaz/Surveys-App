using System;
using System.Collections.Generic;

#nullable disable

namespace DomainModel.Entities
{
    public partial class Result
    {
        public int AnswerId { get; set; }
        public int InterviewId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Interview Interview { get; set; }
    }
}
