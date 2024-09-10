namespace Simple_Pay.Utils;
using Simple_Pay.Models;

internal class Data
{
    public List<Client> clients = new();
    private List<Account> accounts = new();
    private List<Transaction> transactions = new();


    public void AddClient(Client client)
    {
        if (clients.Count() != 0)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].CpfOrcnpj != client.CpfOrcnpj || clients[i].Email != client.Email)
                {
                    Console.WriteLine(clients.Count());
                    clients.Add(client);
                    Console.WriteLine("Client registrado com sucesso");
                    Console.WriteLine(clients.Count());
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Já existe cadastro com email ou cpf");
                }
            }

        }
        else
        {
            Console.WriteLine(clients.Count());
            clients.Add(client);
            Console.WriteLine("Client registrado com sucesso");
            Console.WriteLine(clients.Count());
        }

    }

    public void AddAccount(Account account)
    {
        if (accounts.Count() != 0) 
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                if (accounts[i].AccountId != account.AccountId)
                {
                    accounts.Add(account);
                    Console.WriteLine("conta criada com sucesso");
                }
                else
                {
                    Console.WriteLine("Não foi possivel criar a conta");
                }
            }
        }
        else
        {
            accounts.Add(account);
            Console.WriteLine("conta criada com sucesso");
        }
        
    }

    public void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public Client GetClient(string identifier)
    {
        for (int i = 0; i < clients.Count; i++)
        {
            if (identifier == clients[i].CpfOrcnpj) 
            {
                return clients[i];
            }
          
        }
        Console.WriteLine($"Não foi possivel encontrar usuário com o identificador {identifier}");
        return null;
    }

    public Account GetAccount(int idaccount)
    {
        for (int i = 0; i < accounts.Count; i++)
        {
            if (idaccount == accounts[i].AccountId) ;
            return accounts[i];
        }
        Console.WriteLine($"Não foi possivel encontrar a conta com id {idaccount}");
        return null;

    }

    public Transaction GetTransaction(int trasacioid)
    { 
        for(int i = 0; i < transactions.Count(); i++)
        {
            if (transactions[i].transactionId == trasacioid)
            {
                return transactions[i];
            }
        }
        Console.WriteLine($"Não foi possivel encontrar a conta com id {trasacioid}");
        return null;
    }

}