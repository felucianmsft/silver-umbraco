﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Api.Common.Builders;
using Umbraco.Cms.Api.Management.Routing;
using Umbraco.Cms.Core;
using Umbraco.Cms.Web.Common.Authorization;

namespace Umbraco.Cms.Api.Management.Controllers.DocumentType;

[ApiController]
[VersionedApiBackOfficeRoute(Constants.UdiEntityType.DocumentType)]
[ApiExplorerSettings(GroupName = "Document Type")]
[Authorize(Policy = "New" + AuthorizationPolicies.TreeAccessDocumentTypes)]
public abstract class DocumentTypeControllerBase : ManagementApiControllerBase
{
    protected IActionResult DocumentTypeNotFound() => NotFound(new ProblemDetailsBuilder()
        .WithTitle("The document type could not be found")
        .Build());
}