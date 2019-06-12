using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.DataAccess.Entities
{
    public class Faculty : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [MinLength(1)]
        [MaxLength(200)]
        public string Address { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
