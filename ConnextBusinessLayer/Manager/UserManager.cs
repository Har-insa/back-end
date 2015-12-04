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

        public string checkUser(string email, string password)
        {
            try {
                USER user = (Context.USERs.First(u => u.EMAIL == email && u.PASSWORD == password));
                if (user != null)
                {
                    return addSession(user.ID_USER);
                }
                return null;
            } 
            catch
            {
                throw new Exception("Impossible de vérifier l'utilisateur.");
            }
        }
        public string addSession(int id_user)
        {
            try
            {
                Guid token = Guid.NewGuid();
                SESSION userToken = new SESSION();
                userToken.ID_USER = id_user;
                userToken.TOKEN = token;
                userToken.CREATION_DATE = DateTime.Now;
                userToken.LAST_CONNECT_DATE = DateTime.Now;
                Context.SESSIONs.Add(userToken);
                Context.SaveChanges();
                return token.ToString();
            }
            catch
            {
                throw new Exception("Impossible de créer la session.");
            }
        }

        public int getUserFromSession(Guid token)
        {
            try
            {
                return Context.SESSIONs.Single(s => s.TOKEN == token).ID_USER;
            }
            catch
            {
                throw new Exception();
            }
        }
        public void updateSession(int id_user, Guid token)
        {
            try
            {
                SESSION userToken = new SESSION();
                userToken.ID_USER = id_user;
                userToken.TOKEN = token;
                userToken.CREATION_DATE = DateTime.Now;
                userToken.LAST_CONNECT_DATE = DateTime.Now;
            }
            catch
            {
                throw new Exception("Impossible de créer la session.");
            }
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
                Context.GROUPs.First(g => g.ID_GROUP == 1).USERs.Add(user);
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
