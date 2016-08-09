using System;

namespace @(Model.ApplicationData.Namespace).Model.DbModel
{
    public interface IContext : IDisposable
    {
        /*IDbSet<ENTITYC_CLASS> ENTITY { get; set; }*/
        int SaveChanges();
    }
}