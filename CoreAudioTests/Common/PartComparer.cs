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
    /// Used for comparing IPart instances.
    /// </summary>
    public class PartComparer : IEqualityComparer<IPart>
    {

        public bool Equals(IPart x, IPart y)
        {
            if (x == null || y == null) return false;

            string xId, yId;
            x.GetGlobalId(out xId);
            y.GetGlobalId(out yId);

            return (xId == yId);
        }

        public int GetHashCode(IPart obj)
        {
            if (obj == null) return 0;

            string partId;
            obj.GetGlobalId(out partId);

            return partId.GetHashCode();
        }
    }
}
