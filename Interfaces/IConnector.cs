﻿using System;
using System.Runtime.InteropServices;

namespace CoreAudioAPI
{
    /// <summary>
    /// Represents a point of connection between components.
    /// </summary>
    /// <remarks>
    /// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371048.aspx
    /// </remarks>
    public partial interface IConnector
    {
        /// <summary>
        /// Gets the type of this connector.
        /// </summary>
        /// <param name="connectorType">Receives the connector type.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetType(
            [Out] [MarshalAs(UnmanagedType.I4)] out ConnectorType connectorType);

        /// <summary>
        /// Gets the direction of data flow through this connector.
        /// </summary>
        /// <param name="dataFlow">Receives the data-flow direction.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetDataFlow(
            [Out] [MarshalAs(UnmanagedType.I4)] out DataFlow dataFlow);

        /// <summary>
        /// Connects this connector to a connector in another device topology object.
        /// </summary>
        /// <param name="connector">The connector in the other device topology.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int ConnectTo(
            [In] [MarshalAs(UnmanagedType.Interface)] IConnector connector);

        /// <summary>
        /// Disconnects this connector from another connector.
        /// </summary>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int Disconnect();

        /// <summary>
        /// Indicates whether this connector is connected to another connector.
        /// </summary>
        /// <param name="isConnected">Receives the connection state.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int IsConnected(
            [Out] [MarshalAs(UnmanagedType.Bool)] out bool isConnected);

        /// <summary>
        /// Gets the connector to which this connector is connected.
        /// </summary>
        /// <param name="connector">Receives the connector that the current object is connected to.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetConnectedTo(
            [Out] [MarshalAs(UnmanagedType.Interface)] out IConnector connector);

        /// <summary>
        /// Gets the global ID of the connector, if any, that this connector is connected to.
        /// </summary>
        /// <param name="connectorId">Receives the other connectors ID.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetConnectorIdConnectedTo(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] out string connectorId);

        /// <summary>
        /// Gets the device identifier of the audio device, if any, that this connector is connected to.
        /// </summary>
        /// <param name="deviceId">Receives a string that contains the device identifier of the connected device.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetDeviceIdConnectedTo(
            [Out] [MarshalAs(UnmanagedType.LPWStr)] out string deviceId);
    }
}
