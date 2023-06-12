namespace ef_core_haymatlos.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("post")]
    public class PostModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string[] Tag { get; set; }
        public int Like { get; set; }
        public string Uuid { get; set; }

        //EF RELATION
        public string Owner { get; set; }
        public UserModel User { get; set; }
    }
}
