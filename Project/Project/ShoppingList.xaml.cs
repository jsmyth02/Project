using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<ProductNames> productnames = new ObservableCollection<ProductNames>();

        public ShoppingList()
        {
            InitializeComponent();

            Products.ItemsSource = productnames;
        }

        public async void MakeRequest(string uri)
        {
            var client = new HttpClient(new NativeMessageHandler());
            //var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cdb38dd27831408bb6b0ffa5f746b34c");

            var response = await client.GetStringAsync(uri);

            var jsonObj = JsonConvert.DeserializeObject<RootObject>(response);

            foreach (var obj in jsonObj.uk.ghs.products.results)
            {
                productnames.Add(new ProductNames { DisplayName = Convert.ToString(obj.name) });
            }

        }

        private void Search_OnClicked(object sender, EventArgs e)
        {
            string searchedFood = foodSearched.Text;

            var uri = "https://dev.tescolabs.com/grocery/products/?query=" + searchedFood + "&offset=0&limit=10&";

            MakeRequest(uri);
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }
    }


    public class ProductNames
    {
        public string DisplayName { get; set; }
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
