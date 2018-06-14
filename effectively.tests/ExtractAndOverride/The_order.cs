namespace effectively.tests.ExtractAndOverride
{
	using effectively.ExtractAndOverride;
	using NUnit.Framework;

	[TestFixture]
	public class The_order
	{
		[TestFixture]
		public class GivenTheCurrentUserIsValid
		{

			[Test]
			public void GivenTheOrderAmountIsNegative_TheOrderCannotBeSaved()
			{
				Assert.IsFalse(OrderWithAmountIsValid(-1));
			}

			[Test]
			public void GivenTheOrderAmountIsZero_TheOrderCanBeSaved()
			{
				Assert.IsTrue(OrderWithAmountIsValid(0));
			}
			
			[Test]
			public void GivenTheOrderAmountIsGreaterThanZero_TheOrderCanBeSaved()
			{
				Assert.IsTrue(OrderWithAmountIsValid(1));
			}

			private bool OrderWithAmountIsValid(int amount)
			{
				var order = new Order { Amount = amount };
				var os = new TestableOrderService { UserIsValid = true };

				return os.Add(order);
			}
		}

		[TestFixture]
		public class GivenTheCurrentUserIsInvalid
		{
			[Test]
			public void TheOrderCannotBeSaved()
			{
				var order = new Order { Amount = 1 };
				var os = new TestableOrderService { UserIsValid = false };
				Assert.IsFalse(os.Add(order));
			}
		}

		class TestableOrderService 
			: OrderService
		{
			public bool UserIsValid { get; set; }

			protected override UserService GetUserService()
			{
				return new UserService { isValidUser = this.UserIsValid };
			}
		}
	}
}
