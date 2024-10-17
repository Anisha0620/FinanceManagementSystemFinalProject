using FinanceManagementSystem.Entity;
using System.Collections.Generic;

namespace FinanceManagementSystem.BusinessLayer.Repository
{
	public interface IFinanceRepository
	{
		bool CreateUser(User user);
		bool CreateExpense(Expense expense);
		bool DeleteUser(int userId);
		bool DeleteExpense(int expenseId);
		List<Expense> GetAllExpenses();
		bool UpdateExpense(int userId, Expense expense);
	}
}
