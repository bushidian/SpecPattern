using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpecPattern.Framework.Data
{
    public class Entity 
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

    }
}
