﻿using System.Net.Http;
using MyCouch.Net;

namespace MyCouch.Requests.Factories
{
    public class PutAttachmentHttpRequestFactory :
        AttachmentHttpRequestFactoryBase,
        IHttpRequestFactory<PutAttachmentRequest>
    {
        public PutAttachmentHttpRequestFactory(IConnection connection) : base(connection) { }

        public virtual HttpRequest Create(PutAttachmentRequest request)
        {
            var httpRequest = new HttpRequest(HttpMethod.Put, GenerateRequestUrl(request.DocId, request.DocRev, request.Name));

            httpRequest.SetIfMatch(request.DocRev);
            httpRequest.SetContent(request.Content, request.ContentType);

            return httpRequest;
        }
    }
}