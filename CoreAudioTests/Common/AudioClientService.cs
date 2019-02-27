using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Enumerations;
using Vannatech.CoreAudio.Externals;
using Vannatech.CoreAudio.Interfaces;

namespace CoreAudioTests.Common
{
    /// <summary>
    /// Used for returning audio clients along with the service.
    /// </summary>
    /// <typeparam name="T">The service interface type.</typeparam>
    public class AudioClientService<T> : IDisposable
    {
        /// <summary>
        /// The IAudioClient instance.
        /// </summary>
        public IAudioClient AudioClient
        {
            get;
            set;
        }

        /// <summary>
        /// The requested service interface.
        /// </summary>
        public T ServiceInterface
        {
            get;
            set;
        }

        /// <summary>
        /// The event context associated with the client.
        /// </summary>
        public Guid EventContext
        {
            get;
            set;
        }

        /// <summary>
        /// The share mode of the client.
        /// </summary>
        public AUDCLNT_SHAREMODE ShareMode
        {
            get;
            set;
        }



        /// <summary>
        /// Disposes of the object, releasing all internal COM references.
        /// </summary>
        public void Dispose()
        {
            Marshal.FinalReleaseComObject(AudioClient);
            Marshal.FinalReleaseComObject(ServiceInterface);
        }
    }
}
