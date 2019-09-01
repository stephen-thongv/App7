using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using Android.Content;
using System;
using App7.Helper;

namespace App7
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.Light", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText taskEditText;
        DbHelper dbHelper;
        CustomerAdapter adapter;
        ListView lstTask;


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_item, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_add:
                    taskEditText = new EditText(this);
                    Android.Support.V7.App.AlertDialog dialog = new Android.Support.V7.App.AlertDialog.Builder(this)
                        .SetTitle("Add New Task")
                        .SetMessage("What Do You Want Next?")
                        .SetView(taskEditText)
                        .SetPositiveButton("Add", OkAction)
                        .SetNegativeButton("Cancel", CancelAction)
                        .Create();
                    dialog.Show();

                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {

        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            string task = taskEditText.Text;
            dbHelper.InsertNewTask(task);
            LoadTaskList();
        }

        private void LoadTaskList()
        {
            List<string> taskList = dbHelper.GetTaskList();
            adapter = new CustomerAdapter(this, taskList, dbHelper);
            lstTask.Adapter = adapter;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            dbHelper = new DbHelper(this);
            lstTask = FindViewById<ListView>(Resource.Id.lstTask);


            //information to be loaded 
            LoadTaskList();
        }
    
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    internal class List<T>
    {
    }
}