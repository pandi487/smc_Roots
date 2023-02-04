using System;

namespace USES.Payloads
{
    [Serializable]
    public class StringPayload : Payload
    {
        public string Data { get; }

        public StringPayload(string data)
        {
            Data = data;
        }
    }
}