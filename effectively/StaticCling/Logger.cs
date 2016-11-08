namespace effectively.StaticCling {
    using System;

    public class Logger {
        public virtual void LogInstance(string message) {
            throw new Exception("Actual logging!");
        }

        public static void Log(string message) {
            new Logger().LogInstance(message);
        }
    }
}
