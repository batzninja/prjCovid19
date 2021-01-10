using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TESTECOVID19
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BuscaDadosOMS();
        }

        protected async void BuscaDadosOMS()
        {
            string URL = "https://api.github.com/CSSEGISandData/";
            string param = "COVID-19/blob/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";
            HttpClient OMS = new HttpClient();
            HttpResponseMessage dados = await OMS.GetAsync(URL+param);
            if (dados.StatusCode == HttpStatusCode.OK)
            {
                using (HttpContent conteudo = dados.Content)
                {
                    string resultado = await conteudo.ReadAsStringAsync();
                    var JSONresult = JToken.Parse(resultado);
                }
            }

        }
    }
}