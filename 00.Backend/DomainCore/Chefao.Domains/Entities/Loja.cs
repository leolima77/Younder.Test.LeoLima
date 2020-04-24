using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefao.Domains.Entities
{
    [Table("Loja")]
    public class Loja
    {
        [Key]
        public long IdLoja { get; set; }

        [StringLength(200)]
        public string NomeFantasia { get; set; }

        [StringLength(650)]
        public string Descricao { get; set; }

        [StringLength(350)]
        public string Tags { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(11)]
        public string Telefone { get; set; }

        [StringLength(100)]
        public string Dominio { get; set; }

        public bool Ativa { get; set; }
    }
}