﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public class Food
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_FoodName",1, IsUnique = true)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }
}
