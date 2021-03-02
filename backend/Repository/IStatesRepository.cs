using System.Collections.Generic;
using System.Threading.Tasks;
using Angular_Net_Spa.Models;

namespace Angular_Net_Spa.Repository
{
    public interface IStatesRepository
    {
        Task<List<State>> GetStatesAsync();
    }
}