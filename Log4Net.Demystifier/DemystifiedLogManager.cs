using System;
using System.Reflection;
using log4net;

namespace Log4Net.Demystifier
{
    public static class DemystifiedLogManager
    {
        public static ILog GetLogger(string repository, string name) =>
            CreateDemystifiedLogger(LogManager.GetLogger(repository, name));
        public static ILog GetLogger(Assembly repositoryAssembly, Type type) =>
            CreateDemystifiedLogger(LogManager.GetLogger(repositoryAssembly, type));
        public static ILog GetLogger(string repository, Type type) =>
            CreateDemystifiedLogger(LogManager.GetLogger(repository, type));
        public static ILog GetLogger(Type type) =>
            CreateDemystifiedLogger(LogManager.GetLogger(type));
        public static ILog GetLogger(Assembly repositoryAssembly, string name) =>
            CreateDemystifiedLogger(LogManager.GetLogger(repositoryAssembly, name));

        private static ILog CreateDemystifiedLogger(ILog oldLog) =>
            new DemystifiedLog(oldLog);
    }
}