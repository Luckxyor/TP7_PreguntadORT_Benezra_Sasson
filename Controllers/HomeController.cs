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
    public IActionResult Jugar(){
        Pregunta PreguntaElegida=Juego.ObtenerProximaPregunta();
        if (PreguntaElegida==null){return View("Fin");}
        else{
            ViewBag.PreguntaElegida=PreguntaElegida;
            ViewBag.ListaRespuestas=Juego.ObtenerProximasRespuestas(PreguntaElegida.IdPregunta);
            ViewBag.Usuario=Juego.username;
            ViewBag.PuntajeActual=Juego.puntajeActual;
            return View("Juego");
        }
    }

    public IActionResult VerificarRespuesta(int idRespuesta){
        if(Juego.VerificarRespuesta(idRespuesta)){
            ViewBag.Mensaje="CORRECTO";
        }
        else{
            ViewBag.Mensaje="INCORRECTO";
        }
        return View("Respuesta");
    }
}
