namespace effectively.StaticCling {
    using System;

    public class Logger {

        public static void Log(string message) {
			new Logger().LogInstance(message);
        }

		public virtual void LogInstance(string message)
		{
			throw new Exception("Actual Instance logging!");
		}

	}
}
