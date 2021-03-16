using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    ///<summary>
    ///This class contains database entity.
    ///It was generated using Scaffold-DbContext
    ///</summary>
    public partial class Survey
    {
        /// <summary>
        /// Generating indexes container
        /// </summary>
        public Survey()
        {
            Interviews = new HashSet<Interview>();
            Questions = new HashSet<Question>();
        }

        /// <summary>
        /// Table field primary key
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Required. Table field. 
        /// </summary>
        [Required]
        public string SurveyName { get; set; }
        /// <summary>
        /// Table field. Default value is DateTime.Now.
        /// </summary>
        public DateTime? PublishDateTime { get; set; }
        /// <summary>
        /// Table field. Can be null.
        /// </summary>
        public string SurveyDescription { get; set; }
        /// <summary>
        /// References to Interviews container.
        /// </summary>
        public virtual ICollection<Interview> Interviews { get; set; }
        /// <summary>
        /// References to Questions container.
        /// </summary>
        public virtual ICollection<Question> Questions { get; set; }
    }
}
