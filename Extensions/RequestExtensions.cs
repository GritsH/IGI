﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WEB_953505_Grits.Extensions
{
    public static class RequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.Headers["x-requested-with"].Equals("XMLHttpRequest");
        }
    }
}
