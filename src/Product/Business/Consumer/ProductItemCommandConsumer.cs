﻿using SyncSoft.App.Components;
using SyncSoft.App.Messaging;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.Domain;
using System;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.Consumer
{
    public class ProductItemCommandConsumer
        : IConsumer<CreateProductItemCommand>
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductItemService> _lazyProductItemService = ObjectContainer.LazyResolve<IProductItemService>();
        private IProductItemService _ProductItemService => _lazyProductItemService.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  CreateProductItemCommand  -

        public async Task<object> HandleAsync(IContext<CreateProductItemCommand> context)
        {
            var msg = context.Message;

            return await _ProductItemService.CreateProductItemAsync(msg).ConfigureAwait(false);
        }

        #endregion
    }
}
