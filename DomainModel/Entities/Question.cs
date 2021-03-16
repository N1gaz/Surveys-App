using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    ///<summary>
    ///This class contains database entity.
    ///It was generated using Scaffold-DbContext
    ///</summary>
    public partial class Question
    {
        /// <summary>
        /// Creating answers container
        /// </summary>
        public Question()
        {
            Answers = new HashSet<Answer>();
        }
        /// <summary>
        /// Table field primary key
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Foreign key references to Surveys table
        /// </summary>
        [Required]
        public int SurveyId { get; set; }
        /// <summary>
        /// Table field contains number of question in survey. Required.
        /// </summary>
        [Required]
        public int Number { get; set; }
        /// <summary>
        /// Table field. Required.
        /// </summary>
        [Required]
        public string QuestionText { get; set; }
        /// <summary>
        /// Table field required.
        /// </summary>
        [Required]
        public bool IsMultipleAnswersSupports { get; set; }
        /// <summary>
        /// Reference to Survey.
        /// </summary>
        public virtual Survey Survey { get; set; }
        /// <summary>
        /// Reference to Answers.
        /// </summary>
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
