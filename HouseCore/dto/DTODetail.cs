using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core.dto
{
    [Table(Name = "detail", Type = EngineType.Default)]
    public class DTODetail
    {
        [Constraint(Name = "fk_detail_ref_master_to_master", Type = EConstraintType.ForeignKey, ReferencedField = "id", ReferencedTable = "master")]
        [Field(FieldName = "ref_master", AllowNull = true, IsAutoincrement = false, IsPrimaryKey = true, Type = ParamType.Int32)]
        internal int RefMaster { get; set; }

        [Field(FieldName = "line_number", AllowNull = false, DefaultValue = 0, IsAutoincrement = false, IsPrimaryKey = true, Type = ParamType.Int32)]
        public int Order { get; set; }

        [Field(FieldName = "description", AllowNull = true, Type = ParamType.String)]
        public string Description { get; set; }

        [Field(FieldName = "total", AllowNull = false, DefaultValue = 0, Size = new int[] { 10, 2}, Type = ParamType.Decimal)]
        public decimal Total { get; set; }
    }
}
