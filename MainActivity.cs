using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;

namespace TipCalculadora
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        AppCompatEditText txtCuenta;
        AppCompatButton btnCalcular;
        AppCompatTextView txtPropina;
        AppCompatTextView txtTotal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            txtCuenta = FindViewById<AppCompatEditText>(Resource.Id.txtCuenta);

            txtPropina = FindViewById<AppCompatTextView>(Resource.Id.txtPropina);

            txtTotal = FindViewById<AppCompatTextView>(Resource.Id.txtTotal);

            btnCalcular = FindViewById<AppCompatButton>(Resource.Id.btnCalcular);

            btnCalcular.Click += OnCalculateClick;

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

        }

        public void OnCalculateClick(object sender, EventArgs e)
        {
            string txt = txtCuenta.Text;
            if (double.TryParse(txt, out double cuenta))
            {
                var propina = cuenta * 0.15;
                var total = cuenta + propina;

                txtPropina.Text = propina.ToString();
                txtTotal.Text = total.ToString();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}
