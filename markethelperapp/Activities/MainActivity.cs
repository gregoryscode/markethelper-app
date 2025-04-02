using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using System.Collections.Generic;

namespace markethelperapp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private List<AndroidX.Fragment.App.Fragment> _fragments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _fragments = new List<AndroidX.Fragment.App.Fragment>();
            _fragments.Add(new HomeFragment());
            _fragments.Add(new PurchaseFragment());
            _fragments.Add(new ProfileFragment());

            SupportFragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.content, _fragments[0])
                .Commit();

            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    {
                        SupportFragmentManager
                            .BeginTransaction()
                            .Replace(Resource.Id.content, _fragments[0])
                            .Commit();

                        return true;
                    }

                case Resource.Id.navigation_purchase:
                    {
                        SupportFragmentManager
                            .BeginTransaction()
                            .Replace(Resource.Id.content, _fragments[1])
                            .Commit();

                        return true;
                    }

                case Resource.Id.navigation_profile:
                    {
                        SupportFragmentManager
                            .BeginTransaction()
                            .Replace(Resource.Id.content, _fragments[2])
                            .Commit();

                        return true;
                    }
            }

            return false;
        }
    }
}

