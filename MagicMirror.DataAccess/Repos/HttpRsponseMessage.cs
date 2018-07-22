using System;
using System.Net.Http;

namespace MagicMirror.DataAccess.Repos
{
    internal class HttpRsponseMessage
    {
        public bool IsSuccessStatusCode { get; internal set; }
        public object StatusCode { get; internal set; }
        public object ReasonPhrase { get; internal set; }

        public static implicit operator HttpRsponseMessage(HttpResponseMessage v)
        {
            throw new NotImplementedException();
        }
    }
}