using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gizmo.Web.Api.Client
{
    public class MsgPackContent : HttpContent
    {
        public static MsgPackContent Create(object? obj)
        {
            return Create(obj);
        }

        public static MsgPackContent Create<T>(T obj)
        {
            return new MsgPackContent();
        }

        protected override Task<Stream> CreateContentReadStreamAsync()
        {
            return base.CreateContentReadStreamAsync();
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            throw new NotImplementedException();
        }

        protected override bool TryComputeLength(out long length)
        {
            throw new NotImplementedException();
        }
    }
}
