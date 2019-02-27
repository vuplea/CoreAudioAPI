﻿using System;
using System.Runtime.InteropServices;

namespace Vannatech.CoreAudio.Interfaces
{
    /// <summary>
    /// Provides notification when an audio session is created.
    /// </summary>
    /// <remarks>
    /// MSDN Reference: http://msdn.microsoft.com/en-us/library/dd370969.aspx
    /// </remarks>
    public partial interface IAudioSessionNotification
    {
        /// <summary>
        /// Notifies the registered processes that the audio session has been created.
        /// </summary>
        /// <param name="sessionControl">The <see cref="IAudioSessionControl"/> interface of the audio session that was created.</param>
        /// <returns>An HRESULT code indicating whether the operation succeeded of failed.</returns>
        [PreserveSig]
        int OnSessionCreated(
            [In] IAudioSessionControl sessionControl);
    }
}
