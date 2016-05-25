using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using Core.Configuration;

namespace ServiceFramework
{
    public class ServiceFinder
    {
        public static IList<Type> GetServices(Configuration configuration = null)
        {
            if (configuration == null)
            {
                configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            }
            var serviceModel = configuration.GetSectionGroup("system.serviceModel") as ServiceModelSectionGroup;
            if (serviceModel == null)
            {
                throw new ConfigurationErrorsException("No have system.serviceModel setting");
            }

            var types = new List<Type>();
            foreach (var service in serviceModel.Services.Services)
            {
                var element = service as ServiceElement;
                if (element != null)
                {
                    Type type = null;
                    try
                    {
                        type = Type.GetType(element.Name + "," + element.Name.Substring(0, element.Name.LastIndexOf(".", StringComparison.CurrentCulture)));
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    if (type == null)
                    {
                        throw new ConfigurationErrorsException("Type is not define");
                    }
                    types.Add(type);
                }
            }

            return types;
        }
    }
}
