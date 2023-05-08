using Microsoft.OpenApi.Models;

namespace tmss.Web.Swagger
{
    internal class NonBodyParameter : OpenApiParameter
    {
        public new string Name { get; set; }
        public string Type { get; set; }
        public new string In { get; set; }
    }
}