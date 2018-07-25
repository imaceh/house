using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core
{
    public class Core
    {
        private ECoreModePersistence _mode;
        private DBMSType _dbms_type;

        private Logic _db_logic;

        public Core()
        {
            this.initialize(ECoreModePersistence.DB, DBMSType.SQLite);
        }

        private void initialize(ECoreModePersistence mode, DBMSType dbms)
        {
            this._mode = mode;
            this._dbms_type = dbms;
        }
    }
}
