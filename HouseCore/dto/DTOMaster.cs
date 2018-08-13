using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core.dto
{
    [TableAttribute(Name = "master", Type = EngineType.Default)]
    public class DTOMaster : DTOHouseBase
    {
        [Field(FieldName = "code", DefaultValue = "", AllowNull = false, Size = new[] { 10 }, Type = ParamType.String)]
        public string Code { get; set; }

        [Field(FieldName = "type", DefaultValue = (int)ETypeMaster.None, AllowNull = false, Type = ParamType.Int32)]
        public ETypeMaster Type { get; set; } = ETypeMaster.None;

        [Field(FieldName = "date", Type = ParamType.DateTime)]
        public DateTime Date { get; set; }

        public List<DTODetail> Detail { get; set; }
    }
}
