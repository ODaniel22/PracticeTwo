using BusinessLogic.Managers.Excepciones;
using BusinessLogic.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Managers
{
    public class ManagerPaciente
    {
        private IConfiguration _configuration;
        List<Paciente> _pacientes;
        
        public ManagerPaciente (IConfiguration configuration)
        {
            _configuration = configuration;
            _pacientes = new List<Paciente> ();
            LeerArchivo();
        }
        public List <Paciente> GetAll ()
        {
            return _pacientes;
        }
        public Paciente GetPaciente(int ci)
        {
            Paciente paciente = _pacientes.Find(x => x.CI==ci);
            if (paciente == null) { throw new PacienteNoEncontradoExcepcion("Paciente Extraviado"); }
            return paciente;
        }
        public void CrearPaciente(string name, string lastname, int ci)
        { 
            Paciente paciente = new Paciente (name,lastname,ci,Bloodtype());
            _pacientes .Add(paciente);
            EscribirArchivo();
        }
        public void ActualizarPaciente (string name, string lastname, int ci)
        {
            Paciente paciente = _pacientes.Find(x => x.CI == ci);
            if (paciente == null) { throw new PacienteNoEncontradoExcepcion("Paciente Extraviado"); }
            paciente.Name = name;
            paciente.LastNamee = lastname;
            EscribirArchivo();
        }
        public void BorrarPaciente(int ci)
        {
            Paciente paciente = _pacientes.Find(x => x.CI == ci);
            if (paciente == null) { throw new PacienteNoEncontradoExcepcion("Paciente Extraviado"); }
            _pacientes.Remove(paciente);
            EscribirArchivo();
        }
        private string Bloodtype()
        {
            Random rand = new Random();
            string[] tipos = ["A+", "A-", "B+", "B-", "O+", "AB+", "AB-", "O-"];
            return tipos[rand.Next(0,tipos.Length)];
        }
        private void LeerArchivo()
        {
            _pacientes.Clear();
            StreamReader lector = new StreamReader(_configuration.GetSection("PACIENTESFILEPATH").Value);
            while (!lector.EndOfStream) 
            {
                string linea =lector.ReadLine();
                string[] datos = linea.Split(",");
                Paciente paciente = new Paciente (datos[0], datos[1], int.Parse(datos[2]), datos[3]);
                _pacientes.Add(paciente);
            }
            lector.Close();

        }
        private void EscribirArchivo()
        {
            StreamWriter escritor = new StreamWriter(_configuration.GetSection("PACIENTESFILEPATH").Value);
            foreach(var paciente in _pacientes)
            {
                string[] datos = [paciente.Name, paciente.LastNamee, $"{paciente.CI}", paciente.bloodtype];
                escritor.Write(string.Join(",", datos ));
            }
            escritor.Close();
        }
    }
}
