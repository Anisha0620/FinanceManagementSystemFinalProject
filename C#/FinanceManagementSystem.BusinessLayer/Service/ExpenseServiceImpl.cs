using FinanceManagementSystem.BusinessLayer.Repository;
using FinanceManagementSystem.Entity;
using System;
using System.Collections.Generic;

namespace FinanceManagementSystem.BusinessLayer.Service
{
	public class ExpenseServiceImpl : IExpenseService
	{
		private readonly IFinanceRepository _repository;

		public ExpenseServiceImpl(IFinanceRepository repository)
		{
			_repository = repository;
		}

		public bool AddExpense(Expense expense)
		{
			if (expense == null || expense.Amount <= 0)
			{
				throw new ArgumentException("Invalid expense details.");
			}
			return _repository.CreateExpense(expense);
		}

		public bool UpdateExpense(int userId, Expense expense)
		{
			if (userId <= 0 || expense == null || expense.ExpenseId <= 0)
			{
				throw new ArgumentException("Invalid expense or user ID.");
			}
			return _repository.UpdateExpense(userId, expense);
		}

		public bool DeleteExpense(int expenseId)
		{
			if (expenseId <= 0)
			{
				throw new ArgumentException("Invalid expense ID.");
			}
			return _repository.DeleteExpense(expenseId);
		}

		public List<Expense> GetAllExpenses()
		{
			
			return _repository.GetAllExpenses();
		}
	}
}

