using Simple_Pay.Data;
using Microsoft.EntityFrameworkCore;

using var contex = new SimpleplayContext();

contex.Database.OpenConnection();
Console.WriteLine(contex.Database.GetDbConnection().State);