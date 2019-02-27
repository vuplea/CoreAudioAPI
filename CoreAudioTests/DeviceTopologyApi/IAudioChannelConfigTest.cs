using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioChannelConfig interface.
    /// </summary>
    [TestClass]
    public class IAudioChannelConfigTest : TestClass<IAudioChannelConfig>
    {
        /// <summary>
        /// Tests that the channel configuration can be recieved, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioChannelConfig_GetChannelConfig()
        {
            ExecutePartActivationTest(activation =>
            {
                var configMin = 0x1;
                var configMax = 0x46665;

                UInt32 config = UInt32.MaxValue;
                var result = activation.GetChannelConfig(out config);

                AssertCoreAudio.IsHResultOk(result);
                Assert.IsTrue((config >= configMin) && (config <= configMax), "The channel configuration value is not within the valid range.");
            });
        }

        /// <summary>
        /// Tests that the channel configuration can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioChannelConfig_SetChannelConfig()
        {
            ExecutePartActivationTest(activation =>
            {
                var context = Guid.NewGuid();
                UInt32 valOrig, valTest;
                activation.GetChannelConfig(out valOrig);

                // Test various valid values.
                var result = activation.SetChannelConfig(0x1, context);
                AssertCoreAudio.IsHResultOk(result);
                activation.GetChannelConfig(out valTest);
                Assert.AreEqual(0x1, valTest, "The channel configuration value was not set properly.");

                result = activation.SetChannelConfig(0x28, context);
                AssertCoreAudio.IsHResultOk(result);
                activation.GetChannelConfig(out valTest);
                Assert.AreEqual(0x28, valTest, "The channel configuration value was not set properly.");

                result = activation.SetChannelConfig(0x2000, context);
                AssertCoreAudio.IsHResultOk(result);
                activation.GetChannelConfig(out valTest);
                Assert.AreEqual(0x2000, valTest, "The channel configuration value was not set properly.");

                // Return to original configuration.
                result = activation.SetChannelConfig(valOrig, context);
                AssertCoreAudio.IsHResultOk(result);
            });
        }
    }
}