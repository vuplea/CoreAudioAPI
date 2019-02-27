﻿using System;
using System.Runtime.InteropServices;

namespace Vannatech.CoreAudio.Interfaces
{
    /// <summary>
    /// Enables a client to control and monitor the volume levels for all of the channels in the audio session.
    /// </summary>
    /// <remarks>
    /// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd371023.aspx
    /// </remarks>
    public partial interface IChannelAudioVolume
    {
        /// <summary>
        /// Retrieves the number of channels contained in the session.
        /// </summary>
        /// <param name="channelCount">Receives the channel count.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetChannelCount(
            [Out] [MarshalAs(UnmanagedType.U4)] out UInt32 channelCount);

        /// <summary>
        /// Sets the volume level for the specified channel in the session.
        /// </summary>
        /// <param name="index">The zero-based index of the channel.</param>
        /// <param name="level">The new volume level expressed as a normalized value between 0.0 and 1.0.</param>
        /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetChannelVolume(
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
            [In] [MarshalAs(UnmanagedType.R4)] float level,
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        /// <summary>
        /// Retrieves the volume level for the specified channel in the session.
        /// </summary>
        /// <param name="index">The zero-based channel index.</param>
        /// <param name="level">Receives the volume level expressed as a normalized value between 0.0 and 1.0.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetChannelVolume(
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
            [Out] [MarshalAs(UnmanagedType.R4)] out float level);

        /// <summary>
        /// Sets the individual volume levels for all the channels in the session.
        /// </summary>
        /// <param name="channelCount">The number of channels in the audio stream. This must match the volume level array length.</param>
        /// <param name="levels">The new volume levels for each channel in the audio stream, expressed as normalized values between 0.0 and 1.0.</param>
        /// <param name="eventContext">A user context value that is passed to the notification callback.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetAllVolumes(
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 channelCount,
            [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R4)] float[] levels,
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid eventContext);

        /// <summary>
        /// Retrieves the volume levels for all the channels in the session.
        /// </summary>
        /// <param name="length">The number of elements in the volumes array.</param>
        /// <param name="volumes">Receives an array of volume levels for the channels in the audio stream.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetAllVolumes(
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 length,
            [In, Out] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R4)] float[] volumes);
    }
}
