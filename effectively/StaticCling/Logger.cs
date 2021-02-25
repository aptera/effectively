namespace effectively.StaticCling {
    using System;

    public class Logger {

        public static void Log(string message) {
            new Logger().LogMessage(message);
        }

        public virtual void LogMessage(string message)
        {
            throw new Exception("Actual logging!");
        }
    }
}
