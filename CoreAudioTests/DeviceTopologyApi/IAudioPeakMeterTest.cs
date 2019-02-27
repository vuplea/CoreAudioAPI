using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioPeakMeter interface.
    /// </summary>
    [TestClass]
    public class IAudioPeakMeterTest : TestClass<IAudioPeakMeter>
    {
        /// <summary>
        /// Tests that the channel count can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioPeakMeter_GetChannelCount()
        {
            ExecutePartActivationTest(activation =>
            {
                var count = UInt32.MaxValue;
                var result = activation.GetChannelCount(out count);

                AssertCoreAudio.IsHResultOk(result);
                Assert.AreNotEqual(UInt32.MaxValue, count, "The channel count was not received.");
            });
        }

        /// <summary>
        /// Tests that the level of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioPeakMeter_GetLevel()
        {
            var tested = false;

            ExecutePartActivationTest(activation =>
            {
                var count = UInt32.MaxValue;
                activation.GetChannelCount(out count);

                for (uint i = 0; i < count; i++)
                {
                    var level = 123.456f;
                    var result = activation.GetLevel(i, out level);

                    AssertCoreAudio.IsHResultOk(result);
                    Assert.AreNotEqual(123.456f, level, "The level was not received.");
                    tested = true;
                }
            });

            if (!tested) Assert.Inconclusive("No channels were available to test against.");
        }
    }
}