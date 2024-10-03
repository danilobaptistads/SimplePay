using Simple_Pay.Utils;
using System.Text.Json;
using Newtonsoft.Json;
namespace Simple_Pay.Models;

public class Atendimento
{
     
    Validation validation = new Validation();
    public void MenuInicial()
    {
        Console.Clear();
        Console.WriteLine("===== Menu =====\n");
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Transferir");
        Console.WriteLine("3 - Saldo");
        Console.WriteLine("4 - Listar clientes");
        Console.WriteLine("\n================");

        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                Register();
                break;
            case 2:
                AccountTranfer();
                break;
            
                
        }   

    }
    private void Register()
    {
        Console.Clear();
        Console.WriteLine("=========== Cadastro ===========\n");
        Console.Write("Primeiro Nome: ");
        string firstName = Console.ReadLine();
        Console.Write("Sobrenome Nome ");
        string laststName = Console.ReadLine();
        string identifier;
        string email;
        string tipeOfClient;
        bool doControler = false;
        do
        {
            Console.Write("CPF ou CNPJ: ");
            identifier = Console.ReadLine();
            tipeOfClient = validation.TypeIdentifier(identifier);
            switch (tipeOfClient)
            {
                case "PF":
                    doControler = validation.checkCpf(identifier);
                    break;
                case "PJ":
                    doControler = validation.checkCnpj(identifier);
                    break;
                default:
                    Console.WriteLine("Número identificador invalido");
                    break;
            }
           
        } while (!doControler);
        
        do
        {
            Console.Write("Email: ");
            email = Console.ReadLine();
            doControler = validation.EmailIsUnique(email);
        } while (!doControler);
        
        Console.Write("Entre com uma senha de 6 digitos: ");
        int userPassword = int.Parse(Console.ReadLine());

        Client newClient = new(firstName, laststName, identifier, email, userPassword, tipeOfClient)
        { 
            Account = new Account(new Random().Next()),
        };
       
        string file = "dbContas.json";
        Data.SaveUser(file, newClient);

        Console.WriteLine($"Usuario {firstName}, criado com sucesso");
        Console.ReadKey();



        MenuInicial();

    }
    private void AccountTranfer()
    {
        Console.Clear();
        Console.Write("Entre com seu Cpf/Cnpj: ");
        string nIdentifier = Console.ReadLine();
        Console.Write("Sua senha: ");
        int pass = int.Parse(Console.ReadLine());

        var userValidation = validation.Access(nIdentifier, pass);
        if (userValidation)
        {
            Client client = Data.GetClientById(nIdentifier);
            if (validation.ValidationTypeOfUser(client.TypeOfClient))
            {
                Console.Clear();
                Console.WriteLine("Bem vindo!");

                Console.WriteLine("Qual valor deseja tranferir");
                int value = int.Parse(Console.ReadLine());
                Console.WriteLine("Conta de destino");
                int dstAccount = int.Parse(Console.ReadLine());

                client.Account.Transfer(value, dstAccount, client.TypeOfClient);
                return;
            }
            Console.WriteLine("Apenas Pessoas físicas podem realizar transferencias");
        }
    }
}