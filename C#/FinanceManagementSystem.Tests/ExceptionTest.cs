using NUnit.Framework;
using FinanceManagementSystem.BusinessLayer.Repository;
using System;

namespace FinanceManagementSystem.Tests
{
	[TestFixture]
	public class ExceptionTest
	{
		private FinanceRepositoryImpl _repository;

		[SetUp]
		public void Setup()
		{
			_repository = new FinanceRepositoryImpl();
		}

		[Test]
		public void DeleteUser_ShouldThrowException_WhenUserIdIsInvalid()
		{
			// Arrange
			int invalidUserId = 999;

			// Act & Assert
			Assert.Throws<Exception>(() => _repository.DeleteUser(invalidUserId), "Exception should be thrown when trying to delete a non-existent user");
		}
	}
}
