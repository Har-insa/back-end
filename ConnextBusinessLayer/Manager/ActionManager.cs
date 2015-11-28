using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;

namespace ConnextBusinessLayer.Managers
{
    public class ActionManager : BaseManager
    {
        public ActionManager() : base()
        {

        }
        public List<ACTION> getList()
        {
            try
            {
                var Context = new connext_dbEntities();
#if DEBUG
                return Context.ACTIONs.ToList();
#else
                return Context.ACTIONs.ToList();
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

        public ACTION get(int Id)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.ACTIONs.Single(l => l.ID_ACTION == Id);
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
    }
}
