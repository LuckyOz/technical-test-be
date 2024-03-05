
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apps.Models.Db
{
    [Table("Test01")]
    public class Test01
    {
        [Key]
        [Required]
        [Column("Id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("Nama", Order = 1), MaxLength(100)]
        public string? Nama { get; set; }

        [Required]
        [Column("Status", Order = 2)]
        public short Status { get; set; }

        [Required]
        [Column("Created", Order = 3)]
        public DateTime Created { get; set; }

        [Column("Updated", Order = 4)]
        public DateTime Updated { get; set; }
    }
}
