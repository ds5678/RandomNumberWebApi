using System.Text.Json.Serialization;

namespace RandomNumberWebApi;
public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateSlimBuilder(args);

		builder.Services.ConfigureHttpJsonOptions(options =>
		{
			options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
		});

		var app = builder.Build();

		app.MapGet("/bool", () => Random.Shared.NextBoolean())
			.WithName("GetBoolean")
			.WithOpenApi();
		app.MapGet("/byte", () => Random.Shared.NextByte())
			.WithName("GetByte")
			.WithOpenApi();
		app.MapGet("/sbyte", () => Random.Shared.NextSByte())
			.WithName("GetSByte")
			.WithOpenApi();
		app.MapGet("/short", () => Random.Shared.NextInt16())
			.WithName("GetInt16")
			.WithOpenApi();
		app.MapGet("/ushort", () => Random.Shared.NextUInt16())
			.WithName("GetUInt16")
			.WithOpenApi();
		app.MapGet("/int", () => Random.Shared.NextInt32())
			.WithName("GetInt32")
			.WithOpenApi();
		app.MapGet("/uint", () => Random.Shared.NextUInt32())
			.WithName("GetUInt32")
			.WithOpenApi();
		app.MapGet("/long", () => unchecked((long)Random.Shared.NextUInt64()))
			.WithName("GetInt64")
			.WithOpenApi();
		app.MapGet("/ulong", () => Random.Shared.NextUInt64())
			.WithName("GetUInt64")
			.WithOpenApi();
		app.MapGet("/float", () => Random.Shared.NextSingle())
			.WithName("GetSingle")
			.WithOpenApi();
		app.MapGet("/double", () => Random.Shared.NextDouble())
			.WithName("GetDouble")
			.WithOpenApi();

		app.Run();
	}
}
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(byte))]
[JsonSerializable(typeof(sbyte))]
[JsonSerializable(typeof(short))]
[JsonSerializable(typeof(ushort))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(uint))]
[JsonSerializable(typeof(long))]
[JsonSerializable(typeof(ulong))]
[JsonSerializable(typeof(float))]
[JsonSerializable(typeof(double))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}