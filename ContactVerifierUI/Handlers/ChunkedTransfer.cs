using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ClientVerifierUI.Handlers
{
    public class ChunkedTransfer : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = base.SendAsync(request, cancellationToken);

            response.Result.Headers.TransferEncodingChunked = true;

            return response;
        }
    }
}