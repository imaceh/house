using es.dmoreno.house.core.dto;
using es.dmoreno.utils.apps.masterrecords;
using es.dmoreno.utils.dataaccess.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace es.dmoreno.house.core
{
    internal class Options : MasterRecordsTable<DTOOption>
    {
        public int LastPaymentForecastCode
        {
            get
            {
                var o = this.get("last_" + ETypeMaster.PaymentForecast.ToString()).Result;

                if (o != null)
                {
                    return o.ValueInteger32;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                var o = this.get("last_" + ETypeMaster.PaymentForecast.ToString()).Result;

                if (o == null)
                {
                    o = new DTOOption() { Key = "last_" + ETypeMaster.PaymentForecast.ToString() };
                }

                o.ValueInteger32 = value;

                this.set(o).Wait();
            }
        }

        internal Options(ConnectionParameters param) : base(param)
        {

        }
    }
}
