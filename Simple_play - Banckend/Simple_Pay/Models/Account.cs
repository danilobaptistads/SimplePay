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
    
}

