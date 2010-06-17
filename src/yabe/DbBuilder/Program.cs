namespace DbBuilder
{
    using System;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    class Program
    {
        static void Main()
        {
            var config = new Configuration().Configure();
            SchemaExport export = new SchemaExport(config);
            export.Drop(false, false);
            export.Create(true, true);

            Console.Write("Press <ENTER> to exit...");
            Console.ReadLine();
        }
    }
}
