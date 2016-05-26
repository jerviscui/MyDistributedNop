using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ServiceFramework
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ApplyProxyDataContractResolverAttribute : Attribute, IOperationBehavior
    {
        #region Methods
        public void Validate(OperationDescription operationDescription)
        {
            return;
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            var serializerBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
            serializerBehavior.DataContractResolver = new ProxyDataContractResolver();
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
            var serializerBehavior = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
            serializerBehavior.DataContractResolver = new ProxyDataContractResolver();
        }

        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
            return;
        }
        #endregion
    }
}
