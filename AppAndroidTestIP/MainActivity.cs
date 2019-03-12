using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using AppAndroidTestIP.Adapter;
using AppAndroidTestIP.DataBase;
using AppAndroidTestIP.Model;

namespace AppAndroidTestIP
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        AdapterForList adapter_catalog;
        ListView ListViewCatalog;
        List<Catalog> ListCatalog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            
            ListViewCatalog = FindViewById<ListView>(Resource.Id.ListForCatalog);
            var list_catalog = new GetCatalog<Catalog>().GetItems();
            adapter_catalog = new AdapterForList(this, ListCatalog);
            ListViewCatalog.Adapter = adapter_catalog;

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }
        
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(ViewActivity));
            //intent.PutExtra("about_category", string.Empty);
            StartActivity(intent);
        }
	}
}

