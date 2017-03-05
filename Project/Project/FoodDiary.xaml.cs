using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Project
{
    public partial class FoodDiary : ContentPage
    {
        private string breakfast;
        private string lunch;
        private string dinner;


        public FoodDiary()
        {
            InitializeComponent();
        }

        private void Breakfast_Edit_Clicked(object sender, EventArgs e)
        {
            btnBreakfastEdit.IsVisible = false;
            btnBreakfastStore.IsVisible = true;
            lblBreakfast.IsVisible = false;
            edtBreakfast.IsVisible = true;
        }

        private void Breakfast_Store_Clicked(object sender, EventArgs e)
        {
            breakfast = edtBreakfast.Text;
            lblBreakfast.Text = breakfast;

            btnBreakfastStore.IsVisible = false;
            btnBreakfastEdit.IsVisible = true;
            lblBreakfast.IsVisible = true;
            edtBreakfast.IsVisible = false;

            // Store to database?
        }

        private void Lunch_Edit_Clicked(object sender, EventArgs e)
        {
            btnLunchEdit.IsVisible = false;
            btnLunchStore.IsVisible = true;
            lblLunch.IsVisible = false;
            edtLunch.IsVisible = true;
        }

        private void Lunch_Store_Clicked(object sender, EventArgs e)
        {
            lunch = edtLunch.Text;
            lblLunch.Text = lunch;

            btnLunchEdit.IsVisible = true;
            btnLunchStore.IsVisible = false;
            lblLunch.IsVisible = true;
            edtLunch.IsVisible = false;

            // Store to database?
        }

        private void Dinner_Edit_Clicked(object sender, EventArgs e)
        {
            btnDinnerEdit.IsVisible = false;
            btnDinnerStore.IsVisible = true;
            lblDinner.IsVisible = false;
            edtDinner.IsVisible = true;
        }

        private void Dinner_Store_Clicked(object sender, EventArgs e)
        {
            dinner = edtDinner.Text;
            lblDinner.Text = dinner;

            btnDinnerEdit.IsVisible = true;
            btnDinnerStore.IsVisible = false;
            lblDinner.IsVisible = true;
            edtDinner.IsVisible = false;

            // Store to database?
        }
    }
}
