namespace Simple_Pay.Models;
public class Account
{
    public Account(Client client)
    {
        
        HolderInf = client;
        AccountId =  new Random().Next();
        Balance = 0;
    }

    public Client HolderInf { get;  }
    public int AccountId { get;  }
    public int Balance { get; set; }
    
    public void Transfer(int tranferValue, int destAccount, string accountType)
    {
        if (((Balance - tranferValue) >= 0) && (accountType == "Pf"))
        {
            Balance = Balance - tranferValue;
            
            Transaction transaction  = new(tranferValue, AccountId, destAccount);
            
            
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
        Console.WriteLine($"Nome do titular: {HolderInf.FirstName} {HolderInf.LastName}");
        Console.WriteLine($"Cpf/Cnpj do  Titular: {HolderInf.CpfOrcnpj}");
        Console.WriteLine($"Saldo disponivel: {Balance}");
        Console.WriteLine($"\n=======================================================");
    }
}

