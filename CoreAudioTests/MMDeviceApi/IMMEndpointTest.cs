using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Enumerations;
using Vannatech.CoreAudio.Interfaces;

namespace CoreAudioTests.MMDeviceApi
{
    /// <summary>
    /// Tests all methods of the IMMEndpoint interface.
    /// </summary>
    [TestClass]
    public class IMMEndpointTest
    {
        /// <summary>
        /// Tests that an IMMDevice object can be cast to IMMEndpoint and the method returns a valid data flow, with HRESULT of S_OK.
        /// </summary>
        [TestMethod]
        public void IMMEndpoint_GetDataFlow()
        {
            int result = 0;
            var allDevices = TestUtilities.CreateIMMDeviceCollection(EDataFlow.eAll, DEVICE_STATE_XXX.DEVICE_STATEMASK_ALL);

            foreach (var device in allDevices)
            {
                // Cast compiles to QueryInterface call.
                var endpoint = (IMMEndpoint)device;
                Assert.IsNotNull(endpoint);

                EDataFlow dataFlow = EDataFlow.eAll;
                result = endpoint.GetDataFlow(out dataFlow);

                AssertCoreAudio.IsHResultOk(result);
                Assert.AreNotEqual(EDataFlow.eAll, dataFlow);
            }
        }
    }
}
