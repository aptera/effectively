namespace effectively.StaticCling {
    using System;
    using System.Collections.Generic;

    public static class Database {
        public static IEnumerable<T> Query<T>(string sql) where T : class {
            throw new Exception("Database access!");
        }
    }
}