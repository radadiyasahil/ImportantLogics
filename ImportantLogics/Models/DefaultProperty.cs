namespace ImportantLogics.Models
{
    public class DefaultProperty
    {
        public string? AddedById { get; set; }
        public DateTime AddedOn { get; set; }
        public string? ModifyById { get; set; }
        public DateTime ModifyOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
