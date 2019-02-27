using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Enumerations;

namespace CoreAudioTests.Wasapi
{
    /// <summary>
    /// Tests all methods of the IAudioRenderClient interface.
    /// </summary>
    [TestClass]
    public class IAudioRenderClientTest : TestClass<IAudioRenderClient>
    {
        /// <summary>
        /// Tests that buffers may be received, for each applicable endpoint in the system.
        /// </summary>
        [TestMethod]
        public void IAudioRenderClient_GetBuffer()
        {
            ExecuteRunningServiceTest(runningService =>
            {
                var bufferPtr = IntPtr.Zero;
                var frameCount = UInt32.MaxValue;

                var result = runningService.GetBuffer(128, out bufferPtr);
                runningService.ReleaseBuffer(frameCount, 0);

                if (TestUtilities.IsWasapiError(result))
                    return;

                AssertCoreAudio.IsHResultOk(result);
                Assert.AreNotEqual(IntPtr.Zero, bufferPtr, "The buffer pointer was not received.");
            });
        }

        /// <summary>
        /// Tests that buffers may be released, for each applicable endpoint in the system.
        /// </summary>
        [TestMethod]
        public void IAudioRenderClient_ReleaseBuffer()
        {
            ExecuteRunningServiceTest(runningService =>
            {
                var bufferPtr = IntPtr.Zero;
                var frameCount = UInt32.MaxValue;

                runningService.GetBuffer(128, out bufferPtr);
                var result = runningService.ReleaseBuffer(frameCount, 0);

                if (TestUtilities.IsWasapiError(result))
                    return;

                AssertCoreAudio.IsHResultOk(result);
            });
        }
    }
}