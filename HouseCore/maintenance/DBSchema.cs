using es.dmoreno.house.core.dto;
using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace es.dmoreno.house.core.maintenance
{
    internal class DBSchema
    {
        private DataBaseLogic _db;

        public DBSchema(DataBaseLogic db)
        {
            this._db = db;
        }

        public async Task generate()
        {
            await this._db.Management.createAlterTableAsync<DTOMaster>();
            await this._db.Management.createAlterTableAsync<DTODetail>();
        }
    }
}
