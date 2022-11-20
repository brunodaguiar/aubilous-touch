namespace AubilousTouch.Core.Models
{
    public class MessagesGroupPerEmployee : EntityBase
    {
        public int GroupId { get; set; }
        public int EmployeeId { get; set; }
        public bool? IsActive { get; set; }
    }
}
