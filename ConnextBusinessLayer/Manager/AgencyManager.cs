using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;

namespace ConnextBusinessLayer.Managers
{
    public class AgencyManager : BaseManager
    {
        public AgencyManager() : base()
        {

        }
        public List<AGENCY> getList()
        {
            try
            {
                var Context = new connext_dbEntities();
#if DEBUG
                return Context.AGENCies.ToList();
#else
                return Context.AGENCies.ToList();
#endif
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

        public AGENCY get(int Id)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.AGENCies.Single(l => l.ID_AGENCY == Id);
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



        public void add(AGENCY agency)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.AGENCies.Add(agency);
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

        public void remove(AGENCY agency)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.AGENCies.Remove(agency);
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
