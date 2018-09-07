using es.dmoreno.house.core.baseclasses;
using es.dmoreno.house.core.dto;
using es.dmoreno.house.core.interfaces;
using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core.businesslogic.local
{
    public class LocalMasterDetail : Base, IMasterDetail
    {
        internal LocalMasterDetail(ConnectionParameters con) : base(con)
        {

        }

        public bool insert(DTOMaster md)
        {
            throw new NotImplementedException();
        }
    }
}
