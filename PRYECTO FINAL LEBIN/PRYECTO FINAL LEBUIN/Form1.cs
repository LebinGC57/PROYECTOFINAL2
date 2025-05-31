using System;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsistenteAgricolaClima
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConsultarClima_Click(object sender, EventArgs e)
        {
            string ciudad = txtCiudad.Text.Trim();
            if (string.IsNullOrWhiteSpace(ciudad))
            {
                MessageBox.Show("Por favor, escribe la ciudad o ubicación.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pregunta = $"¿Cuál es el pronóstico del clima para mañana en {ciudad}?";
            string respuesta = await ConsultarIA(pregunta);

            listBoxClima.Items.Clear();
            foreach (var linea in (respuesta ?? string.Empty).Split('\n'))
                if (!string.IsNullOrWhiteSpace(linea))
                    listBoxClima.Items.Add(linea.Trim());

            bool guardado = await GuardarEnBDAsync(pregunta, respuesta);
            if (guardado)
                MessageBox.Show("Consulta de clima guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnConsultarCultivo_Click(object sender, EventArgs e)
        {
            string cultivo = txtCultivo.Text.Trim();
            if (string.IsNullOrWhiteSpace(cultivo))
            {
                MessageBox.Show("Por favor, indica el cultivo.", "Campo vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pregunta = $"¿Qué día de la próxima semana es mejor para sembrar o cosechar {cultivo} según el pronóstico del clima?";
            string respuesta = await ConsultarIA(pregunta);

            listBoxCultivo.Items.Clear();
            foreach (var linea in (respuesta ?? string.Empty).Split('\n'))
                if (!string.IsNullOrWhiteSpace(linea))
                    listBoxCultivo.Items.Add(linea.Trim());

            bool guardado = await GuardarEnBDAsync(pregunta, respuesta);
            if (guardado)
                MessageBox.Show("Consulta de cultivo guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<string> ConsultarIA(string entrada)
        {
            try
            {
                string prompt = $"Eres un asistente agrícola experto en clima. El usuario pregunta: \"{entrada}\". " +
                                "Responde de forma clara y útil para agricultores.";

                var request = new
                {
                    model = "llama3-70b-8192",
                    messages = new[] {
                        new { role = "user", content = prompt }
                    }
                };

                var json = System.Text.Json.JsonSerializer.Serialize(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer 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"); AQUI VA LA API, SOLO QUE COMENTE LA LINEA PARA PODERLA SUBIR AL GIT

                HttpResponseMessage response = await client.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    using var doc = System.Text.Json.JsonDocument.Parse(jsonResponse);
                    return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
                }
                else
                {
                    return $"La API respondió con error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Error al consultar la IA: {ex.Message}";
            }
        }

        private async Task<bool> GuardarEnBDAsync(string entrada, string respuesta)
        {
            string cadenaConexion = "Server=LAPTOP-OITJRR5J\\SQLEXPRESS;Database=PROYECTOFINAL;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    await conn.OpenAsync();
                    string query = "INSERT INTO HistorialConsultas (Entrada, Respuesta) VALUES (@entrada, @respuesta)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@entrada", entrada);
                        cmd.Parameters.AddWithValue("@respuesta", respuesta);
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
