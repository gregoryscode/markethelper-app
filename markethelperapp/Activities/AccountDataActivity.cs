using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Button;
using Google.Android.Material.Snackbar;
using Google.Android.Material.TextField;
using markethelperapp.Helpers;
using System;


namespace markethelperapp.Activities
{
    [Activity(Label = "@string/title_account_data", Theme = "@style/AppTheme")]
    public class AccountDataActivity : AppCompatActivity
    {
        private LinearLayout _parent;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_account_data);

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
            _parent = FindViewById<LinearLayout>(Resource.Id.layoutAccountData);
            var btnCreate = FindViewById<MaterialButton>(Resource.Id.btnADSave);

            btnCreate.Click += BtnCreate_Click;
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Clear();

                Snackbar
                    .Make(_parent, "Dados alterados com sucesso.", 5000)
                    .SetAction("OK", (View.IOnClickListener)null).Show();
            }
        }

        private bool Validate()
        {
            var txtNameLayout = FindViewById<TextInputLayout>(Resource.Id.txtADNameLayout);
            var txtEmailLayout = FindViewById<TextInputLayout>(Resource.Id.txtADEmailLayout);
            var txtPaswordLayout = FindViewById<TextInputLayout>(Resource.Id.txtADPasswordLayout);
            var txtConfirmPasswordLayout = FindViewById<TextInputLayout>(Resource.Id.txtADConfirmPasswordLayout);

            var txtName = FindViewById<EditText>(Resource.Id.txtADName);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtADEmail);
            var txtPassword = FindViewById<EditText>(Resource.Id.txtADPassword);
            var txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtADConfirmPassword);

            bool validated = false;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtNameLayout.Error = Constants.AccountCreationFieldError;
            }
            else
            {
                txtNameLayout.Error = null;
                validated = true;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmailLayout.Error = Constants.AccountCreationFieldError;
            }
            else
            {
                txtEmailLayout.Error = null;
                validated = true;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPaswordLayout.Error = Constants.AccountCreationFieldError;
                validated = false;
            }
            else
            {
                txtPaswordLayout.Error = null;
                validated = true;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                txtConfirmPasswordLayout.Error = Constants.AccountCreationFieldError;
                validated = false;
            }
            else
            {
                txtConfirmPasswordLayout.Error = null;
                validated = true;
            }

            if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtConfirmPassword.Text) && (!txtPassword.Text.Equals(txtConfirmPassword.Text)))
            {
                txtConfirmPasswordLayout.Error = Constants.AccountDataPasswordError;
                validated = false;
            }
            else if (!string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtConfirmPassword.Text) && (txtPassword.Text.Equals(txtConfirmPassword.Text)))
            {
                txtConfirmPasswordLayout.Error = null;
                validated = true;
            }

            return validated;
        }

        private void Clear()
        {
            var txtPassword = FindViewById<EditText>(Resource.Id.txtADPassword);
            var txtConfirmPassword = FindViewById<EditText>(Resource.Id.txtADConfirmPassword);

            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
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