using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DomainModel.Entities
{
    public partial class Interview
    {
        [Required]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string UserEmail { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string UserPhone { get; set; }

        [Required]
        public int SurveyId { get; set; }
        public DateTime? PassDateTime { get; set; }

        public virtual Survey Survey { get; set; }
    }
}
