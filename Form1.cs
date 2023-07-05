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
        private Dictionary<string, string> languageCodes; //Se crea el diccionario para guardar los idiomas de entrada y salida.
        public Form1()
        {
            InitializeComponent();
            txtOutput.ReadOnly = true;

            languageCodes = new Dictionary<string, string> //Se implementa el contenido del diccionario.
            {
                {"Español" , "es"},
                {"Inglés", "en" },
                {"Francés", "fr" },
                {"Alemán", "de" }
            };

            //Agregar idiomas de entrada cmbInputLanguage
            cmbInputLanguage.DataSource = new BindingSource(languageCodes, null);
            cmbInputLanguage.DisplayMember = "Key";
            cmbInputLanguage.ValueMember = "Value";
            cmbInputLanguage.SelectedIndex = 0; //Idioma por defecto de entrada.En mi caso he elegido Español

            //Agregar idiomas de salida cmbOutputLanguage
            cmbOutputLanguage.DataSource = new BindingSource(languageCodes, null);
            cmbOutputLanguage.DisplayMember = "Key";
            cmbOutputLanguage.ValueMember = "Value";
            cmbOutputLanguage.SelectedIndex = 1; //Idioma por defecto de salida. En mi caso he elegido Inglés
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
                string inputLanguage = ((KeyValuePair<string,  string>)cmbInputLanguage.SelectedItem).Value;
                string outputLanguage = ((KeyValuePair<string, string>)cmbOutputLanguage.SelectedItem).Value;

                    string translatedText = await TranslateText(inputText, inputLanguage, outputLanguage);
                    txtOutput.Text = translatedText;
                
            }

        }

        private async Task<string> TranslateText(string inputText, string inputLanguage, string outputLanguage)
        {
            string url = $"http://api.mymemory.translated.net/get?q={Uri.EscapeDataString(inputText)}&langpair={inputLanguage}|{outputLanguage}";

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
