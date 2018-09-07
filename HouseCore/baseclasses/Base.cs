using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core.baseclasses
{
    public abstract class Base
    {
        protected ConnectionParameters ConnectionParameters { get; private set; }
        protected DataBaseLogic DBLogic { get; private set; }

        internal Base(ConnectionParameters con)
        {
            this.initializate(con, null);
        }

        private void initializate(ConnectionParameters con, DataBaseLogic db)
        {
            this.ConnectionParameters = con;
            this.DBLogic = db;
        }
    }
}
