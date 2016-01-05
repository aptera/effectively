namespace effectively.ExtractAndOverride {

    public class Order {
        private User _user;
        public Order() {
            _user = new User();
        }

        public bool Add() {
            if (_user.ValidUser) {
                //do something
                return true;
            } else {
                //dont add send an exception and log it
                return false;
            }
        }
    }
}
