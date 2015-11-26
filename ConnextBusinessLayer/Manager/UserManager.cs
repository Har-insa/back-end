using System;
using System.Collections.Generic;
using System.Linq;
using ConnextBusinessLayer.Bdd;
using ConnextBusinessLayer.Manager;
using System.Data.Entity;

namespace ConnextBusinessLayer.Managers
{
    public class UserManager : BaseManager
    {

        public List<USER> getList()
        {
            try
            {
#if DEBUG
                return Context.USERs.ToList();
#else
                return Context.USERs.ToList();
#endif
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer la liste des utilisateurs." + Environment.NewLine + ex.StackTrace);
#else
                throw new Exception("Impossible de récupérer la liste des utilisateurs.");

#endif
            }
        }

        public bool checkUser(string email, string password)
        {
            if (Context.USERs.First(u => u.EMAIL == email && u.PASSWORD == password) != null)
                return true;
            return false;        
        }

        public USER get(int Id)
        {
            try
            {
                return Context.USERs.Single(l => l.ID_USER == Id);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de récupérer l'utilisateur." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de récupérer l'utilisateur.");

#endif
            }
        }



        public void add(USER user)
        {
            try
            {
                Context.USERs.Add(user);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de ajouter l'utilisateur." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de ajouter l'utilisateur.");

#endif
            }

        }

        public void remove(USER user)
        {
            try
            {
                Context.USERs.Remove(user);
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

        public void modify(USER user)
        {
            try
            {
                Context.USERs.Attach(user);
                Context.Entry(user).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
#if DEBUG
                throw new Exception("Impossible de modifier l'utilisateur." + Environment.NewLine + ex.StackTrace);
#else
        throw new Exception("Impossible de modifier l'utilisateur.");

#endif
            }
        }
    }
}
