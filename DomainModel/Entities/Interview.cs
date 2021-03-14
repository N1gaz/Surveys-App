using System;
using System.Collections.Generic;

#nullable disable

namespace DomainModel.Entities
{
    public partial class Interview
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public int SurveyId { get; set; }
        public DateTime? PassDateTime { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
