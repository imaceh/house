﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace es.dmoreno.house.core.dto
{
    [DataContract]
    public class DTOConfigDB
    {
        [DataMember(IsRequired = true, Name = "host")]
        public string Host { get; set; }

        [DataMember(IsRequired = false, Name = "port")]
        public int Port { get; set; }

        [DataMember(IsRequired = false, Name = "name")]
        public string Name { get; set; }

        [DataMember(IsRequired = false, Name = "user")]
        public string User { get; set; }

        [DataMember(IsRequired = false, Name = "password")]
        public string Password { get; set; }

        [DataMember(IsRequired = true, Name = "dbms")]
        public string DBMS { get; set; }
    }
}
