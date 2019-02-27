using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Externals;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IKsFormatSupport interface.
    /// </summary>
    [TestClass]
    public class IKsFormatSupportTest : TestClass<IKsFormatSupport>
    {
        /// <summary>
        /// Tests that the preferred format can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IKsFormatSupport_GetDevicePreferredFormat()
        {
            ExecutePartActivationTest(activation =>
            {
                var formatPtr = IntPtr.Zero;
                var result = activation.GetDevicePreferredFormat(out formatPtr);

                AssertCoreAudio.IsHResultOk(result);
                Assert.AreNotEqual(IntPtr.Zero, formatPtr);
            });
        }

        /// <summary>
        /// Tests that the format support flag can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IKsFormatSupport_IsFormatSupported()
        {
            ExecutePartActivationTest(activation =>
            {
                Assert.Fail("TODO: Determine how to test this method properly.");

                bool valOne = true;
                bool valTwo = false;
                KSDATAFORMAT dataFormat = new KSDATAFORMAT();

                var result = activation.IsFormatSupported(IntPtr.Zero, dataFormat.FormatSize, out valOne);
                AssertCoreAudio.IsHResultOk(result);

                result = activation.IsFormatSupported(IntPtr.Zero, dataFormat.FormatSize, out valTwo);
                AssertCoreAudio.IsHResultOk(result);

                Assert.AreEqual(valOne, valTwo, "The format support flag was not received.");
            });
        }
    }
}