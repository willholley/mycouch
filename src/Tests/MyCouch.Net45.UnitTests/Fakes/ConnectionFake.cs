﻿using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MyCouch.Net;

namespace MyCouch.UnitTests.Fakes
{
    public class ConnectionFake : IConnection
    {
        public Uri Address { get; private set; }

        public ConnectionFake(Uri address)
        {
            Address = address;
        }

        public virtual void Dispose() { }

        public Task<HttpResponseMessage> SendAsync(HttpRequest httpRequest)
        {
            return null;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequest httpRequest, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequest httpRequest, HttpCompletionOption completionOption)
        {
            return null;
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequest httpRequest, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
