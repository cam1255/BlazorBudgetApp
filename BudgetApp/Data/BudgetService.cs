using System.Diagnostics.Eventing.Reader;

namespace BudgetApp.Data
{
	public class BudgetService
	{
		private static List<Entry> expenses = new List<Entry>();
		private static decimal Income = 0;
		private static decimal CurrentBankAmount = 0;
		
		public async Task<bool> AddEntry(Entry newEntry)
		{
            expenses.Add(newEntry);
			return true;
		}

		public async Task<List<Entry>> GetAllEntries()
		{
			return expenses;
		}
		public async Task<bool> SetIncome(decimal income)
		{
			Income = income;
			return true;
		}
		public async Task<decimal> GetIncome()
		{
			return Income;
		}

		public async Task<bool> SetBankAmount(decimal bankAmount)
		{
			CurrentBankAmount = bankAmount;
			return true;
		}
		public async Task<decimal> GetBankAmount()
		{
			return CurrentBankAmount;
		}
	}
}
