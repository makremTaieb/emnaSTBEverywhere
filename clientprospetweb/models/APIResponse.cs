﻿using System.Net;

namespace clientprospetweb.models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode {  get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }

    }
}
