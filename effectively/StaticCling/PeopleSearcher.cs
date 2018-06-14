
using System.Collections.Generic;

namespace effectively.StaticCling
{
    public class PeopleSearcher
    {
		readonly Database _Database;

		public PeopleSearcher()
		{
			_Database = new Database();
		}

		public PeopleSearcher(Database db)
		{
			_Database = db;
		}

        public IEnumerable<Person> Search(string query)
        {
            return _Database.QueryInstance<Person>("select * from Person where Name like '%" + query + "%'");
        }
    }
}
