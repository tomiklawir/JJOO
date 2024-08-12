using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using JJOO.Models;

namespace JJOO.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Index");
    }
    public IActionResult Creditos()
    {
        return View("Creditos");
    }
    public IActionResult Paises()
    {
        return View("Paises");
        ViewBag.ListaPais = BD.ListarPaises();
    }
    public IActionResult Deportes()
    {
        return View("Deportes");
        ViewBag.ListaDeportes = BD.ListarDeportes();
    }
    public IActionResult VerDetalleDeporte(int IdDeporte)
    {
        ViewBag.DetalleDeporte = BD.VerInfoDeporte();
        ViewBag.DeportistasXDeporte = BD.ListarDeportistasDeporte();
        return View("DetalleDeporte");
    }
    public IActionResult DetalleDeportista(int IdDeportista)
    {
        ViewBag.DetalleDeportista = BD.VerInfoDeportista();
        return View("DetalleDeportista");
    }
    public IActionResult DetallePais(int IdPais)
    {
        ViewBag.DetallePais = BD.VerInfoPais();
        ViewBag.DeportistasXPais = BD.ListarDeportistasPais();
        return View("DetallePais");
    }
    public IActionResult AgregarDeportista()
    {
        ViewBag.ListaPais = BD.ListarPaises();
        ViewBag.ListaDeportes = BD.ListarDeportes();
        return View("AgregarDeportista");
    }
    [HttpPost] public  IActionResult GuardarDeportista(Deportista dep){
        BD.AgregarDeportista(dep);
        return View("Index");
    }
    public IActionResult EliminarDeportista(int IdCandidato)
    {
        BD.EliminarDeportista(IdCandidato);
        return View("Index");
    }
}
