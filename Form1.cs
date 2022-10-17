using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Analizador_Lexico
{
    public partial class Form1 : Form
    {
        //static string conexionstring = "Data Source=LAPTOP-1PPKPEKT;Initial Catalog=Matriz de transicion;Integrated Security=True";
        static string conexionstring = "Data Source=Mwry-GO;Initial Catalog=Matriz;Integrated Security=True";

        SqlConnection conexion = new SqlConnection(conexionstring);
       
        List<Error> ListaErrores = new List<Error>();
        List<Simbolo> ListaSimbolo = new List<Simbolo>();
        List<String> listaDeGramaticas = new List<string>();

        //ListaTokens miListaTokens = new ListaTokens();
        Programa miPrograma = new Programa();

        //Matriz de transicion y gramaticas.
        DataTable Matriz = new DataTable();
        DataTable Gramaticas = new DataTable();

        //string GuardarTOKENS;
        int lineaError = 1;
        int contadorLinea = 0;

        DataTable dtGramaticas = new DataTable();
        Dictionary<string, string> dictGramaticas = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Open();

            string Consulta = "Select * From Matriz6";
            SqlCommand comando = new SqlCommand(Consulta, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);

            data.Fill(Matriz);
            conexion.Close();

            conexion.Open();
            Consulta = "Select * from gramaticas";
            comando = new SqlCommand(Consulta, conexion);
            data = new SqlDataAdapter(comando);
            data.Fill(Gramaticas);

            conexion.Close();


            miPrograma.Matriz = Matriz;
            miPrograma.Gramaticas = Gramaticas;
            //miPrograma.NormalizarMatriz();

            dgvTabla.DataSource = miPrograma.Matriz;
        }

        private void btnAnalizador_Click(object sender, EventArgs e)
        {
            //dgvSimbolos.DataSource = null;
            lineaError = 1;
            contadorLinea = 1;
            miPrograma.StrCodigoFuente = txtFuente.Text;
            miPrograma.GenerarTokens();
            miPrograma.ObtenerTokens();

            miPrograma.Tokens.LstTokens.ForEach((linea) =>
            {
                linea.ForEach((token) =>
                {
                    txtToken.Text += token.StrToken + " ";
                    Console.WriteLine(token.StrToken);
                });
            });


            //miPrograma.generarCodigoFuente(txtFuente.Text);
            //miPrograma.Gramaticas = tablaGramaticas;
            //miPrograma.obtenerTokens(txtToken.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //GuardarTOKENS = txtToken.Text;
            //MessageBox.Show("Se guardo correctamente el archivo de tokens: \n"+ GuardarTOKENS);

            SaveFileDialog saveFileDialog1;
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Guardar Archivo de Texto";
            saveFileDialog1.Filter = "Archivo de Texto (.txt) |*.txt";

            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.InitialDirectory = @"C:\\";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta = saveFileDialog1.FileName;

                StreamWriter fichero = new StreamWriter(ruta);
                string txt = txtToken.Text;
                fichero.Write(txt.ToString());
                fichero.Close();
                MessageBox.Show("Se guardo el archivo: " + saveFileDialog1.FileName);
                //txtToken.Text = "";
            }
            else
            {
                MessageBox.Show("Has cancelado.");
            }
            saveFileDialog1.Dispose();
            saveFileDialog1 = null;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            txtDerivacionesSintaxis.Text = "";
            //leerTokens();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtToken.Text = "";

            miPrograma.Tokens.DepurarTokens();

            miPrograma.VerificarSintaxis();

            miPrograma.Tokens.LineasDerivadas.ForEach((linea) =>
            {
                linea.ForEach((Token) =>
                {
                    Console.WriteLine(Token.StrToken);
                    txtToken.Text += Token.StrToken;
                    txtToken.Text += " ";
                });

                txtToken.Text += "\n";
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int numLinea = 1;
            miPrograma.Tokens.LstTokens.ForEach((linea) => {
                Console.Write("Linea {0}: ", numLinea);
                linea.ForEach((token) => {
                    Console.Write(token.StrToken + ' ');
                });
                Console.Write("\n");
                numLinea++;
            });
        }
    }
}
