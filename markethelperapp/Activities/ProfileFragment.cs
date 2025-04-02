using Android.OS;
using Android.Views;
using Android.Widget;
using Google.Android.Material.Button;

namespace markethelperapp.Activities
{
    public class ProfileFragment : AndroidX.Fragment.App.Fragment 
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            LinearLayout layout = inflater.Inflate(Resource.Layout.fragment_profile, container, false) as LinearLayout;

            SetupFields(layout);

            return layout;
        }

        private void SetupFields(LinearLayout layout)
        {
            var btnAccount = layout.FindViewById<MaterialButton>(Resource.Id.btnAccount);
            var btnHelp = layout.FindViewById<MaterialButton>(Resource.Id.btnHelp);
            var btnExit = layout.FindViewById<MaterialButton>(Resource.Id.btnExit);

            btnAccount.Click += BtnAccount_Click;
            btnHelp.Click += BtnHelp_Click;
            btnExit.Click += BtnExit_Click;
        }

        private void BtnAccount_Click(object sender, System.EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this.Context, typeof(AccountActivity)));
        }

        private void BtnHelp_Click(object sender, System.EventArgs e) { }

        private void BtnExit_Click(object sender, System.EventArgs e)
        {
            StartActivity(new Android.Content.Intent(this.Context, typeof(LoginActivity)));
            Activity.Finish();
        }
    }
}