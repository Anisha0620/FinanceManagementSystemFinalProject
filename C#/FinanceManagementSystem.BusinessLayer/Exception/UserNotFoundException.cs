using System;

namespace FinanceManagementSystem.BusinessLayer.Exception
{
	public class UserNotFoundException : System.Exception
	{
		public UserNotFoundException(string message) : base(message) { }
	}
}

