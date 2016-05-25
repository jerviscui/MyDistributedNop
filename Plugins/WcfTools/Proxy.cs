using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace WcfTools
{
    public class Proxy<T> where T : class
    {
        #region Fields

        private readonly string _sectionName;

        private T _targetInstance;

        private IChannel _channelInstance;
        #endregion

        #region Ctor

        public Proxy(string sectionName)
        {
            _sectionName = sectionName;
            Create();
        }
        #endregion

        #region Properties

        private IChannel Channel
        {
            get { return _channelInstance; }
        }

        public T Client
        {
            get { return _targetInstance; }
        }

        #endregion

        #region Private

        private void Create()
        {
            ChannelFactory<T> factory = new ChannelFactory<T>(_sectionName);
            _targetInstance = factory.CreateChannel();
            _channelInstance = (IChannel)_targetInstance;
        }
        #endregion

        #region Methods

        public void Open()
        {
            if (Channel.State != CommunicationState.Opened)
            {
                try
                {
                    Channel.Open();
                }
                catch (Exception)
                {
                    Close();
                    Create();

                    Channel.Open();
                }
            }
        }

        public void Close()
        {
            if (Channel.State != CommunicationState.Closed)
            {
                Channel.Abort();
                Channel.Close();
            }
        }
        #endregion
    }
}
