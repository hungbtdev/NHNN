﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vinorsoft.Core.Interface
{
    public interface ITenantProvider
    {
        Guid? GetTenantId();
    }
}
