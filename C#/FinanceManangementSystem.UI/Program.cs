using FinanceManagementSystem.BusinessLayer.Repository;
using FinanceManagementSystem.Entity;
using System;
using System.Collections.Generic;

namespace FinanceManagementSystem.UI
{
	class Program
	{
		static void Main(string[] args)
		{
			// Initialize the repository
			IFinanceRepository repo = new FinanceRepositoryImpl();

			bool running = true;
			while (running)
			{
				Console.WriteLine("\nFinance Management System");
				Console.WriteLine("1. Add User");
				Console.WriteLine("2. Add Expense");
				Console.WriteLine("3. View All Expenses");
				Console.WriteLine("4. Delete User");
				Console.WriteLine("5. Delete Expense");
				Console.WriteLine("6. Update Expense");
				Console.WriteLine("0. Exit");

				int choice;
				if (!int.TryParse(Console.ReadLine(), out choice))
				{
					Console.WriteLine("Invalid input. Please enter a number.");
					continue;
				}
				switch (choice)
				{
					case 1:
						AddUser(repo);
						break;
					case 2:
						AddExpense(repo);
						break;
					case 3:
						ViewAllExpenses(repo);
						break;
					case 4:
						DeleteUser(repo);
						break;
					case 5:
						DeleteExpense(repo);
						break;
					case 6:
						UpdateExpense(repo);
						break;
					case 0:
						running = false;
						break;
					default:
						Console.WriteLine("Invalid choice! Please choose a valid option.");
						break;
				}
			}
		}

		static void AddUser(IFinanceRepository repo)
		{
			Console.Write("Enter Username: ");
			string username = Console.ReadLine();
			Console.Write("Enter Password: ");
			string password = Console.ReadLine();
			Console.Write("Enter Email: ");
			string email = Console.ReadLine();

			User user = new User
			{
				Username = username,
				Password = password,
				Email = email
			};

			if (repo.CreateUser(user))
				Console.WriteLine("User created successfully!");
			else
				Console.WriteLine("Failed to create user.");
		}

		static void AddExpense(IFinanceRepository repo)
		{
			Console.Write("Enter User ID: ");
			int userId = int.Parse(Console.ReadLine());

			Console.Write("Enter Amount: ");
			decimal amount = decimal.Parse(Console.ReadLine());

			Console.Write("Enter Category ID: ");
			int categoryId = int.Parse(Console.ReadLine());

			Console.Write("Enter Description: ");
			string description = Console.ReadLine();

			Expense expense = new Expense
			{
				UserId = userId,
				Amount = amount,
				CategoryId = categoryId,
				Date = DateTime.Now,
				Description = description
			};

			if (repo.CreateExpense(expense))
				Console.WriteLine("Expense added successfully!");
			else
				Console.WriteLine("Failed to add expense.");
		}

		static void ViewAllExpenses(IFinanceRepository repo)
		{
			List<Expense> expenses = repo.GetAllExpenses();
			if (expenses.Count > 0)
			{
				Console.WriteLine("\nExpenses List:");
				foreach (var expense in expenses)
				{
					Console.WriteLine($"Expense ID: {expense.ExpenseId}, User ID: {expense.UserId}, Amount: {expense.Amount}, Category ID: {expense.CategoryId}, Date: {expense.Date}, Description: {expense.Description}");
				}
			}
			else
			{
				Console.WriteLine("No expenses found.");
			}
		}

		static void DeleteUser(IFinanceRepository repo)
		{
			Console.Write("Enter User ID to delete: ");
			int userId = int.Parse(Console.ReadLine());

			if (repo.DeleteUser(userId))
				Console.WriteLine("User deleted successfully!");
			else
				Console.WriteLine("Failed to delete user.");
		}

		static void DeleteExpense(IFinanceRepository repo)
		{
			Console.Write("Enter Expense ID to delete: ");
			int expenseId = int.Parse(Console.ReadLine());

			if (repo.DeleteExpense(expenseId))
				Console.WriteLine("Expense deleted successfully!");
			else
				Console.WriteLine("Failed to delete expense.");
		}

		static void UpdateExpense(IFinanceRepository repo)
		{
			Console.Write("Enter Expense ID to update: ");
			int expenseId = int.Parse(Console.ReadLine());

			Console.Write("Enter User ID: ");
			int userId = int.Parse(Console.ReadLine());

			Console.Write("Enter New Amount: ");
			decimal amount = decimal.Parse(Console.ReadLine());

			Console.Write("Enter New Category ID: ");
			int categoryId = int.Parse(Console.ReadLine());

			Console.Write("Enter New Description: ");
			string description = Console.ReadLine();

			Expense updatedExpense = new Expense
			{
				ExpenseId = expenseId,
				UserId = userId,
				Amount = amount,
				CategoryId = categoryId,
				Date = DateTime.Now,
				Description = description
			};

			if (repo.UpdateExpense(userId, updatedExpense))
				Console.WriteLine("Expense updated successfully!");
			else
				Console.WriteLine("Failed to update expense.");
		}
	}
}
