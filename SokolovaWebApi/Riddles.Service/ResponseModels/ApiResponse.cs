using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Riddles.Service.ResponseModels
{
    public class ApiResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string Json { get; set; }

        public ApiResponse(bool success = false, string message = "", object jsonData = null)
        {
            this.Success = success;
            this.Message = message;
            if (jsonData != null)
            {
                this.Json = JsonSerializer.Serialize(jsonData);
            }
        }
    }
}
