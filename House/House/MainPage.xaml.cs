using es.dmoreno.house.core;
using es.dmoreno.utils.path;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace House
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            Task.Run(() => this.runApp());
        }

        private void runApp()
        {
            Device.BeginInvokeOnMainThread(() => {
                this.ltext.Text = "Realizando operaciones iniciales...";
            });

            try
            {
                App.Core.initializeDBSchema();
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() => {
                    this.ltext.Text = "Error: " + ex.Message;
                });
            }

            Device.BeginInvokeOnMainThread(() => {
                this.ltext.Text = "Iniciando...";
            });
        }
	}
}
