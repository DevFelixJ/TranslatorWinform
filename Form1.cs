using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace Traductor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtOutput.ReadOnly = true;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.Text = string.Empty;
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text;

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                string translatedText = await TranslateText(inputText);
                txtOutput.Text = translatedText;
            }

        }

        private async Task<string> TranslateText(string inputText)
        {
            string url = $"http://api.mymemory.translated.net/get?q={Uri.EscapeDataString(inputText)}&langpair=es|en";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject translationObject = JObject.Parse(jsonResponse);

                    return translationObject["responseData"]["translatedText"].ToString();
                }
                else
                {
                    // Manejar el error de la solicitud aquí si es necesario
                    return string.Empty;
                }
            }
        }

    }
}
