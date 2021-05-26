#!/bin/bash
GIT_SOURCE="https://nuget.pkg.github.com/alexandreyembo/index.json"
GIT_API_KEY="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"
NUGET_SOURCE="https://api.nuget.org/v3/index.json"
NUGET_API_KEY="oy2dmbtoiu32tlygyhhq5jccreaahqtu3apio5nbplwjoe"

VERSION=1.0.0-beta-$(date +'%y%m%d').2 #for each release you change csproj with version and update here.


dotnet pack --configuration -c Release /p:Version=$VERSION

dotnet nuget push Hydra.Core.Api.Tests/bin/Release/Hydra.Core.Api.Tests.$VERSION.nupkg --api-key $GIT_API_KEY --source $GIT_SOURCE
dotnet nuget push Hydra.Core.Api.Tests/bin/Release/Hydra.Core.Api.Tests.$VERSION.nupkg --api-key $NUGET_API_KEY --source $NUGET_SOURCE

# dotnet nuget push Hydra.Tests.Fixtures.Builders/bin/Release/Hydra.Core.Tests.Fixtures.Builders.$VERSION.nupkg --api-key $GIT_API_KEY --source $GIT_SOURCE
# dotnet nuget push Hydra.Tests.Fixtures.Builders/bin/Release/Hydra.Core.Tests.Fixtures.Builders.$VERSION.nupkg --api-key $NUGET_API_KEY --source $NUGET_SOURCE

# dotnet nuget push Hydra.Tests.Fixtures/bin/Release/Hydra.Core.Tests.Fixtures.$VERSION.nupkg --api-key $GIT_API_KEY --source $GIT_SOURCE
# dotnet nuget push Hydra.Tests.Fixtures/bin/Release/Hydra.Core.Tests.Fixtures.$VERSION.nupkg --api-key $NUGET_API_KEY --source $NUGET_SOURCE