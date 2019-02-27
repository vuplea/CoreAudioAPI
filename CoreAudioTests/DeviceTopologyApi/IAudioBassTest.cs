using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;
using System.Linq;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioBass interface.
    /// </summary>
    [TestClass]
    public class IAudioBassTest
    {
        /// <summary>
        /// Tests that the channel count can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioBass_GetChannelCount()
        {
            (new IPerChannelDbLevelTest<IAudioBass>()).ExecuteGetChannelCountTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioBass_GetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioBass>()).ExecuteGetLevelTest();
        }

        /// <summary>
        /// Tests that the level range of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioBass_GetLevelRange()
        {
            (new IPerChannelDbLevelTest<IAudioBass>()).ExecuteGetLevelRangeTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioBass_SetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioBass>()).ExecuteSetLevelTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioBass_SetLevelAllChannels()
        {
            (new IPerChannelDbLevelTest<IAudioBass>()).ExecuteSetLevelAllChannelsTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set uniformly, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioBass_SetLevelUniform()
        {
            (new IPerChannelDbLevelTest<IAudioBass>()).ExecuteSetLevelUniformTest();
        }
    }
}