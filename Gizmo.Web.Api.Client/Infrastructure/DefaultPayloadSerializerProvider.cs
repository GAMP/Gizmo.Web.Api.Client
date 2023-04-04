using System;
using System.Collections.Generic;
using System.Linq;

namespace Gizmo.Web.Api.Clients
{
    public class DefaultPayloadSerializerProvider : IPayloadSerializerProvider
    {
        #region CONSTRUCTOR
        public DefaultPayloadSerializerProvider(IEnumerable<IPayloadSerializer> payloadSerializers)
        {
            //ensure that at least one serialzier exists
            if (!payloadSerializers.Any())
                throw new ArgumentException("No payload serializers registered.");

            //create lookpu dictionary
            _serializers = payloadSerializers.ToDictionary(key => key.Name, v => v);

            //get first serializer from the registered payload serializers
            _defaultSerializer = payloadSerializers.First();

            //get default serializer name
            _defaultSerializerName = _defaultSerializer.Name;

        }
        #endregion

        #region FIELDS
        private readonly string _defaultSerializerName;
        private readonly Dictionary<string, IPayloadSerializer> _serializers;
        private readonly IPayloadSerializer _defaultSerializer;
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets default serializer name.
        /// </summary>
        public string DefaultSerializerName
        {
            get { return _defaultSerializerName; }
        } 

        /// <summary>
        /// Gets default serializer.
        /// </summary>
        public IPayloadSerializer DefaultSerializer
        {
            get { return _defaultSerializer; }
        }

        #endregion

        #region FUNCTIONS
        
        public IPayloadSerializer? GetSerializer(string name)
        {
            if (_serializers.TryGetValue(name, out var serializer))
                return serializer;

            return null;
        } 

        #endregion
    }
}
