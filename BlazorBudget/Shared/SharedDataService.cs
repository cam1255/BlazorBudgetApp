using System.Collections.Generic;

public class SharedDataService
{
    public FinancialData FinancialData { get; set; } = new FinancialData();

    public Dictionary<string, List<Expense>> MonthlyExpenses { get; set; } = new Dictionary<string, List<Expense>>();
}
