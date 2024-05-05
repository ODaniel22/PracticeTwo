using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class ManagerPaciente
    {
        List<Paciente> _pacientes;
        
        public ManagerPaciente ()
        {
            _pacientes = new List<Paciente> ();
        }
        public List <Paciente> GetAll ()
        {
            return _pacientes;
        }
        public Paciente GetPaciente(int ci)
        {
            Paciente paciente = _pacientes.Find(x => x.CI==ci);
            return paciente;
        }
        public void CrearPaciente(string name, string lastname, int ci)
        { 
            Paciente paciente = new Paciente (name,lastname,ci,Bloodtype());
            _pacientes .Add(paciente);
        }
        public void ActualizarPaciente (string name, string lastname, int ci)
        {
            Paciente paciente = _pacientes.Find(x => x.CI == ci);
            paciente.Name = name;
            paciente.LastNamee = lastname;
           
        }
        public void BorrarPaciente(int ci)
        {
            Paciente paciente = _pacientes.Find(x => x.CI == ci);
            _pacientes.Remove(paciente);
        }
        private string Bloodtype()
        {
            Random rand = new Random();
            string[] tipos = ["A+", "A-", "B+", "B-", "O+", "AB+", "AB-", "O-"];
            return tipos[rand.Next(0,tipos.Length)];
        }
    }
}
