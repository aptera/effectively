namespace effectively.ExtractAndOverride
{
    public class OrderService
    {
		private UserService _userService;

		public OrderService(UserService userService)
		{
			_userService = userService;
		}

		public OrderService()
		{
			_userService = new UserService();
		}

	   public bool Add(Order order)
		{
			//_userService = GetUserService();

			if (_userService.isValidUser &&  order.Amount >= 0)//Can the current user save an order
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
    