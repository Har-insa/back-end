using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnextBusinessLayer.Manager
{
    public abstract class BaseManager
    {
        private Bdd.connext_dbEntities context;

        internal Bdd.connext_dbEntities Context
        {
            get { return context; }
        }

        public BaseManager()
        { 
            context = new Bdd.connext_dbEntities();
        }

    }
}
