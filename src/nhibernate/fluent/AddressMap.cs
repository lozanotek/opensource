namespace fluent {
    using domain;
    using FluentNHibernate.Mapping;

    public sealed class AddressMap : ClassMap<Address> {
        public AddressMap() {
            Table("Addresses");

            Id(x => x.Id)
                .GeneratedBy.Guid();

            Map(x => x.City);
            Map(x => x.Line1);
            Map(x => x.Line2);
            Map(x => x.State);
            Map(x => x.Zip);
        }
    }
}
