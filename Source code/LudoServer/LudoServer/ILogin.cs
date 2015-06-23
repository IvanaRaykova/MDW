using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LudoServer
{
    [ServiceContract(Namespace = "LoginContract")]
    public interface ILogin
    {
        [OperationContract]
        bool Login(string username, string password);

        [OperationContract]
        void Register(string username, string password);
    }
}
