using System;
using System.Collections.Generic;
using System.Text;

namespace TriboPersonal.Model
{
    internal class Usuario
    {        
        public string NomeAluno { get; set; }
        public string NomeUsuario { get; set; }
        public string SenhaAluno { get; set; }
        public bool IsProfessor { get; set; }
        public bool IsAtivo { get; set; }
        public string CreatedAt { get; set; }
        public string VencimentoEm { get; set; }
        public object TipoPlano { get; set; }
        public object QtdeVezesSemana { get; set; }
        public object PeriodoContrato { get; set; }
        public string ValorMensalidade { get; set; }
    }
}
