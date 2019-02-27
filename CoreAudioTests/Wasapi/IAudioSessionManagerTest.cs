using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;
using System.Runtime.InteropServices;

namespace CoreAudioTests.Wasapi
{
    /// <summary>
    /// Tests all methods of the IAudioSessionManager interface.
    /// </summary>
    [TestClass]
    public class IAudioSessionManagerTest : TestClass<IAudioSessionManager>
    {
        /// <summary>
        /// Tests that the audio session control may be received, for each available session manager.
        /// </summary>
        [TestMethod]
        public void IAudioSessionManager_GetAudioSessionControl()
        {
            ExecuteDeviceActivationTest(activation =>
            {
                IAudioSessionControl sessionControl;
                var result = activation.GetAudioSessionControl(Guid.NewGuid(), 0, out sessionControl);
                AssertCoreAudio.IsHResultOk(result);
                Manager.EnsureDisposal(sessionControl);
            });
        }

        /// <summary>
        /// Tests that the simple volume interface may be received, for each available session manager.
        /// </summary>
        [TestMethod]
        public void IAudioSessionManager_GetSimpleAudioVolume()
        {
            ExecuteDeviceActivationTest(activation =>
            {
                ISimpleAudioVolume audioVolume;
                var result = activation.GetSimpleAudioVolume(Guid.NewGuid(), 0, out audioVolume);
                AssertCoreAudio.IsHResultOk(result);
                Manager.EnsureDisposal(audioVolume);
            });
        }
    }
}