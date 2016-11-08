namespace effectively.StaticCling {
    using System;
    using System.Collections.Generic;

    public class Database {
        private Logger logger;

        public Database(Logger logger) {
            this.logger = logger;
        }

        public IEnumerable<T> QueryInstance<T>(string sql) where T : class {
            logger.LogInstance(sql);
            return AccessDatabase<T>(sql);
        }

        public static IEnumerable<T> Query<T>(string sql) where T : class {
            return new Database(new Logger()).QueryInstance<T>(sql);
        }

        protected virtual IEnumerable<T> AccessDatabase<T>(string sql) {
            throw new Exception("Database access!");
        }
    }
}