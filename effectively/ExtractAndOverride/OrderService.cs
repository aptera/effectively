namespace effectively.ExtractAndOverride
{

    public class OrderService
    {
        protected UserService _userService;
        public OrderService()
        {
            _userService = new UserService();
        }

        public bool Add(Order order)
        {
            if (_userService.isValidUser)//Can the current user save an order
            {
                //save order
                return true;
            }
            else {
                //dont add send an exception and log it
                return false;
            }
        }
    }
}
    