using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioMute interface.
    /// </summary>
    [TestClass]
    public class IAudioMuteTest : TestClass<IAudioMute>
    {
        /// <summary>
        /// Tests that the muting state of may be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMute_GetMute()
        {
            ExecutePartActivationTest(activation =>
            {
                bool valOne = true, valTwo = false;

                var result = activation.GetMute(out valOne);
                AssertCoreAudio.IsHResultOk(result);

                result = activation.GetMute(out valTwo);
                AssertCoreAudio.IsHResultOk(result);

                Assert.AreEqual(valOne, valTwo, "The mute state was not received.");
            });
        }

        /// <summary>
        /// Tests that the muting state of may be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMute_SetMute()
        {
            ExecutePartActivationTest(activation =>
            {
                var context = Guid.NewGuid();
                bool valOrig, valCurrent;
                activation.GetMute(out valOrig);

                var result = activation.SetMute(!valOrig, context);
                AssertCoreAudio.IsHResultOk(result);

                activation.GetMute(out valCurrent);
                Assert.AreEqual(!valOrig, valCurrent);

                result = activation.SetMute(valOrig, context);
                AssertCoreAudio.IsHResultOk(result);
            });
        }
    }
}