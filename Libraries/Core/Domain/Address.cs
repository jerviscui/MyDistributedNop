namespace Core.Domain
{
    public class Address : BaseEntity
    {
        public string Code { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
