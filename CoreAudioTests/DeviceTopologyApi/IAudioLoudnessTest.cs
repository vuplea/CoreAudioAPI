using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioLoudness interface.
    /// </summary>
    [TestClass]
    public class IAudioLoudnessTest : TestClass<IAudioLoudness>
    {
        /// <summary>
        /// Tests that the enabled state can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioLoudness_GetEnabled()
        {
            ExecutePartActivationTest(activation =>
            {
                bool valOne = true, valTwo = false;

                var result = activation.GetEnabled(out valOne);
                AssertCoreAudio.IsHResultOk(result);

                result = activation.GetEnabled(out valTwo);
                AssertCoreAudio.IsHResultOk(result);

                Assert.AreEqual(valOne, valTwo, "The enabled state was not received.");
            });
        }

        /// <summary>
        /// Tests that the enabled state can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioLoudness_SetEnabled()
        {
            ExecutePartActivationTest(activation =>
            {
                var context = Guid.NewGuid();
                bool valOrig, valTest;
                activation.GetEnabled(out valOrig);

                var result = activation.SetEnabled(!valOrig, context);
                AssertCoreAudio.IsHResultOk(result);

                activation.GetEnabled(out valTest);
                Assert.AreEqual(!valOrig, valTest, "The enabled state was not set properly.");

                result = activation.SetEnabled(valOrig, context);
                AssertCoreAudio.IsHResultOk(result);
            });
        }
    }
}