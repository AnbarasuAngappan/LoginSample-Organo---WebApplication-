using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoginSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReadService" in both code and config file together.
    [ServiceContract]
    public interface IReadService
    {
        [OperationContract]
        DataTable GetHousdetails(string _houseID);

        [OperationContract]
        DataTable GetHouseDetails();
    }
}
