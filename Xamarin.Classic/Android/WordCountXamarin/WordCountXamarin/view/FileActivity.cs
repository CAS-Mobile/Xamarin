using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.IO;
using Java.Lang;
using Newtonsoft.Json;
using WordCountXamarin.data;
using WordCountXamarin.domain;
using Exception = System.Exception;
using Console = System.Console;

namespace WordCountXamarin.view
{
    [Activity(Label = "WordCountXamarin: Main View", MainLauncher = true)]
    public class FileActivity : AppCompatActivity
    {
        public static string DebugTag = "WordApp";
        public static string KeyWordResult = "WordResult";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_file);

            var toolbar = (Android.Support.V7.Widget.Toolbar) FindViewById(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            // Liste erstellen
            var listView = (ListView) FindViewById(Resource.Id.listView);

            // Liste mit Daten fuellen
            var files = FileProvider.GetFiles();
            var adapter = new FileHolderArrayAdapter(this, files);
            listView.Adapter = adapter;

            // Listener fuer ListView
            listView.ItemClick += (sender, args) => FileSelected(FileProvider.GetFiles()[args.Position]);

        }

        private void FileSelected(FileHolder holder)
        {
            Toast.MakeText(ApplicationContext, $"File selected: {holder.Filename}", ToastLength.Short).Show();

            var text = LoadFile(holder.Id);
            var counters = AnalyzeText(text);
            var result = new WordCountResult(holder, counters);

            var showResultIntent = new Intent(this, typeof(WordListActivity));
            var bundle = new Bundle();

            // hier brauchen wir einfach Newtonsoft.Json und übergeben 
            // unser Result als string (statt ISerializable von Java zu implementieren)
            bundle.PutString(KeyWordResult, JsonConvert.SerializeObject(result));
            showResultIntent.PutExtras(bundle);

            StartActivity(showResultIntent);
        }

        private string LoadFile(int id)
        {
            var sb = new StringBuilder();
            using (var br = new BufferedReader(new InputStreamReader(Resources.OpenRawResource(id))))
            {
                try
                {
                    string readLine = null;
                    while ((readLine = br.ReadLine()) != null)
                    {
                        sb.Append(readLine);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

            }

            var text = sb.ToString();

            Log.Debug(DebugTag, $"File loaded size={text.Length}");

            return text;
        }

        private List<WordCount> AnalyzeText(string text)
        {
            var result = new WordCounter().CountWords(text);
            Log.Debug(DebugTag, "File analyzed");
            return result;
        }



        public class FileHolderArrayAdapter : ArrayAdapter<FileHolder>
        {
            private List<FileHolder> Values { get; }

            public FileHolderArrayAdapter(Context context, List<FileHolder> values) : base(context, Resource.Layout.file_item, values)
            {
                Values = values;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var inflater = (LayoutInflater) Context.GetSystemService(Context.LayoutInflaterService);

                var rowView = inflater.Inflate(Resource.Layout.file_item, parent, false);

                var fh = Values[position];

                ((TextView) rowView.FindViewById(Resource.Id.fileNameTextView)).Text = fh.Filename;
                ((TextView) rowView.FindViewById(Resource.Id.fileSizeTextView)).Text = $"{fh.Size}kByte";

                return rowView;
            }
        }
    }
}