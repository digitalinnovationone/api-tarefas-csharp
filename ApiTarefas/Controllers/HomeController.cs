using ApiTarefas.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public HomeView Index()
    {
        return new HomeView
        {
            Mensagem = "Bem vindo a API de tarefas",
            Documentacao = "/swagger"
        };
    }
}
