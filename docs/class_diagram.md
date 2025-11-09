# Class Diagrams

This document contains class diagrams for the core components of TheChest project.

## IContainer Diagram

The `IContainer` diagram represents a generic container interface that holds slots for items.

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
	namespace TheChest.Core.Containers.Interfaces {
        class IContainer~T~ {
	        +ISlot~T~ this[int index]
	        +int Size
	        +bool IsEmpty
	        +bool IsFull
	        +bool Contains(T item)
			+bool Contains(T item, int amount)
        }
	}
	namespace TheChest.Core.Slots.Interfaces {
        class ISlot~T~ {
	        +bool IsEmpty
	        +bool IsFull
	        +bool Contains(T item)
        }
	}
	namespace TheChest.Core.Containers {
        class Container~T~ {
			-ISlot~T~[] slots
			+ISlot~T~ this[int index]
	        +int Size
	        +bool IsEmpty
	        +bool IsFull
	        +bool Contains(T item)
			+bool Contains(T item, int amount)
        }
	}
	namespace TheChest.Core.Slots {
        class Slot~T~ {
			-T content
			+bool IsEmpty
			+bool IsFull
			+bool Contains(T item)
        }
	}

	<<interface>> IContainer
	<<interface>> ISlot

    Container --|> IContainer : implements
    ISlot --* IContainer
    Slot --|> ISlot : implements
```

## IStackContainer Diagram
The `IStackContainer` diagram represents a generic container interface that supports stackable slots, allowing multiple items from the same type to be stored in a single slot.

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
	namespace TheChest.Core.Containers.Interfaces {
		class IStackContainer~T~ {
	        +IStackSlot~T~ this[int index]
	        +int Size
	        +bool IsEmpty
	        +bool IsFull
	        +bool Contains(T item)
			+bool Contains(T item, int amount)
        }
	}
	namespace TheChest.Core.Slots.Interfaces {
        class ISlot~T~ {
	        +bool IsEmpty
	        +bool IsFull
	        +bool Contains(T item)
        }
        class IStackSlot~T~ {
            +int Amount
            +int MaxAmount
	        +bool Contains(T[] items)
        }
	}
	namespace TheChest.Core.Containers {
		class StackContainer~T~ {
			-IStackSlot~T~[] slots
			+IStackSlot~T~ this[int index]
	        +int Size
	        +bool IsEmpty
	        +bool IsFull
	        +bool Contains(T item)
			+bool Contains(T item, int amount)
        }
		class StackSlot~T~{
			-T content
			-int amount            
			+int Amount
            +int MaxAmount
			-int maxAmount
	        +bool IsEmpty
	        +bool IsFull
	        +bool Contains(T item)
	        +bool Contains(T[] items)
		}
	}

	<<interface>> IStackContainer
    <<interface>> IStackSlot

    StackContainer --|> IStackContainer : implements
    IStackSlot --|> ISlot : implements
    StackSlot --|> IStackSlot : implements
    IStackSlot --* IStackContainer
```

## ILazyStackContainer Diagram
The `ILazyStackContainer` diagram represents a generic container interface that supports lazy loading of stackable slots, allowing multiple items from the same type to be stored in a single slot.

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
	namespace TheChest.Core.Containers.Interfaces {
		class ILazyStackContainer~T~ {
	        +ILazyStackSlot~T~ this[int index]
	        +int Size
	        +bool IsEmpty
	        +bool IsFull
        }
	}
	namespace TheChest.Core.Slots.Interfaces {
        class ISlot~T~ {
	        +bool IsEmpty
	        +bool IsFull
        }
        class ILazyStackSlot~T~ {
			+int Amount
            +int MaxAmount
        }
	}
	namespace TheChest.Core.Containers {
		class LazyStackContainer~T~ {
			-ILazyStackSlot~T~[] slots
			+ILazyStackSlot~T~ this[int index]
			+int Size
			+bool IsEmpty
			+bool IsFull
        }
	}

	<<interface>> ILazyStackContainer
    <<interface>> ILazyStackSlot

    LazyStackContainer --|> ILazyStackContainer : implements
    ILazyStackSlot --|> ISlot : implements
    ILazyStackSlot --* ILazyStackContainer
```