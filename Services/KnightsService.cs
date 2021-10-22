using System;
using Knights.Models;
using Knights.Repositories;

namespace Knights.Services
{
  public class KnightsService
  {
    private readonly KnightsRepository _knightsRepository;

    public KnightsService(KnightsRepository knightsRepository)
    {
      _knightsRepository = knightsRepository;
    }

    internal object GetAll()
    {
      return _knightsRepository.GetAll();
    }
    internal object GetById(int knightId)
    {
      Knight foundKnight = _knightsRepository.GetById(knightId);
      if(foundKnight == null)
      {
        return new Exception("unable to find knight or something");
      }
      return foundKnight;
    }

    internal Knight Post(Knight knightData)
    {
      return _knightsRepository.Post(knightData);
    }

  }
}