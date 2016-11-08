namespace effectively.ExtractAndOverride {

    public class OrderService {
        private UserService _userService;
        public OrderService() {
            _userService = new UserService();
        }

        public bool Add(Order order) {
            if (GetIsValidUser())//Can the current user save an order
            {
                if (order.Amount < 0)
                    return false;
                //save order
                SaveToDatabase(order);
                return true;
            } else {
                //dont add send an exception and log it
                return false;
            }
        }

        protected virtual bool GetIsValidUser() {
            return _userService.isValidUser;
        }

        protected virtual void SaveToDatabase(Order order) {
            // Calls to the database class.
        }
    }
}
