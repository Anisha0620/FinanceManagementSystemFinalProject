using FinanceManagementSystem.Entity;
using FinanceManagementsytem.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FinanceManagementSystem.BusinessLayer.Repository
{
	public class FinanceRepositoryImpl : IFinanceRepository
	{
		// Create a new user and insert it into the database
		public bool CreateUser(User user)
		{
			try
			{
				using (SqlConnection conn = DBConnectionUtil.GetConnection())
				{
					
					string query = "INSERT INTO Users (Username, Password, Email) VALUES (@Username, @Password, @Email)";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Username", user.Username);
						cmd.Parameters.AddWithValue("@Password", user.Password);
						cmd.Parameters.AddWithValue("@Email", user.Email);
						cmd.ExecuteNonQuery();
					}
					return true;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		// Create a new expense and insert it into the database
		public bool CreateExpense(Expense expense)
		{
			try
			{
				using (SqlConnection conn = DBConnectionUtil.GetConnection())
				{
					
					string query = "INSERT INTO Expenses (UserId, Amount, CategoryId, Date, Description) VALUES (@UserId, @Amount, @CategoryId, @Date, @Description)";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@UserId", expense.UserId);
						cmd.Parameters.AddWithValue("@Amount", expense.Amount);
						cmd.Parameters.AddWithValue("@CategoryId", expense.CategoryId);
						cmd.Parameters.AddWithValue("@Date", expense.Date);
						cmd.Parameters.AddWithValue("@Description", expense.Description);
						cmd.ExecuteNonQuery();
					}
					return true;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		// Delete a user from the database based on the user ID
		public bool DeleteUser(int userId)
		{
			try
			{
				using (SqlConnection conn = DBConnectionUtil.GetConnection())
				{
					
					string query = "DELETE FROM Users WHERE UserId = @UserId";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@UserId", userId);
						cmd.ExecuteNonQuery();
					}
					return true;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		// Delete an expense from the database based on the expense ID
		public bool DeleteExpense(int expenseId)
		{
			try
			{
				using (SqlConnection conn = DBConnectionUtil.GetConnection())
				{
					
					string query = "DELETE FROM Expenses WHERE ExpenseId = @ExpenseId";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@ExpenseId", expenseId);
						cmd.ExecuteNonQuery();
					}
					return true;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}

		// Retrieve all expenses for a given user (already implemented)
		public List<Expense> GetAllExpenses()
		{
			List<Expense> expenseList = new List<Expense>();
			using (SqlConnection conn = DBConnectionUtil.GetConnection())
			{
				string query = "SELECT * FROM Expenses";
				SqlCommand cmd = new SqlCommand(query, conn);

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						Expense expense = new Expense()
						{
							ExpenseId = Convert.ToInt32(reader["ExpenseId"]),
							UserId = Convert.ToInt32(reader["UserId"]),
							Amount = Convert.ToDecimal(reader["Amount"]),
							CategoryId = Convert.ToInt32(reader["CategoryId"]),
							Date = Convert.ToDateTime(reader["Date"]),
							Description = Convert.ToString(reader["Description"])
						};
						expenseList.Add(expense);
					}
				}
			}
			return expenseList;
		}

		// Update an existing expense in the database
		public bool UpdateExpense(int userId, Expense expense)
		{
			try
			{
				using (SqlConnection conn = DBConnectionUtil.GetConnection())
				{
					
					string query = "UPDATE Expenses SET Amount = @Amount, CategoryId = @CategoryId, Date = @Date, Description = @Description WHERE ExpenseId = @ExpenseId AND UserId = @UserId";
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.AddWithValue("@Amount", expense.Amount);
						cmd.Parameters.AddWithValue("@CategoryId", expense.CategoryId);
						cmd.Parameters.AddWithValue("@Date", expense.Date);
						cmd.Parameters.AddWithValue("@Description", expense.Description);
						cmd.Parameters.AddWithValue("@ExpenseId", expense.ExpenseId);
						cmd.Parameters.AddWithValue("@UserId", userId);
						cmd.ExecuteNonQuery();
					}
					return true;
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
	}
}

