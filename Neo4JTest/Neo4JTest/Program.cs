using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;

namespace Neo4JTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = GraphDatabase.Driver("bolt://hobby-flnmogdaojekgbkeodhcogol.dbs.graphenedb.com:24786",
                AuthTokens.Basic(".NETNEO4JTESTER", "b.E2uOEzKQDaCE.oVMegmypt0GSCHFs"),
                Config.Builder.WithEncryptionLevel(EncryptionLevel.Encrypted).ToConfig());


            using (var session = driver.Session())
            {
                //session.Run("CREATE (a:Person {name: {name}, title: {title}})",
                 //   new Dictionary<string, object> {{"name", "Arthur"}, {"title", "King"}});

                //var result = session.Run("MATCH (a:Person) WHERE a.name = {name} " +
                //                         "RETURN a.name AS name, a.title AS title",
                //    new Dictionary<string, object> {{"name", "Arthur"}});

                var result = session.Run("Match (a:Airport) Where a.city= {name} return a.name AS name", new Dictionary<string, object> { {"name", "Rotterdam"} });

                foreach (var record in result)
                {
                    Console.WriteLine($"{record["name"].As<string>()}");
                }
                Console.ReadLine();

                /*
                var session = driver.Session();
                using (var tx = session.BeginTransaction())
                {
                    //tx.Run("CREATE (n:Person {name:'Bob'})");
                    //tx.Success();


                    //Needs a dictionary because the return type implements a readonlydictionary interface
                    var result = tx.Run("MATCH (n:Airport { city: {name} }) RETURN n", new Dictionary<string, object> { { "name", "Rotterdam" } });


                    foreach (var record in result)
                    {
                        Console.WriteLine($"{record["name"].As<string>()}");
                    }
                    Console.ReadLine();
                }
                */
            }
        }
    }
}

/*
using Neo4j.Driver.V1;

using (var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "neo4j")))
using (var session = driver.Session())
{
    session.Run("CREATE (a:Person {name: {name}, title: {title}})",
                new Dictionary<string, object> { {"name", "Arthur"}, {"title", "King"} });

    var result = session.Run("MATCH (a:Person) WHERE a.name = {name} " +
                             "RETURN a.name AS name, a.title AS title",
                             new Dictionary<string, object> { { "name", "Arthur" } });

    foreach (var record in result)
    {
        Output.WriteLine($"{record["title"].As<string>()} {record["name"].As<string>()}");
*/