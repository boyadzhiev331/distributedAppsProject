using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.DataAccess.Entities
{
    public class Nationality : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
