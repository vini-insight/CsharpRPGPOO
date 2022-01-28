using System;
using System.ComponentModel.DataAnnotations;

namespace Src.Domain.DTO
{
    public class CreateHero
    {
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Name { get; set; }
        public string RealName { get; set; }
        public int? groupId { get; set; }
    }
}