using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using markethelperapp.Adapters;
using markethelperapp.Models;
using System.Collections.Generic;

namespace markethelperapp.Activities
{
    [Activity(Label = "@string/title_account", Theme = "@style/AppTheme")]
    public class AccountActivity : AppCompatActivity
    {
        private List<ImageListView> _menu;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_account);

            SetupToolbar();

            SetupFields();
        }

        private void SetupToolbar()
        {
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
        }

        private void SetupFields()
        {
            _menu = new List<ImageListView>()
            {
                new ImageListView()
                {
                    Image = Resource.Mipmap.ic_action_profile,
                    Description = "Dados"
                },
                new ImageListView()
                {
                    Image = Resource.Mipmap.ic_action_notification,
                    Description = "Notificações"
                }
            };

            var list = FindViewById<ListView>(Resource.Id.listViewAccount);
            var adapter = new AccountListViewAdapter(this, _menu);
            list.Adapter = adapter;
            list.ItemClick += List_ItemClick;
        }

        private void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (_menu[e.Position].Description.Equals("Dados"))
            {
                StartActivity(typeof(AccountDataActivity));
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }

            return true;
        }
    }
}