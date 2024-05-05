using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class Paciente
    {
        public string Name { get; set; }
        public string LastNamee { get; set; }
        public int CI { get; set; }
        public string bloodtype { get; set; }  

        public Paciente (string Name, string LastName, int ci, string bloodtype)
        {
            this.Name = Name;
            this.LastNamee  = LastName; 
            this.CI = ci;
            this.bloodtype = bloodtype;
        }
    }

}
