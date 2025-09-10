using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APITransacitons.Models
{
    public class Subject
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        [JsonIgnore] 
        public ICollection<Transaction> Transactions { get; set; } // Uma coleção de transações associadas ao sujeito (0...*)

    }
}
