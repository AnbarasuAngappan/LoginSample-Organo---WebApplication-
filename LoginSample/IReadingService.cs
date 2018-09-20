using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LoginSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReadingService" in both code and config file together.
    [ServiceContract]
    public interface IReadingService
    {
        [OperationContract]
        void DoWork();


        [OperationContract]
        DataTable GetHousdetails(string _societyID);

        [OperationContract]
        DataTable GetHouseDetails();
    }
}
