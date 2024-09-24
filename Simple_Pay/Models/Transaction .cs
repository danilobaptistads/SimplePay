using Simple_Pay.Utils;
namespace Simple_Pay.Models;
public class Transaction
{
    public int transactionId;
    public int TransactionValue { get; set; }
    public int TransactionOrigAccount { get; set; }
    public int TransactionDestnAccount { get; set; }
    public string TransactionStatus { get; set; }

    public Transaction(int transactionValue, int origAccount,int destAccount)
    {
        TransactionValue = transactionValue;
        TransactionOrigAccount = origAccount;
        TransactionDestnAccount = destAccount;
       
    }
       
    public bool ExecTrasaction()
    {   
        if (ValidateTrasacion()) 
        {  
            Account dstaccount = Data.GetAccountByid(TransactionDestnAccount);
            int dstNewBalance = dstaccount.Balance + TransactionValue;
            Data.SaveNewBAlance(dstaccount.AccountId, dstNewBalance);
            return true;
           
        }
        return false;
          
    }


    private bool ValidateTrasacion() 
    {  
        if (Data.GetAccountByid(TransactionDestnAccount) != null)
        {
            return true;
        }
        return false;
    }

    
}

