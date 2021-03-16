using System;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    ///<summary>
    ///This class contains database entity.
    ///It was generated using Scaffold-DbContext
    ///</summary>
    public partial class Interview
    {
        /// <summary>
        /// Table field primary key
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Table field. Can be null. Unique pair with UserPhone.
        /// </summary>

        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string UserEmail { get; set; }
        /// <summary>
        /// Table field. Can be null. Unique pair with UserEmail.
        /// </summary>

        [Phone(ErrorMessage = "Invalid phone number")]
        public string UserPhone { get; set; }

        /// <summary>
        /// Foreign key references to Surveys table.
        /// </summary>
        [Required]
        public int SurveyId { get; set; }
        /// <summary>
        /// Pass DateTime. Default value is DateTime.Now.
        /// </summary>
        public DateTime? PassDateTime { get; set; }
        /// <summary>
        /// Reference to Survey.
        /// </summary>
        public virtual Survey Survey { get; set; }
    }
}
