using System;
using System.Runtime.InteropServices;

namespace CoreAudioAPI
{
    public static class MarshalUtils
    {
        public static TInterface CreateInstance<TInterface>(Guid clsid) =>
            (TInterface)Activator.CreateInstance(Type.GetTypeFromCLSID(clsid));

        public static TInterface CreateInstance<TInterface>(string clsid) => CreateInstance<TInterface>(new Guid(clsid));

        public static void VerifyHR(this int errorCode) => Marshal.ThrowExceptionForHR(errorCode);
    }
}

