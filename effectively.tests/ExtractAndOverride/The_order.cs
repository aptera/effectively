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
			[TestCase(-1, ExpectedResult = false, TestName = "Given an order with a negative amount does not save the order")]
			[TestCase(1, ExpectedResult = true, TestName = "Given an order with a zero amount saves the order")]
			[TestCase(0, ExpectedResult = true, TestName = "Given an order with a positive amount saves the order")]
			public bool OrderWithAmountIsValid(int amount)
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
