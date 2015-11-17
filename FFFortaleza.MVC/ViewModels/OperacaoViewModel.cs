﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CrdFortes.Domain.Entities;

namespace CrdFortes.MVC.ViewModels
{
    public class OperacaoViewModel
    {
        [Key]
        public int OperacaoId { get; set; }

        [DisplayName("Tipo")]
        public EnumTipoOperacao TipoOperacao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Observação")]
        [MaxLength(150, ErrorMessage = "Maximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo de {0} caracteres")]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Categoria")]
        [MaxLength(150, ErrorMessage = "Maximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo de {0} caracteres")]
        public string Categoria { get; set; }
        
        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0","9999999999")]
        [Required(ErrorMessage = "Preencha o campo Valor")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        
    }
}