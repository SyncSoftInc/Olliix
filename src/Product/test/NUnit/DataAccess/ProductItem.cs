﻿using Dapper;
using NUnit.Framework;
using SyncSoft.App.Components;
using SyncSoft.Olliix.Product.Command.ProductItem;
using SyncSoft.Olliix.Product.DataAccess;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductItem : DALTestBase
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IProductItemMDAL> _lazyProductItemMDAL = ObjectContainer.LazyResolve<IProductItemMDAL>();
        private IProductItemMDAL _ProductItemMDAL => _lazyProductItemMDAL.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Insert  -

        [Test]
        public async Task Insert()
        {
            var familyIds = Connection.Query<string>("SELECT ID FROM ProductFamilies").AsList();

            var a = familyIds.SelectMany(familyId =>
            {
                var maxItems = new Random().Next(1, 10);
                var maxImageHashs = new Random().Next(1, maxItems);

                var imageHashes = Enumerable.Range(1, maxImageHashs).Select(i =>
                {
                    return (i, Guid.NewGuid().ToLowerNString());
                }).ToDictionary(x => x.Item1 - 1, x => x.Item2);

                var b = Enumerable.Range(1, maxItems).Select(async itemId =>
                {
                    var cmd = Mock.CreateWithRandomData<CreateProductItemCommand>();
                    cmd.ItemNo = $"{familyId}:{TestEnv.Item_IdPrefix}{itemId:D3}";
                    cmd.Family_ID = familyId;
                    cmd.ImageHash = imageHashes[new Random().Next(0, maxImageHashs - 1)];
                    cmd.ImageUrl = $"{cmd.ImageHash}.jpg";

                    var msgCode = await _ProductItemMDAL.InsertAsync(cmd).ConfigureAwait(false);
                    Assert.IsTrue(msgCode.IsSuccess());
                    return msgCode;
                });

                return b;
            }).ToArray();

            await Task.WhenAll(a).ConfigureAwait(false);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Cleanup  -

        [Test, Order(0)]
        public void Cleanup()
        {
            Connection.Execute(sql: $"DELETE FROM ProductItems WHERE Family_ID LIKE '{TestEnv.Family_IdPrefix}%'");
        }

        #endregion
    }
}
