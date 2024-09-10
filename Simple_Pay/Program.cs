using Simple_Pay.Models;
using Simple_Pay.Utils;

Data  data = new Data();

Client client001 = new("Jenifer", "stela soza Baptista", ("13194003"), 1104, "jenifers@hotmail.com");

data.AddClient(client001);

Client infoclient = data.GetClient("13194003");

infoclient.DisplaClientInformation();