using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vannatech.CoreAudio.Constants;
using Vannatech.CoreAudio.Enumerations;
using Vannatech.CoreAudio.Externals;
using Vannatech.CoreAudio.Interfaces;

namespace CoreAudioTests.Common
{
    /// <summary>
    /// Test manager used to run tests within the context of an MMDeviceActivation object.
    /// </summary>
    /// <typeparam name="T">The interface type.</typeparam>
    public class PartActivationTestManager<T> : TestManager<T>
    {
        /// <summary>
        /// Creats a new test manager instance.
        /// </summary>
        /// <typeparam name="T">The interface type.</typeparam>
        /// <param name="comIId">The COM IID of the interface.</param>
        /// <returns>A new activation test manager instance.</returns>
        public static PartActivationTestManager<T> Create(string comIId)
        {
            return new PartActivationTestManager<T>(TestUtilities.CreatePartActivationCollection<T>(comIId));
        }

        /// <summary>
        /// A list of device activation objects to test against.
        /// </summary>
        protected IEnumerable<PartActivation<T>> Items
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="items">A list of device activations to use.</param>
        public PartActivationTestManager(IEnumerable<PartActivation<T>> items)
        {
            Items = items;
        }

        /// <summary>
        /// Runs the tests.
        /// </summary>
        protected override void OnRun()
        {
            foreach (var i in Items)
            {
                try
                {
                    OnTestReady(i.ActiveInterface);
                }
                finally
                {
                    EnsureDisposal(i);
                }
            }
        }
    }
}
