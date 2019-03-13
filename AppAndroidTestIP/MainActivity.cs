using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Widget;
using AppAndroidTestIP.Adapter;
using AppAndroidTestIP.DataBase;
using AppAndroidTestIP.Model;

namespace AppAndroidTestIP
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView ListViewCatalog;
        AdapterForList adapter_catalog;
        List<Catalog> ListCatalog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Title = "Cтворення запису";
            ListViewCatalog = FindViewById<ListView>(Resource.Id.ListForCatalog);
            ListCatalog = new GetCatalog<Catalog>().GetItems();
            adapter_catalog = new AdapterForList(this, ListCatalog);
            ListViewCatalog.Adapter = adapter_catalog;

            ListViewCatalog.ItemClick += ListViewCatalog_ItemClick;

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        private void ListViewCatalog_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var intent = new Intent(this, typeof(ViewActivity));
            intent.PutExtra("id", ListCatalog[e.Position].Id);
            StartActivity(intent);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(ViewActivity));
            intent.PutExtra("id", 0);
            StartActivity(intent);
        }
	}
}

