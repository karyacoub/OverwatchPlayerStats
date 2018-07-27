﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace OverwatchPlayerStats
{
    abstract class APIRequester
    {
        protected HttpClient client;

        protected APIRequester()
        {
            client = new HttpClient();

            // ensure that the string that is returned is in JSON format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // dispose of client when object is garbage-collected
        ~APIRequester()
        {
            client.Dispose();
        }

        protected abstract string getResponseString(string playerUsername);
    }
}
