using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetSpa.Models;

namespace DotNetSpa.Repository
{
  public interface IStatesRepository
  {
    Task<List<State>> GetStatesAsync();
  }
}