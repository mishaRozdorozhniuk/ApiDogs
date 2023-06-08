using System;
using ApiDogs.Abstract;
using ApiDogs.Controllers.Request;
using ApiDogs.DAL;
using ApiDogs.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace ApiDogs.Services;

public class DogServices
{
    private readonly DogsContext _dogsContext;

    public DogServices(DogsContext dogsContext)
    {
        _dogsContext = dogsContext;
    }

    public string Ping()
        => "Dogs house service. Version 1.0.1";

    public async Task<List<Dog>> GetDogsAsync()
        => await _dogsContext.Dog.ToListAsync();

    public async Task<DataServiceMessage> CreateDogAsync(DogRequest dogRequest)
    {
        var isDogExist = await _dogsContext.Dog.FirstOrDefaultAsync(x => x.Name == dogRequest.Name);

        if (isDogExist is not null) return new DataServiceMessage(false, "Dog already created");

        var dog = new Dog();

        dog.Color = dogRequest.Color;
        dog.Name = dogRequest.Name;
        dog.TailLength = dogRequest.TailLength;
        dog.Weight = dogRequest.Weight;

        await _dogsContext.Dog.AddAsync(dog);
        await _dogsContext.SaveChangesAsync();

        return new DataServiceMessage(true, dog);
    }

    public async Task<List<Dog>> GetFilteredDogs(string attribute, string order)
    {
        var response = new List<Dog>();

        switch (attribute.ToLower())
        {
            case "name":
                response = await FilterByOrderAsync(order);
                break;
            default:
                break;
        }

        return response;
    }

    private async Task<List<Dog>> FilterByOrderAsync(string order)
    {
        if (order.ToLower() == "desc")
            return await _dogsContext.Dog.OrderByDescending(d => d.Name).ToListAsync();
        else
            return await _dogsContext.Dog.OrderBy(d => d.Name).ToListAsync();
    }
}

