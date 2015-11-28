using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;

namespace ConnextBusinessLayer.Managers
{
    public class PublicationManager : BaseManager
    {
        public PublicationManager() : base()
        {

        }
        public List<PUBLICATION> getList()
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.PUBLICATIONs.ToList();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la liste des agences." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de récupérer la liste des agences.");

#endif
            }
        }

        public PUBLICATION get(int Id)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.PUBLICATIONs.Single(l => l.ID_PUBLICATION == Id);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer l'agence." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de récupérer l'agence.");

#endif
            }
        }



        public void add(PUBLICATION publication)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.PUBLICATIONs.Add(publication);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de modifier le lieu." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de modifier le lieu.");

#endif
            }

        }

        public void remove(PUBLICATION publication)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.PUBLICATIONs.Remove(publication);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de supprimer le lieu." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de supprimer le lieu.");

#endif
            }

        }
    }
}
