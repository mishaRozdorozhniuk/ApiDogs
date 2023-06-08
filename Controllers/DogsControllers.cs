using System;
using ApiDogs.Controllers.Request;
using ApiDogs.Models;
using ApiDogs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDogs.Controllers;

[ApiController]
[Route("[controller]")]
public class DogsControllers : ControllerBase
{
    private readonly DogServices _dogServices;

    public DogsControllers(DogServices dogServices)
    {
        _dogServices = dogServices;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        var message = _dogServices.Ping();
        return Ok(message);
    }

    [HttpGet("dogs")]
    public async Task<IActionResult> GetDogs()
        => Ok( await _dogServices.GetDogsAsync());

    [HttpPost("dog")]
    public async Task<IActionResult> CreateDog([FromBody] DogRequest dogRequest)
        => Ok(await _dogServices.CreateDogAsync(dogRequest));

    [HttpGet("dogsFilter")]
    public async Task<IActionResult> GetDogs([FromQuery] string attribute, [FromQuery] string order)
        => Ok(await _dogServices.GetFilteredDogs(attribute, order));
}

