using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PracticeApp.ViewModels;
using System.Text.RegularExpressions;
using Practice.Commom.Models;
using System.Runtime.InteropServices;
using Practice.Commom.Services;
using System.Net.Cache;

namespace PracticeApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly IApiService _apiService;
        public MainPage(IApiService apiService)
        {
            _apiService = apiService;
            InitializeComponent();
            ListGroup.Items.Add("Grupo 1");
            ListGroup.Items.Add("Grupo 2");
            ListGroup.Items.Add("Grupo 3");
            ListGroup.Items.Add("Grupo 4");
        }

        public async void GetProblem_Clicked(object sender, EventArgs e)
        {
            if (Document.Text == "") 
            {
              await DisplayAlert("Alert", "Document", "ok");
                return;
            };
            if (Firstname.Text == "")
            {
                await DisplayAlert("Alert", "FirstName", "ok");
                return;
            }
            if (Lastname.Text == "")
            {
                await DisplayAlert("Alert", "Lastname", "ok");
                return;
            }
            if (Email.Text == "" || Email.Text != "andersonmendoza2703.itm.edu.c0")
            {
                await DisplayAlert("Alert", "Email", "ok");
                return;
            }
            if (Telephone.Text == "")
            {
                await DisplayAlert("Alert", "Telephone", "ok");
                return;
            }

            string url = App.Current.Resources["URLAPI"].ToString();
            Form user = new Form
            {
                username = "andersonmendoza207524@itm.edu.co",
                Document = Document.Text,
                Firstname = Firstname.Text,
                Lastname = Lastname.Text,
                phone = Telephone.Text,
                group = 2
            };
            Response response = await _apiService.GetListAsync<Response>(
                url,
                "Account",
                "GetProblem",
                user
                );

            await DisplayAlert("Alert", response.problem, "ok");
            Respuesta.Text = response.ToString();

            return;
        }

        public async void Send_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Ingreso", "ok");
            
            return;
        }
    }
}