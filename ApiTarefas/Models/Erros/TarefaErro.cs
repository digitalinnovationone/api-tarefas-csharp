namespace ApiTarefas.Model.Erros;

public class TarefaErro : Exception 
{
    public TarefaErro(string message) : base(message){}
}