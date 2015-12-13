using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using TravelListAppG7Service.DataObjects;
using TravelListAppG7Service.Models;

namespace TravelListAppG7Service.Controllers
{
    public class PackingItemController : TableController<PackingItem>
    {
        
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListAppG7Context context = new TravelListAppG7Context();
            DomainManager = new EntityDomainManager<PackingItem>(context, Request, Services);
        }

        // GET tables/PackingItem
        public IQueryable<PackingItem> GetAllPackingItem()
        {
            return Query(); 
        }

        // GET tables/PackingItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<PackingItem> GetPackingItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/PackingItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<PackingItem> PatchPackingItem(string id, Delta<PackingItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/PackingItem
        public async Task<IHttpActionResult> PostPackingItem(PackingItem item)
        {
            PackingItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/PackingItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeletePackingItem(string id)
        {
             return DeleteAsync(id);
        }

    }
}