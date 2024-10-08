namespace TP7_PreguntadORT_Benezra_Sasson.Models;

static class Juego{
    public static string username;
    public static int puntajeActual;
    private static int contadorPreguntaActual;
    private static int cantidadPreguntasCorrectas;
    private static List<Pregunta> Preguntas;
    private static List<Respuesta> preguntasxRespuesta;
    private static int preguntaElegida;

    private static void InicializarJuego(){
        username = null;
        puntajeActual=0;
        cantidadPreguntasCorrectas=0;
        contadorPreguntaActual=0;
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
        ObtenerPreguntaRandom();
        if(Preguntas.Count!=0){
            return Preguntas[preguntaElegida];
        }
        else{
            return null;
        }
    }
    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta){
        return BD.ObtenerRespuestas(idPregunta);
    }
    public static bool VerificarRespuesta(int idRespuesta){
        bool EsCorrecto=BD.EsCorrecta(idRespuesta);
        if(EsCorrecto==true){
            puntajeActual=puntajeActual+50;
            cantidadPreguntasCorrectas++;
        }
        Preguntas.RemoveAt(preguntaElegida);
        contadorPreguntaActual++;
        return EsCorrecto;
    }
    public static void ObtenerPreguntaRandom(){
        Random rnd = new();
        preguntaElegida = rnd.Next(0, Preguntas.Count);
    }
    public static int FinalJuego(){
        Puntaje puntaje=new Puntaje(username, puntajeActual, DateTime.Now);
        BD.IngresarPuntaje(puntaje);
        return puntajeActual;
    }

}