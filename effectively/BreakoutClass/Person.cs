namespace effectively.BreakoutClass {
    public class Person {
        public Person(string username) {
            Username = username;
            Avatar = FileSystem.LoadAvatar(username);
        }

        public byte[] Avatar { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // add a DisplayName property
        // that lists a sortable full name (Last, First).
    }
}
