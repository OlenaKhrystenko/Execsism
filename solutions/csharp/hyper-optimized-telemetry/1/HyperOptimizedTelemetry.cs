public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];

        byte prefix = reading switch
        {
            >= 4_294_967_296L => Pack(BitConverter.GetBytes(reading), 8, true),
            >= 2_147_483_648L => Pack(BitConverter.GetBytes((uint)reading), 4, false),
            >= 65_536L      => Pack(BitConverter.GetBytes((int)reading), 4, true),
            >= 0L          => Pack(BitConverter.GetBytes((ushort)reading), 2, false),
            >= -32_768L     => Pack(BitConverter.GetBytes((short)reading), 2, true),
            >= -2_147_483_648L => Pack(BitConverter.GetBytes((int)reading), 4, true),
            _             => Pack(BitConverter.GetBytes(reading), 8, true)
        };

        buffer[0] = prefix;
        
        return buffer;

        byte Pack(byte[] bytes, byte count, bool isSigned)
        {
            Array.Copy(bytes, 0, buffer, 1, count);

            return isSigned ? (byte)(256 - count) : count;
        }
    }

    

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length == 0)
        {
            return 0;
        }

        byte prefix = buffer[0];

        switch (prefix)
        {
            case 2: // ushort (2 bytes payload, unsigned)
                if (buffer.Length < 3) return 0;
                return BitConverter.ToUInt16(buffer, 1);

            case 4: // uint (4 bytes payload, unsigned)
                if (buffer.Length < 5) return 0;
                return BitConverter.ToUInt32(buffer, 1);

            case 254: // short (2 bytes payload, signed)
                if (buffer.Length < 3) return 0;
                return BitConverter.ToInt16(buffer, 1);

            case 252: // int (4 bytes payload, signed)
                if (buffer.Length < 5) return 0;
                return BitConverter.ToInt32(buffer, 1);

            case 248: // long (8 bytes payload, signed)
                if (buffer.Length < 9) return 0;
                return BitConverter.ToInt64(buffer, 1);

            default: // Unexpected prefix byte
                return 0;
        }
    }
}
