﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace VG.CDF.Server.WebApi.Controllers
{
    /// <summary>
    /// https://stackoverflow.com/questions/36452468/swagger-ui-web-api-documentation-present-enums-as-strings
    /// </summary>
    public class SwaggerAddEnumDescriptions : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            // add enum descriptions to result models
            foreach (var property in swaggerDoc.Components.Schemas.Where(x => x.Value?.Enum?.Count > 0))
            {
                var propertyEnums = property.Value.Enum;
                if (propertyEnums != null && propertyEnums.Count > 0)
                {
                    property.Value.Description += DescribeEnum(propertyEnums, property.Key);
                }
            }

            // add enum descriptions to input parameter
            foreach (var pathItem in swaggerDoc.Paths.Values)
            {
                DescribeEnumParameters(pathItem.Operations, swaggerDoc);
            }
        }

        private void DescribeEnumParameters(IDictionary<OperationType, OpenApiOperation> operations, OpenApiDocument swaggerDoc)
        {
            if (operations == null) return;
            foreach (var oper in operations)
            {
                foreach (var param in oper.Value.Parameters)
                {
                    var paramEnum = swaggerDoc.Components.Schemas.FirstOrDefault(x => x.Key == param.Name);
                    if (paramEnum.Value != null)
                    {
                        param.Description += DescribeEnum(paramEnum.Value.Enum, paramEnum.Key);
                    }
                }
            }
        }

        private static Type GetEnumTypeByName(string enumTypeName)
        {
            Type type = default!;
            try
            {
                type = AppDomain.CurrentDomain
               .GetAssemblies()
               .SelectMany(x => x.GetTypes())
               .FirstOrDefault(x => x.Name == enumTypeName)!;
            }
            catch
            {

            }

            return type!;
           
        }

        private string? DescribeEnum(IEnumerable<IOpenApiAny> enums, string proprtyTypeName)
        {
            var enumDescriptions = new List<string>();
            var enumType = GetEnumTypeByName(proprtyTypeName);
            if (enumType == null)
                return null;

            foreach (var openApiAny in enums)
            {
                if (!(openApiAny is OpenApiInteger enumOption)) continue;
                int enumInt = enumOption.Value;
                enumDescriptions.Add($"{enumInt} = {Enum.GetName(enumType, enumInt)}");

            }

            return string.Join(", ", enumDescriptions.ToArray());
        }
    }
}


