using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatServiceMDW;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ChatServiceMDW
{
    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]

        void onMessageAdded(DateTime timestamp, string playerName, string message);
    }
}
