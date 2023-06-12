namespace ef_core_haymatlos.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("user")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("nickname")]
        [MaxLength(20)]
        public string Nickname { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("uuid")]
        [Required]
        public string Uuid { get; set; }

        //EF RELATION
        public IEnumerable<PostModel> Posts { get; set; } 
    }
}
