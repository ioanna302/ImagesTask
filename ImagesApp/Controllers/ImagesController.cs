#nullable disable

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ImagesApp.Models;
using ImagesTask.Core.DTOs;
using ImagesTask.Core.Interfaces;
using ImagesTask.Core.Queries;
using System.Diagnostics;

namespace ImagesApp.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IImagesService _imagesService;
        private readonly IMapper _imageMapper;
        private readonly IMediator _mediator;

        public ImagesController(IImagesService imagesService, IMediator mediator, AutoMapper.IMapper mapper)
        {

            _imagesService = imagesService;
            _imageMapper = mapper;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetImagesQuery());
            return View(_imageMapper.Map<List<ImageViewModel>>(result));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImageViewModel image)
        {
            if (image.ImageFile.Length >= 5242880)
            {
                return BadRequest("Cannot upload image. Image file size > 5 MB ");
            }
            if (ModelState.IsValid)
            {
                ImageDTO imageBBL = _imageMapper.Map<ImageDTO>(image);

                await _mediator.Send(new CreateImageCommand() { imageFile = imageBBL });

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteImageCommand() { imageID = id });
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
