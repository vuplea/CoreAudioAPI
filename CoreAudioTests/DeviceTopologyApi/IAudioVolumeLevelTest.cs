using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioVolumeLevel interface.
    /// </summary>
    [TestClass]
    public class IAudioVolumeLevelTest : TestClass<IAudioVolumeLevel>
    {
        /// <summary>
        /// Tests that the channel count can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioVolumeLevel_GetChannelCount()
        {
            (new IPerChannelDbLevelTest<IAudioVolumeLevel>()).ExecuteGetChannelCountTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioVolumeLevel_GetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioVolumeLevel>()).ExecuteGetLevelTest();
        }

        /// <summary>
        /// Tests that the level range of each channel can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioVolumeLevel_GetLevelRange()
        {
            (new IPerChannelDbLevelTest<IAudioVolumeLevel>()).ExecuteGetLevelRangeTest();
        }

        /// <summary>
        /// Tests that the level of each channel can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioVolumeLevel_SetLevel()
        {
            (new IPerChannelDbLevelTest<IAudioVolumeLevel>()).ExecuteSetLevelTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioVolumeLevel_SetLevelAllChannels()
        {
            (new IPerChannelDbLevelTest<IAudioVolumeLevel>()).ExecuteSetLevelAllChannelsTest();
        }

        /// <summary>
        /// Tests that the level of all channels can be set uniformly, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioVolumeLevel_SetLevelUniform()
        {
            (new IPerChannelDbLevelTest<IAudioVolumeLevel>()).ExecuteSetLevelUniformTest();
        }
    }
}