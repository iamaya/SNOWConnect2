using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SNOWConnect2.Models.Incidents;

namespace SNOWConnect2
{
    public interface ILoginService
    {
        void AttemptLogin(string domain, string username, string password, Action<RootObject> success, Action<Exception> error);
    }

    public class LoginService : ILoginService
    {
        ISNOWService _snowService = new SNOWService();

        public void AttemptLogin(string domain, string username, string password, Action<RootObject> success, Action<Exception> error)
        {
            //    throw new NotImplementedException();
            string URL = string.Format("https://{0}/api/now/table/incident?sysparm_limit=1", (domain ?? "empty") + ".service-now.com");
            _snowService.MakeRequest<RootObject>(URL, "GET", username, password, success, error);
        }
    }
}