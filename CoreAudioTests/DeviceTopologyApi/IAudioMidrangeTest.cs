using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioMidrange interface.
    /// </summary>
    [TestClass]
    public class IAudioMidrangeTest
    {
        /// <summary>
        /// Tests that the channel count can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMidrange_GetChannelCount()
        {
            (new IPerChannelDbLevelTest<IAudioMidrange>()).ExecuteGetChannelCountTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMidrange_GetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioMidrange>()).ExecuteGetLevelTest();
        }

        /// <summary>
        /// Tests that the level range of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMidrange_GetLevelRange()
        {
            (new IPerChannelDbLevelTest<IAudioMidrange>()).ExecuteGetLevelRangeTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMidrange_SetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioMidrange>()).ExecuteSetLevelTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMidrange_SetLevelAllChannels()
        {
            (new IPerChannelDbLevelTest<IAudioMidrange>()).ExecuteSetLevelAllChannelsTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set uniformly, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioMidrange_SetLevelUniform()
        {
            (new IPerChannelDbLevelTest<IAudioMidrange>()).ExecuteSetLevelUniformTest();
        }
    }
}