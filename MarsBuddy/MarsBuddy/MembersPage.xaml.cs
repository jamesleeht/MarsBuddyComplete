using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MarsBuddy
{
	public partial class MembersPage : ContentPage
	{
		public MembersPage ()
		{
			InitializeComponent ();
            GetDataAsync();
		}

        public async void GetDataAsync()
        {
            //Get data from Azure Mobile Apps
            var client = new MobileServiceClient("https://marsxam.azurewebsites.net");
            IMobileServiceTable<Member> memberTable = client.GetTable<Member>();
            List<Member> memberList = await memberTable.ToListAsync();

            //Set source
            MemberListView.ItemsSource = memberList;
        }
    }
}
