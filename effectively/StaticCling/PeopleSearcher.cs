
using System.Collections.Generic;

namespace effectively.StaticCling
{
    public class PeopleSearcher
    {
        public PeopleSearcher(Database database)
        {
            Database = database;
        }

        public Database Database { get; }

        public IEnumerable<Person> Search(string query)
        {
            return Database.QuerySQL<Person>("select * from Person where Name like '%" + query + "%'");
        }


    }
}
