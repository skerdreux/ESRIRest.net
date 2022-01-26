using System.ComponentModel;
using RestSharp;

namespace ESRIRest.net.Models
{
    internal abstract class QueryESRIRest : RestSharp.RestRequest
    {
        private string Token { get; set; }

        public Format FormatOut { get; set; }

        public const string NameOfParameterFormat = "f";

        public enum Format
        {
            [Description("HTML out for browser")]
            html,
            [Description("Json for programming")]
            json,
            [Description("Json for programming and easier to read than json ")]
            pjson,
            [Description("GeoJson rfc7946")]
            geojson
        }

        protected QueryESRIRest(Method method, Format formatOut, string token) 
        {
            this.Method = method;
            this.FormatOut = formatOut;
            this.Token = token;
            this.AddParameter(NameOfParameterFormat, formatOut, ParameterType.GetOrPost);
        }

        public bool IsQueryProtectedWithToken() { return !string.IsNullOrEmpty(this.Token); }
    }
}
