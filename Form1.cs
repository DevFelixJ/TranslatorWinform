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
            txtOutput.ReadOnly = true; //Aqui le indicamos que el texto de salida sea solo de lectura para que no se pueda escribir en el.
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.Text = string.Empty; //Esto hace que al empezar a borrar el texto de entrada, la caja de texto de salida se quede vacio.
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            string inputText = txtInput.Text; //Al hacer click en el boton traducir, Guardamos la cadena de texto de la caja de entrada en una variable.

            if (!string.IsNullOrWhiteSpace(inputText))
            {
                string translatedText = await TranslateText(inputText); //Si la cadena de texto no esta en blanco ni solo tiene un espacio en blanco, el texto a traducir hace un request a la api
                txtOutput.Text = translatedText;// Si despues de llamar a la api, da todo OK, la caja de texto de salida mostrara la traduccion.
            }

        }

        private async Task<string> TranslateText(string inputText) // Esta api
        {
            string url = $"http://api.mymemory.translated.net/get?q={Uri.EscapeDataString(inputText)}&langpair=es|en"; //Llamada a la api diciendo que el origen es ES y el de salida EN

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
