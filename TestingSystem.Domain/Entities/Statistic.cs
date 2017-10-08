using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingSystem.Domain.Entities
{
    public partial class Statistic
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TestId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public double Percentage { get; set; }

        public bool IsPassed { get; set; }

        public virtual Test Test { get; set; }

        public virtual User User { get; set; }
    }
}
