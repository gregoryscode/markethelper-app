using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Button;
using Google.Android.Material.Snackbar;
using Google.Android.Material.TextField;
using markethelperapp.Helpers;
using System.Text.RegularExpressions;

namespace markethelperapp.Activities
{
    [Activity(Label = "@string/title_account_create", Theme = "@style/AppTheme")]
    public class AccountCreateActivity : AppCompatActivity
    {
        private LinearLayout _parent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_account_create);

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
            _parent = FindViewById<LinearLayout>(Resource.Id.layoutAccountCreate);
            var chkLegal = FindViewById<Google.Android.Material.CheckBox.MaterialCheckBox>(Resource.Id.chkLegalPerson);
            var btnCreate = FindViewById<MaterialButton>(Resource.Id.btnRegister);
            var txtCpf = FindViewById<EditText>(Resource.Id.txtACCpf);

            chkLegal.CheckedChange += ChkLegal_CheckedChange;
            btnCreate.Click += BtnCreate_Click;
        }

        private void BtnCreate_Click(object sender, System.EventArgs e)
        {
            if (Validate())
            {
                Clear();

                Snackbar
                    .Make(_parent, "Conta cadastrada com sucesso. Após aprovação, você receberá um e-mail com instruções.", 5000)
                    .SetAction("OK", (Android.Views.View.IOnClickListener)null).Show();
            }
        }

        private bool Validate()
        {
            var txtCpfLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCpfLayout);
            var txtCnpjLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCnpjLayout);
            var txtCustomerNameLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCustomerNameLayout);
            var txtNameLayout = FindViewById<TextInputLayout>(Resource.Id.txtACNameLayout);
            var txtEmailLayout = FindViewById<TextInputLayout>(Resource.Id.txtACEmailLayout);
            var txtCellphoneLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCellphoneLayout);
            var txtCepLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCepLayout);
            var txtStreetLayout = FindViewById<TextInputLayout>(Resource.Id.txtACStreetLayout);
            var txtNumberLayout = FindViewById<TextInputLayout>(Resource.Id.txtACNumberLayout);           

            var txtCpf = FindViewById<EditText>(Resource.Id.txtACCpf);
            var txtCnpj = FindViewById<EditText>(Resource.Id.txtACCnpj);
            var txtCustomerName = FindViewById<EditText>(Resource.Id.txtACCustomerName);
            var txtName = FindViewById<EditText>(Resource.Id.txtACName);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtACEmail);
            var txtCellphone = FindViewById<EditText>(Resource.Id.txtACCellphone);
            var txtCep = FindViewById<EditText>(Resource.Id.txtACCep);
            var txtStreet = FindViewById<EditText>(Resource.Id.txtACStreet);
            var txtNumber = FindViewById<EditText>(Resource.Id.txtACNumber);

            bool validated = false;

            if (txtCnpjLayout.Visibility == ViewStates.Visible && string.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                txtCnpjLayout.Error = Constants.AccountCreationFieldError;
            }
            else if (txtCpfLayout.Visibility == ViewStates.Visible && !string.IsNullOrWhiteSpace(txtCnpj.Text))
            {
                txtCnpjLayout.Error = null;
                validated = true;
            }

            if (txtCustomerNameLayout.Visibility == ViewStates.Visible && string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                txtCustomerNameLayout.Error = Constants.AccountCreationFieldError;
            }
            else if (txtCpfLayout.Visibility == ViewStates.Visible && !string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                txtCustomerNameLayout.Error = null;
                validated = true;
            }

            if (txtCpfLayout.Visibility == ViewStates.Visible && string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                txtCpfLayout.Error = Constants.AccountCreationFieldError;
            }
            else if (txtCpfLayout.Visibility == ViewStates.Visible && !string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                txtCpfLayout.Error = null;
                validated = true;
            }

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

            if (string.IsNullOrWhiteSpace(txtCellphone.Text))
            {
                txtCellphoneLayout.Error = Constants.AccountCreationFieldError;
            }
            else
            {
                txtCellphoneLayout.Error = null;
                validated = true;
            }

            if (string.IsNullOrWhiteSpace(txtCep.Text))
            {
                txtCepLayout.Error = Constants.AccountCreationFieldError;
            }
            else
            {
                txtCepLayout.Error = null;
                validated = true;
            }

            if (string.IsNullOrWhiteSpace(txtStreet.Text))
            {
                txtStreetLayout.Error = Constants.AccountCreationFieldError;
            }
            else
            {
                txtStreetLayout.Error = null;
                validated = true;
            }

            if (string.IsNullOrWhiteSpace(txtNumber.Text))
            {
                txtNumberLayout.Error = Constants.AccountCreationFieldError;
            }
            else
            {
                txtNumberLayout.Error = null;
                validated = true;
            }

            return validated;
        }

        private void Clear()
        {
            var txtCpf = FindViewById<EditText>(Resource.Id.txtACCpf);
            var txtCnpj = FindViewById<EditText>(Resource.Id.txtACCnpj);
            var txtCustomerName = FindViewById<EditText>(Resource.Id.txtACCustomerName);
            var txtName = FindViewById<EditText>(Resource.Id.txtACName);
            var txtEmail = FindViewById<EditText>(Resource.Id.txtACEmail);
            var txtCellphone = FindViewById<EditText>(Resource.Id.txtACCellphone);
            var txtCep = FindViewById<EditText>(Resource.Id.txtACCep);
            var txtStreet = FindViewById<EditText>(Resource.Id.txtACStreet);
            var txtNumber = FindViewById<EditText>(Resource.Id.txtACNumber);

            txtCpf.Text = string.Empty;
            txtCnpj.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCellphone.Text = string.Empty;
            txtCep.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtNumber.Text = string.Empty;
        }

        private void ChkLegal_CheckedChange(object sender, Android.Widget.CompoundButton.CheckedChangeEventArgs e)
        {
            var txtCnpjLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCnpjLayout);
            var txtCpfLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCpfLayout);
            var txtCustomerNameLayout = FindViewById<TextInputLayout>(Resource.Id.txtACCustomerNameLayout);


            if (e.IsChecked)
            {
                txtCpfLayout.Visibility = ViewStates.Gone;
                txtCnpjLayout.Visibility = ViewStates.Visible;
                txtCustomerNameLayout.Visibility = ViewStates.Visible;
            }
            else
            {
                txtCpfLayout.Visibility = ViewStates.Visible;
                txtCnpjLayout.Visibility = ViewStates.Gone;
                txtCustomerNameLayout.Visibility = ViewStates.Gone;
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