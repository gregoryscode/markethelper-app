using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace markethelperapp.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/LoginTheme", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            Setup();
        }

        private void Setup()
        {
            var btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            var lblRegister = FindViewById<TextView>(Resource.Id.lblRegister);
            var lblForgotPassword = FindViewById<TextView>(Resource.Id.lblForgotPassword);

            lblRegister.Click += LblRegister_Click;
            lblForgotPassword.Click += TxtForgotPassword_Click;
            btnLogin.Click += BtnLogin_Click;
        }

        private void LblRegister_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(AccountCreateActivity));
        }

        private void TxtForgotPassword_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ForgotPasswordActivity));
            Finish();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}