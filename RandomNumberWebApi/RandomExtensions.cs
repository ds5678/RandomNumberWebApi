namespace RandomNumberWebApi;

internal static class RandomExtensions
{
	public static bool NextBoolean(this Random random) => (random.Next() & 1) == 1;
	public static byte NextByte(this Random random) => unchecked((byte)random.Next());
	public static sbyte NextSByte(this Random random) => unchecked((sbyte)random.NextByte());
	public static short NextInt16(this Random random)
	{
		Span<byte> bytes = stackalloc byte[2];
		random.NextBytes(bytes);
		return BitConverter.ToInt16(bytes);
	}
	public static ushort NextUInt16(this Random random)
	{
		Span<byte> bytes = stackalloc byte[2];
		random.NextBytes(bytes);
		return BitConverter.ToUInt16(bytes);
	}
	public static int NextInt32(this Random random)
	{
		Span<byte> bytes = stackalloc byte[4];
		random.NextBytes(bytes);
		return BitConverter.ToInt32(bytes);
	}
	public static uint NextUInt32(this Random random)
	{
		Span<byte> bytes = stackalloc byte[4];
		random.NextBytes(bytes);
		return BitConverter.ToUInt32(bytes);
	}
	public static ulong NextUInt64(this Random random)
	{
		Span<byte> bytes = stackalloc byte[8];
		random.NextBytes(bytes);
		return BitConverter.ToUInt64(bytes);
	}
}
