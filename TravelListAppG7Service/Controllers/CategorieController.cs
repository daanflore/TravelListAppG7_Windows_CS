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
    public class CategorieController : TableController<Categorie>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            TravelListAppG7Context context = new TravelListAppG7Context();
            DomainManager = new EntityDomainManager<Categorie>(context, Request, Services);
        }

        // GET tables/Categorie
        public IQueryable<Categorie> GetAllCategorie()
        {
            return Query(); 
        }

        // GET tables/Categorie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Categorie> GetCategorie(string id)
        {
            return Lookup(id);
        }
        
        // PATCH tables/Categorie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Categorie> PatchCategorie(string id, Delta<Categorie> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Categorie
        public async Task<IHttpActionResult> PostCategorie(Categorie item)
        {
            Categorie current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Categorie/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCategorie(string id)
        {
             return DeleteAsync(id);
        }

    }
}