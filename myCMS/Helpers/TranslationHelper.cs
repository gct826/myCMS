using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Builders;
using myCMS.Models;

namespace myCMS.Helpers
{
    public class TranslationHelper
    {
        private MongoHelper<Translation> _translations;

        public string DefaultTranslation()
        {
            _translations = new MongoHelper<Translation>();

            var translationQuery = Query<Translation>.EQ(g => g.IsDefault, true);
            var foundTranslation = _translations.Collection.FindOne(translationQuery);

            return foundTranslation.Code;
        }

        public bool ValidTranslation(string testCode)
        {
            _translations = new MongoHelper<Translation>();

            var translationQuery = Query<Translation>.EQ(g => g.Code, testCode.ToLower());
            var foundTranslation = _translations.Collection.FindOne(translationQuery);

            if (foundTranslation != null)
            {
                return true;
            }
            return false;
        }
    }
}