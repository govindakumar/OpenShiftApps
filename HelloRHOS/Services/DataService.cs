using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRHOS.Services
{
    public class DataService 
    {
        public DataService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        //public async Task<object> GetDataAsync(string query)
        //{
        //    using var connection = new MySqlConnection(Configuration["ConnectionStrings:Default"]);
        //    await connection.OpenAsync();

        //    using var command = new MySqlCommand("SELECT field FROM table;", connection);
        //    using var reader = await command.ExecuteReaderAsync();
        //    while (await reader.ReadAsync())
        //    {
        //        var value = reader.GetValue(0);
        //        // do something with 'value'
        //    }
        //}
    }
}
