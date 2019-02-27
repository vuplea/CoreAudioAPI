using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioTreble interface.
    /// </summary>
    [TestClass]
    public class IAudioTrebleTest
    {
        /// <summary>
        /// Tests that the channel count can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioTreble_GetChannelCount()
        {
            (new IPerChannelDbLevelTest<IAudioTreble>()).ExecuteGetChannelCountTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioTreble_GetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioTreble>()).ExecuteGetLevelTest();
        }

        /// <summary>
        /// Tests that the level range of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioTreble_GetLevelRange()
        {
            (new IPerChannelDbLevelTest<IAudioTreble>()).ExecuteGetLevelRangeTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioTreble_SetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioTreble>()).ExecuteSetLevelTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioTreble_SetLevelAllChannels()
        {
            (new IPerChannelDbLevelTest<IAudioTreble>()).ExecuteSetLevelAllChannelsTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set uniformly, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioTreble_SetLevelUniform()
        {
            (new IPerChannelDbLevelTest<IAudioTreble>()).ExecuteSetLevelUniformTest();
        }
    }
}