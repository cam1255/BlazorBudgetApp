
public class FinancialData
{
    public decimal Gross { get; set; }
    public Deductions TaxDeductions { get; set; } = new Deductions();
    public Deductions PreTaxDeductions { get; set; } = new Deductions();
    public decimal TotalDeductions => TaxDeductions.CalculateTotalDeductions(Gross) + PreTaxDeductions.CalculateTotalPretaxDeductions(Gross);
    public decimal Net => Gross - TotalDeductions;
    public decimal NetPerPaycheck => Net / 24;
}

public class Deductions
{
    public decimal CalculateFederalTax(decimal grossIncome)
    {
        decimal tax = 0;

        if (grossIncome <= 9950)
            tax = grossIncome * 0.10M;
        else if (grossIncome <= 40525)
            tax = (9950 * 0.10M) + (grossIncome - 9950) * 0.12M;
        else if (grossIncome <= 86375)
            tax = (9950 * 0.10M) + (40525 - 9950) * 0.12M + (grossIncome - 40525) * 0.22M;
        else if (grossIncome <= 164925)
            tax = (9950 * 0.10M) + (40525 - 9950) * 0.12M + (86375 - 40525) * 0.22M + (grossIncome - 86375) * 0.24M;
        else if (grossIncome <= 209425)
            tax = (9950 * 0.10M) + (40525 - 9950) * 0.12M + (86375 - 40525) * 0.22M + (164925 - 86375) * 0.24M + (grossIncome - 164925) * 0.32M;
        else if (grossIncome <= 523600)
            tax = (9950 * 0.10M) + (40525 - 9950) * 0.12M + (86375 - 40525) * 0.22M + (164925 - 86375) * 0.24M + (209425 - 164925) * 0.32M + (grossIncome - 209425) * 0.35M;
        else // For grossIncome > 523600
            tax = (9950 * 0.10M) + (40525 - 9950) * 0.12M + (86375 - 40525) * 0.22M + (164925 - 86375) * 0.24M + (209425 - 164925) * 0.32M + (523600 - 209425) * 0.35M + (grossIncome - 523600) * 0.37M;

        return tax;
    }
    public decimal CalculateTotalDeductions(decimal grossIncome)
    {
        decimal fedTax = CalculateFederalTax(grossIncome);
        return fedTax + (grossIncome * (FICA / 100 + Medicare / 100 + StateTax / 100 + LocalTax / 100));
    }
    public decimal CalculateTotalPretaxDeductions(decimal grossIncome)
    {
        
        return (grossIncome * (Retirement401k / 100) + PreTaxTotal);
    }
    public decimal FICA { get; set; }
    public decimal Medicare { get; set; }
    public decimal StateTax { get; set; }
    public decimal LocalTax { get; set; }
    public decimal Vision { get; set; }
    public decimal Retirement401k { get; set; }
    public decimal PreTaxTotal => Vision;
}
