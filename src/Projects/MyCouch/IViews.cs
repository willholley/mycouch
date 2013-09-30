﻿using System;
using System.Threading.Tasks;
using MyCouch.Querying;
using MyCouch.Requests;
using MyCouch.Responses;

namespace MyCouch
{
    /// <summary>
    /// Used to query views.
    /// </summary>
    public interface IViews
    {
        /// <summary>
        /// Lets you run an <see cref="QueryViewRequest"/>.
        /// The resulting <see cref="JsonViewQueryResponse"/> will consist of
        /// Rows being JSON-strings.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<JsonViewQueryResponse> QueryAsync(QueryViewRequest query);

        /// <summary>
        /// Lets you run an <see cref="QueryViewRequest"/>.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<ViewQueryResponse<T>> QueryAsync<T>(QueryViewRequest query);

        /// <summary>
        /// Creates and executes an <see cref="QueryViewRequest"/> on the fly.
        /// The resulting <see cref="JsonViewQueryResponse"/> will consist of
        /// Rows being JSON-strings.
        /// </summary>
        /// <param name="designDocument"></param>
        /// <param name="viewname"></param>
        /// <param name="configurator"></param>
        /// <returns></returns>
        Task<JsonViewQueryResponse> QueryAsync(string designDocument, string viewname, Action<ViewQueryConfigurator> configurator);

        /// <summary>
        /// Creates and executes an <see cref="QueryViewRequest"/> on the fly.
        /// </summary>
        /// <param name="designDocument"></param>
        /// <param name="viewname"></param>
        /// <param name="configurator"></param>
        /// <returns></returns>
        Task<ViewQueryResponse<T>> QueryAsync<T>(string designDocument, string viewname, Action<ViewQueryConfigurator> configurator);
    }
}