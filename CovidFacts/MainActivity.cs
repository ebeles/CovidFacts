using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;

namespace CovidFacts
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<string> facts = new List<string>()
        {
            "COVID-19 is an illnes caused by a virus that can be spread from a person to a person",
            "COVID-19 sympoms can range from mild (or no symptoms) to severe illness",
            "If you are sick, you should stay at home and warn people",
            "Avoid public transportation, ride-sharing or taxis",
            "If you need medical attention, you should call ahead"
        };

        private Button btn_fact;
        private TextView txt_fact;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btn_fact = FindViewById<Button>(Resource.Id.btn_fact);
            txt_fact = FindViewById<TextView>(Resource.Id.text_fact);

            btn_fact.Click += OnFactButtonClicked;
            
        }
        
        private void OnFactButtonClicked(object sender, System.EventArgs e)
        {
            txt_fact.Text = GetRandomFact();
        }

        string GetRandomFact()
        {
            Random random = new Random();
            var iRandom = random.Next(facts.Count);
            var mySelectedRandomFact = facts[iRandom];

            return mySelectedRandomFact;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}