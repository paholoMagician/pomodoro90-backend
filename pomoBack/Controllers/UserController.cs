using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pomoBack.Models;

namespace pomoBack.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {

        readonly private pomodoro90Context _context;

        public UserController(pomodoro90Context context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("guardarUsuario")]
        public async Task<IActionResult> guardarUsuario([FromBody] Usuario model)
        {

            var usuarioExistente = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (usuarioExistente != null) {
                return BadRequest("El email ya está registrado");
            }

            if (ModelState.IsValid) {
                _context.Usuario.Add(model);
                if (await _context.SaveChangesAsync() > 0) {
                    return Ok(model);
                }
                else {
                    return BadRequest("No se pudo guardar el usuario");
                }
            }
            else {
                return BadRequest("Modelo no válido");
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Usuario userInfo)
        {
            var result = await _context.Usuario.FirstOrDefaultAsync(x => x.Email == userInfo.Email && x.Password == userInfo.Password);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Datos incorrectos");
            }
        }

    }
}
