﻿using System;
using System.IO;
using Kudu.Core.Infrastructure;

namespace Kudu.Core.Deployment
{
    public class DeploymentConfiguration
    {
        private const string DeployConfigFile = ".deployment";
        private readonly IniFile _iniFile;
        private readonly string _path;

        public DeploymentConfiguration(string path)
        {
            _path = path;
            _iniFile = new IniFile(Path.Combine(path, DeployConfigFile));
        }

        public string ProjectPath
        {
            get
            {
                string projectPath = _iniFile.GetSectionValue("config", "project");
                if (String.IsNullOrEmpty(projectPath))
                {
                    return null;
                }

                return Path.Combine(_path, projectPath.TrimStart('/', '\\'));
            }
        }
    }
}