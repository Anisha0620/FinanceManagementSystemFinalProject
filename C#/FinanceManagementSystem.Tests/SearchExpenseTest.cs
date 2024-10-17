using NUnit.Framework;
using FinanceManagementSystem.BusinessLayer.Repository;
using FinanceManagementSystem.Entity;
using System.Collections.Generic;

namespace FinanceManagementSystem.Tests
{
	[TestFixture]
	public class SearchExpenseTest
	{
		private FinanceRepositoryImpl _repository;

		[SetUp]
		public void Setup()
		{
			_repository = new FinanceRepositoryImpl();
		}

		[Test]
		public void GetAllExpenses_ShouldReturnListOfExpenses_WhenExpensesExist()
		{
			// Act
			List<Expense> expenses = _repository.GetAllExpenses();

			// Assert
			Assert.IsNotNull(expenses, "Expenses should be returned");
			Assert.GreaterOrEqual(expenses.Count, 0, "Expenses should be retrieved from the repository");
		}
	}
}

