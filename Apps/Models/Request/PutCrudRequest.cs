namespace Apps.Models.Request
{
    public class PutCrudRequest
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public short Status { get; set; }
    }
}
