﻿using System;
using System.Runtime.InteropServices;

namespace Vannatech.CoreAudio.Interfaces
{
    /// <summary>
    /// Enables a client to control and monitor the volume levels for all of the channels in an audio stream.
    /// </summary>
    /// <remarks>
    /// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd370977.aspx
    /// </remarks>
    public partial interface IAudioStreamVolume
    {
        /// <summary>
        /// Retrieves the number of channels contained in the audio stream.
        /// </summary>
        /// <param name="count">Receives the channel count.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetChannelCount(
            [Out] [MarshalAs(UnmanagedType.U4)] out UInt32 count);

        /// <summary>
        /// Sets the volume level for the specified channel in the audio stream.
        /// </summary>
        /// <param name="index">The zero-based index of the channel.</param>
        /// <param name="level">The new volume level expressed as a normalized value between 0.0 and 1.0.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetChannelVolume(
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
            [In] [MarshalAs(UnmanagedType.R4)] float level);

        /// <summary>
        /// Retrieves the volume level for the specified channel in the audio stream.
        /// </summary>
        /// <param name="index">The zero-based channel index.</param>
        /// <param name="level">Receives the volume level expressed as a normalized value between 0.0 and 1.0.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int GetChannelVolume(
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 index,
            [Out] [MarshalAs(UnmanagedType.R4)] out float level);

        /// <summary>
        /// Sets the individual volume levels for all the channels in the audio stream.
        /// </summary>
        /// <param name="count">The number of channels in the audio stream. This must match the volume level array length.</param>
        /// <param name="levels">The new volume levels for each channel in the audio stream, expressed as normalized values between 0.0 and 1.0.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int SetAllVolumes(
            [In] [MarshalAs(UnmanagedType.U4)] UInt32 count,
            [In] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R4)] float[] levels);

        /// <summary>
        /// Retrieves the volume levels for all the channels in the audio stream.
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
