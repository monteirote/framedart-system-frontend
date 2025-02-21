using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace framedart_frontend.Models.Login {
    public class LoginResponse {
        public bool Success { get; set; }
        public string Message { get; set; }
        public bool PermissionDenied { get; set; }
        public string Data { get; set; }
    }
}