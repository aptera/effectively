namespace effectively.ExtractAndOverride
{
    public class OrderService
    {
	   public bool Add(Order order)
		{
			UserService userService = GetUserService();

			if (userService.isValidUser &&  order.Amount >= 0)//Can the current user save an order
			{
				//save order
				return true;
			}
			else
			{
				//dont add send an exception and log it
				return false;
			}
		}

		protected virtual UserService GetUserService()
		{
			return new UserService();
		}
	}
}
    