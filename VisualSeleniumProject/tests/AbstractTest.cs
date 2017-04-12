//using RelevantCodes.ExtentReports.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace VisualSeleniumProject.tests
{
    class AbstractTest
    {
        public void UpdateConfig(String key, String value)
        {
            Configuration configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configFile.AppSettings.Settings.Remove(key);
            configFile.AppSettings.Settings.Add(key, value);

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name); ;
        }

        public string InitializeEnvironment(String environment, String text)
        {
            if (environment == null)
                environment = ConfigurationManager.AppSettings[text];
            else
                UpdateConfig(text, environment);

            return environment;
        }

    }
}
