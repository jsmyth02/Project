using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCLStorage;
using Realms;
using Xamarin.Forms;

namespace Project
{
    public partial class FoodDiary : ContentPage
    {
        private string breakfast;
        private string lunch;
        private string dinner;

        private readonly IFolder _rootFolder = FileSystem.Current.LocalStorage;


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

            Load("MondayDinner");

            // Store to database?
        }

        private void Dinner_Edit_Clicked(object sender, EventArgs e)
        {
            btnDinnerEdit.IsVisible = false;
            btnDinnerStore.IsVisible = true;
            lblDinner.IsVisible = false;
            edtDinner.IsVisible = true;
        }

        private async void Dinner_Store_Clicked(object sender, EventArgs e)
        {
            dinner = edtDinner.Text;
            lblDinner.Text = dinner;

            btnDinnerEdit.IsVisible = true;
            btnDinnerStore.IsVisible = false;
            lblDinner.IsVisible = true;
            edtDinner.IsVisible = false;

            await Save("MondayDinner", dinner);
            // Store to database?
        }

        //public void PCLCreateFile(string fileName, string content)
        //{
        //    IFolder localStorage = FileSystem.Current.LocalStorage;
        //    IFile file = localStorage.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting).Result;
        //    file.WriteAllTextAsync(content);
        //}

        //public string PCLReadFile(string fileName)
        //{
        //    IFolder localStorage = FileSystem.Current.LocalStorage;
        //    if (PCLCheckFileExists(fileName, FileStorageType.File))
        //    {
        //        IFile file = localStorage.GetFileAsync(fileName).Result;
        //        //return file.ReadAllTextAsync().Result; //This wouldn't work. You will hit deadlock. 
        //        return ReadFile(file, fileName).Result;
        //    }
        //    return string.Empty;
        //}

        //public async Task<string> ReadFile(IFile f, string fileName)
        //{
        //    return await Task.Run(() => f.ReadAllTextAsync()).ConfigureAwait(false);
        //}

        public async Task Save(string path, string name)
        {
            IFile file = await _rootFolder.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting);
            await file.WriteAllTextAsync(name);
        }

        public string Load(string path)
        {
            try
            {
                IFile file = _rootFolder.GetFileAsync(path).Result;
                return file.ReadAllTextAsync().Result;
            }
            catch (Exception)
            {
            }
            return null;
        }

        public interface ISettingsService
        {
            T GetValueOrDefault<T>(string key, T defaultValue = default(T));
            bool AddOrUpdateValue(string key, Object value);
            void Save();
        }
    }

}
