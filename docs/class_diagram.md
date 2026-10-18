# Class Diagrams

This document contains separate class diagrams for the containers and slots in TheChest.Core.

## Container Diagrams

### Container

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
    namespace TheChest.Core.Abstractions {
        class IContentState {
            <<interface>>
            +bool IsFull
            +bool IsEmpty
        }
        class IContainer {
            <<interface>>
            +int Size
        }
    }
    namespace TheChest.Core.Containers.Interfaces {
        class IContainer~T~ {
            <<interface>>
        }
    }
    namespace System.Collections.Generic {
        class "IEnumerable<IEnumerable<T>>" as IEnumerableOfEnumerableT {
            <<interface>>
        }
    }
    namespace TheChest.Core.Slots.Interfaces {
        class ISlot~T~ {
            <<interface>>
        }
    }
    namespace TheChest.Core.Containers {
        class Container~T~ {
            #ISlot~T~[] slots
            +int Size
            +bool IsFull
            +bool IsEmpty
            +Container()
            +Container(T[] items)
            +Container(int size)
            +Container(T[] items, int size)
            +Container(ISlot~T~[] slots)
        }
    }
    IContainer ..|> IContentState
    IContainer~T~ ..|> IContainer
    IContainer~T~ ..|> IEnumerableOfEnumerableT
    ISlot~T~ ..|> IContentState
    ISlot~T~ ..|> IEnumerableOfEnumerableT
    Container~T~ ..|> IContainer~T~
    Container~T~ o-- ISlot~T~ : slots
    note for IContainer~T~ "T is covariant (out)"
```

### StackContainer

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
    namespace TheChest.Core.Abstractions {
        class IContentState {
            <<interface>>
            +bool IsFull
            +bool IsEmpty
        }
        class IContainer {
            <<interface>>
            +int Size
        }
    }
    namespace TheChest.Core.Containers.Interfaces {
        class IStackContainer~T~ {
            <<interface>>
        }
    }
    namespace System.Collections.Generic {
        class "IEnumerable<IEnumerable<T>>" as IEnumerableOfEnumerableT {
            <<interface>>
        }
    }
    namespace TheChest.Core.Slots.Interfaces {
        class IStackSlot~T~ {
            <<interface>>
        }
    }
    namespace TheChest.Core.Containers {
        class StackContainer~T~ {
            #IStackSlot~T~[] slots
            +int Size
            +bool IsFull
            +bool IsEmpty
            +StackContainer()
            +StackContainer(int size, int maxStackSize)
            +StackContainer(T[] items, int maxStackSize)
            +StackContainer(IStackSlot~T~[] slots)
        }
    }
    IContainer ..|> IContentState
    IStackContainer~T~ ..|> IContainer
    IStackContainer~T~ ..|> IEnumerableOfEnumerableT
    StackContainer~T~ ..|> IStackContainer~T~
    StackContainer~T~ o-- IStackSlot~T~ : slots
    note for IStackContainer~T~ "T is covariant (out)"
```

### LazyStackContainer

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
    namespace TheChest.Core.Abstractions {
        class IContentState {
            <<interface>>
            +bool IsFull
            +bool IsEmpty
        }
        class IContainer {
            <<interface>>
            +int Size
        }
    }
    namespace TheChest.Core.Containers.Interfaces {
        class ILazyStackContainer~T~ {
            <<interface>>
        }
    }
    namespace TheChest.Core.Slots.Interfaces {
        class ILazyStackSlot~T~ {
            <<interface>>
        }
    }
    namespace TheChest.Core.Containers {
        class LazyStackContainer~T~ {
            #ILazyStackSlot~T~[] slots
            +int Size
            +bool IsFull
            +bool IsEmpty
            +LazyStackContainer()
            +LazyStackContainer(int size, int maxStackSize)
            +LazyStackContainer((T item, int amount)[] items, int maxAmount)
            +LazyStackContainer(ILazyStackSlot~T~[] slots)
        }
    }
    IContainer ..|> IContentState
    ILazyStackContainer~T~ ..|> IContainer
    LazyStackContainer~T~ ..|> ILazyStackContainer~T~
    LazyStackContainer~T~ o-- ILazyStackSlot~T~ : slots
    note for LazyStackContainer~T~ "Default size: 20; max stack size: 1"
    note for ILazyStackContainer~T~ "T is contravariant (in)"
