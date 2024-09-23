using Simple_Pay.Utils;
namespace Simple_Pay.Models;

public class Client
{
   
    public Client(string firsrname, string lastname, string cpfOrCnpj, string email, int userPassword, string tipeOfClient) 
    {
        FirstName = firsrname;
        LastName = lastname;
        CpfOrcnpj = cpfOrCnpj;
        UserPassword = userPassword;
        TypeOfClient = tipeOfClient;
        Email = email;
        
    }
    public string CpfOrcnpj {  get; set; }
    public int UserPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public  string TypeOfClient { get; set; }
    public Account Account { get; set; }
    public void DisplaClientInformation()
    {

        Console.WriteLine($"=================== Dados Cadastrais ==================\n");
        Console.WriteLine($"Nome: {FirstName} {LastName}");
        Console.WriteLine($"Cpf/Cnpj: {CpfOrcnpj}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Client: {TypeOfClient}");
        Console.WriteLine($"\n=======================================================");
        Console.ReadKey();
        new Atendimento().MenuInicial();

    }
}

