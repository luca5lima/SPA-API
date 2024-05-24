using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace SPA.Api.Models
{
    public class Despesa
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }

        public Despesa()
        {
            Description = string.Empty;
        }
    }
}
