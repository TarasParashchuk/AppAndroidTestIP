using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using AppAndroidTestIP.Model;
using FFImageLoading;

namespace AppAndroidTestIP.Adapter
{
    class AdapterForList : BaseAdapter<Catalog>
    {
        private Context context;
        private List<Catalog> data;
        private ListViewAdapterViewHolder viewHolder;

        public AdapterForList(Context context, List<Catalog> data)
        {
            this.context = context;
            this.data = data;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Catalog this[int position]
        {
            get
            {
                return data[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            var item = data[position];

            if (view != null)
                viewHolder = view.Tag as ListViewAdapterViewHolder;
            else
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.list_item, null, false);

                viewHolder = new ListViewAdapterViewHolder();

                viewHolder.PhotoUrl = view.FindViewById<FFImageLoading.Views.ImageViewAsync>(Resource.Id.photo_catalog);
                viewHolder.NameCatalog = view.FindViewById<TextView>(Resource.Id.name_catalog);
                viewHolder.PriceCatalog = view.FindViewById<TextView>(Resource.Id.price_catalog);

                view.Tag = viewHolder;
            }

            ImageService.Instance.LoadUrl(item.PhotoUrl).WithCache(FFImageLoading.Cache.CacheType.All).Into(viewHolder.PhotoUrl);
            viewHolder.NameCatalog.Text = item.Name;
            viewHolder.PriceCatalog.Text = item.Price + " грн.";

            return view;
        }

        public override int Count
        {
            get
            {
                return data.Count;
            }
        }

    }

    class ListViewAdapterViewHolder : Java.Lang.Object
    {
        internal FFImageLoading.Views.ImageViewAsync PhotoUrl;
        internal TextView NameCatalog;
        internal TextView PriceCatalog;
    }
}