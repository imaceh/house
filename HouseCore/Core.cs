using es.dmoreno.house.core.dto;
using es.dmoreno.utils.dataaccess.db;
using es.dmoreno.utils.dataaccess.textplain;
using es.dmoreno.utils.serialize;
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

        public Core(string config_file)
        {
            this.initialize(config_file);
        }

        private void initialize(string config_file)
        {
            using (TextPlainFile tp = new TextPlainFile(config_file))
            {
                if (tp.open())
                {
                    tp.set(JSon.serializeJSON<DTOConfig>(new DTOConfig() {
                        DataBase = new DTOConfigDB() {
                            DBMS = "SQLite",
                            Host = "database.db"
                        }
                    })).Wait();
                }
            }
        }
    }
}
