namespace effectively.ExtractAndOverride
{
    public class OrderService
    {
        public bool Add(Order order)
        {
            var userService = new UserService();
            if (userService.isValidUser)//Can the current user save an order
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
    