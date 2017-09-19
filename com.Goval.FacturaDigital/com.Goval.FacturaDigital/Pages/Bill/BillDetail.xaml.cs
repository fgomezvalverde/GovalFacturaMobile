﻿using com.Goval.FacturaDigital.Abstraction.DependencyServices;
using com.Goval.FacturaDigital.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace com.Goval.FacturaDigital.Pages.Bill
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillDetail : ContentPage
    {
        Model.Bill ActualBill;


        public BillDetail(Model.Bill pCurrentBill)
        {
            InitializeComponent();
            ActualBill = pCurrentBill;
            this.BindingContext = ActualBill;
        }

        private async void Button_SeeBill_Clicked(object sender, EventArgs e)
        {
            App.ShowLoading(true);
            Dictionary<string, string> values = await Utils.BillSecurity.BillToDictionary(ActualBill);
            await DependencyService.Get<IReportingService>().CreateAndRunReport(values, ActualBill.Id + "");
            App.ShowLoading(false);
        }

        private void ProductListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = sender as ListView;
            listView.SelectedItem = null;
        }
    }
}