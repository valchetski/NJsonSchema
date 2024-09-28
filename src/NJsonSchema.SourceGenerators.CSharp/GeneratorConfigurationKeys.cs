namespace NJsonSchema.SourceGenerators.CSharp
{
    /// <summary>
    /// Contains contstants with configuration keys used for Source Generation.
    /// </summary>
    public static class GeneratorConfigurationKeys
    {
        /// <summary>
        /// Prefix for all NJsonSchema-related configuration keys.
        /// </summary>
        public const string Prefix = "NJsonSchema";

        /// <summary>
        /// Indicating whether optional schema properties (not required) are generated as nullable properties.
        /// </summary>
        public const string GenerateOptionalPropertiesAsNullable = "GenerateOptionalPropertiesAsNullable";

        /// <summary>
        /// .NET namespace of the generated types.
        /// </summary>
        public const string Namespace = "Namespace";

        /// <summary>
        /// C# class name.
        /// </summary>
        public const string TypeNameHint = "TypeNameHint";

        /// <summary>
        /// Name of the file containing generated classes.
        /// </summary>
        public const string FileName = "FileName";
    }
}
