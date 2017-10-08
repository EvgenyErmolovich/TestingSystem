using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Domain.Entities
{
    public partial class Question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public byte[] Img { get; set; }

        public int TestId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }

        public virtual Test Test { get; set; }
    }
}
