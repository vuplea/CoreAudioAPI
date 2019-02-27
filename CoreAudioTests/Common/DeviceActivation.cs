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
    /// Used for returning IMMDevice interface along with actived interfaces.
    /// </summary>
    /// <typeparam name="T">The activated interface type.</typeparam>
    public class DeviceActivation<T> : IDisposable
    {
        /// <summary>
        /// The IMMDevice instance.
        /// </summary>
        public IMMDevice MMDevice
        {
            get;
            set;
        }

        /// <summary>
        /// The activated interface.
        /// </summary>
        public T ActiveInterface
        {
            get;
            set;
        }

        /// <summary>
        /// Disposes of the object, releasing all internal COM references.
        /// </summary>
        public void Dispose()
        {
            Marshal.FinalReleaseComObject(MMDevice);
            Marshal.FinalReleaseComObject(ActiveInterface);
        }
    }
}
