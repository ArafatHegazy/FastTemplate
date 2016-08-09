using System.Data.Entity;

namespace @(Model.ApplicationData.Namespace).Model.DbModel
{
    public class Context : DbContext, IContext
    {
        public Context()
            : base("ConnectionName")
        {
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        /*public IDbSet<ENTITY_CLASS> ENTITY { get; set; }*/
    }
}
