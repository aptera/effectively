namespace effectively.tests.ExtractAndOverride
{
    using effectively.ExtractAndOverride;
    using NUnit.Framework;

	[TestFixture]
	public class The_order_service
	{
		[TestFixture]
		public class Given_the_current_user_is_invalid
		{
			[Test]
			public void The_order_cannot_be_placed()
			{
				//arrange
				var os = new OrderService();
				var order = new Order();
				//act
				var returnValue = os.CanPlace(order);
				//assert
				Assert.IsFalse(returnValue);
			}
		}

		[TestFixture]
		public class Given_the_current_user_is_valid
		{
			[TestFixture]
			public class and_the_order_amount_is_positive
			{
				[Test]
				public void The_order_can_be_placed()
				{
					var os = new OrderServiceUserIsValid();
					var order = new Order();
					order.Amount = 100;
					var returnValue = os.CanPlace(order);
					Assert.IsTrue(returnValue);
				}
			}

			[TestFixture]
			public class and_the_order_amount_is_negative
			{
				[Test]
				public void The_order_cannot_be_placed()
				{
					// already generates UserService, but the user is not valid
					var os = new OrderServiceUserIsValid();
					var order = new Order();
					order.Amount = -100;
					var returnValue = os.CanPlace(order);
					Assert.IsFalse(returnValue);
				}
			}
		}
	}


	class OrderServiceUserIsValid : OrderService
    {
        protected override bool UserIsValid()
        {
			return true;
        }
    }
}
