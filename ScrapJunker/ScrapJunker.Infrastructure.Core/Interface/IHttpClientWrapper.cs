using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapJunker.Infrastructure.Core.Interface
{
    public interface IHttpClientWrapper
    {
       void Post<T>(string url, T body);
    }
}
