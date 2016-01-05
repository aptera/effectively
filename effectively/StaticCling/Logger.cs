namespace effectively.StaticCling {
    using System;

    public static class Logger {

        public static void Log(string message) {
            throw new Exception("Actual logging!");
        }
    }
}
