using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;

namespace ConnextBusinessLayer.Managers
{
    public class CategoryManager : BaseManager
    {
        public CategoryManager() : base()
        {

        }
        public List<CATEGORY> getList()
        {
            try
            {
                var Context = new connext_dbEntities();
#if DEBUG
                return Context.CATEGORies.ToList();
#else
                return Context.CATEGORies.ToList();
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

        public CATEGORY get(int Id)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.CATEGORies.Single(l => l.ID_CATEGORY == Id);
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



        public void add(CATEGORY cat)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.CATEGORies.Add(cat);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de modifier l'agence." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de modifier l'agence.");

#endif
            }

        }

        public void remove(CATEGORY cat)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.CATEGORies.Remove(cat);
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
