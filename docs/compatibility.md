# Compatibility

TheChest targets **.NET Standard 2.1**.

Targeting .NET Standard 2.1 defines the API surface available to the library. However, targeting a platform does not necessarily mean that every runtime implementing .NET Standard 2.1 is actively tested or officially supported by the project.

## Tested runtimes

| Runtime       | Status        | Notes                                             |
|---------------|---------------|---------------------------------------------------|
| .NET Core 2.1 | Unsupported   | Does not support .NET Standard 2.1                |
| .NET Core 3.1 | Not tested    | Test project does not support this runtime        |
| .NET 5        | Not tested    | Test project does not support this runtime        |
| .NET 6        | Tested        |                                                   |
| .NET 7        | Tested        |                                                   |
| .NET 8        | Tested        |                                                   |
| .NET 10       | Known issues  | Issues with references used by internal classes   |

> Other platforms implementing .NET Standard 2.1 may also work, but are not currently included in the project's CI test matrix.

## Status Definitions

### Tested

The library is executed against this runtime as part of the project's test process. Passing the test suite indicates that this runtime is expected to work correctly with the current version of the library.

### Not tested

The runtime may be capable of running the library, but it is not currently included in the project's test matrix. Compatibility is therefore not guaranteed.

### Unsupported

The runtime does not satisfy the requirements of the library's target framework or is otherwise explicitly unsupported.

### Known issues

The runtime can satisfy the target framework requirements, but known problems prevent the project from considering it fully compatible.

## Other .NET Standard 2.1 Implementations

Other platforms implementing .NET Standard 2.1 may also be compatible with TheChest.

Unless explicitly listed as tested, these platforms are not part of the project's test matrix and their compatibility is not guaranteed.

## Compatibility Policy

A runtime is considered **tested** only when the project's automated or maintained test suite is successfully executed against that runtime.

Failure to include a runtime in the test matrix does not by itself mean that the library is incompatible with that runtime.

Known incompatibilities should be documented in this file and, when appropriate, referenced in the project's changelog or issue tracker.
