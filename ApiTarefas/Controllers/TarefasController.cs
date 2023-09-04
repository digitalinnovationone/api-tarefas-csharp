using ApiTarefas.Database;
using ApiTarefas.Dto;
using ApiTarefas.Model.Erros;
using ApiTarefas.Models;
using ApiTarefas.ModelViews;
using ApiTarefas.Servicos;
using ApiTarefas.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers;

[ApiController]
[Route("/tarefas")]
public class TarefasController : ControllerBase
{
    public TarefasController(ITarefaServico servico)
    {
        _servico = servico;
    }

    private ITarefaServico _servico;

    [HttpGet]
    public IActionResult Index(int page = 1)
    {
        var tarefas = _servico.Lista(page);
        return StatusCode(200, tarefas);
    }

    [HttpPost]
    public IActionResult Create([FromBody] TarefaDto tarefaDto)
    {
        try
        {
            var tarefa = _servico.Incluir(tarefaDto);
            return StatusCode(201, tarefa);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }
    }

    [HttpGet("{id}")]
    public IActionResult Show([FromRoute] int id)
    {
        try
        {
            var tarefaDb = _servico.BuscaPorId(id);
            return StatusCode(200, tarefaDb);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(404, new ErroView { Mensagem = erro.Message });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] TarefaDto tarefaDto)
    {   
        try
        {
            var tarefaDb = _servico.Update(id, tarefaDto);
            return StatusCode(200, tarefaDb);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _servico.Delete(id);
            return StatusCode(204);
        }
        catch(TarefaErro erro)
        {
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }
    }
}

