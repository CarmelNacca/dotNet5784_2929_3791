namespace DalApi;
using static DalApi.Config;
using System.Reflection;
/// <summary>
/// The class contains a method called Get that produces/returns an initialization of the corresponding class DalList or DalXml, 
/// according to what is written in the configuration file dal-config.xml which it knows how to read with the help of the Config class.
/// </summary>
/// <summary>
/// Factory class responsible for creating instances of IDal implementations.
/// </summary>
public static class Factory
{
    /// <summary>
    /// Gets the instance of IDal implementation based on the configuration.
    /// </summary>
    /// <exception cref="DalConfigException">Thrown when there is an issue with the DAL configuration.</exception>
    public static IDal Get
    {
        get
        {
            // Retrieve the DAL type from configuration
            string dalType = s_dalName ?? throw new DalConfigException($"DAL name is not extracted from the configuration");

            // Retrieve the DAL implementation based on the DAL type
            DalImplementation dal = s_dalPackages[dalType] ?? throw new DalConfigException($"Package for {dalType} is not found in packages list in dal-config.xml");

            try
            {
                // Load the assembly containing the DAL implementation
                Assembly.Load(dal.Package ?? throw new DalConfigException($"Package {dal.Package} is null"));
            }
            catch (Exception ex)
            {
                throw new DalConfigException($"Failed to load {dal.Package}.dll package", ex);
            }

            // Get the Type of the DAL implementation class
            Type type = Type.GetType($"{dal.Namespace}.{dal.Class}, {dal.Package}") ??
                throw new DalConfigException($"Class {dal.Namespace}.{dal.Class} was not found in {dal.Package}.dll");

            // Retrieve the singleton instance property from the DAL implementation class
            return type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static)?.GetValue(null) as IDal ??
                throw new DalConfigException($"Class {dal.Class} is not a singleton or wrong property name for Instance");
        }
    }
}

