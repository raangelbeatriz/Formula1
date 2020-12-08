using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Formula1.Models{
    public class Posicao{
        [Key]
        public int Id {get; set;}

        [Display(Name = "Nome do Piloto")]
        public string NomePiloto {get; set;}

        [Display(Name = "Nome da Equipe")]
        public string NomeEquipe {get ; set;}

        [Display(Name = "Posição no Grid")]
        public string PosicaoGrid {get; set;}

        [Display(Name = "Pontos na Corrida")]
        public string PontosCorrida {get; set;}
        

    } 
}