using FinanceManagementSystem.BusinessLayer.Repository;
using FinanceManagementSystem.Entity;
using System;

namespace FinanceManagementSystem.BusinessLayer.Service
{
	public class UserServiceImpl : IUserService
	{
		private readonly IFinanceRepository _repository;

		public UserServiceImpl(IFinanceRepository repository)
		{
			_repository = repository;
		}

		public bool RegisterUser(User user)
		{
			if (user == null || string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
			{
				throw new ArgumentException("Invalid user details.");
			}
			return _repository.CreateUser(user);
		}

		public bool DeleteUser(int userId)
		{
			if (userId <= 0)
			{
				throw new ArgumentException("Invalid user ID.");
			}
			return _repository.DeleteUser(userId);
		}

		public User GetUserDetails(int userId)
		{
			// Logic to get user details from repository
			return new User();
		}
	}
}
