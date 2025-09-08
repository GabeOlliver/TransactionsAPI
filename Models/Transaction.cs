namespace APITransacitons.Models
{

    public enum typeOfTransaction
    {
        income, // receita 0 por padrão 
        expense // despesa 1 por padrão
    }

    public class Transaction
    {
        public int id { get; set; }

        public string description { get; set; }

        public double amount { get; set; }

        public typeOfTransaction type { get; set; }

        public Subject idSubject { get; set; } // uma transação vai ter apenas um sujeito associado 

    }
}
