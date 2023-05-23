﻿using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Install.Models;

namespace Umbraco.Cms.Core.Installer;

public class NewInstallStepCollection : BuilderCollectionBase<IInstallStep>
{
    public NewInstallStepCollection(Func<IEnumerable<IInstallStep>> items)
        : base(items)
    {
    }
}
