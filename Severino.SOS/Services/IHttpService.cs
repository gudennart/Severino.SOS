using Severino.SOS.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Severino.SOS.Services
{
    public interface IHttpService
    {
        public Task<Response> GetAsync(string URL, Dictionary<string, string> Parms, object body);
        public Task<Response> PostAsync(string URL, object Body ,Dictionary<string, string> Parms);
        public Task<Response> PutAsync(string URL, string ID, object Body, Dictionary<string, string> Parms);
        public Task<Response> DeleteAsync(string URL, Dictionary<string, string> Parms);
    }
}
