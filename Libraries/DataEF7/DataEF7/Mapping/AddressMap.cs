using Core.Domain;
using Microsoft.Data.Entity;

namespace DataEF7.Mapping
{
    public class AddressMap : BaseMap
    {
        public AddressMap() : base(Mapping, "Address")
        {
            
        }

        private static void Mapping(ModelBuilder builder)
        {
            var entity = builder.Entity<Address>();
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Code).HasMaxLength(50).HasAnnotation("code", "唯一编码");
            entity.Property(o => o.City).HasMaxLength(100);
            entity.Property(o => o.Country).HasMaxLength(100);
            entity.Property(o => o.Province).HasMaxLength(100);
        }

        protected override void ModelMapping(ModelBuilder builder)
        {
            base.ModelMapping(builder);

            var entity = builder.Entity<Address>();
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Code).HasMaxLength(50).HasAnnotation("code", "唯一编码");
            entity.Property(o => o.City).HasMaxLength(100);
            entity.Property(o => o.Country).HasMaxLength(100);
            entity.Property(o => o.Province).HasMaxLength(100);
        }
    }
}
