using ConsoleApp.Models;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System;
using System.Reflection;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // configuration of connection string
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x => {
                x.ConnectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=BankDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
            });

            // add assembly
            cfg.AddAssembly(Assembly.GetExecutingAssembly());

            // use NHibernate Api's
            // ISession APi
            var seApi = cfg.BuildSessionFactory();
            using(var session=seApi.OpenSession())    // open connection with database
            {
                // Transaction Api
                using (var tr = session.BeginTransaction())
                {
                    // IQuery Api
                    // create code
                    //var person1 = new Models.Person
                    //{
                    //    FirstName = "Kasia",
                    //    LastName = "Nobbs",
                    //    Email = "flannel@wuffwuff.com",
                    //    Phone = "12345678"
                    //};

                    //var person2 = new Models.Person
                    //{
                    //    FirstName = "Jim",
                    //    LastName = "Spriggs",
                    //    Email = "js@wuffwuff.com",
                    //    Phone = "87654321"
                    //};

                    //session.Save(person1);
                    //session.Save(person2);
                    //tr.Commit();

                    // read code 
                    var persons = session.CreateCriteria<Person>().List<Person>();
                    foreach( var item in persons)
                    {
                        Console.WriteLine("{0}\t{1} \t{2} \t{3} \t{4}", item.Id, item.FirstName, item.LastName, item.Email, item.Phone);
                    }

                }
                Console.ReadLine();
            }

        }
    }
}
