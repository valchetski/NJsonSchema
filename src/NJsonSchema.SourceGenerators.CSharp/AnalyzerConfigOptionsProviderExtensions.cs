using H.Generators.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using static NJsonSchema.SourceGenerators.CSharp.GeneratorConfigurationKeys;

namespace NJsonSchema.SourceGenerators.CSharp
{
    /// <summary>
    /// Extension methods for <see cref="AnalyzerConfigOptionsProvider"/>.
    /// </summary>
    public static class AnalyzerConfigOptionsProviderExtensions
    {
        /// <summary>
        /// Converts options from <see cref="AnalyzerConfigOptionsProvider"/> to <see cref="JsonSchemaSourceGeneratorConfig"/>.
        /// </summary>
        /// <param name="analyzerConfigOptionsProvider">Analyzer options provider.</param>
        /// <param name="additionalText">Additional text item.</param>
        /// <returns></returns>
        public static JsonSchemaSourceGeneratorConfig ToJsonSchemaSourceGeneratorConfig(
           this AnalyzerConfigOptionsProvider analyzerConfigOptionsProvider,
           AdditionalText additionalText)
        {
            return new JsonSchemaSourceGeneratorConfig(
                        analyzerConfigOptionsProvider.GetResolvedOptionBoolean(additionalText, GenerateOptionalPropertiesAsNullable),
                        analyzerConfigOptionsProvider.GetResolvedOption(additionalText, Namespace),
                        analyzerConfigOptionsProvider.GetOption(additionalText, TypeNameHint, prefix: Prefix),
                        analyzerConfigOptionsProvider.GetOption(additionalText, FileName, prefix: Prefix));
        }

        private static bool? GetResolvedOptionBoolean(
            this AnalyzerConfigOptionsProvider provider,
            AdditionalText additionalText,
            string key)
        {
            var option = GetResolvedOption(provider, additionalText, key);

            if (bool.TryParse(option, out bool result))
            {
                return result;
            }

            return null;
        }

        private static string? GetResolvedOption(
            this AnalyzerConfigOptionsProvider provider,
            AdditionalText additionalText,
            string key)
        {
            return provider.GetOption(additionalText, key, prefix: Prefix) ?? provider.GetGlobalOption(key, Prefix);
        }
    }
}
