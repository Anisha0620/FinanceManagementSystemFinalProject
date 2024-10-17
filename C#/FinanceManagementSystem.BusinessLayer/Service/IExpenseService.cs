using FinanceManagementSystem.Entity;
using System.Collections.Generic;

namespace FinanceManagementSystem.BusinessLayer.Service
{
	public interface IExpenseService
	{
		bool AddExpense(Expense expense);
		bool UpdateExpense(int userId, Expense expense);
		bool DeleteExpense(int expenseId);
		List<Expense> GetAllExpenses();
	}
}
