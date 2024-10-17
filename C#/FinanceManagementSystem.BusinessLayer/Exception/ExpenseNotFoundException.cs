using System;

namespace FinanceManagementSystem.BusinessLayer.Exception
{
	public class ExpenseNotFoundException : System.Exception
	{
		public ExpenseNotFoundException(string message) : base(message) { }
	}
}
