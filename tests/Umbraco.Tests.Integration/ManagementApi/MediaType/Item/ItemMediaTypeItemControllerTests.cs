﻿using System.Linq.Expressions;
using System.Net;
using Umbraco.Cms.Api.Management.Controllers.MediaType.Item;

namespace Umbraco.Cms.Tests.Integration.ManagementApi.MediaType.Item;

public class ItemMediaTypeItemControllerTests : ManagementApiUserGroupTestBase<ItemMediaTypeItemController>
{
    protected override Expression<Func<ItemMediaTypeItemController, object>> MethodSelector =>
        x => x.Item(new HashSet<Guid> { Guid.NewGuid() });

    protected override UserGroupAssertionModel AdminUserGroupAssertionModel => new()
    {
        ExpectedStatusCode = HttpStatusCode.OK
    };

    protected override UserGroupAssertionModel EditorUserGroupAssertionModel => new()
    {
        ExpectedStatusCode = HttpStatusCode.Forbidden
    };

    protected override UserGroupAssertionModel SensitiveDataUserGroupAssertionModel => new()
    {
        ExpectedStatusCode = HttpStatusCode.Forbidden
    };

    protected override UserGroupAssertionModel TranslatorUserGroupAssertionModel => new()
    {
        ExpectedStatusCode = HttpStatusCode.Forbidden
    };

    protected override UserGroupAssertionModel WriterUserGroupAssertionModel => new()
    {
        ExpectedStatusCode = HttpStatusCode.Forbidden
    };

    protected override UserGroupAssertionModel UnauthorizedUserGroupAssertionModel => new()
    {
        ExpectedStatusCode = HttpStatusCode.Unauthorized
    };
}
