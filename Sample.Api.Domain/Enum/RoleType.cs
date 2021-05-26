using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sample.Api.Domain.Enum
{
   [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RoleType
    {
        Admin,
        Approver
    }
}
