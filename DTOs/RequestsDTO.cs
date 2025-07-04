namespace TyphoonTaskingTool.DTOs
{
    public class RequestsDTO
    {
        public Guid RequestTaskId { get; set; }

        public string? RequestShortId { get; set; }

        public DateTime? RequestCreated { get; set; }

        public int? RankId { get; set; }

        public string? RequestFirstName { get; set; }

        public string? RequestLastName { get; set; }

        public string? RequestEmailAdd { get; set; }

        public string? RequestContactPhone { get; set; }

        public int? UnitId { get; set; }

        public int? TeamId { get; set; }

        public string? RequestTitle { get; set; }

        public string? RequestTaskDescription { get; set; }

        public int? StatusId { get; set; }

        public bool? RequestArchive { get; set; }
    }
}
