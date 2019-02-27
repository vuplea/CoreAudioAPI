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
    /// Used for returning IPart interface along with actived interfaces.
    /// </summary>
    /// <typeparam name="T">The activated interface type.</typeparam>
    public class PartActivation<T> : IDisposable
    {
        /// <summary>
        /// The IPart instance.
        /// </summary>
        public IPart Part
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
            Marshal.FinalReleaseComObject(Part);
            Marshal.FinalReleaseComObject(ActiveInterface);
        }
    }
}
