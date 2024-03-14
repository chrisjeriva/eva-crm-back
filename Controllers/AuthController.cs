using Prospectos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Prospectos.Services;
using Prospectos.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using Prospectos.Data.Interfaces;
using Newtonsoft.Json.Linq;

namespace Prospectos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IApiRepository _repository;

        public AuthController(ITokenService tokenService, IApiRepository repository)
        {
            _tokenService = tokenService;
            _repository = repository;
        }

        [HttpGet("account")]
        public async Task<IActionResult> Account([FromHeader] string Authorization)
        {
            if (Authorization != null && Authorization != "")
            {
                var token = Authorization.Replace("Bearer ","");
                var valid = _tokenService.ValidateToken(token);

                if (valid)
                {
                    var login = _tokenService.DecodeToken(token);
                    var usuario = await _repository.GetUserByLoginAsync(login);
                    var autorities = new List<string>();
                    if (usuario == null)
                    {
                        return BadRequest("La sesión caducó, es necesario volver a iniciar sesión.");
                    }
                    else
                    {
                        autorities.Add(usuario.Authority.name);
                    }

                    
                    return Ok(new
                    {
                        id_token = token,
                        id = usuario.nUsuario,
                        username = usuario.login,
                        activated = usuario.activated,
                        authorities = autorities,
                        email = usuario.email,
                        firstName = usuario.firstName,
                        langKey = usuario.langKey,
                        lastName = usuario.lastName,
                        login = usuario.login,
                        imageUrl = ""
                    });
                } 
                else
                {
                    return BadRequest("Su sesión expiró, vuelva a iniciar sesión.");
                }

            }
            else
            {
                return BadRequest("Su petición carece del token de autenticación.");
            }
        }

        [HttpPost("account")]
        public async Task<IActionResult> Save([FromHeader] string Authorization, [FromBody] Account account)
        {
            if (Authorization != null && Authorization != "")
            {
                var token = Authorization.Replace("Bearer ", "");
                var valid = _tokenService.ValidateToken(token);

                if (valid)
                {
                    var login = _tokenService.DecodeToken(token);
                    var usuario = await _repository.GetUserByLoginAsync(login);

                    usuario.lastName = account.lastName;
                    usuario.firstName = account.firstName;
                    usuario.email = account.email;

                    _repository.Update(usuario);
                    _repository.SaveAll();
                }

                return Ok();
            }
            else
            {
                return BadRequest("Su petición carece del token de autenticación.");
            }
               
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromHeader] string Authorization, [FromBody]ChangePassword data)
        {
            if (Authorization != null && Authorization != "")
            {
                var token = Authorization.Replace("Bearer ", "");
                var valid = _tokenService.ValidateToken(token);

                if (valid)
                {
                    var login = _tokenService.DecodeToken(token);
                    var usuario = await _repository.GetUserByLoginAsync(login);

                    if(usuario.password == data.currentPassword)
                    {
                        usuario.password = data.newPassword;
                        _repository.Update(usuario);
                        _repository.SaveAll();

                    }
                    else
                    {
                        return BadRequest("La contraseña actual no coincide.");
                    } 
                }

                return Ok();
            }
            else
            {
                return BadRequest("Su petición carece del token de autenticación.");
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn([FromBody] SignIn user)
        {
            var token = "";
            var usuario = await _repository.GetUserByLoginAsync(user.username);
            var autorities = new List<string>();
            if(usuario == null)
            {
                return BadRequest("Usuario o contraseña incorrectos.");
            } 
            else
            {
                if(usuario.password == user.password)
                {
                    token = _tokenService.CreateToken(user);

                    HttpContext.Response.Headers.Add("Authorization", "Bearer " + token);

                    autorities.Add(usuario.Authority.name);
                } 
                else
                {
                    return BadRequest("Usuario o contraseña incorrectos.");
                }
            }



            return Ok(new
            {
                id_token = token,
                id = usuario.nUsuario,
                username = usuario.login,
                activated = usuario.activated,
                authorities = autorities,
                email = usuario.email,
                firstName = usuario.firstName,
                langKey = usuario.langKey,
                lastName = usuario.lastName,
                login = usuario.login,
                imageUrl = ""
            });

        }
    }
}
