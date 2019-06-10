using SyncSoft.ECP.WebApi.ApiProxies;

namespace SyncSoft.Olliix.API
{
    public class OlliixApiBase : ECPApiProxyBase
    {
        protected override string UriKey => "olx_product_api_v1";
    }
}
