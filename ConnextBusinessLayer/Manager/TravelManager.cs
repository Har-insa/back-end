using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;

namespace ConnextBusinessLayer.Managers
{
    public class TravelManager : BaseManager
    {
        public TravelManager() : base()
        {

        }
        public List<TRAVEL> getList()
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.TRAVELs.ToList();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la liste des covoiturages." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de récupérer la liste des covoiturages.");

#endif
            }
        }

        public List<TRAVEL> getListByUser(int id_user)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.TRAVELs.Where(t => t.PUBLICATION.ID_USER == id_user).ToList();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la liste des covoiturages." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de récupérer la liste des covoiturages.");

#endif
            }
        }

        public TRAVEL get(int Id)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.TRAVELs.Single(l => l.ID_TRAVEL == Id);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer le covoiturage." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de récupérer le covoiturage.");

#endif
            }
        }



        public void add(TRAVEL travel)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.TRAVELs.Add(travel);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de modifier le covoiturage." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de modifier le covoiturage.");

#endif
            }

        }

        public void add(TRAVEL travel, PUBLICATION publication)
        {
            try
            {
                var Context = new connext_dbEntities();
                publication.TRAVELs.Add(travel);
                Context.PUBLICATIONs.Add(publication);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de modifier le covoiturage." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de modifier le covoiturage.");

#endif
            }

        }

        public void remove(TRAVEL travel)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.TRAVELs.Remove(travel);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de supprimer le covoiturage." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de supprimer le covoiturage.");

#endif
            }

        }
    }
}
