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

            var jsonObj = JsonConvert.DeserializeObject<RootObject>(response);

            foreach (var obj in jsonObj.uk.ghs.products.results)
            {
                LabelOne.Text = LabelOne.Text + Convert.ToString(obj.name);
            }

        }
    }


    public class Result
    {
        public string image { get; set; }
        public int tpnb { get; set; }
        public int UnitOfSale { get; set; }
        public List<string> description { get; set; }
        public string UnitQuantity { get; set; }
        public double unitprice { get; set; }
        public bool IsSpecialOffer { get; set; }
        public double price { get; set; }
        public string ContentsMeasureType { get; set; }
        public string PromotionDescription { get; set; }
        public string name { get; set; }
        public double AverageSellingUnitWeight { get; set; }
        public double ContentsQuantity { get; set; }
    }

    public class Totals
    {
        public int all { get; set; }
        public int offer { get; set; }
        public int @new { get; set; }
    }

    public class Products
    {
        public List<Result> results { get; set; }
        public List<object> suggestions { get; set; }
        public Totals totals { get; set; }
    }

    public class Ghs
    {
        public Products products { get; set; }
    }

    public class Uk
    {
        public Ghs ghs { get; set; }
    }

    public class RootObject
    {
        public Uk uk { get; set; }
    }


    //public class Rootobject
    //{
    //    public List<Products> products { get; set; }
    //}

    //public class Products
    //{
    //    public List<Results> results { get; set; }
    //}

    //public class Results
    //{
    //    public string name { get; set; }
    //}
}
