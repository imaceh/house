using es.dmoreno.house.core.dto;
using es.dmoreno.house.core.maintenance;
using es.dmoreno.utils.dataaccess.db;
using es.dmoreno.utils.dataaccess.textplain;
using es.dmoreno.utils.path;
using es.dmoreno.utils.serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace es.dmoreno.house.core
{
    public class Core
    {
        static private DTOConfig DefaultConfig
        {
            get
            {
                return new DTOConfig()
                {
                    DataBase = new DTOConfigDB() {
                        DBMS = "SQLite",
                        Host = "database.db"
                    }
                };
            }
        }

        private ECoreModePersistence _mode;
        private DBMSType _dbms_type;
        private DTOConfig _config_data;

        private DataBaseLogic _db_logic;

        public Core(string config_file)
        {
            this.initialize(config_file, null);
        }

        public Core(DTOConfig config)
        {
            this.initialize(null, config);
        }

        private void initialize(string config_file, DTOConfig config_data)
        {
            //Read configuration
            if (config_data != null)
            {
                this._config_data = config_data;
            }
            else if (!string.IsNullOrEmpty(config_file))
            {
                if (File.Exists(config_file))
                {
                    using (TextPlainFile tp = new TextPlainFile(config_file))
                    {
                        if (tp.open())
                        {
                            this._config_data = JSon.deserializeJSON<DTOConfig>(tp.get());
                        }
                        else
                        {
                            throw new Exception("Application can not read config file in: " + config_file);
                        }
                    }
                }
                else
                {
                    using (TextPlainFile tp = new TextPlainFile(config_file))
                    {
                        if (tp.open())
                        {
                            this._config_data = DefaultConfig;
                            tp.set(JSon.serializeJSON<DTOConfig>(DefaultConfig));
                        }
                        else
                        {
                            throw new Exception("Application can not create config file in: " + config_file);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Application can not run without config parameters");
            }

            //Set configuration values
            if (string.IsNullOrEmpty(this._config_data.ModePersistence))
            {
                this._mode = ECoreModePersistence.DB;
            }
            else if (this._config_data.ModePersistence.ToUpper() == "DB")
            {
                this._mode = ECoreModePersistence.DB;
            }
            else if (this._config_data.ModePersistence.ToUpper() == "RESTAPI")
            {
                this._mode = ECoreModePersistence.RestAPI;
            }
            else
            {
                throw new Exception("Application have not set persistence mode");
            }

            if (this._mode == ECoreModePersistence.DB)
            {
                if (this._config_data.DataBase.DBMS.ToUpper() == "SQLITE")
                {
                    this._db_logic = new DataBaseLogic(DBMSType.SQLite, DataBaseLogic.createStringConnection(DBMSType.SQLite, Path.Combine(PathHelper.getAppDataFolder(), this._config_data.DataBase.Host), "", "", "", 0), null);
                }
                else
                {
                    throw new NotImplementedException("Other database engine is not supported");
                }
            }
            else
            {
                throw new NotImplementedException("Other persistence mode is not supported");
            }
        }

        public void initializeDBSchema()
        {
            DBSchema db_sch;

            using (DataBaseLogic l = this._db_logic.duplicate())
            {
                //db_sch = new DBSchema(l.Statement); ;
                //db_sch.generate().Wait();
                //l.Statement.beginTransaction();
                //l.Management.createAlterTable<DTOMaster>();
                //l.Statement.acceptTransaction();
            }
        }
    }
}
