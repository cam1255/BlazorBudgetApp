public class Expense
{
    public string Name { get; set; }
    public string Amount { get; set; }
    public string Month { get; set; }
    public Expense()
    {
		Month = DateOnly.FromDateTime(dateTime: DateTime.Now).Month.ToString();
        Name = "";
        Amount = "";
    }

}