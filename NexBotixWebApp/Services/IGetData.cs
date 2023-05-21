using System.Collections.Generic;
using System.Threading.Tasks;
using NexBotixWebApp.Models;

namespace NexBotixWebApp.Services
{
    public interface IGetData
    {
        IEnumerable<TableOutputModel> DataOutput();
        Task<List<T>> GetItemsFromEndPoint<T>(string endpoint);
    }
}