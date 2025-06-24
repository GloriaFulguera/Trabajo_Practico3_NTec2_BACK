using Newtonsoft.Json;
using Stock.Models;
using Stock.Models.DTO;
using Stock.Services.Handlers;
using Stock.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Services
{
    public class LoginService : ILoginRepository
    {
        public async Task<List<Login>> GetUsuarios()
        {
            string query = "SELECT * from login";
            string json=SqliteHandler.GetJson(query);

            List<Login> result = JsonConvert.DeserializeObject<List<Login>>(json);
            return result;
        }

        public async Task<LoginResultDTO> Login(LoginDTO login)
        {
            string query = $"SELECT count(*) as Existe from login " +
                $"WHERE usuario='{login.Usuario}' AND clave='{login.Clave}'";
            string result=SqliteHandler.GetScalar(query);

            LoginResultDTO loginResult=new LoginResultDTO();
            if (result == "0")
            {
                loginResult.Result = false;
                loginResult.Mensaje = "Credenciales inválidas o usuario inexistente.";
            }
            else
            {
                query = $"SELECT Estado from login " +
                    $"WHERE usuario='{login.Usuario}' AND clave='{login.Clave}'";
                result=SqliteHandler.GetScalar(query);

                if (result != "A")
                {
                    loginResult.Result = false;
                    loginResult.Mensaje = "El usuario se encuentra inactivo.";
                }
                else
                {
                    query = $"UPDATE login SET Fecha_ultLogin='{DateTime.Now.ToString()}' WHERE usuario='{login.Usuario}'";
                    bool resultUpd=SqliteHandler.Exec(query);
                    if(resultUpd)
                    {
                        loginResult.Result = true;
                        loginResult.Mensaje = "Usuario validado correctamente";
                    }
                    else
                    {
                        loginResult.Result = false;
                        loginResult.Mensaje = "Ocurrio un problema, comuníquese con el administrador.";
                    }
                }
            }

            return loginResult;
        }
    }
}