```


## Slot Diagrams

### Slot

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
    namespace TheChest.Core.Abstractions {
        class IContentState {
            <<interface>>
            +bool IsFull
            +bool IsEmpty
        }
    }
    namespace TheChest.Core.Slots.Interfaces {
        class ISlot~T~ {
            <<interface>>
        }
    }
    namespace System.Collections.Generic {
        class "IEnumerable<IEnumerable<T>>" as IEnumerableOfEnumerableT {
            <<interface>>
        }
    }
    namespace TheChest.Core.Slots {
        class Slot~T~ {
            -object content
            +T Content
            +bool IsFull
            +bool IsEmpty
            +Slot()
            +Slot(T currentItem)
        }
    }
    ISlot~T~ ..|> IContentState
    ISlot~T~ ..|> IEnumerableOfEnumerableT
    Slot~T~ ..|> ISlot~T~
    note for ISlot~T~ "T is covariant (out)"
```

### StackSlot

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
    namespace TheChest.Core.Abstractions {
        class IContentState {
            <<interface>>
            +bool IsFull
            +bool IsEmpty
        }
        class IStackable {
            <<interface>>
            +int Amount
            +int MaxAmount
            +int AvailableAmount
        }
    }
    namespace TheChest.Core.Slots.Interfaces {
        class IStackSlot~T~ {
            <<interface>>
        }
    }
    namespace System.Collections.Generic {
        class IEnumerable~T~ {
            <<interface>>
        }
    }
    namespace TheChest.Core.Slots {
        class StackSlot~T~ {
            -object[] content
            -int amount
            -int maxAmount
            -T[] cacheContent
            -bool isCacheValid
            +IEnumerable~T~ Content
            +int Amount
            +int MaxAmount
            +int AvailableAmount
            +bool IsFull
            +bool IsEmpty
            +StackSlot()
            +StackSlot(int maxAmount)
            +StackSlot(T[] items)
            +StackSlot(T[] items, int maxAmount)
        }
    }
    IStackSlot~T~ ..|> IContentState
    IStackSlot~T~ ..|> IStackable
    IStackSlot~T~ ..|> IEnumerable~T~
    StackSlot~T~ ..|> IStackSlot~T~
    note for IStackSlot~T~ "T is covariant (out)"
```

### LazyStackSlot

```mermaid
---
config:
  theme: mc
  look: classic
  class:
    hideEmptyMembersBox: true
---
classDiagram
direction BT
    namespace TheChest.Core.Abstractions {
        class IContentState {
            <<interface>>
            +bool IsFull
            +bool IsEmpty
        }
        class IStackable {
            <<interface>>
            +int Amount
            +int MaxAmount
            +int AvailableAmount
        }
    }
    namespace TheChest.Core.Slots.Interfaces {
        class ILazyStackSlot~T~ {
            <<interface>>
        }
    }
    namespace TheChest.Core.Slots {
        class LazyStackSlot~T~ {
            -object content
            -int amount
            -int maxAmount
            +T Content
            +int Amount
            +int MaxAmount
            +int AvailableAmount
            +bool IsFull
            +bool IsEmpty
            +LazyStackSlot()
            +LazyStackSlot(int maxAmount)
            +LazyStackSlot(T currentItem, int amount, int maxAmount)
        }
    }
    ILazyStackSlot~T~ ..|> IContentState
    ILazyStackSlot~T~ ..|> IStackable
    LazyStackSlot~T~ ..|> ILazyStackSlot~T~
    note for ILazyStackSlot~T~ "T is contravariant (in)"
```
