using NUnit.Framework;
using FinanceManagementSystem.BusinessLayer.Repository;
using FinanceManagementSystem.Entity;
using System;

namespace FinanceManagementSystem.Tests
{
	[TestFixture]
	public class CreateExpenseTest
	{
		private FinanceRepositoryImpl _repository;

		[SetUp]
		public void Setup()
		{
			_repository = new FinanceRepositoryImpl();
		}

		[Test]
		public void CreateExpense_ShouldReturnTrue_WhenExpenseIsCreated()
		{
			// Arrange
			var expense = new Expense { UserId = 1, Amount = 500.00M, CategoryId = 2, Date = DateTime.Now, Description = "Groceries" };

			// Act
			var result = _repository.CreateExpense(expense);

			// Assert
			Assert.IsTrue(result, "Expense should be created successfully");
		}
	}
}
