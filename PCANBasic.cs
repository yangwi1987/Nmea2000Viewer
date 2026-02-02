using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Nmea2000Viewer
{
    // Simplified PCANBasic wrapper
    public static class PCANBasic
    {
        #region Parameter definitions
        public const ushort PCAN_NONEBUS = 0x00;
        public const ushort PCAN_USBBUS1 = 0x51;
        
        // PCAN error and status codes
        public const uint PCAN_ERROR_OK = 0x00000;
        public const uint PCAN_ERROR_XMTFULL = 0x00001;
        public const uint PCAN_ERROR_OVERRUN = 0x00002;
        public const uint PCAN_ERROR_BUSLIGHT = 0x00004;
        public const uint PCAN_ERROR_BUSHEAVY = 0x00008;
        public const uint PCAN_ERROR_BUSOFF = 0x00010;
        public const uint PCAN_ERROR_ANYBUSERR = (PCAN_ERROR_BUSLIGHT | PCAN_ERROR_BUSHEAVY | PCAN_ERROR_BUSOFF);
        public const uint PCAN_ERROR_QRCVEMPTY = 0x00020;
        public const uint PCAN_ERROR_QOVERRUN = 0x00040;
        public const uint PCAN_ERROR_QXMTFULL = 0x00080;
        public const uint PCAN_ERROR_REGTEST = 0x00100;
        public const uint PCAN_ERROR_NODRIVER = 0x00200;
        public const uint PCAN_ERROR_HWINUSE = 0x00400;
        public const uint PCAN_ERROR_NETINUSE = 0x00800;
        public const uint PCAN_ERROR_ILLHW = 0x01400;
        public const uint PCAN_ERROR_ILLNET = 0x01800;
        public const uint PCAN_ERROR_ILLCLIENT = 0x01C00;
        public const uint PCAN_ERROR_ILLHANDLE = 0x01C00; // Same as ILLCLIENT
        public const uint PCAN_ERROR_RESOURCE = 0x02000;
        public const uint PCAN_ERROR_ILLPARAMTYPE = 0x04000;
        public const uint PCAN_ERROR_ILLPARAMVAL = 0x08000;
        public const uint PCAN_ERROR_UNKNOWN = 0x10000;
        public const uint PCAN_ERROR_ILLDATA = 0x20000;
        public const uint PCAN_ERROR_CAUTION = 0x2000000;
        public const uint PCAN_ERROR_INITIALIZE = 0x4000000;
        public const uint PCAN_ERROR_ILLOPERATION = 0x8000000;

        // PCAN message types
        public const byte PCAN_MESSAGE_STANDARD = 0x00;
        public const byte PCAN_MESSAGE_RTR = 0x01;
        public const byte PCAN_MESSAGE_EXTENDED = 0x02;
        public const byte PCAN_MESSAGE_FD = 0x04;
        public const byte PCAN_MESSAGE_BRS = 0x08;
        public const byte PCAN_MESSAGE_ESI = 0x10;
        public const byte PCAN_MESSAGE_ERRFRAME = 0x40;
        public const byte PCAN_MESSAGE_STATUS = 0x80;

        // Baudrates
        public const ushort PCAN_BAUD_250K = 0x011C;

        #endregion

        #region Structures
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TPCANMsg
        {
            public uint ID;
            [MarshalAs(UnmanagedType.U1)]
            public byte MSGTYPE;
            public byte LEN;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] DATA;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TPCANTimestamp
        {
            public uint millis;
            public ushort millis_overflow;
            public ushort micros;
        }
        #endregion

        #region PCAN-Basic API Implementation
        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Initialize")]
        public static extern uint Initialize(
            [MarshalAs(UnmanagedType.U2)] ushort Channel,
            [MarshalAs(UnmanagedType.U2)] ushort Btr0Btr1,
            [MarshalAs(UnmanagedType.U1)] byte HwType,
            uint IOPort,
            [MarshalAs(UnmanagedType.U2)] ushort Interrupt);

        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Uninitialize")]
        public static extern uint Uninitialize(
            [MarshalAs(UnmanagedType.U2)] ushort Channel);

        [DllImport("PCANBasic.dll", EntryPoint = "CAN_Read")]
        public static extern uint Read(
            [MarshalAs(UnmanagedType.U2)] ushort Channel,
            out TPCANMsg MessageBuffer,
            out TPCANTimestamp TimestampBuffer);

        [DllImport("PCANBasic.dll", EntryPoint = "CAN_GetErrorText")]
        public static extern uint GetErrorText(
            uint Error,
            [MarshalAs(UnmanagedType.U2)] ushort Language,
            StringBuilder Buffer);
        #endregion
    }
}
