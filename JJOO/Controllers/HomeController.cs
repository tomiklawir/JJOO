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
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult Paises()
    {
        ViewBag.ListaPais = BD.ListarPaises();
        return View();
    }
    public IActionResult Deportes()
    {
        ViewBag.ListaDeportes = BD.ListarDeportes();
        return View();
    }
    public IActionResult VerDetalleDeporte(int IdDeporte)
    {
        ViewBag.DetalleDeporte = BD.VerInfoDeporte(IdDeporte);
        ViewBag.DeportistasXDeporte = BD.ListarDeportistasDeporte(IdDeporte);
        return View();
    }
    public IActionResult DetalleDeportista(int IdDeportista)
    {
        ViewBag.DetalleDeportista = BD.VerInfoDeportista(IdDeportista);
        return View();
    }
    public IActionResult DetallePais(int IdPais)
    {
        ViewBag.DetallePais = BD.VerInfoPais(IdPais);
        ViewBag.DeportistasXPais = BD.ListarDeportistasPais(IdPais);
        return View();
    }
    public IActionResult AgregarDeportista()
    {
        ViewBag.ListaPais = BD.ListarPaises();
        ViewBag.ListaDeportes = BD.ListarDeportes();
        return View();
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
