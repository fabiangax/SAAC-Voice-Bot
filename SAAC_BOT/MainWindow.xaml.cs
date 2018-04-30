using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace SAAC_BOT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        String ultimo;
        SpeechRecognitionEngine reconocimiento_de_voz = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("es-ES"));
        SpeechRecognitionEngine reconocimiento_de_voz2 = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("es-ES"));
        String palabras;
        // Initialize a new instance of the SpeechSynthesizer.
        SpeechSynthesizer synth = new SpeechSynthesizer();
        // Configure the audio output. 
        //synth.SetOutputToDefaultAudioDevice();
        //Program conexion = new Program();
        
        public MainWindow()
        {
            InitializeComponent();
            inicio();
        }


        private void btnVoz1_Click(object sender, RoutedEventArgs e)
        {
            vozCanvas.Visibility = Visibility.Visible;
            chatCanvas.Visibility = Visibility.Hidden;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            ayudaCanvas.Visibility = Visibility.Visible;
            vozCanvas.Visibility = Visibility.Hidden;
            ultimo = "voz";
        }

        private void btnInfo1_Click(object sender, RoutedEventArgs e)
        {
            ayudaCanvas.Visibility = Visibility.Visible;
            chatCanvas.Visibility = Visibility.Hidden;
            ultimo = "chat";
        }

        private void btnInfo2_Click(object sender, RoutedEventArgs e)
        {
            if (ultimo == "voz")
            {
                vozCanvas.Visibility = Visibility.Visible;
                ayudaCanvas.Visibility = Visibility.Hidden;

            }
            else if (ultimo == "chat")
            {
                chatCanvas.Visibility = Visibility.Visible;
                ayudaCanvas.Visibility = Visibility.Hidden;
            }
        }

        private void txtPreguntas_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPreguntas.Text = "";
        }

        private void btnVoz_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("Ripio el 2");
            reconocimiento_de_voz2.RecognizeAsyncCancel(); //Detiene la escucha 
            System.Media.SoundPlayer s = new System.Media.SoundPlayer();
            string dirpath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "SoundEffect.wav");
            Console.WriteLine(dirpath);
            s.SoundLocation = dirpath;
            //s.SoundLocation = "C:\\Users\\mario\\source\\repos\\SAAC_BOTllenodebugs\\SAAC_BOT\\SAAC_BOT\\SoundEffect.wav";
            s.Load(); 
            s.Play();
            //Inicia la escucha con el dispositivo de entrada de audio predeterminado 
            //Console.WriteLine("Inicio el 2");
            reconocimiento_de_voz2.SetInputToDefaultAudioDevice(); // Usaremos el microfono predeterminado del sistema 
            //reconocimiento_de_voz.LoadGrammar(new DictationGrammar());
            reconocimiento_de_voz2.LoadGrammar(CreateGrammarFromFile()); //Carga la gramatica de Windows 
            reconocimiento_de_voz2.SpeechRecognized += te_escucho2; // Controlador de eventos. Se ejecutara al reconocer 
            reconocimiento_de_voz2.RecognizeAsync(RecognizeMode.Single); //Iniciamos reconocimiento 
            //txtConversacionVoz.Text = "Estoy Escuchando...";
            synth.SetOutputToDefaultAudioDevice();
        }

        private void btnChat_Click(object sender, RoutedEventArgs e)
        {
            //reconocimiento_de_voz.RecognizeAsyncStop(); //Detiene la escucha 
            chatCanvas.Visibility = Visibility.Visible;
            vozCanvas.Visibility = Visibility.Hidden;
        }

        private void inicio()
        {
            //Console.WriteLine("Ripio el 1");
            reconocimiento_de_voz.RecognizeAsyncCancel(); //Detiene la escucha 
            //Inicia la escucha con el dispositivo de entrada de audio predeterminado 
            //Console.WriteLine("inicio el 1");
            reconocimiento_de_voz.SetInputToDefaultAudioDevice(); // Usaremos el microfono predeterminado del sistema 
            //reconocimiento_de_voz.LoadGrammar(new DictationGrammar());
            reconocimiento_de_voz.LoadGrammar(CreateGrammarFromFile2()); //Carga la gramatica de Windows 
            reconocimiento_de_voz.SpeechRecognized += te_escucho; // Controlador de eventos. Se ejecutara al reconocer 
            reconocimiento_de_voz.RecognizeAsync(RecognizeMode.Single); //Iniciamos reconocimiento 
            synth.SetOutputToDefaultAudioDevice();
        }

        private static Grammar CreateGrammarFromFile()
        {
            string dirpath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "gramatica.xml");
            Grammar Gramatica = new Grammar(dirpath);
            Gramatica.Name = "Gramatica Principal";
            return Gramatica;
        }

        private static Grammar CreateGrammarFromFile2()
        {
            string dirpath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "gramaticasal.xml");
            Grammar Gramatica = new Grammar(dirpath);
            Gramatica.Name = "Gramatica Principal";
            return Gramatica;
        }
        void te_escucho(object sender, SpeechRecognizedEventArgs e)
        {
            palabras = e.Result.Text;
            if(palabras.Equals("Hey Zack"))
            {
                txtConversacionVoz.Text = "Escuchando...";
                //Console.WriteLine("Finalizo el 1"); 
                btnVoz_Click(new Object(), new RoutedEventArgs());
            }
        }
        void te_escucho2(object sender, SpeechRecognizedEventArgs e)
        {
            palabras = e.Result.Text;
            if (palabras.Equals(""))
            {
                //Console.WriteLine("mierda");
            }
            else
            {
                Console.WriteLine("Pregunta:" + palabras);
                txtConversacionChat.AppendText("\n User: " + palabras);
                palabras = palabras.ToLower();
                buscar(palabras);
                //Console.Read();
                txtConversacionVoz.Text = "Pregunta de nuevo con el boton :)";
                //inicio();
                palabras = "";
            }
        }
        public void buscar(String x)
        {
            int idpreg = 0;
            switch (x)
            {
                case "insertar una tabla":
                case "como insertar una tabla":
                case "como inserto una tabla":
                case "como puedo insertar una tabla":
                case "insertar tablas":
                case "como insertar tablas":
                case "como inserto tablas":
                case "como puedo insertar tablas":
                    idpreg = 1;
                    break;
                case "insertar una imagen":
                case "como insertar una imagen":
                case "como inserto una imagen":
                case "como puedo insertar una imagen":
                case "insertar imagenes":
                case "como insertar imagenes":
                case "como inserto imagenes":
                case "como puedo insertar imagenes":
                    idpreg = 2;
                    break;
                case "cambiar el tipo de letra":
                case "como cambiar el tipo de letra":
                case "como cambio el tipo de letra":
                case "como puedo cambiar el tipo de letra":
                case "cambiar tipos de letra":
                case "como cambiar tipos de letra":
                case "como cambio tipos de letra":
                case "como puedo cambiar tipos de letra":
                    idpreg = 3;
                    break;
                case "agregar una pagina en blanco":
                case "como agregar una pagina en blanco":
                case "como agrego una pagina en blanco":
                case "como puedo agregar una pagina en blanco":
                case "agregar paginas en blanco":
                case "como agregar paginas en blanco":
                case "como agrego paginas en blanco":
                case "como puedo agregar paginas en blanco":
                case "insertar una pagina en blanco":
                case "como insertar una pagina en blanco":
                case "como inserto una pagina en blanco":
                case "como puedo insertar una pagina en blanco":
                case "insertar paginas en blanco":
                case "como insertar paginas en blanco":
                case "como inserto paginas en blanco":
                case "como puedo insertar paginas en blanco":
                    idpreg = 4;
                    break;
                case "cambiar el color de la letra":
                case "como cambiar el color de la letra":
                case "como cambio el color de la letra":
                case "como puedo cambiar el color de la letra":
                case "cambiar colores de letra":
                case "como cambiar colores de letra":
                case "como cambio colores de letra":
                case "como puedo cambiar colores de letra":
                    idpreg = 5;
                    break;
                case "cambiar el disenio de la pagina":
                case "como cambiar el disenio de la pagina":
                case "como cambio el disenio de la pagina":
                case "como puedo cambiar el disenio de la pagina":
                case "cambiar disenios de pagina":
                case "como cambiar disenios de pagina":
                case "como cambio disenios de pagina":
                case "como puedo cambiar disenios de pagina":
                    idpreg = 7;
                    break;
                case "agregar espacio entre renglones":
                case "como agregar espacio entre renglones":
                case "como agrego espacio entre renglones":
                case "como puedo agregar espacio entre renglones":
                case "agregar espacios entre renglones":
                case "como agregar espacios entre renglones":
                case "como agrego espacios entre renglones":
                case "como puedo agregar espacios entre renglones":
                    idpreg = 8;
                    break;
                case "agregar bordes a la pagina":
                case "como agregar bordes a la pagina":
                case "como agrego bordes a la pagina":
                case "como puedo agregar bordes a la pagina":
                    idpreg = 9;
                    break;
                case "dividir texto en columnas":
                case "como dividir texto en columnas":
                case "como divido texto en columnas":
                case "como puedo dividir texto en columnas":
                    idpreg = 10;
                    break;
                case "agregar Word Art":
                case "como agregar Word Art":
                case "como agrego Word Art":
                case "como puedo agregar Word Art":
                case "insertar Word Art":
                case "como insertar Word Art":
                case "como inserto Word Art":
                case "como puedo insertar Word Art":
                    idpreg = 11;
                    break;
                case "hacer pie de pagina":
                case "como hacer pie de pagina":
                case "como hago pie de pagina":
                case "como puedo hacer pie de pagina":
                case "hacer pies de pagina":
                case "como hacer pies de pagina":
                case "como hago pies de pagina":
                case "como puedo hacer pies de pagina":
                    idpreg = 12;
                    break;
                case "agregar un encabezado":
                case "como agregar un encabezado":
                case "como agrego un encabezado":
                case "como puedo agregar un encabezado":
                case "agregar encabezados":
                case "como agregar encabezados":
                case "como agrego encabezados":
                case "como puedo agregar encabezados":
                    idpreg = 13;
                    break;
                case "agregar numero de pagina":
                case "como agregar numero de pagina":
                case "como agrego numero de pagina":
                case "como puedo agregar numero de pagina":
                case "agregar numeros de paginas":
                case "como agregar numeros de paginas":
                case "como agrego numeros de paginas":
                case "como puedo agregar numeros de paginas":
                    idpreg = 14;
                    break;
                case "agregar un comentario":
                case "como agregar un comentario":
                case "como agrego un comentario":
                case "como puedo agregar un comentario":
                case "agregar comentarios":
                case "como agregar comentarios":
                case "como agrego comentarios":
                case "como puedo agregar comentarios":
                    idpreg = 15;
                    break;
                case "agregar un grafico":
                case "como agregar un grafico":
                case "como agrego un grafico":
                case "como puedo agregar un grafico":
                case "agregar graficos":
                case "como agregar graficos":
                case "como agrego graficos":
                case "como puedo agregar graficos":
                    idpreg = 16;
                    break;
                case "agregar una forma":
                case "como agregar una forma":
                case "como agrego una forma":
                case "como puedo agregar una forma":
                case "agregar formas":
                case "como agregar formas":
                case "como agrego formas":
                case "como puedo agregar formas":
                case "agregar una figura":
                case "como agregar una figura":
                case "como agrego una figura":
                case "como puedo agregar una figura":
                case "agregar figuras":
                case "como agregar figuras":
                case "como agrego figuras":
                case "como puedo agregar figuras":
                    idpreg = 17;
                    break;
                case "agregar un hipervinculo":
                case "como agregar un hipervinculo":
                case "como agrego un hipervinculo":
                case "como puedo agregar un hipervinculoa":
                case "agregar hipervinculos":
                case "como agregar hipervinculos":
                case "como agrego hipervinculos":
                case "como puedo agregar hipervinculos":
                    idpreg = 18;
                    break;
                case "hacer un salto de pagina":
                case "como hacer un salto de pagina":
                case "como hago un salto de pagina":
                case "como puedo hacer un salto de pagina":
                case "hacer saltos de paginas":
                case "como hacer saltos de paginas":
                case "como hago saltos de paginas":
                case "como puedo hacerr saltos de paginas":
                    idpreg = 19;
                    break;
                default:
                    idpreg = 0;
                    break;
            }
            //Console.WriteLine("Finalizo el 2");
            string datasource = @"serverdb.czhcdacyy7nr.us-west-1.rds.amazonaws.com, 1433";
            string database = "SAAC";
            string username = "EquipoSAAC";
            string password = "Saac12345";
            string connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            SqlConnection conn = new SqlConnection(connString);
            Console.WriteLine("Getting Connection ...");
            try
            {
                Console.WriteLine("Openning Connection ...");


                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;
                if (idpreg == 0)
                {
                    Console.WriteLine("no se encontro coincidencia...");
                    txtConversacionChat.AppendText("\n Zack: No tengo informacion al respecto :(");
                }
                else
                {
                    cmd.CommandText = "SELECT respuesta FROM Respuestas where id_respuesta=" + idpreg;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string resp = (string)reader["respuesta"];
                        Console.WriteLine("Respuesta: " + resp);
                        txtConversacionChat.AppendText("\n Zack: " + resp);
                        synth.Speak(resp);

                    }
                }
                Console.WriteLine("Connection successful!");
            }
            catch (Exception sql)
            {
                Console.WriteLine("Error: " + sql.Message);
            }
        }

        private void btnEnviarPregunta_click(object sender, RoutedEventArgs e)
        {
            txtConversacionChat.AppendText("\n User: " + txtPreguntas.Text);
            buscar(txtPreguntas.Text);
        }
    }
}