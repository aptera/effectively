namespace effectively.StaticCling {
    using System;
    using System.Collections.Generic;

    public class Database {
		private Logger _logger;

		public Database()
		{
			_logger = new Logger();
		}

		public Database(Logger logger)
		{
			_logger = logger;
		}
        public static IEnumerable<T> Query<T>(string sql) where T : class {
			return new Database().QueryInstance<T>(sql);
        }

		public virtual IEnumerable<T> QueryInstance<T>(string sql) where T : class
		{
			_logger.LogInstance(sql);
			return HitTheDatabase<T>();
		}

		protected virtual IEnumerable<T> HitTheDatabase<T>()
		{
			throw new Exception("Database access!");
		}

	}
}