using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using AppAndroidTestIP.DataBase;
using AppAndroidTestIP.Model;

namespace AppAndroidTestIP
{
    [Activity(Label = "ViewActivity")]
    public class ViewActivity : AppCompatActivity
    {
        EditText PhotoCatalog;
        EditText PriceCatalog;
        EditText NameCatalog;
        Button ButtonSave;
        GetCatalog<Catalog> catalog;
        int id;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.view_item);

            Title = "Опис каталогу";
            catalog = new GetCatalog<Catalog>();
            id = Intent.GetIntExtra("id", 0);

            ButtonSave = FindViewById<Button>(Resource.Id.SaveElement);
            PhotoCatalog = FindViewById<EditText>(Resource.Id.PhotoCatalog);
            NameCatalog = FindViewById<EditText>(Resource.Id.NameCatalog);
            PriceCatalog = FindViewById<EditText>(Resource.Id.PriceCatalog);
            ButtonSave.Click += ButtonSave_Click;

            if (id != 0)
            {
                var item = catalog.GetItem(id);
                PhotoCatalog.Text = item.PhotoUrl;
                NameCatalog.Text = item.Name;
                PriceCatalog.Text = item.Price.ToString();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var message = string.Empty;
            var item_catalog = new Catalog { Id = id, PhotoUrl = PhotoCatalog.Text, Name = NameCatalog.Text, Price = Convert.ToDouble(PriceCatalog.Text.Replace(".", ",")) };

            if (id != 0)
            {
                catalog.SaveItem(item_catalog);
                message = "Оновлено елемент каталогу ";
            }
            else
            {
                catalog.InsertItem(item_catalog);
                message = "Створено новий елемент каталогу ";
            }

            Toast.MakeText(this, message + item_catalog.Name, ToastLength.Short).Show();
            StartActivity(typeof(MainActivity));
        }
    }
}