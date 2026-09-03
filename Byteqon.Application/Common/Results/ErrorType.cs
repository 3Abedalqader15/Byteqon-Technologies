using System;
using System.Collections.Generic;
using System.Text;

namespace Byteqon.Application.Common.Results;

public enum ErrorType
{
    None = 0,
    Validation = 1,
    NotFound = 2,
    Conflict = 3,
    Unauthorized = 4,
    Forbidden = 5,
    Failure = 6
}
