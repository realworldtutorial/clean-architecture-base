Tools directory '/Users/admin/.dotnet/tools' is not currently on the PATH environment variable.
If you are using zsh, you can add it to your profile by running the following command:

cat << \EOF >> ~/.zprofile
# Add .NET Core SDK tools
export PATH="$PATH:/Users/admin/.dotnet/tools"
EOF

And run `zsh -l` to make it available for current session.

You can only add it to the current session by running the following command:

export PATH="$PATH:/Users/admin/.dotnet/tools"

You can invoke the tool using the following command: dotnet-ef
Tool 'dotnet-ef' (version '9.0.3') was successfully installed.
<truncated 424 lines>
info : Installed Microsoft.Build.Framework 16.10.0 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.build.framework/16.10.0 with content hash uD2GUw3AYlFSpU42c/80DouuJL6w1Kb06q4FEjQhW/9wjhBwukgx13T5MPIpSvQ8ssahKINanHfMUL89EVQHgQ==.
info : Installed Microsoft.Build.Framework 17.8.3 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.build.framework/17.8.3 with content hash NrQZJW8TlKVPx72yltGb8SVz3P5mNRk9fNiD/ao8jRSk48WqIIdCn99q4IjlVmPcruuQ+yLdjNQLL8Rb4c916g==.
info : Installed Microsoft.CodeAnalysis.Workspaces.MSBuild 4.8.0 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.codeanalysis.workspaces.msbuild/4.8.0 with content hash IEYreI82QZKklp54yPHxZNG9EKSK6nHEkeuf+0Asie9llgS1gp0V1hw7ODG+QyoB7MuAnNQHmeV1Per/ECpv6A==.
info : Installed System.Text.Json 7.0.3 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/system.text.json/7.0.3 with content hash AyjhwXN1zTFeIibHimfJn6eAsZ7rTBib79JQpzg8WAuR/HKDu9JGNHTuu3nbbXQ/bgI+U4z6HtZmCHNXB1QXrQ==.
info : Installed Microsoft.CodeAnalysis.CSharp.Workspaces 4.8.0 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.codeanalysis.csharp.workspaces/4.8.0 with content hash 3amm4tq4Lo8/BGvg9p3BJh3S9nKq2wqCXfS7138i69TUpo/bD+XvD0hNurpEBtcNZhi1FyutiomKJqVF39ugYA==.
info : Installed Microsoft.CodeAnalysis.Common 4.8.0 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.codeanalysis.common/4.8.0 with content hash /jR+e/9aT+BApoQJABlVCKnnggGQbvGh7BKq2/wI1LamxC+LbzhcLj4Vj7gXCofl1n4E521YfF9w0WcASGg/KA==.
info : Installed Microsoft.CodeAnalysis.Workspaces.Common 4.8.0 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.codeanalysis.workspaces.common/4.8.0 with content hash LXyV+MJKsKRu3FGJA3OmSk40OUIa/dQCFLOnm5X8MNcujx7hzGu8o+zjXlb/cy5xUdZK2UKYb9YaQ2E8m9QehQ==.
info : Installed Microsoft.CodeAnalysis.Analyzers 3.3.4 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.codeanalysis.analyzers/3.3.4 with content hash AxkxcPR+rheX0SmvpLVIGLhOUXAKG56a64kV9VQZ4y9gR9ZmPXnqZvHJnmwLSwzrEP6junUF11vuc+aqo5r68g==.
info : Installed Microsoft.CodeAnalysis.CSharp 4.8.0 from https://api.nuget.org/v3/index.json to /Users/admin/.nuget/packages/microsoft.codeanalysis.csharp/4.8.0 with content hash +3+qfdb/aaGD8PZRCrsdobbzGs1m9u119SkkJt8e/mk3xLJz/udLtS2T6nY27OTXxBBw10HzAbC8Z9w08VyP/g==.
info :   CACHE https://api.nuget.org/v3/vulnerabilities/index.json
info :   CACHE https://api.nuget.org/v3-vulnerabilities/2025.03.26.23.24.54/vulnerability.base.json
info :   CACHE https://api.nuget.org/v3-vulnerabilities/2025.03.26.23.24.54/2025.03.30.05.25.04/vulnerability.update.json
info : Package 'Microsoft.EntityFrameworkCore.Design' is compatible with all the specified frameworks in project 'src/Infrastructure/CleanArchitecture.Persistence/CleanArchitecture.Persistence.csproj'.
info : PackageReference for package 'Microsoft.EntityFrameworkCore.Design' version '9.0.3' added to file '/Users/admin/Developer/Workspace/dotnet/learn/src/Infrastructure/CleanArchitecture.Persistence/CleanArchitecture.Persistence.csproj'.
info : Generating MSBuild file /Users/admin/Developer/Workspace/dotnet/learn/src/Infrastructure/CleanArchitecture.Persistence/obj/CleanArchitecture.Persistence.csproj.nuget.g.props.
info : Generating MSBuild file /Users/admin/Developer/Workspace/dotnet/learn/src/Infrastructure/CleanArchitecture.Persistence/obj/CleanArchitecture.Persistence.csproj.nuget.g.targets.
info : Writing assets file to disk. Path: /Users/admin/Developer/Workspace/dotnet/learn/src/Infrastructure/CleanArchitecture.Persistence/obj/project.assets.json
log  : Restored /Users/admin/Developer/Workspace/dotnet/learn/src/Infrastructure/CleanArchitecture.Persistence/CleanArchitecture.Persistence.csproj (in 3,22 sec).
# Clean Architecture Solution

This is a .NET Core solution following Clean Architecture principles.

## Project Structure

- **src/Core/**
  - **CleanArchitecture.Domain**: Contains enterprise logic and entities
  - **CleanArchitecture.Application**: Contains business logic and interfaces

- **src/Infrastructure/**
  - **CleanArchitecture.Infrastructure**: Contains external services implementation
  - **CleanArchitecture.Persistence**: Contains database contexts and repositories

- **src/Presentation/**
  - **CleanArchitecture.API**: Contains API controllers and configuration

## Getting Started

1. Ensure you have .NET SDK installed
2. Clone the repository
3. Run `dotnet restore`
4. Run `dotnet build`
5. Navigate to `src/Presentation/CleanArchitecture.API` and run `dotnet run`

## Architecture Overview

This solution follows Clean Architecture principles:

1. Domain Layer: Core business entities
2. Application Layer: Business logic and interfaces
3. Infrastructure Layer: Implementation of interfaces, external services
4. Presentation Layer: API endpoints and UI concerns
