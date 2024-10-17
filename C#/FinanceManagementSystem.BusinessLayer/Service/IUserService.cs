using FinanceManagementSystem.Entity;

namespace FinanceManagementSystem.BusinessLayer.Service
{
	public interface IUserService
	{
		bool RegisterUser(User user);
		bool DeleteUser(int userId);
		User GetUserDetails(int userId);
	}
}
