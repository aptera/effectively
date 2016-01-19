
using System.Collections.Generic;

namespace effectively.StaticCling
{
    public class PeopleSearcher
    {
        public IEnumerable<Person> Search(string query)
        {
            return Database.Query<Person>("select * from Person where Name like '%" + query + "%'");
        }
    }
}
