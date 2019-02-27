using System;
using CoreAudioTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Interfaces;
using Vannatech.CoreAudio.Constants;

namespace CoreAudioTests.DeviceTopologyApi
{
    /// <summary>
    /// Tests all methods of the IAudioInputSelector interface.
    /// </summary>
    [TestClass]
    public class IAudioInputSelectorTest : TestClass<IAudioInputSelector>
    {
        /// <summary>
        /// Tests that the selected part ID of the input selector can be received, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioInputSelector_GetSelection()
        {
            ExecutePartActivationTest(activation =>
            {
                var selection = UInt32.MaxValue;
                var result = activation.GetSelection(out selection);

                AssertCoreAudio.IsHResultOk(result);
                Assert.AreNotEqual(UInt32.MaxValue, selection, "The part ID of the selected input was not received.");
            });
        }

        /// <summary>
        /// Tests that the selected part ID of the input selector can be set, for each applicable part in the system.
        /// </summary>
        [TestMethod]
        public void IAudioInputSelector_SetSelection()
        {
            ExecutePartActivationTest(activation =>
            {
                var context = Guid.NewGuid();
                UInt32 valOrig;
                activation.GetSelection(out valOrig);

                Assert.Fail("TODO: Determine how to test SetSelection method properly.");

                // In order to test this we need to enumerate all valid ID of parts attached to the multiplexer.
                // Unknown: Do these IDs need to be for parts directly connected to mux, or endpoint connector IDs.

                var result = activation.SetSelection(0x0, context);
                AssertCoreAudio.IsHResultOk(result);

                result = activation.SetSelection(valOrig, context);
                AssertCoreAudio.IsHResultOk(result);
            });
        }
    }
}