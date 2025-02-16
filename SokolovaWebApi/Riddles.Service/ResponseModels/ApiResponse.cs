﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                var options = new JsonSerializerOptions()
                {
                    MaxDepth = 1000,
                    ReferenceHandler = ReferenceHandler.Preserve
                };

                this.Json = JsonSerializer.Serialize(jsonData, options);
            }
        }
    }
}
