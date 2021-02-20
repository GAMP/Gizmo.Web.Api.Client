using MessagePack;

namespace Gizmo.Web.Api.Client
{
    /// <summary>
    /// Message pack payload serializer options.
    /// </summary>
    public class MessagePackPayloadSerializerOptions
    {
        #region FIELDS
        private MessagePackSerializerOptions? _messagePackSerializerOptions;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets message pack serialization options.
        /// </summary>
        public MessagePackSerializerOptions MessagePackSerializerOptions
        {
            get
            {
                if (_messagePackSerializerOptions == null)
                    _messagePackSerializerOptions = MessagePackSerializerOptions.Standard;       

                return _messagePackSerializerOptions;
            }
            set
            {
                _messagePackSerializerOptions = value;
            }
        } 
        
        #endregion
    }
}
