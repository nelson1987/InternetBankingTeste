using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;

namespace BGB.Core.Config
{
    public static class ApplicationSettings
    {
        public IConfiguration Configuration { get; }

        public static class ApplicationSettings(IConfiguration configuration)
        {

        }

        public static string NameAssemblyMappin
        {
            get
            {
                var key = "BGB.FLUENT.MAPPINS";
                var value = new AppSettingsReader().GetValue(key, typeof(string)).ToString();

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Assembly de mapeamento não definido." +
                        $"Inclua no arquivo de configuração (.config) a chave {key}.");

                return value;
            }
        }

        public static string SecretWord
        {
            get
            {
                var key = "BGB.TOKEN.KEY";
                var value = new AppSettingsReader().GetValue(key, typeof(string)).ToString();

                if (string.IsNullOrEmpty(value))
                    throw new Exception("Palavra de segurança não definida." +
                        $"Inclua no arquivo de configuração (.config) a chave {key}.");

                return value;
            }
        }

        public static string BaseUri
        {
            get
            {
                var key = "BGB.BASEURI";
                var value = new AppSettingsReader().GetValue(key, typeof(string)).ToString();

                if (string.IsNullOrEmpty(value))
                    throw new Exception("A Base da URI não está configurada." +
                        $"Inclua no arquivo de configuração (.config) a chave {key}.");

                return value;
            }
        }

        public static string EmailSendFrom
        {
            get
            {
                return "naoresponder@bancoguanabara.com.br";
            }
        }

        public static string EmailSendToAlternative
        {
            get
            {
                var value = new AppSettingsReader().GetValue("BGB.EMAILSENDTO.ALTERNATIVE", typeof(string)).ToString();

                if (string.IsNullOrEmpty(value))
                    return "ti.sistemas@bancoguanabara.com.br";

                return value;
            }
        }
        public static string SystemExecutionEnvironment
        {
            get
            {
                var value = new AppSettingsReader().GetValue("BGB.ENVIRONMENT", typeof(string)).ToString();

                return string.IsNullOrEmpty(value) ? "D" : value;
            }
        }

        public static bool IsDeveloperEnvironment
        {
            get { return (SystemExecutionEnvironment.Equals("D")); }
        }

        public static string FolderTemplates
        {
            get
            {
                return new AppSettingsReader().GetValue("BGB.TEMPLATES.FOLDER", typeof(string)).ToString();
            }
        }
    }
}