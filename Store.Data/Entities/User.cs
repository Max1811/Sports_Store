using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportsStore.Data.Entities
{
    [Table("USERS")]
    public class User
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public User(string name, Guid id)
        {
            Name = name;
            Id = id;
        }
    }
}
