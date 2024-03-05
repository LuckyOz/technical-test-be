
namespace Apps.Models.Response
{
    public class CrudResponse
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public short Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
