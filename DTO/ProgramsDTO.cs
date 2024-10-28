
namespace DTO
{
    public class ProgramsDTO
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public string ProducerName { get; set; }
        public string Trailer { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public  CategoryDTO? Category { get; set; }
      

    }
}