namespace WorkingWithVisualStudio.Controllers
{
	using System.Linq;

	using Microsoft.AspNetCore.Mvc;

	using WorkingWithVisualStudio.Models;

	public class HomeController : Controller
	{
		// GET
		// public IActionResult Index() => View(SimpleRepository.SharedRepository.Products);
		public IActionResult Index() => View(SimpleRepository.SharedRepository.Products.Where(p => p.Price < 50));
	}
}