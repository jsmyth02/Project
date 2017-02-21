using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Project
{
    public partial class HomePage : MasterDetailPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Home_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;
        }

        private void FoodDiary_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FoodDiary());
            IsPresented = false;
        }

        private void ShoppingList_OnClicked(object sender, EventArgs e)
        {
            Detail = new TabbedPage
            {
                Children =
                {
                    new ShoppingList(),
                    new ShoppingListView()
                }
            };
            IsPresented = false;
        }


    }
}
