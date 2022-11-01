using System.Diagnostics;
using Chr.Common.OpenTelemetry.Exporter;

const string serviceName = "AppliedResearch.OpenTelemetry.ConsoleAppExample";
const string serviceVersion = "1.0.0";

using var tracerProvider = HostOpenTelemetryTracerProvider.Create(new OtlpTracerProviderOptions()
{
    TracerProviderExporter = ConfiguredExporters.ConsoleExporter,
    SourceNames = new List<string>() { "AppliedResearch.*"},
    ServiceName = serviceName, 
    ServiceVersion = serviceVersion
});

using var MyActivitySource = new ActivitySource(serviceName);

using var activity = MyActivitySource.StartActivity("Say Hello");
activity?.SetTag("foo", 1);
activity?.SetTag("bar", "Hello, World!");
activity?.SetTag("baz", new[] { 1, 2, 3 });