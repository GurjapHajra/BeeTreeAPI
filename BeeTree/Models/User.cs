using System.ComponentModel.DataAnnotations;


namespace BeeTree.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string firstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string lastName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(5)]
        public string Gender { get; set; }
        [Required]
        public Boolean Premium { get; set; }

        public override String ToString()
        {
            if (this == null){
                return "null";
            }

            return String.Format("Name: {0} {1}\n" +
                "Email: {2}\n" +
                "Gender: {3}\n" +
                "Premium: {4}", this.firstName,this.lastName,this.Email,this.Gender,this.Premium);
        }

    }
}
