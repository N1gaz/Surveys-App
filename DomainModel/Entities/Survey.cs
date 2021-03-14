using System;
using System.Collections.Generic;

#nullable disable

namespace DomainModel.Entities
{
    public partial class Survey
    {
        public Survey()
        {
            Interviews = new HashSet<Interview>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string SurveyName { get; set; }
        public DateTime? PublishDateTime { get; set; }
        public string SurveyDescription { get; set; }

        public virtual ICollection<Interview> Interviews { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
