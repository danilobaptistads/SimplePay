using Simple_Pay.Utils;
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
       
    public bool ExecTrasaction()
    {   
        if (ValidateTrasacion()) 
        {  
            //Data data = new Data();
            //Account dstaccount = data.GetAccountByid(TransactionDestnAccount);
            //dstaccount.Balance = dstaccount.Balance + TransactionValue;
            return true;
           
        }
        return false;
          
    }

    private bool ValidateTrasacion() 
    {  
        //Data data = new Data();
        //if (data.GetAccountByid(TransactionDestnAccount) != null)
        //{
        //    return true;
        //}
        return false;
    }

    
}

