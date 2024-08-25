namespace TP7_PreguntadORT_Benezra_Sasson.Models;

static class Juego{
    static string username;
    static int puntajeActual;
    static int cantidadPreguntasCorrectas;
    static List<Pregunta> Preguntas;
    static List<Respuesta> preguntasxRespuesta;

    public static void InicializarJuego(){
        username = null;
        puntajeActual=0;
        cantidadPreguntasCorrectas=0;
    }
    public static List<Categoria> ObtenerCategorias(){
        return BD.ObtenerCategorias();;
    }
    public static List<Dificultad> ObtenerDificultades(){
        return BD.ObtenerDificultades();;
    }
    public static CargarPartida(string username, int dificultad, int categoria){
        
    }
}