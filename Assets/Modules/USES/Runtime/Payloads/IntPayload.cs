using System;

namespace USES.Payloads
{
    [Serializable]
    public class IntPayload : Payload
    {
        public int Data { get; }

        public IntPayload(int data)
        {
            Data = data;
        }
    }
}