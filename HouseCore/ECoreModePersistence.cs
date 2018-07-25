using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core
{
    public enum ECoreModePersistence
    {
        /// <summary>
        /// Core directly accesses the database
        /// </summary>
        DB = 0,

        /// <summary>
        /// Core accesses the data throught a restapi
        /// </summary>
        RestAPI = 1
    }
}
