using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Structures;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IKsJackSinkInformation interface.
    /// </summary>
    [TestClass]
    public class IKsJackSinkInformationTest : TestClass<IKsJackSinkInformation>
    {
        /// <summary>
        /// Tests that the sink information may be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IKsJackSinkInformation_GetJackSinkInformation()
        {
            ExecutePartActivationTest(activation =>
            {
                Assert.Fail("TODO: Must update IKsJackSinkInformation interface before valid unit test can be created.");
                var info = new KSJACK_SINK_INFORMATION();
                var result = activation.GetJackSinkInformation(out info);

                AssertCoreAudio.IsHResultOk(result);
            });
        }
    }
}