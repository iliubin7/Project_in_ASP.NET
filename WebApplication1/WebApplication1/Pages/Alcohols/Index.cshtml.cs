using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.Alcohols
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1Context _context;

        public IndexModel(WebApplication1Context context)
        {
            _context = context;
        }

        public IList<Alcohol> Alcohol { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            string currencyRateEUR = await ShowCurRate("EUR");
            ViewData["CurrencyRateEUR"] = currencyRateEUR;
            string currencyRateUSD = await ShowCurRate("USD");
            ViewData["CurrencyRateUSD"] = currencyRateUSD;
            string currencyRateCHF = await ShowCurRate("CHF");
            ViewData["CurrencyRateCHF"] = currencyRateCHF;
            string currencyRateGBP = await ShowCurRate("GBP");
            ViewData["CurrencyRateGBP"] = currencyRateGBP;

            Alcohol = await _context.Alcohol.ToListAsync();

            return Page();
        }

        private async Task<string> downloadData(string code)
        {
            string table = "A";
            HttpClient client = new HttpClient();
            string call = "http://api.nbp.pl/api/exchangerates/rates/" + table + "/" + code + "/?format=json";
            string json = await client.GetStringAsync(call);
            return json;
        }

        private async Task<string> ShowCurRate(string code)
        {
            string json = await downloadData(code);
            Currency cur = JsonConvert.DeserializeObject<Currency>(json);
            string m = string.Empty;
            m = cur.rates[0].mid.ToString();
            return m;
        }
    }
}
