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
        Programa miPrograma;

        DataTable tabla = new DataTable();
        DataTable tablaGramaticas = new DataTable();

        //string GuardarTOKENS;
        int lineaError = 1;
        int ContadorLinea = 0;
        string tipoDeDato = "";

        DataTable dtGramaticas = new DataTable();
        Dictionary<string, string> dictGramaticas = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

        public int CalcularEstado(int Simbolo)
        {
            switch (Simbolo)
            {
                case 97: return 1;
                case 98: return 2;
                case 99: return 3;
                case 100: return 4;
                case 101: return 5;
                case 102: return 6;
                case 103: return 7;
                case 104: return 8;
                case 105: return 9;
                case 106: return 10;
                case 107: return 11;
                case 108: return 12;
                case 109: return 13;
                case 110: return 14;
                case 164: return 15;
                case 111: return 16;
                case 112: return 17;
                case 113: return 18;
                case 114: return 19;
                case 115: return 20;
                case 116: return 21;
                case 117: return 22;
                case 118: return 23;
                case 119: return 24;
                case 120: return 25;
                case 121: return 26;
                case 122: return 27;
                case 65: return 28;
                case 66: return 29;
                case 67: return 30;
                case 68: return 31;
                case 69: return 32;
                case 70: return 33;
                case 71: return 34;
                case 72: return 35;
                case 73: return 36;
                case 74: return 37;
                case 75: return 38;
                case 76: return 39;
                case 77: return 40;
                case 78: return 41;
                case 165: return 42;
                case 79: return 43;
                case 80: return 44;
                case 81: return 45;
                case 82: return 46;
                case 83: return 47;
                case 84: return 48;
                case 85: return 49;
                case 86: return 50;
                case 87: return 51;
                case 88: return 52;
                case 89: return 53;
                case 90: return 54;
                case 48: return 55;
                case 49: return 56;
                case 50: return 57;
                case 51: return 58;
                case 52: return 59;
                case 53: return 60;
                case 54: return 61;
                case 55: return 62;
                case 56: return 63;
                case 57: return 64;
                case 60: return 65;
                case 62: return 66;
                case 61: return 67;
                case 33: return 68;
                case 43: return 69;
                case 45: return 70;
                case 47: return 71;
                case 42: return 72;
                case 94: return 73;
                case 95: return 74;
                case 64: return 75;
                case 35: return 76;
                case 39: return 77;
                case 32: return 78;
                case 46: return 79;
                case 34: return 80;
                case 36: return 81;
                case 59: return 82;
                case 40: return 83;
                case 41: return 84;
                case 123: return 85;
                case 125: return 86;
                case 38: return 87;
                case 124: return 88;
            }

            return 100;
        }
        //#region Sintaxis
        //public void leerTokens()
        //{
        //    //StreamReader leer = new StreamReader("C:/Users/jesus/Documents/TOKENS.txt");
        //    StreamReader leer = new StreamReader("C:/Users/jesus/OneDrive/Escritorio/TOKENS.txt");
        //    string linea;
        //    List<string> listaLineas = new List<string>();
        //    while((linea = leer.ReadLine()) != null)
        //    {
        //        //Se agregan linea por linea del archivo a la lista
        //        listaLineas.Add(linea.ToLower());
        //    }
        //    string[] arregloTokens = new string[listaLineas.Count()];
        //    //RECORRE EL TOTAL DE LINEAS
        //    for(int i = 0; i<listaLineas.Count(); i++)
        //    {
        //        arregloTokens[i] = listaLineas[i].Trim(' ');
        //        int numeroTokens = arregloTokens[i].Split(' ').Length;
        //        string[] AuxiliarTokens = new string[numeroTokens];
        //        arregloTokens[i].Split(' ').CopyTo(AuxiliarTokens, 0);

        //        bool enviarABottomUp = true;
        //        foreach (var token in AuxiliarTokens) //Valida si hay un token de ERROR en la salida del léxico
        //            enviarABottomUp = !token.Contains("ERROR");

        //        if (enviarABottomUp)
        //        { //Si no hay error envía los tokens de la linea actual a BottomUp
        //            BottomUp(AuxiliarTokens);
        //        }
        //        else
        //        { //Si encuentra un error (de una palabra que no existe) avisa para corregir desde léxico
        //            //rtxTokenSintaxis.Text = "";
        //            MessageBox.Show("Existe un error en léxico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            break;
        //        }
        //        //MessageBox.Show(listaLineas[i]);
        //    }
        //}
        //public void BottomUp(string[] arrTokens) //Recibe un arreglo con una linea de tokens
        //{
        //    int cantidadTokens = arrTokens.Length; //Obtiene el tamaño de la cadena de tokens
        //    string cadenaTokens = string.Join(" ", arrTokens); //Convertir el arreglo de la cadena de tokens a un string
        //    txtDerivacionesSintaxis.Text += cadenaTokens + "\n"; //Agrega la cadena de tokens al textbox de derivaciones

        //    if (dictGramaticas.ContainsKey(cadenaTokens) && dictGramaticas[cadenaTokens] == "S")
        //    { //Si encuentra una S
        //        MessageBox.Show("Se encontró una S DIRECTO");
        //        txtDerivacionesSintaxis.Text += dictGramaticas[cadenaTokens] + "\n";
        //    }
        //    else //Caso: No encuentra una S directa, necesita derivarse o validar que realmente no existe
        //    {
        //        string cadenaTokensModificada = cadenaTokens;
        //        int aux = 0;
        //        string strBloque;
        //        int restador = 1;
        //        do
        //        {
        //            int cantidadAuxiliar = cadenaTokensModificada.Split(' ').Length; //toma la cantidad de tokens en la cadena modificada
        //            string[] ArrTokensModificados = new string[cantidadAuxiliar];
        //            cadenaTokensModificada.Split(' ').CopyTo(ArrTokensModificados, 0); // Convierto en arreglo la cadena modificada

        //            strBloque = string.Join(" ", ArrTokensModificados.Skip(aux).Take(cantidadAuxiliar - restador)); //1-6 alguna variable que vaya restando 1 a cantaux? //2-7

        //            if (dictGramaticas.ContainsKey(strBloque))
        //            {
        //                cadenaTokensModificada = cadenaTokensModificada.Replace(strBloque, dictGramaticas[strBloque]);
        //                txtDerivacionesSintaxis.Text += cadenaTokensModificada + "\n";
        //                aux = 0;
        //                restador = 0;
        //            }
        //            else
        //            {
        //                if ((aux + (cantidadAuxiliar - restador)) == cantidadAuxiliar)
        //                {
        //                    aux = 0;
        //                    restador++;
        //                }
        //                else
        //                {
        //                    aux++;
        //                }
        //            }
        //        } while (cadenaTokensModificada.Split(' ').Length > 1 && strBloque != "");
        //        //rtxDerivaciones.Text = "";
        //    }
        //}
        //#endregion

        //#region Convertir gramaticas en diccionario

        //public Dictionary<string, string> ConvertirTablaEnDiccionario(DataTable tabla)
        //{
        //    Dictionary<string, string> diccionario = new Dictionary<string, string>();
        //    foreach (DataRow fila in tabla.Rows)
        //    {
        //        diccionario.Add(fila["PRODUCCION"].ToString(), fila["CASO"].ToString());
        //    }
        //    return diccionario;
        //}
        //#endregion

        //#region Ajustar Tokens Para Sintaxis
        //public string AjustarTokensParaSintaxis(string strCadena)
        //{
        //    var reemplazos = new Dictionary<string, string>();
        //    reemplazos.Add("CORE", "CONS");
        //    reemplazos.Add("COEN", "CONS");
        //    reemplazos.Add("OR01", "OPRE");
        //    reemplazos.Add("OR02", "OPRE");
        //    reemplazos.Add("OR03", "OPRE");
        //    reemplazos.Add("OR04", "OPRE");
        //    reemplazos.Add("OR05", "OPRE");
        //    reemplazos.Add("OA01", "OPAR");
        //    reemplazos.Add("OA02", "OPAR");
        //    reemplazos.Add("OA03", "OPAR");
        //    reemplazos.Add("OA04", "OPAR");

        //    foreach (var reemplazo in reemplazos)
        //    {
        //        strCadena = strCadena.Replace(reemplazo.Key, reemplazo.Value);
        //    }

        //    return strCadena;
        //}
        //#endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            conexion.Open();

            string Consulta = "Select * From Matriz6";
            SqlCommand comando = new SqlCommand(Consulta, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            
            data.Fill(tabla);
            dgvTabla.DataSource = tabla;
            conexion.Close();

            conexion.Open();
            string Consulta2 = "Select * From Matriz6";
            SqlCommand comando2 = new SqlCommand(Consulta2, conexion);
            SqlDataAdapter data2 = new SqlDataAdapter(comando2);
            DataTable tabla2 = new DataTable();
            data2.Fill(dtGramaticas);
            dgvGramatica.DataSource = tabla2;

            Consulta = "Select * from gramaticas";
            comando = new SqlCommand(Consulta, conexion);
            data = new SqlDataAdapter(comando);
            data.Fill(tablaGramaticas);

            conexion.Close();

            //dictGramaticas = ConvertirTablaEnDiccionario(dtGramaticas); 
            //Se trae la tabla ya convertida en diccionario
        }

        private void btnAnalizador_Click(object sender, EventArgs e)
        {
            miPrograma = new Programa();
            //dgvSimbolos.DataSource = null;
            lineaError = 1;
            ContadorLinea = 0;
            txtLinea.Text = "";
            //txtLinea.Text = "";
            if (txtFuente.Text == "")
            {
                MessageBox.Show("Ingrese el codigo fuente.");
                return;
            }

            txtToken.Text = null;
            ListaErrores.Clear();
            ListaSimbolo.Clear();

            dgvError.DataSource = null;
            dgvError.DataSource = ListaErrores;

            dgvSimbolos.DataSource = null;
            dgvSimbolos.DataSource = ListaSimbolo;

            string Cadena = txtFuente.Text;
            char[] AlmacenaSimbolo = new char[Cadena.Length+1];
            AlmacenaSimbolo[Cadena.Length] = '?';

            //ALMACENA LA CANDENA
            for (int i = 0; i < Cadena.Length; i++)
            {
                //Almacena caractaer por caracter en formato ASCCI
                AlmacenaSimbolo[i] = char.Parse(Cadena.Substring(i, 1));
            }

            int Estado = 0;
            int EstadoAnt = 0;
            int Codigo = 0;
            int ContadorError = 0;
            int ContadorIdentificador = 0;
            string nomSim = "";
            char Anterior=' ';
            double VARaceptada = 0;
            string GuardarValor = "";
            int Bandera = 0;

            txtToken.Text = "";

            for (int i = 0; i < Cadena.Length+1; i++)
            {
                //GUARDAS DATOS
                if (AlmacenaSimbolo[i] == '=')
                {
                    VARaceptada = 1;
                }
                if(VARaceptada == 1)
                {
                    if ((AlmacenaSimbolo[i] > 47 && AlmacenaSimbolo[i] < 58) || (AlmacenaSimbolo[i] == 46 || AlmacenaSimbolo[i] == 45))
                    {
                        GuardarValor = GuardarValor + AlmacenaSimbolo[i];
                    }
                }
                if (i != 0)
                {
                    //Guarda el Codigo ASCCI anterior
                    Anterior = AlmacenaSimbolo[i - 1];
                    EstadoAnt = Estado;
                }
                if (Anterior == ' ' && AlmacenaSimbolo[i] == ' ' || AlmacenaSimbolo[i] == '\r')
                {
                    //Estado = 0;
                    continue;
                }
                //Si el caracter es distinto de ? Y el codigo ASCCI se encuentra entre las letras Mayusculas, Minisculas o Numeros
                if((AlmacenaSimbolo[i] != '?') && (VARaceptada == 0) &&((AlmacenaSimbolo[i] > 64  && AlmacenaSimbolo[i] < 91) || (AlmacenaSimbolo[i] > 96 && AlmacenaSimbolo[i] < 123) || (AlmacenaSimbolo[i]>47 && AlmacenaSimbolo[i] < 58)))
                {
                    //Concatena el caracter
                    nomSim = nomSim + AlmacenaSimbolo[i];
                }
                

                //ESTADOS DE ERROR
                if (Estado > 199 && (AlmacenaSimbolo[i] == ' ' || AlmacenaSimbolo[i] == '\n' || AlmacenaSimbolo[i] == '?'))
                {
                    ContadorError = ContadorError + 1;
                    Error miError = new Error();
                    miError.Numero = ContadorError;
                    miError.Tipo_de_Error = dgvTabla.Rows[Estado-6].Cells[90].Value.ToString();
                    //87
                    //LINEA DE CODIGO MODIFICADA
                    miError.Linea_Error = lineaError;

                    ListaErrores.Add(miError);

                    dgvError.DataSource = null;
                    dgvError.DataSource = ListaErrores;


                    string Error = "ERROR" + ContadorError;

                    txtToken.SelectionStart = txtToken.TextLength;
                    txtToken.SelectionLength = 0;
                    txtToken.SelectionColor = Color.Red;
                    txtToken.AppendText(Error);
                    txtToken.SelectionColor = txtToken.ForeColor;


                    if (AlmacenaSimbolo[i] == ' ')
                    {
                        
                        txtToken.SelectionStart = txtToken.TextLength;
                        txtToken.SelectionLength = 0;
                        txtToken.AppendText(" ");
                        
                    }
                    
                    if(AlmacenaSimbolo[i] == '\n')
                    {
                        lineaError += 1;
                        //txtLinea.AppendText((lineaError-1).ToString());
                        //txtLinea.AppendText("\r" + "\n");
                        txtToken.SelectionStart = txtToken.TextLength;
                        txtToken.SelectionLength = 0;
                        txtToken.AppendText("\r" + "\n");
                    }
                    //Se reinicia la bandera de que es aceptada la cadena
                    VARaceptada = 0;
                    GuardarValor = "";
                    nomSim = "";
                    //Se reincia el Estado
                    Estado = 0;

                    continue;
                }

                //SIGUIENTE ESTADO DE ERROR
                if (Estado > 199)
                {
                    continue;
                }

                //FIN DE CADENA
                //Verifica si se ha terminado la cadena
                if (AlmacenaSimbolo[i] == '?')
                {
                    lineaError += 1;
                    //txtLinea.AppendText((lineaError-1).ToString());
                    //txtLinea.AppendText("\r" + "\n");
                    if (Estado == 0)
                    {
                        break;
                    }
                    if (Estado > 199)
                    {
                        break;
                    }
                    else
                    {
                        if (dgvTabla.Rows[Estado].Cells[90].Value.ToString() == "")
                        {
                            Estado = int.Parse(dgvTabla.Rows[Estado].Cells[89].Value.ToString());
                            i = i - 1;
                            continue;
                        }
                        else
                        {
                            //Verifica si despues de = va una CNEN o CNRE
                            //53 || 56
                           
                            switch (Estado)
                            {
                                case 118: tipoDeDato = "INT"; break;//CNEN
                                case 121: tipoDeDato = "FLOAT"; break;//CNRE
                                case 126: tipoDeDato = "FLOAT"; break;//CNEXP
                                case 140: tipoDeDato = "STRING"; break;//CDNA
                                case 53: tipoDeDato = "BOOL"; break;//FALSE
                                case 105: tipoDeDato = "BOOL"; break;//TRUE
                                default: break;
                            }
                            if ((Estado == 118 || Estado == 121 || Estado == 126 || Estado == 140 || Estado == 53 || Estado == 105) && VARaceptada == 1)
                            {
                                //MICHU
                                ContadorIdentificador = ContadorIdentificador + 1;
                                Simbolo miSimbolo = new Simbolo();
                                miSimbolo.INDENTIFICADOR = ContadorIdentificador;
                                miSimbolo.NOMBRE = nomSim;
                                miSimbolo.VALOR = double.Parse(GuardarValor);
                                miSimbolo.TIPODATO = tipoDeDato;

                                ListaSimbolo.Add(miSimbolo);

                                dgvSimbolos.DataSource = null;
                                dgvSimbolos.DataSource = ListaSimbolo;
                                VARaceptada = 0;
                                GuardarValor = "";
                                nomSim = "";
                                tipoDeDato = "";
                            }
                            //49 de Identificador
                            if (Estado == 113)
                            {
                                string sim = nomSim;
                                foreach (Simbolo simbolo in ListaSimbolo)
                                {
                                    if(nomSim == simbolo.NOMBRE)
                                    {
                                        sim = simbolo.NOMBRE;
                                        ContadorIdentificador--;
                                        Bandera = 1;
                                        break;
                                    }
                                    else
                                    {
                                        sim = nomSim;
                                    }
                                } 

                                if(Bandera == 0)
                                {
                                    //MICHU
                                    ContadorIdentificador = ContadorIdentificador + 1;
                                    Simbolo miSimbolo = new Simbolo();
                                    miSimbolo.INDENTIFICADOR = ContadorIdentificador + 1;
                                    miSimbolo.NOMBRE = sim;
                                    miSimbolo.TIPODATO = tipoDeDato;

                                    ListaSimbolo.Add(miSimbolo);

                                    dgvSimbolos.DataSource = null;
                                    dgvSimbolos.DataSource = ListaSimbolo;
                                    VARaceptada = 0;
                                    GuardarValor = "";
                                    nomSim = "";
                                    tipoDeDato = "";
                                }
                                Bandera = 0;

                            }

                            //Estado == 49
                            if(Estado == 113)
                            {
                                ContadorIdentificador++;
                                txtToken.SelectionStart = txtToken.TextLength;
                                txtToken.SelectionLength = 0;
                                txtToken.AppendText(dgvTabla.Rows[Estado].Cells[90].Value.ToString() + ContadorIdentificador);
                            }
                            else
                            {
                                txtToken.SelectionStart = txtToken.TextLength;
                                txtToken.SelectionLength = 0;
                                txtToken.AppendText(dgvTabla.Rows[Estado].Cells[90].Value.ToString());
                            }
                            
                            break;
                        }
                    }

                    //fin

                    //listaDeTokens.Add(txtT);
                }

                //FIN DE CADENA Y SIGUIENTE
                if (AlmacenaSimbolo[i] == ' ' || AlmacenaSimbolo[i] == '\n' )
                {
                    ContadorLinea++;
                    txtLinea.AppendText((ContadorLinea).ToString());
                    txtLinea.AppendText("\r" + "\n");

                    if (Estado == 0)
                    {
                        txtToken.SelectionStart = txtToken.TextLength;
                        txtToken.SelectionLength = 0;
                        txtToken.AppendText("\r" + "\n");
                        continue;
                    }

                    Estado = int.Parse(dgvTabla.Rows[Estado].Cells[89].Value.ToString());

                    switch (Estado)
                    {
                        case 118: tipoDeDato = "INT"; break;//CNEN
                        case 121: tipoDeDato = "FLOAT"; break;//CNRE
                        case 126: tipoDeDato = "FLOAT"; break;//CNEXP
                        case 140: tipoDeDato = "STRING"; break;//CDNA
                        case 53: tipoDeDato = "BOOL"; break;//FALSE
                        case 105: tipoDeDato = "BOOL"; break;//TRUE
                        default: break;
                    }
                    //53 o 56
                    if ((Estado == 118 || Estado == 121 || Estado == 126 || Estado == 140 || Estado == 53 || Estado == 105) && VARaceptada == 1 )
                    {
                        //Bandera = 1;
                        //MICHU
                        ContadorIdentificador = ContadorIdentificador + 1;
                        Simbolo miSimbolo = new Simbolo();
                        miSimbolo.INDENTIFICADOR = ContadorIdentificador;
                        miSimbolo.NOMBRE = nomSim;
                        miSimbolo.VALOR = double.Parse(GuardarValor);
                        miSimbolo.TIPODATO = tipoDeDato;

                        ListaSimbolo.Add(miSimbolo);

                        dgvSimbolos.DataSource = null;
                        dgvSimbolos.DataSource = ListaSimbolo;
                        VARaceptada = 0;
                        GuardarValor = "";
                        tipoDeDato = "";

                    }

                    //49
                    if (Estado == 113 && AlmacenaSimbolo[i + 1] != '=')
                    {
                        string sim = nomSim;
                        foreach (Simbolo simbolo in ListaSimbolo)
                        {
                            if (nomSim == simbolo.NOMBRE)
                            {
                                sim = simbolo.NOMBRE;
                                ContadorIdentificador--;
                                Bandera = 1;
                                break;
                            }
                            else
                            {
                                sim = nomSim;
                            }
                        }

                        if(Bandera == 0)
                        {
                            //MICHU
                            ContadorIdentificador = ContadorIdentificador + 1;
                            Simbolo miSimbolo = new Simbolo();
                            miSimbolo.INDENTIFICADOR = ContadorIdentificador + 1;
                            miSimbolo.NOMBRE = sim;
                            miSimbolo.VALOR = null;
                            miSimbolo.TIPODATO = tipoDeDato;

                            ListaSimbolo.Add(miSimbolo);

                            dgvSimbolos.DataSource = null;
                            dgvSimbolos.DataSource = ListaSimbolo;
                            VARaceptada = 0;
                            GuardarValor = "";
                            nomSim = "";
                            tipoDeDato = "";
                        }
                        Bandera = 0;

                    }

                    //andera = 0;
                    
                    //49
                    if (Estado == 113)
                    {
                        ContadorIdentificador++;
                        txtToken.SelectionStart = txtToken.TextLength;
                        txtToken.SelectionLength = 0;
                        txtToken.AppendText(dgvTabla.Rows[Estado].Cells[90].Value.ToString() + ContadorIdentificador);
                   
                    }
                    else
                    {
                        txtToken.SelectionStart = txtToken.TextLength;
                        txtToken.SelectionLength = 0;
                        txtToken.AppendText(dgvTabla.Rows[Estado].Cells[90].Value.ToString());
                    }




                    if (AlmacenaSimbolo[i] == ' ')
                    {
                        txtToken.SelectionStart = txtToken.TextLength;
                        txtToken.SelectionLength = 0;
                        txtToken.AppendText(" ");
                    }
                    else
                    {
                        lineaError += 1;
                        //txtLinea.AppendText((lineaError-1).ToString());
                        //txtLinea.AppendText("\r" + "\n");
                        txtToken.SelectionStart = txtToken.TextLength;
                        txtToken.SelectionLength = 0;
                        txtToken.AppendText("\r" + "\n");
                    }


                    if (AlmacenaSimbolo[i + 1] == '=' || AlmacenaSimbolo[i-1] == '=' )
                    {
                        
                    }
                    else
                    {
                        nomSim = "";
                    }


                    Estado = 0;

                    continue;
                }

               
                //CAMBIAR ESTADO
                //Almacena el codigo ASCCI del caracter de la cadena como entero
                Codigo = (int)AlmacenaSimbolo[i];
                //El metodo CalcularEstado devuelve la posicion de la columna de la tabala en la que el caracter se encuentra
                Estado = int.Parse(dgvTabla.Rows[Estado ].Cells[CalcularEstado(Codigo)].Value.ToString());

                //MessageBox.Show(Estado.ToString());

            }

            miPrograma.generarCodigoFuente(txtFuente.Text);
            miPrograma.Gramaticas = tablaGramaticas;
            miPrograma.obtenerTokens(txtToken.Text);
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

            miPrograma.LstTokens.DepurarTokens();

            miPrograma.verificarSintaxis();

            miPrograma.LstTokens.LineasDerivadas.ForEach((linea) =>
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
            miPrograma.LstTokens.LstTokens.ForEach((linea) => {
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
