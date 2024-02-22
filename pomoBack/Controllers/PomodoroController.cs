using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pomoBack.Models;

namespace pomoBack.Controllers
{
    [Route("api/Pomodoro")]
    [ApiController]
    public class PomodoroController : ControllerBase
    {

        readonly private pomodoro90Context _context;

        public PomodoroController(pomodoro90Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("guardarPomodoro")]
        public async Task<IActionResult> guardarEstudiaCurso([FromBody] PomodoroTasks model)
        {

            if (ModelState.IsValid)
            {
                _context.PomodoroTasks.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(model);
                }

                else
                {
                    return BadRequest("Datos incorrectos");
                }

            }
            else
            {
                return BadRequest("ERROR");
            }

        }

        [HttpGet("obtenerPomodoros/{usercrea}")]
        public async Task<IActionResult> ObtenerPomodoros([FromRoute] int usercrea)
        {
            var pomodoros = await _context.PomodoroTasks.Where(u => u.Idusercrea == usercrea).ToListAsync();
            if (pomodoros == null || !pomodoros.Any()) {
                return NotFound("No se han encontrado tareas pomodoro para este usuario");
            }

            return Ok(pomodoros);

        }

        [HttpDelete("eliminarPomodoro/{idPomodoro}")]
        public async Task<IActionResult> eliminarPomodoro([FromRoute] int idPomodoro)
        {
            // Busca el Pomodoro por su id
            var pomodoro = await _context.PomodoroTasks.FirstOrDefaultAsync(p => p.Id == idPomodoro);

            // Si el Pomodoro no existe, devuelve un NotFound
            if (pomodoro == null)
            {
                return NotFound("No se ha encontrado el Pomodoro a eliminar...");
            }

            // Elimina el Pomodoro de la base de datos
            _context.PomodoroTasks.Remove(pomodoro);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
