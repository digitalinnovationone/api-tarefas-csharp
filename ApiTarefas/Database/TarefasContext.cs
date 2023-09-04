using ApiTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Database;

public class TarefasContext : DbContext
{
    #nullable disable
    public TarefasContext(DbContextOptions<TarefasContext> options) : base(options) {}

    public DbSet<Tarefa> Tarefas { get; set; }
}
