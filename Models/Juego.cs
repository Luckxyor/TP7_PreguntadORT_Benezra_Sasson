namespace TP7_PreguntadORT_Benezra_Sasson.Models;

static class Juego{
    private static string username;
    private static int puntajeActual;
    private static int contadorPreguntaActual;
    private static int cantidadPreguntasCorrectas;
    private static List<Pregunta> Preguntas;
    private static List<Respuesta> preguntasxRespuesta;

    private static void InicializarJuego(){
        username = null;
        puntajeActual=0;
        cantidadPreguntasCorrectas=0;
        contadorPreguntaActual=1;
    }
    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();
    }
    public static List<Dificultad> ObtenerDificultades(){
        return BD.ObtenerDificultades();
    }
    public static void CargarPartida(string Username, int dificultad, int categoria){
        InicializarJuego();
        username=Username;
        Preguntas=BD.ObtenerPreguntas(dificultad, categoria);
    }
    public static Pregunta ObtenerProximaPregunta(){
        return Preguntas[contadorPreguntaActual];
    }
    public static void ObtenerProximasRespuestas(int idPregunta){

    }
    public static void VerificarRespuesta(int idPregunta, int idRespuesta){

    }
}