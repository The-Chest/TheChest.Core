# The Chest Core

The Chest Core is a library that provides a collection of abstract classes/interfaces and functions that are used to create and manage Containers.

## How does it work



## How to use it

### Installation

```bash

```

### Usage

#### Using existing classes

#### Creating a new Container extending the Container class


```csharp
using TheChest.Core.Containers;

public class MyContainer : Container<int>
{
	public MyContainer(int[] items) : base(items)
	{
	}
}
```

You can also override the `Container<T>`/`Slot<T>` properties to add custom behavior to your container.

```csharp
using TheChest.Core.Containers;

public class MyContainer : Container<int>
{
	public MyContainer(int[] items) : base(items)
	{
		if(items.Length != 10)
			throw new System.ArgumentException("Invalid container size"));
	}
	
	public override int Size{
		get{
			return 10;
		}
	}
}
```

#### Creating a new Container implementing IContainer interface
```csharp

```
