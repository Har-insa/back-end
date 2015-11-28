using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;

namespace ConnextBusinessLayer.Managers
{
    public class GroupManager : BaseManager
    {
        public GroupManager() : base()
        {

        }
        public List<GROUP> getList()
        {
            try
            {
                var Context = new connext_dbEntities();
#if DEBUG
                return Context.GROUPs.ToList();
#else
                return Context.GROUPs.ToList();
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la liste des groupes." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de récupérer la liste des groupes.");

#endif
            }
        }

        public GROUP get(int Id)
        {
            try
            {
                var Context = new connext_dbEntities();
                return Context.GROUPs.Single(l => l.ID_GROUP == Id);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la groupe." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de récupérer la groupe.");

#endif
            }
        }



        public void add(GROUP group)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.GROUPs.Add(group);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible d'ajouter la groupe." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible d'ajouter la groupe.");

#endif
            }

        }

        public void removeUser(int id_group, int id_user)
        {
            try
            {
                Context.GROUPs.First(g => g.ID_GROUP == id_group).USERs.Remove(Context.USERs.First(u => u.ID_USER == id_user));
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de supprimer l'utilisateur." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de supprimer l'utilisateur.");

#endif
            }
        }

        public void addUser(int id_group, int id_user)
        {
            try
            {
                Context.GROUPs.First(g => g.ID_GROUP == id_group).USERs.Add(Context.USERs.First(u => u.ID_USER == id_user));
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible d'ajouter l'utilisateur." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible d'ajouter l'utilisateur.");

#endif
            }
        }

        public void remove(GROUP group)
        {
            try
            {
                var Context = new connext_dbEntities();
                Context.GROUPs.Remove(group);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de supprimer la groupe." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de supprimer la groupe.");

#endif
            }

        }
    }
}
