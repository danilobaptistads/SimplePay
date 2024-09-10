using System.Net;

namespace Simple_Pay.Models;

public class Transaction
{
    public int transactionId;
    public int TransactionValue { get; set; }
    public int TransactionOrigAccount { get; set; }
    public int TransactionDestnAccount { get; set; }

    public Transaction(int transactionValue, int origAccount,int destAccount)
    {
        TransactionValue = transactionValue;
        TransactionOrigAccount = origAccount;
        TransactionDestnAccount = destAccount;
    }

    
    public void ExecTrasaction()
    {
        if (ValidateTrasacion()) 
        {  

            
           
        }
        
          
    }

    private bool ValidateTrasacion() 
    {  
        return true; 
    }


    
}

