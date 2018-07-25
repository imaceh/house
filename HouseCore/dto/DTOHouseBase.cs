using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core.dto
{
    [TableAttributte]
    public class DTOHouseBase
    {
        [FieldAttribute(FieldName = "id", IsAutoincrement = true, Type = ParamType.Int32, IsPrimaryKey = true)]
        internal int ID { get; set; }
    }
}
