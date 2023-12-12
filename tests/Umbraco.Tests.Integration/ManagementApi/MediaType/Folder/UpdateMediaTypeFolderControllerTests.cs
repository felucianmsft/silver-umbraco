﻿using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;
using NUnit.Framework;
using Umbraco.Cms.Api.Management.Controllers.MediaType.Folder;
using Umbraco.Cms.Api.Management.ViewModels.Folder;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Services;

namespace Umbraco.Cms.Tests.Integration.ManagementApi.MediaType.Folder;

[TestFixture]
public class UpdateMediaTypeFolderControllerTests : ManagementApiUserGroupTestBase<UpdateMediaTypeFolderController>
{
    private IMediaTypeContainerService _mediaTypeContainerService;
    private Guid _mediaTypeKey;

    [SetUp]
    public async Task Setup()
    {
        _mediaTypeKey = Guid.NewGuid();
        _mediaTypeContainerService = GetRequiredService<IMediaTypeContainerService>();
        await _mediaTypeContainerService.CreateAsync(_mediaTypeKey, "TestFolder", null, Constants.Security.SuperUserKey);
    }

    protected override Expression<Func<UpdateMediaTypeFolderController, object>> MethodSelector =>
        x => x.Update(_mediaTypeKey, null);

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

    protected override async Task<HttpResponseMessage> ClientRequest()
    {
        UpdateFolderResponseModel updateFolderResponseModel = new() { Name = "TesterFolders" };

        return await Client.PutAsync(Url, JsonContent.Create(updateFolderResponseModel));
    }
}
