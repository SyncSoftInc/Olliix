using Nest;
using SyncSoft.App.Components;
using SyncSoft.ECP.DTOs;
using SyncSoft.Olliix.Product.DataAccess;
using SyncSoft.Olliix.Product.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncSoft.Olliix.Product.ElasticSearch.Catalogue
{
    public class CatalogueItemQDAL : ICatalogueItemQDAL
    {
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private const string IndexName = "olx_catalogue_items";

        #endregion
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IElasticClient> _lazyElasticClient = ObjectContainer.LazyResolve<IElasticClient>();
        private IElasticClient _ElasticClient => _lazyElasticClient.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  BulkInsertItems  -

        public async Task<string> BulkInsertItemsAsync(IEnumerable<CatalogueItemDTO> items)
        {
            var resp = await _ElasticClient.BulkAsync(x => x.Index(IndexName)
                .IndexMany(items)
            ).ConfigureAwait(false);
            return HandleResponse(resp);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  DeleteFamilyItems  -

        public async Task<string> DeleteFamilyItemsAsync(string familyId)
        {
            var resp = await _ElasticClient.DeleteByQueryAsync<CatalogueItemDTO>(x => x.Index(IndexName)
                //.Query(q => q.ConstantScore(c => c.Filter(f => f.Term("Family_ID", familyId.ToLower()))))
                .Query(q => q.Match(m => m.Field("Family_ID").Query(familyId)))
            );
            return HandleResponse(resp);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  GetFamilyItems  -

        public async Task<IList<CatalogueItemDTO>> GetFamilyItemsAsync(string familyId)
        {
            var resp = await _ElasticClient.SearchAsync<CatalogueItemDTO>(x => x.Index(IndexName)
                //.Query(q => q.ConstantScore(c => c.Filter(f => f.Term("Family_ID", familyId.ToLower()))))
                .Query(q => q.Match(m => m.Field("Family_ID").Query(familyId)))
            ).ConfigureAwait(false);

            return resp.Documents.ToList();
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  Search  -

        public Task<PagedList<CatalogueItemDTO>> SearchAsync()
        {
            throw new NotImplementedException();
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  HandleResponse  -

        private string HandleResponse(ResponseBase resp)
        {
            return resp.IsValid ? MsgCodes.SUCCESS : resp.DebugInformation;
        }

        #endregion
    }
}
