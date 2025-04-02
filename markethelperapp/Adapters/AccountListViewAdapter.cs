using Android.Content;
using Android.Views;
using Android.Widget;
using markethelperapp.Models;
using System.Collections.Generic;

namespace markethelperapp.Adapters
{
    public class AccountListViewAdapter : BaseAdapter<ImageListView>
    {
        public List<ImageListView> _list;
        private Context _context;

        public AccountListViewAdapter(Context context, List<ImageListView> list)
        {
            _list = list;
            _context = context;
        }

        public override ImageListView this[int position]
        {
            get
            {
                return _list[position];
            }
        }

        public override int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(_context).Inflate(Resource.Layout.list_view_account_row, parent, false);
            }

            ImageView imgViolationItem = row.FindViewById<ImageView>(Resource.Id.imgAccountRow);
            imgViolationItem.SetImageResource(_list[position].Image);

            TextView txtViolationItem = row.FindViewById<TextView>(Resource.Id.txtAccountRow);
            txtViolationItem.Text = _list[position].Description;

            return row;
        }
    }
}