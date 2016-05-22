namespace Core.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public byte[] Timespan { get; set; }

        public bool IsDelete { get; set; }
    }
}
