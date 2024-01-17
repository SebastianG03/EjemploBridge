using EjemploBridge.Domain.Models;
using System.Net.Http.Json;

namespace EjemploBridge.Domain.Services
{
    public class BridgePatternService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private static BridgePatternService? instance;
        private readonly String _urlDevice = "https://bridgepatternapi20240117114944.azurewebsites.net/api/Device";
        private readonly String _urlRemote = "https://bridgepatternapi20240117114944.azurewebsites.net/api/Remote";


        private BridgePatternService() {}

        public static BridgePatternService Singleton()
        {
            if (instance== null)
            {
                instance= new BridgePatternService();
            }
            return instance;
        }

        public async Task<List<Remote>> GetRemotes()
        {            
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Remote>>(_urlRemote);
                Console.WriteLine(res);
                return res!;
            }catch(HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public async Task<List<Device>> GetDevices()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Device>>(_urlDevice);
                Console.WriteLine(res);
                return res!;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

    }
}
