using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIA.Common.Adaptor
{
    public interface IWebApiAdaptor
    {
        To Get<To>(string uri);

        To Post<Ti,To>(string uri, Ti obj);

        To Put<Ti,To>(string uri, Ti obj);

        To Delete<To>(string uri);
    }
}
