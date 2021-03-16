using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{ 
    ///<summary>
    ///This class contains database entity.
    ///It was generated using Scaffold-DbContext
    ///</summary>
public partial class Result
    {
        [Required]
        public int AnswerId { get; set; }

        [Required]
        public int InterviewId { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual Interview Interview { get; set; }
    }
}
