# The Chest Core

The Chest Core is a library that provides a collection of abstract classes, interfaces, and utility functions to create and manage containers and slots. It is designed to be flexible and extensible.

## How does it work

The library revolves around the concepts of `Container` and `Slot`. A `Container` holds multiple `Slot` objects, and each `Slot` can store an item. The library provides base implementations and interfaces to simplify the creation of custom containers and slots.

## How to use it

### Installation

#### NuGet
To install the library via Nuget, you can use the following command:
```bash
dotnet add package TheChest.Core
```

#### DLL
Alternatively, you can download the DLL file and reference it directly in your project.

### Usage

#### Extending the classes
The library provides ready-to-use implementations such as `Container<T>` and `Slot<T>`. These can be used directly or extended to add custom behavior. For example:

```csharp
using TheChest.Core.Containers;

public class MyContainer : Container<int>
{
    public MyContainer(ISlot<int>[] items) : base(items)
    {
        if (items.Length != 10)
            throw new System.ArgumentException("Invalid container size");
    }

    public override int Size
    {
        get
        {
            return 10;
        }
    }
}
```

----------

```csharp
using TheChest.Core.Slots;

public class CustomSlot : Slot<string>
{
    public CustomSlot(string item) : base(item)
    {
    }

    public override bool IsEmpty => this.content == null;

    public override bool IsFull => this.content != null;
}
```

#### Implementing interfaces

If you need more control, you can implement the interfaces directly. For example:

```csharp
using TheChest.Core.Containers.Interfaces;
using TheChest.Core.Slots.Interfaces;

public class MyContainer : IContainer<int>
{
    private readonly ISlot<int>[] slots; 

    public ISlot<int> this[int index] => this.slots.ToArray()[index];

    public int Size { get; }

    public bool IsFull { get; }

    public bool IsEmpty { get; }

    public MyContainer(ISlot<int>[] slots)
    {
        if (slots.Length != 10)
            throw new System.ArgumentException("Invalid container size");
        this.slots = slots ?? throw new ArgumentNullException(nameof(slots));
    }
}
```

----------

```csharp
using TheChest.Core.Slots.Interfaces;

public class CustomSlot : ISlot<int>
{
    protected int? content;

    public bool IsEmpty => content == 0;

    public bool IsFull => content != 0;

    public CustomSlot(int? item)
    {
        content = item;
    }
}
```

## Future Plans

The plans for future versions of The Chest Core are in this [GitHub Project Board](https://github.com/orgs/The-Chest/projects/16/views/2), with insights into upcoming features, improvements, and release timelines.