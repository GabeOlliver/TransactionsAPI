using System.Text.Json.Serialization;

namespace APITransacitons.DTOs.Subject
{
    public class UpdateSubjectDTO
    {
        [JsonIgnore]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}