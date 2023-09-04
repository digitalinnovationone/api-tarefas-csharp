using ApiTarefas.Database;
using ApiTarefas.Dto;
using ApiTarefas.Model.Erros;
using ApiTarefas.Models;

namespace ApiTarefas.Servicos.Interfaces;

public interface ITarefaServico
{
    List<Tarefa> Lista(int page);

    Tarefa Incluir(TarefaDto tarefaDto);

    Tarefa Update(int id, TarefaDto tarefaDto);

    Tarefa BuscaPorId(int id);

    void Delete(int id);
}