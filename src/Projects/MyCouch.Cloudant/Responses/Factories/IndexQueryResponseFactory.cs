﻿using System.Net.Http;
using MyCouch.Extensions;
using MyCouch.Responses.Factories;
using MyCouch.Serialization;

namespace MyCouch.Cloudant.Responses.Factories
{
    public class IndexQueryResponseFactory : ResponseFactoryBase
    {
        public IndexQueryResponseFactory(IResponseMaterializer responseMaterializer) : base(responseMaterializer) { }

        public virtual IndexQueryResponse<T> Create<T>(HttpResponseMessage response) where T : class
        {
            return CreateResponse<IndexQueryResponse<T>>(response, OnSuccessfulViewQueryResponseContentMaterializer, OnFailedResponseContentMaterializer);
        }

        protected virtual void OnSuccessfulViewQueryResponseContentMaterializer<T>(HttpResponseMessage response, IndexQueryResponse<T> result) where T : class
        {
            using (var content = response.Content.ReadAsStream())
                ResponseMaterializer.PopulateViewQueryResponse(result, content);
        }
    }
}