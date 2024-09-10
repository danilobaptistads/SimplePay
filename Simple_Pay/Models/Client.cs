using Simple_Pay.Utils;
namespace Simple_Pay.Models;

public class Client
{
    
    public Client(string firsrname, string lastname, string cpfOrCnpj,int userPassword, string email) 
    {
        FirstName = firsrname;
        LastName = lastname;
        CpfOrcnpj = cpfOrCnpj;
        UserPassword = userPassword;
        //TypeOfClient = CpfOrcnpj.CheckTypeIdentifier();
        Email = email;
    }
    public string CpfOrcnpj;
    public int UserPassword { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string TypeOfClient { get; set; }

    public void DisplaClientInformation()
    {

        Console.WriteLine($"=================== Dados Cadastrais ==================\n");
        Console.WriteLine($"Nome: {FirstName} {LastName}");
        Console.WriteLine($"Cpf/Cnpj: {CpfOrcnpj}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Client: {TypeOfClient}");
        Console.WriteLine($"\n=======================================================");

    }
}

