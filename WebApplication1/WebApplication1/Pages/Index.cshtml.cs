using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApplication1.Models;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        private async Task<string> downloadData()
        {
            string code = "USD";
            string table = "A";
            HttpClient client = new HttpClient();
            string call = "http://api.nbp.pl/api/exchangerates/rates/" + table + "/" + code + "/?format=json";
            string json = await client.GetStringAsync(call);
            return json;
        }
        private async Task<string> ShowCurRate()
        {
            string json = await downloadData();
            Currency cur = JsonConvert.DeserializeObject<Currency>(json);
            // label4.Text = cur.currency + "\nKurs kupna: " + cur.rates[0].bid.ToString() + " PLN  " + "\nKurs sprzedaży: " + cur.rates[0].ask.ToString() + " PLN";
            string m = cur.rates[0].bid.ToString();
            return m;
        }

        }
}