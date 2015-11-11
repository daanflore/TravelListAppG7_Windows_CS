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
    public class TravelListController : TableController<TravelList>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListAppG7Context context = new TravelListAppG7Context();
            DomainManager = new EntityDomainManager<TravelList>(context, Request, Services);
        }

        // GET tables/TravelList
        public IQueryable<TravelList> GetAllTravelList()
        {
            return Query(); 
        }

        // GET tables/TravelList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<TravelList> GetTravelList(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TravelList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<TravelList> PatchTravelList(string id, Delta<TravelList> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/TravelList
        public async Task<IHttpActionResult> PostTravelList(TravelList item)
        {
            TravelList current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TravelList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTravelList(string id)
        {
             return DeleteAsync(id);
        }

    }
}