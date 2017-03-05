using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Project
{
    public partial class DaySelect : ContentPage
    {
        private string dates;

        public DaySelect()
        {
            InitializeComponent();

            //getDays();
        }

        public void getDays()
        {

            dates = Convert.ToString(DateTime.Today);
            
            String.Format("{0:dddd dd MMMM}", dates);
            //dates = dates + " " + Convert.ToString(DateTime.Now.AddDays(1));
            //dates = dates + " " + Convert.ToString(DateTime.Now.AddDays(2));
            //dates = dates + " " + Convert.ToString(DateTime.Now.AddDays(3));
            //dates = dates + " " + Convert.ToString(DateTime.Now.AddDays(4));
            //dates = dates + " " + Convert.ToString(DateTime.Now.AddDays(5));
            //dates = dates + " " + Convert.ToString(DateTime.Now.AddDays(6));

            //days.Text = Convert.ToString(dates);
        }
    }

}
