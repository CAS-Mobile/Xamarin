using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using WordCountXamarin.data;

namespace WordCountXamarin.view
{
    [Activity(Label = "WordCountXamarin: Result View")]
    public class WordListActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_word_list);


            var toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);


            // Intent auslesen (steht direkt als Property zur Verfügung)
            if (Intent == null)
            {
                Log.Debug(FileActivity.DebugTag, "intent is null");
                return;
            }

            var bundle = Intent.Extras;
            if (bundle == null)
            {
                Log.Debug(FileActivity.DebugTag, "bundle is null");
                return;
            }

            var resultJson = bundle.GetString(FileActivity.KeyWordResult);
            var result = JsonConvert.DeserializeObject<WordCountResult>(resultJson);
            if (result == null)
            {
                Log.Debug(FileActivity.DebugTag, "result is null");
                return;
            }

            // Liste erstellen
            var listView = (ListView)FindViewById(Resource.Id.listView);

            // Liste mit Daten fuellen
            listView.Adapter = new WordCountArrayAdapter(this, result.Counters);

            // Dateiname setzen
            SupportActionBar.Title = $"{Resource.String.app_name} von {result.FileHolder.Filename}";

        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }


        public class WordCountArrayAdapter : ArrayAdapter<WordCount> {

            private List<WordCount> Values { get; }

            public WordCountArrayAdapter(Context context, List<WordCount> values):base(context, Resource.Layout.list_item, values)
            {
                Values = values;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var inflater = (LayoutInflater)Context.GetSystemService(Context.LayoutInflaterService);

                var rowView = inflater.Inflate(Resource.Layout.list_item, parent, false);

                var wc = Values[position];

                ((TextView)rowView.FindViewById(Resource.Id.countTextView)).Text = wc.Count.ToString();
                ((TextView)rowView.FindViewById(Resource.Id.wordTextView)).Text = wc.Word;

                return rowView;
            }
        }

    }
}