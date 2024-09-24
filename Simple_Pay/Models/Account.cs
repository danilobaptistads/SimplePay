using Simple_Pay.Utils;
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

        if (accountType == "PF") 
        {
            if ((Balance -= tranferValue) >= 0)
            {

                Transaction transaction = new(tranferValue, AccountId, destAccount);
                
                if (transaction.ExecTrasaction())
                {
                    
                    transaction.TransactionStatus = "Sussecs";
                    //Data.GetAccountByid(AccountId);
                   
                    Console.WriteLine("Trasação realizada com sucesso");
                    Data.SaveNewBAlance(AccountId, Balance);
                    Data.RegisterTrasaction("dbTransactions.json", transaction);

                    return;
                }
                Console.WriteLine("Não foi possivel realizar a transação");
                Balance = Balance += tranferValue;
                transaction.TransactionStatus = "Fail";
                Data.RegisterTrasaction("dbTransactions.json", transaction);
                return;
            }
            Console.WriteLine("Saldo insuficiente");
            return;
            
        }
    }

    public void Deposit(int value) 
    {
        Balance += value;
        Data.SaveNewBAlance(AccountId, Balance);
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

