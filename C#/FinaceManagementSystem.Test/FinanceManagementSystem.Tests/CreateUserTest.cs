using NUnit.Framework;
using FinanceManagementSystem.BusinessLayer.Repository;
using FinanceManagementSystem.Entity;

namespace FinanceManagementSystem.Tests
{
	[TestFixture]
	public class CreateUserTest
	{
		private FinanceRepositoryImpl _repository;

		[SetUp]
		public void Setup()
		{
			_repository = new FinanceRepositoryImpl();
		}

		[Test]
		public void CreateUser_ShouldReturnTrue_WhenUserIsCreated()
		{
			// Arrange
			var user = new User { Username = "test_user", Password = "test123", Email = "test@example.com" };

			// Act
			var result = _repository.CreateUser(user);

			// Assert
			Assert.IsTrue(result, "User should be created successfully");
		}
	}
}
