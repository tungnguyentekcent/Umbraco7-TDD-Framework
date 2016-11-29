﻿using SampleFramework.Domain.Models;
using umbraco.interfaces;

namespace SampleFramework.Services.Interfaces
{
    public interface IApplicationService
    {
        T GetPageModel<T>(string docTypeAlias) where T : BaseModel;

        INode GetNode(string docTypeAlias);

    }
}
