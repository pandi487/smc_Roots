using System;

namespace USES.Payloads
{
    [Serializable]
    public class FloatPayload : Payload
    {
        public float Data { get; }

        public FloatPayload(float data)
        {
            Data = data;
        }
    }
}