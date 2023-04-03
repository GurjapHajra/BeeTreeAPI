using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace BeeTree.Models
{
    public class UserData
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [AllowNull]
        public string? instagram { get; set; }
        [AllowNull]
        public string? Twitter { get; set; }
        [AllowNull]
        public string? LinkedIn { get; set; }
        [AllowNull]
        public string? Facebook { get; set; }
        [AllowNull]
        public string? Other { get; set; }

    }
}
