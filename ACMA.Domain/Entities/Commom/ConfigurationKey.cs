using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMA.Domain.Entities.Commom
{
    public enum ConfigurationKey
    {
        PORT,
        SERVER_IPADDRESS,
        INTERVAL_SEND_DATA_TO_DATABASE,
        TEST_SPEED_QUANTITY,
        MAX_SPEED_LINK,
        MIN_THRESHOLD_SPEED,
        MAX_THRESHOLD_SPEED,
        INTERVAL_TIMER_NETWORK_VERIFICATION,
        CRITICAL_NETWORK_MAX_USAGE_PERCENTUAL,
        WARNING_NETWORK_MAX_USAGE_PERCENTUAL,
        OK_NETWORK_MAX_USAGE_PERCENTUAL,
        CURRENT_NETWORK_STATUS
    }
}
