using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
    ///<summary>
    ///This class contains database entity.
    ///It was generated using Scaffold-DbContext.
    ///Both fields make up the primary key.
    ///</summary>
    public partial class Result
    {
        /// <summary>
        /// Reference to Answers table.
        /// </summary>
        [Required]
        public int AnswerId { get; set; }
        /// <summary>
        /// Reference to Interviews table
        /// </summary>
        [Required]
        public int InterviewId { get; set; }
        /// <summary>
        /// Reference to Answer
        /// </summary>
        public virtual Answer Answer { get; set; }
        /// <summary>
        /// Reference to Interview
        /// </summary>
        public virtual Interview Interview { get; set; }
    }
}
