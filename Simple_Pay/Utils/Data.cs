using Newtonsoft.Json;
using Simple_Pay.Models;

namespace Simple_Pay.Utils;
internal class Data
{
    public static void SaveUser(string file, Client client)
    {
        string desserializedJson = File.ReadAllText(file);

        List<Client> listAccounts = JsonConvert.DeserializeObject<List<Client>>(desserializedJson);
        if (listAccounts != null)
        {
            listAccounts.Add(client);
            string serializeObject = JsonConvert.SerializeObject(listAccounts, Formatting.Indented);
            File.WriteAllText(file, serializeObject);
        }
        else
        {
            List<Client> newList = new List<Client>();

            newList.Add(client);
            string serializeObject = JsonConvert.SerializeObject(newList, Formatting.Indented);
            File.WriteAllText(file, serializeObject);
        }
    }

    public static Client GetClientById(string NIdentifier)
    {
        string desserializedJson = File.ReadAllText("dbContas.json");
        List<Client> listAccounts = JsonConvert.DeserializeObject<List<Client>>(desserializedJson);
        
        if (listAccounts != null)
        {
            for (int i = 0; i < listAccounts.Count; i++)
            {
                Client client = listAccounts[i];

                if (NIdentifier == client.CpfOrcnpj)
                {
                    return client;
                }

            }
        }
        return null;
    }
    
}
