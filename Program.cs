using Newtonsoft.Json.Linq;

var client = new HttpClient();
var kanyeURL = "https://api.kanye.rest/";
var swansonURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
var ronResponse = client.GetStringAsync(swansonURL).Result;
var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
for(int i =0; i < 10; i++)
{
    Console.WriteLine(ronQuote);
    Console.WriteLine($"\"{kanyeQuote}\"");
    kanyeResponse = client.GetStringAsync(kanyeURL).Result;
    kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
    ronResponse = client.GetStringAsync(swansonURL).Result;
    ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
}
