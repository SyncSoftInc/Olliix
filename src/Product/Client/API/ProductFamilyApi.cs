﻿using SyncSoft.App.Http;
using SyncSoft.App.WebApi.Auth;
using SyncSoft.Olliix.API;
using System.Threading;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.API
{
    public class ProductFamilyApi : OlliixApiBase, IProductFamilyApi
    {
        public Task<HttpResult<string>> CreateProductFamilyAsync(object cmd, CancellationToken? cancellationToken)
        {
            return base.PostAsync<string>(BearerAuthModeEnum.Client, "product/family", cmd, cancellationToken: cancellationToken);
        }
    }
}
