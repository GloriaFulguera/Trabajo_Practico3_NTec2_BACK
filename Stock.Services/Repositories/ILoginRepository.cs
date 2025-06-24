using Stock.Models;
using Stock.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Services.Repositories
{
    public interface ILoginRepository
    {
        public Task<List<Login>> GetUsuarios();
        public Task<LoginResultDTO> Login(LoginDTO login);
    }
}
