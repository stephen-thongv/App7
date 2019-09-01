using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace App7.Helper
{
    class CustomerAdapter : BaseAdapter
    {
        private MainActivity mainActivity;
        private List<string> taskList;
        private DbHelper dbHelper;

        public CustomerAdapter(MainActivity mainActivity, List<string> taskList, DbHelper dbHelper)
        {
            this.mainActivity = mainActivity;
            this.taskList = taskList;
            this.dbHelper = dbHelper;
        }

        public override int Count => taskList.Count
        {
           get
            {
                return
            }

        }

        public override Java.Lang.Object GetItem(int position)
        {
            return taskList.Count;
        }

        
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            throw new NotImplementedException();
        }
    }
}