namespace fluent {
    using domain;
    using FluentNHibernate.Mapping;

    public sealed class PersonMap : ClassMap<Person> {
        public PersonMap() {
            Table("People");

            Id(x => x.Id)
                .GeneratedBy.Guid();

            Component(x => x.FullName, c =>
            {
                c.Map(x => x.FirstName, "First_Name");
                c.Map(x => x.LastName, "Last_Name");
                c.Map(x => x.MiddleName, "Middle_Name");
            });

            References(x => x.Address);

            Not.LazyLoad();
        }
    }
}
