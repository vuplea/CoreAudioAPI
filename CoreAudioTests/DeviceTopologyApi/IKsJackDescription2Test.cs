using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Structures;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IKsJackDescription2 interface.
    /// </summary>
    [TestClass]
    public class IKsJackDescription2Test : TestClass<IKsJackDescription2>
    {
        /// <summary>
        /// Tests that the jack count may be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IKsJackDescription2_GetJackCount()
        {
            ExecutePartActivationTest(activation =>
            {
                var count = UInt32.MaxValue;
                var result = activation.GetJackCount(out count);

                AssertCoreAudio.IsHResultOk(result);
                Assert.AreNotEqual(UInt32.MaxValue, count, "The count was not received.");
            });
        }

        /// <summary>
        /// Tests that the jack description may be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IKsJackDescription2_GetJackDescription2()
        {
            var tested = false;

            ExecutePartActivationTest(activation =>
            {
                UInt32 count;
                activation.GetJackCount(out count);

                for (uint i = 0; i < count; i++)
                {
                    KSJACK_DESCRIPTION2 description = new KSJACK_DESCRIPTION2();
                    description.JackCapabilities = UInt32.MaxValue;
                    var result = activation.GetJackDescription(i, out description);

                    AssertCoreAudio.IsHResultOk(result);
                    Assert.AreNotEqual(UInt32.MaxValue, description.JackCapabilities, "The jack capabilities was not received.");
                    tested = true;
                }
            });

            if (!tested) Assert.Inconclusive("The test cannot be run properly. No jacks were found.");
        }
    }
}