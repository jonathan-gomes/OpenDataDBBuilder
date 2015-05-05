using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using OpenDataDBBuilder.Business.VO;
using System.Resources;

namespace OpenDataDBBuilder.UI.Localization
{
    public class Localization
    {
        public List<KeyValue> languages = new List<KeyValue>();
        private KeyValue englishUS = new KeyValue("en-US", "English");
        private KeyValue portugueseBR = new KeyValue("pt-BR", "Português (Brasil)");

        public Localization()
        {
            languages.Add(englishUS);
            languages.Add(portugueseBR);
        }
        public String getLocalizedResource(CultureInfo language, String resourceName)
        {
            foreach (KeyValue lang in languages)
            {
                if (language.Name.Equals(lang.Key))
                {
                    return getResourceManagerByLanguage(lang.Key).GetString(resourceName);
                }
            }
            return "";
        }

        public ResourceManager getResourceManagerByLanguage(String language)
        {
            if (language.Equals("en-US"))
            {
                return Properties.Resources_en_US.ResourceManager;
            }
            else if(language.Equals("pt-BR"))
            {
                return Properties.Resources_pt_BR.ResourceManager;
            }
            return Properties.Resources_en_US.ResourceManager;
        }
    }
}
