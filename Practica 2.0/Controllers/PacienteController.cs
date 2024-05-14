using BusinessLogic.Managers;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Practica_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly ManagerPaciente _managerpaciente;
        public PacienteController(ManagerPaciente managerpaciente)
        { 
            _managerpaciente = managerpaciente;
        }
        [HttpGet]
        public List<Paciente> Get()
        {
            return _managerpaciente.GetAll();        
        }
        [HttpGet]
        [Route("{ci}")]
        public Paciente Get(int ci)
        {
            return _managerpaciente.GetPaciente(ci);
        }
        [HttpPost]
        public async void Post([FromBody]Paciente paciente)
        {
            await _managerpaciente.CrearPaciente(paciente.Name, paciente.LastNamee,paciente.CI);
        }
        [HttpPut("{ci}")]
        public async void Put(int ci, [FromBody] Paciente paciente)
        {
            await _managerpaciente.ActualizarPaciente(paciente.Name, paciente.LastNamee, ci);
        }
        [HttpDelete("{ci}")]
        public void Delete (int ci)
        {
            _managerpaciente.BorrarPaciente(ci);
        }

    }
}
