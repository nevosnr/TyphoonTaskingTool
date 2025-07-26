namespace TyphoonTaskingTool.DTOs
{
    public class RequestUpdatesDTO
    {
        public Guid UpdateId { get; set; }

        public Guid RequestTaskId { get; set; }

        public DateTime? UpdateTimeStamp { get; set; }

        public string? UpdateDescription { get; set; }

        public string? UpdateBy { get; set; }

    }
}
