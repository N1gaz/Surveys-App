using System.ComponentModel.DataAnnotations;

namespace DomainModel.Entities
{
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
