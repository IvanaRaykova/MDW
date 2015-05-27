using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ChatServiceMDW;

namespace ChatServiceMDW
{
    [ServiceContract(Namespace = "LoginContract")]
    public interface ILogin
    {
        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        void Register(string username,string password);
    }
}
