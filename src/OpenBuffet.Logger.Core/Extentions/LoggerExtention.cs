using OpenBuffet.Logger.Core.Interfaces;
using OpenBuffet.Logger.Core.Managers;
using OpenBuffet.Logger.Core.Configurator;
using OpenBuffet.Logger.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenBuffet.Logger.Core.Extentions {
    /// <summary>
    /// this class is a extentions to 
    /// service collection for open buffet logger
    /// </summary>
    public static class LoggerExtention {


        /// <summary>
        /// this method adds open buffet jsonl logger to service collection
        /// </summary>
        /// <param name="services">service collection</param>
        /// <param name="configuration">jsonl logger configuration</param>
        /// <returns>return added logger service collection</returns>
        public static IServiceCollection AddOpenBuffetJsonlLogger(this IServiceCollection services, Action<JsonlLoggerConfigurator> configuration) {
            JsonlLoggerConfigurator jsonlConfigurator = new JsonlLoggerConfigurator();
            configuration?.Invoke(jsonlConfigurator);
            JsonlLogger jsonlLogger = new JsonlLogger(jsonlConfigurator);
            services.AddSingleton<ILoggerService>(jsonlLogger);
            return services;
        }



        /// <summary>
        /// this method adds open buffet text logger to service collection
        /// </summary>
        /// <param name="services">service collection</param>
        /// <param name="configuration">text logger configuration</param>
        /// <returns>return added logger service collection</returns>
        public static IServiceCollection AddOpenBuffetTextLogger(this IServiceCollection services, Action<TextLoggerConfigurator> configuration) {
            TextLoggerConfigurator textLoggerConfigurator = new TextLoggerConfigurator();
            configuration?.Invoke(textLoggerConfigurator);
            TextLogger textLogger = new TextLogger(textLoggerConfigurator);
            services.AddSingleton<ILoggerService>(textLogger);
            return services;
        }


        /// <summary>
        /// this method adds open buffet console logger to service collection
        /// </summary>
        /// <param name="services">service collection</param>
        /// <returns>return added logger service collection</returns>
        public static IServiceCollection AddOpenBuffetConsoleLogger(this IServiceCollection services) {
            services.AddSingleton<ILoggerService, ConsoleLogger>();
            return services;
        }



        /// <summary>
        /// this method adds open buffet logger to service collection 
        /// </summary>
        /// <param name="services">services in service collection</param>
        /// <returns>return added logger service collection</returns>
        public static IServiceCollection AddOpenBuffetLoggerManager(this IServiceCollection services) {
            services.AddSingleton<LoggerManager>();
            return services;
        }

    }
}
