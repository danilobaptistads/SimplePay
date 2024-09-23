namespace Simple_Pay.Models;
public class Account
{
    public Account(int accountID)
    {
        
        
        AccountId =  accountID;
        Balance = 0;
    }

    public int AccountId { get;  }
    public int Balance { get; set; }
    
    public void Transfer(int tranferValue, int destAccount, string accountType)
    {
        if (((Balance - tranferValue) >= 0) && (accountType == "Pf"))
        {
            Balance = Balance - tranferValue;
            
            Transaction transaction  = new(tranferValue, AccountId, destAccount);
            if (!transaction.ExecTrasaction())
            {
                Balance = Balance + tranferValue;
                return;
            }
            Console.WriteLine("Trasação realizada com sucesso");
        }


    }

    public void CheckAccountbalance()
    {
        Console.WriteLine($"Saldo em conta: {Balance}");
    }
    public void DisplayAccountInf()
    {
        Console.WriteLine($"=====================    Conta    =====================");
        Console.WriteLine($"                       {AccountId}                     ");
        Console.WriteLine($"=======================================================\n");
        Console.WriteLine($"Saldo disponivel: {Balance}");
        Console.WriteLine($"\n=======================================================");
    }
}

