using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace es.dmoreno.house.core.dto
{
    [DataContract]
    public class DTOConfig
    {
        [DataMember(Name = "modePersistence", IsRequired = false)]
        public string ModePersistence { get; set; }

        [DataMember(Name = "database", IsRequired = true)]
        public DTOConfigDB DataBase { get; set; }
    }
}
