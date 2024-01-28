﻿// 32feet.NET - Personal Area Networking for .NET
//
// InTheHand.Net.Sockets.BluetoothDeviceInfo
// 
// Copyright (c) 2003-2024 In The Hand Ltd, All rights reserved.
// This source code is licensed under the MIT License

using InTheHand.Net.Bluetooth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InTheHand.Net.Sockets
{
    /// <summary>
    /// Provides information about an available device obtained by the client during device discovery.
    /// </summary>
    [DebuggerDisplay("({DeviceAddress.ToString(\"C\")}) {DeviceName}")]
    public sealed partial class BluetoothDeviceInfo : IEquatable<BluetoothDeviceInfo>
    {
        private readonly IBluetoothDeviceInfo _bluetoothDeviceInfo;

        internal BluetoothDeviceInfo(IBluetoothDeviceInfo bluetoothDeviceInfo)
        {
            _bluetoothDeviceInfo = bluetoothDeviceInfo;
        }

        /// <summary>
        /// Forces the system to refresh the device information.
        /// </summary>
        public void Refresh() =>  _bluetoothDeviceInfo.Refresh();

        /// <summary>
        /// Gets the device identifier.
        /// </summary>
        public BluetoothAddress DeviceAddress { get => _bluetoothDeviceInfo.DeviceAddress; }

        /// <summary>
        /// Gets the name of a device.
        /// </summary>
        public string DeviceName { get => _bluetoothDeviceInfo.DeviceName; }

        /// <summary>
        /// Returns the Class of Device of the remote device.
        /// </summary>
        public ClassOfDevice ClassOfDevice { get => _bluetoothDeviceInfo.ClassOfDevice; }

        /// <premliminary/>
        /// <summary>
        /// Gets a list of all available Rfcomm service UUIDs on the remote device.
        /// </summary>
        /// <param name="cached">If true and supported on the runtime platform return locally cached devices without doing an SDP request.</param>
        /// <returns>All available Rfcomm service UUIDs on the remote device.</returns>
        public Task<IEnumerable<Guid>> GetRfcommServicesAsync(bool cached = true) => _bluetoothDeviceInfo.GetRfcommServicesAsync(cached);
        
        /// <summary>
        /// Specifies whether the device is connected.
        /// </summary>
        public bool Connected { get => _bluetoothDeviceInfo.Connected; }

        /// <summary>
        /// Specifies whether the device is authenticated, paired, or bonded.
        /// All authenticated devices are remembered.
        /// </summary>
        public bool Authenticated { get => _bluetoothDeviceInfo.Authenticated; }

        

        /// <summary>
        /// Compares two BluetoothDeviceInfo instances for equality.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BluetoothDeviceInfo other)
        {
            if (other is null)
                return false;

            return DeviceAddress == other.DeviceAddress;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is BluetoothDeviceInfo info)
            {
                return Equals(info);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return DeviceAddress.GetHashCode();
        }
    }
}
