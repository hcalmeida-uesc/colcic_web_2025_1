using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ddd_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Turma2025 : ControllerBase
    {
        public string Get(){
            return "Turma 2025 - Desenvolvimento de Aplicações Web";
        }
    }
}
