namespace effectively.ExtractAndOverride
{
    public class OrderService
    {
        public bool CanPlace(Order order)
        {
            
            if (UserIsValid() && order.Amount > 0)//Can the current user save an order
            {
                //save order
                return true;
            }
            else {
                //dont add send an exception and log it
                return false;
            }
        }

        protected virtual bool UserIsValid()
        {
            var userService = new UserService();
            return userService.IsValidUser;
        }
    }
}
    