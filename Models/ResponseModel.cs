namespace APITransacitons.Models
{
    public class ResponseModel<T>
    {

        public T? Dados { get; set; } //Model genérico que ainda pode ser Null (T?) 
        public string mensagem { get; set; }
        public bool status { get; set; }

    }
}
