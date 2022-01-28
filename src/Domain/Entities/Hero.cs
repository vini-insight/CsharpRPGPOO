using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Src.Domain.DTO;

namespace Src.Domain.Entities
{
    public class Hero
    {
        public Hero() { }
        public Hero(CreateHero hero)
        {
            this.Name = hero.Name;
            this.RealName = hero.Name;
            this.createdAt = DateTime.Now;
            this.groupId = hero.groupId;
        }


        [Key]
        public int Id { get; set; }
        [MaxLength(80)]
        [Required]
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(90)]
        public string RealName { get; set; }
        public DateTime createdAt { get; set; }
        public int? groupId { get; set; }

        [ForeignKey("groupId")]
        public Group group { get; set; }
    }
}