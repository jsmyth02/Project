using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using ModernHttpClient;
using Xamarin.Forms;

namespace Project
{
    public partial class ShoppingList : ContentPage
    {

        public ShoppingList()
        {
            InitializeComponent();

            MakeRequest();
        }

        public async void MakeRequest()
        {
            var client = new HttpClient(new NativeMessageHandler());
            //var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cdb38dd27831408bb6b0ffa5f746b34c");

            var uri = "https://dev.tescolabs.com/grocery/products/?query=ham&offset=0&limit=10&";

            var response = await client.GetStringAsync(uri);

            LabelOne.Text = Convert.ToString(response);
        }
    }
}
