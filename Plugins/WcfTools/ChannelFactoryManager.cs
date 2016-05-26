using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WcfTools
{
    public class ChannelFactoryManager
    {
        #region Fields

        private readonly Dictionary<Type, ChannelFactory> _channelFactories;

        #endregion

        #region Ctor

        public ChannelFactoryManager()
        {
            _channelFactories = new Dictionary<Type, ChannelFactory>();
        }
        #endregion

        #region Properties

        public Dictionary<Type, ChannelFactory> Factories
        {
            get
            {
                return _channelFactories;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Create channel by channel factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateChannel<T>() where T : class
        {
            return CreateChannel<T>(typeof(T));
        }

        /// <summary>
        /// Create channel by channel factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">channel type</param>
        /// <returns></returns>
        public T CreateChannel<T>(Type type) where T : class
        {
            ChannelFactory factory = null;
            if (_channelFactories.ContainsKey(type))
            {
                factory = _channelFactories[type];
            }
            else
            {
                factory = new ChannelFactory<T>(type.Name);
                _channelFactories.Add(type, factory);
            }

            var proxy = factory as ChannelFactory<T>;
            if (proxy == null)
            {
                throw new InvalidChannelBindingException("create factory error!");
            }
            return proxy.CreateChannel();
        }
        #endregion
    }
}
