using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Snackbar;
using System;

namespace markethelperapp.Activities
{
    [Activity(Label = "@string/title_forgot_password", Theme = "@style/LoginTheme")]
    public class ForgotPasswordActivity : AppCompatActivity
    {
        private LinearLayout _parent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_forgot_password);

            Setup();
        }

        private void Setup()
        {
            _parent = FindViewById<LinearLayout>(Resource.Id.layoutForgotPassword);
            var btnBack = FindViewById<Button>(Resource.Id.btnBack);
            var btnSend = FindViewById<Button>(Resource.Id.btnSend);

            btnBack.Click += BtnBack_Click;
            btnSend.Click += BtnSend_Click;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(LoginActivity));
            Finish();
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            var txtEmail = FindViewById<EditText>(Resource.Id.txtForgotPasswordEmail);

            if(string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                Snackbar
                    .Make(_parent, "O e-mail informado é inválido.", Snackbar.LengthLong)
                    .SetAction("OK", (Android.Views.View.IOnClickListener)null).Show();
            }
            else
            {
                txtEmail.Text = string.Empty;

                Snackbar
                    .Make(_parent, "As instruções foram enviadas com sucesso.", Snackbar.LengthLong)
                    .SetAction("OK", (Android.Views.View.IOnClickListener)null).Show();
            }
        }
    }
}