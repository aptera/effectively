namespace effectively.tests.ExtractAndOverride
{
	using NUnit.Framework;

	[TestFixture]
	public class The_order_service
	{
		[TestFixture]
		public class Given_the_current_user_is_invalid
		{
			[Test]
			[Ignore("This needs to be implemented!")]
			public void The_order_cannot_be_placed()
			{

			}
		}

		[TestFixture]
		public class Given_the_current_user_is_valid
		{
			[TestFixture]
			public class and_the_order_amount_is_positive
			{
				[Test]
				[Ignore("This needs to be implemented!")]
				public void The_order_can_be_placed()
				{

				}
			}

			[TestFixture]
			public class and_the_order_amount_is_negative
			{
				[Test]
				[Ignore("This needs to be implemented!")]
				public void The_order_cannot_be_placed()
				{

				}
			}
		}
	}
}
