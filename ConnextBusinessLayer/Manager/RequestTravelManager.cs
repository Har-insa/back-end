using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;

namespace ConnextBusinessLayer.Managers
{
    public class RequestTravelManager : BaseManager
    {
        public RequestTravelManager() : base()
        {

        }
        public List<REQUEST_TRAVEL> getList()
        {
            try
            {
                var Context = new connext_dbEntities();
#if DEBUG
                return Context.REQUEST_TRAVEL.ToList();
#else
                return Context.REQUEST_TRAVEL.ToList();
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la liste des requests." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de récupérer la liste des requests.");

#endif
            }
        }

        public List<REQUEST_TRAVEL> getList(int id_travel)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.REQUEST_TRAVEL.Where(r => r.ID_TRAVEL == id_travel).ToList();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la liste des requests." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de récupérer la liste des requests.");

#endif
            }
        }

        public REQUEST_TRAVEL get(int Id)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.REQUEST_TRAVEL.Single(l => l.ID_REQUEST_TRAVEL == Id);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer le request." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de récupérer le request.");

#endif
            }
        }



        public void add(REQUEST_TRAVEL request)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.REQUEST_TRAVEL.Add(request);
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

        public void modify(int id, int idaction)
        {
            try
            {
                var Context = new connext_dbEntities();
                REQUEST_TRAVEL requesttravel = Context.REQUEST_TRAVEL.First(r => r.ID_REQUEST_TRAVEL == id);
                requesttravel.ID_ACTION = idaction;
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

        public void remove(REQUEST_TRAVEL request)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.REQUEST_TRAVEL.Remove(request);
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
