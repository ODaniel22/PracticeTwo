using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers.Excepciones
{
    public class PacienteNoEncontradoExcepcion:Exception
    {
        public PacienteNoEncontradoExcepcion(string msg) : base(msg) 
        { }
    }
}
