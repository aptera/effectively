namespace effectively.StaticCling {
    using System;
    using System.Collections.Generic;

    public class Database {
        public Database(Logger logger)
        {
            Logger = logger;
        }

        public Logger Logger { get; }


        public Database() : this(new Logger())
        {

        }

        public static IEnumerable<T> Query<T>(string sql) where T : class {
           return new Database().QuerySQL<T>(sql);
            
        }

        public IEnumerable<T> QuerySQL<T> (string sql) where T: class
        {
            Logger.LogMessage(sql);
            return OnQuerySQL<T>(sql);
        }


        protected virtual IEnumerable<T> OnQuerySQL<T>(string sql) where T : class
        {
            throw new Exception("Database access!");
        }
    }
}
