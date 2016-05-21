using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemoApp.Models;
using CoreDemoApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemoApp.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            var repository = new AlbumRepository();
            var model = repository.GetAlbums().Select(a => new AlbumModel
            {
                AlbumId = a.AlbumId,
                Genre = new GenreModel { Name = a.Genre.Name},
                Title = a.Title,
                Price = a.Price

            }).ToList();
            return View(model);
        }
    }
}