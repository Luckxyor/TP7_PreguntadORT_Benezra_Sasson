using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP7_PreguntadORT_Benezra_Sasson.Models;

namespace TP7_PreguntadORT_Benezra_Sasson.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Tutorial()
    {
        return View();
    }
    public IActionResult ConfigurarJuego()
    {
        ViewBag.ListaDificultades=Juego.ObtenerDificultades();
        ViewBag.ListaCategorias=Juego.ObtenerCategorias();
        return View();
    }
    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        return RedirectToAction("Jugar");
    }

    //SASSÓN tenes que crear una funcion que sea "TerminarJuego", donde en Juego.cshtml tenes que crear un boton para finalizar el juego
    //Tambien aca abajo en la funcion jugar, en el if Pregunta==null, tenes que copiar todo eso y llevarlo a la nueva funcion
    //Y obviamente adentro del if hacer un redirectToAction a la funcion nueva
    //Ahora anda a Juego.cshtml y en Puntaje.cshtml 
    //Obviamente cuando termines borra TODOS los comentarios que te dejé
    //Cualquier duda, preguntame en whatsapp, si no te respondo es que me estan ajustando los brackets

    public IActionResult Jugar(){
        Pregunta PreguntaElegida=Juego.ObtenerProximaPregunta();
        if(PreguntaElegida==null){
            Juego.FinalJuego();
            return RedirectToAction("Puntaje", new {mensaje = "FINAL DEL JUEGO"});
        }
        else{
            return RedirectToAction("Preguntas", PreguntaElegida);
        }
    }
    public IActionResult Preguntas(Pregunta PreguntaElegida){
        ViewBag.PreguntaElegida=PreguntaElegida;
        ViewBag.ListaRespuestas=Juego.ObtenerProximasRespuestas(PreguntaElegida.IdPregunta);
        ViewBag.Usuario=Juego.username;
        ViewBag.PuntajeActual=Juego.puntajeActual;
        return View("Juego");
    }
    public IActionResult Puntaje(string mensaje){
        ViewBag.MensajeFinal=mensaje;
        ViewBag.TopPuntajes=BD.ObtenerPuntajes();
        return View("Puntaje");
    }

    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta){
        if(Juego.VerificarRespuesta(idRespuesta)){
            ViewBag.Mensaje="CORRECTO";
        }
        else{
            ViewBag.Mensaje="INCORRECTO";
            ViewBag.RespuestaCorrecta=$"La repsuesta correcta era: {BD.CualEraCorrecta(idPregunta)}";
        }
        return View("Respuesta");
    }
}
