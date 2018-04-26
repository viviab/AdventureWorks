using AdventureWorks.Core.Mappers;
using AdventureWorks.UI.Api;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MappingConfiguration), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MappingConfiguration), "Stop")]

namespace AdventureWorks.UI.Api
{

    public static class MappingConfiguration
    {

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            MapperConfig.InitializeInstanceMapping();
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
        }


    }
}